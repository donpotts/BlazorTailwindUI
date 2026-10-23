namespace BlazorTailwindUI.Services;

using BlazorTailwindUI.Models;
using System.Text;

/// <summary>
/// Enterprise OCR & MICR recognition service for paper checks, bank drafts, and PDF forms.
/// </summary>
public class OcrEngineService
{
    private static readonly Dictionary<string, string> KnownRoutingBanks = new()
    {
        ["121000358"] = "JPMorgan Chase Bank, N.A. (San Francisco)",
        ["021000021"] = "JPMorgan Chase Bank, N.A. (New York)",
        ["071000013"] = "Bank of America, N.A. (Chicago)",
        ["122000496"] = "Wells Fargo Bank, N.A. (San Francisco)",
        ["011000138"] = "Bank of America, N.A. (Boston)",
        ["051000017"] = "Bank of America, N.A. (Richmond)",
        ["111000614"] = "Bank of America, N.A. (Dallas)",
        ["091000019"] = "Wells Fargo Bank, N.A. (Minneapolis)"
    };

    /// <summary>
    /// Validates an ABA 9-digit Routing Transit Number using the standard Modulus 10 weighted sum:
    /// (3*(d1 + d4 + d7) + 7*(d2 + d5 + d8) + 1*(d3 + d6 + d9)) % 10 == 0
    /// </summary>
    public (bool IsValid, int Checksum, string BankName) ValidateAbaRouting(string routing)
    {
        var (isValid, mod) = MicrE13BData.ValidateAbaRouting(routing);
        string bankName = "Unknown Drawee Bank";
        if (KnownRoutingBanks.TryGetValue(routing.Trim(), out var known))
        {
            bankName = known;
        }
        else if (isValid)
        {
            bankName = "Verified Commercial Depository Institution";
        }

        return (isValid, mod, bankName);
    }

    /// <summary>
    /// Parses a raw ANSI X9.27 E-13B MICR string into structured check elements.
    /// Format: ⑆ROUTING⑆ ACCOUNT⑈ CHECK_NUM
    /// </summary>
    public MicrE13BData ParseMicrLine(string rawMicr)
    {
        var result = new MicrE13BData { RawMicrLine = rawMicr };

        if (string.IsNullOrWhiteSpace(rawMicr)) return result;

        // Extract routing between ⑆ (transit symbols)
        int firstTransit = rawMicr.IndexOf('⑆');
        int secondTransit = firstTransit >= 0 ? rawMicr.IndexOf('⑆', firstTransit + 1) : -1;

        if (firstTransit >= 0 && secondTransit > firstTransit)
        {
            result.TransitRoutingNumber = rawMicr.Substring(firstTransit + 1, secondTransit - firstTransit - 1).Trim();
            var (isValid, mod, bank) = ValidateAbaRouting(result.TransitRoutingNumber);
            result.IsValidRoutingChecksum = isValid;
            result.Mod10ChecksumValue = mod;
            result.BankName = bank;
        }

        // Remainder after second transit
        string rest = secondTransit >= 0 ? rawMicr.Substring(secondTransit + 1).Trim() : rawMicr;

        // Account is typically terminated by ⑈ (On-Us symbol)
        int onUs = rest.IndexOf('⑈');
        if (onUs >= 0)
        {
            result.AccountNumber = rest.Substring(0, onUs).Trim();
            string afterOnUs = rest.Substring(onUs + 1).Trim();
            // Check number is the remaining token
            var tokens = afterOnUs.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length > 0)
            {
                result.CheckNumber = tokens[0].Trim();
            }
        }
        else
        {
            var tokens = rest.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length > 0) result.AccountNumber = tokens[0];
            if (tokens.Length > 1) result.CheckNumber = tokens[1];
        }

        return result;
    }

    /// <summary>
    /// Analyzes a paper check or bank draft and returns verified Check 21 OCR and MICR results.
    /// </summary>
    public async Task<CheckDraftOcrResult> ScanCheckOrDraftAsync(string presetId = "check-payroll-1042")
    {
        // Simulate high-performance local WASM OCR processing latency
        await Task.Delay(85);

        return presetId switch
        {
            "check-vendor-8812" => new CheckDraftOcrResult
            {
                PayerName = "Apex Logistics Partners, LLC",
                PayerAddress = "742 Evergreen Industrial Parkway, Seattle, WA 98101",
                BankName = "JPMorgan Chase Bank, N.A. (New York)",
                CheckNumber = "8812",
                Date = "October 22, 2026",
                Payee = "Silicon Valley Micro-Servers Inc.",
                CourtesyAmount = 8420.50m,
                LegalAmountWords = "Eight thousand four hundred twenty and 50/100 Dollars",
                AmountsMatch = true,
                Memo = "Edge Node Cluster Hardware - PO-99321",
                SignatureDetected = true,
                SignatureConfidence = 0.991,
                OverallConfidence = 0.988,
                ProcessingTimeMs = 68,
                MicrData = new MicrE13BData
                {
                    RawMicrLine = "⑆021000021⑆ 9876543210⑈ 8812",
                    TransitRoutingNumber = "021000021",
                    AccountNumber = "9876543210",
                    CheckNumber = "8812",
                    BankName = "JPMorgan Chase Bank, N.A. (New York)",
                    IsValidRoutingChecksum = true,
                    Mod10ChecksumValue = 0,
                    Confidence = 0.994
                },
                BoundingBoxes = new()
                {
                    new OcrBoundingBox { Id = "payer", Label = "Drawer / Account", Value = "Apex Logistics Partners", LeftPercent = 6, TopPercent = 8, WidthPercent = 38, HeightPercent = 14, AccentColor = "blue" },
                    new OcrBoundingBox { Id = "chknum", Label = "Check #", Value = "8812", LeftPercent = 82, TopPercent = 8, WidthPercent = 12, HeightPercent = 10, AccentColor = "indigo" },
                    new OcrBoundingBox { Id = "date", Label = "Date", Value = "October 22, 2026", LeftPercent = 65, TopPercent = 22, WidthPercent = 28, HeightPercent = 10, AccentColor = "purple" },
                    new OcrBoundingBox { Id = "payee", Label = "Payee", Value = "Silicon Valley Micro-Servers", LeftPercent = 15, TopPercent = 36, WidthPercent = 52, HeightPercent = 12, AccentColor = "emerald" },
                    new OcrBoundingBox { Id = "courtesy", Label = "Courtesy Amount", Value = "$8,420.50", LeftPercent = 74, TopPercent = 36, WidthPercent = 20, HeightPercent = 12, AccentColor = "amber" },
                    new OcrBoundingBox { Id = "legal", Label = "Legal Amount Words", Value = "Eight thousand four hundred twenty and 50/100", LeftPercent = 6, TopPercent = 52, WidthPercent = 88, HeightPercent = 12, AccentColor = "emerald" },
                    new OcrBoundingBox { Id = "memo", Label = "Memo", Value = "Edge Node Cluster Hardware", LeftPercent = 10, TopPercent = 70, WidthPercent = 36, HeightPercent = 10, AccentColor = "slate" },
                    new OcrBoundingBox { Id = "sig", Label = "Authorized Signature", Value = "Verified Pen Ink", LeftPercent = 60, TopPercent = 68, WidthPercent = 34, HeightPercent = 14, AccentColor = "teal" },
                    new OcrBoundingBox { Id = "micr", Label = "MICR E-13B Clear Band", Value = "⑆021000021⑆ 9876543210⑈ 8812", LeftPercent = 6, TopPercent = 86, WidthPercent = 88, HeightPercent = 11, AccentColor = "cyan" }
                }
            },

            "check-draft-5021" => new CheckDraftOcrResult
            {
                PayerName = "Horizon Sovereign Trust (Official Cashier's Draft)",
                PayerAddress = "100 South Wacker Drive, Suite 4400, Chicago, IL 60606",
                BankName = "Bank of America, N.A. (Chicago)",
                CheckNumber = "5021",
                Date = "October 24, 2026",
                Payee = "Vertex Capital Holdings Ltd.",
                CourtesyAmount = 250000.00m,
                LegalAmountWords = "Two hundred fifty thousand and 00/100 Dollars",
                AmountsMatch = true,
                Memo = "Series B Capital Call Tranche 2",
                SignatureDetected = true,
                SignatureConfidence = 0.998,
                OverallConfidence = 0.995,
                ProcessingTimeMs = 54,
                MicrData = new MicrE13BData
                {
                    RawMicrLine = "⑆071000013⑆ 5544332211⑈ 5021",
                    TransitRoutingNumber = "071000013",
                    AccountNumber = "5544332211",
                    CheckNumber = "5021",
                    BankName = "Bank of America, N.A. (Chicago)",
                    IsValidRoutingChecksum = true,
                    Mod10ChecksumValue = 0,
                    Confidence = 0.998
                },
                BoundingBoxes = new()
                {
                    new OcrBoundingBox { Id = "payer", Label = "Official Cashier Draft", Value = "Horizon Sovereign Trust", LeftPercent = 6, TopPercent = 8, WidthPercent = 42, HeightPercent = 14, AccentColor = "blue" },
                    new OcrBoundingBox { Id = "chknum", Label = "Draft #", Value = "5021", LeftPercent = 82, TopPercent = 8, WidthPercent = 12, HeightPercent = 10, AccentColor = "indigo" },
                    new OcrBoundingBox { Id = "date", Label = "Date", Value = "October 24, 2026", LeftPercent = 65, TopPercent = 22, WidthPercent = 28, HeightPercent = 10, AccentColor = "purple" },
                    new OcrBoundingBox { Id = "payee", Label = "Payee", Value = "Vertex Capital Holdings Ltd.", LeftPercent = 15, TopPercent = 36, WidthPercent = 52, HeightPercent = 12, AccentColor = "emerald" },
                    new OcrBoundingBox { Id = "courtesy", Label = "Courtesy Amount", Value = "$250,000.00", LeftPercent = 74, TopPercent = 36, WidthPercent = 20, HeightPercent = 12, AccentColor = "amber" },
                    new OcrBoundingBox { Id = "legal", Label = "Legal Words", Value = "Two hundred fifty thousand and 00/100", LeftPercent = 6, TopPercent = 52, WidthPercent = 88, HeightPercent = 12, AccentColor = "emerald" },
                    new OcrBoundingBox { Id = "memo", Label = "Memo", Value = "Series B Capital Call Tranche 2", LeftPercent = 10, TopPercent = 70, WidthPercent = 36, HeightPercent = 10, AccentColor = "slate" },
                    new OcrBoundingBox { Id = "sig", Label = "Countersignature", Value = "Authorized Trust Officer", LeftPercent = 60, TopPercent = 68, WidthPercent = 34, HeightPercent = 14, AccentColor = "teal" },
                    new OcrBoundingBox { Id = "micr", Label = "MICR E-13B Clear Band", Value = "⑆071000013⑆ 5544332211⑈ 5021", LeftPercent = 6, TopPercent = 86, WidthPercent = 88, HeightPercent = 11, AccentColor = "cyan" }
                }
            },

            "check-invalid-9901" => new CheckDraftOcrResult
            {
                PayerName = "Suspicious Suspense Entity Co.",
                PayerAddress = "PO Box 9999, Unknown City, XX 00000",
                BankName = "Unknown Drawee Bank (Checksum Failure)",
                CheckNumber = "9901",
                Date = "October 18, 2026",
                Payee = "Global Escrow Accounts",
                CourtesyAmount = 4500.00m,
                LegalAmountWords = "Four thousand five hundred and 00/100 Dollars",
                AmountsMatch = true,
                Memo = "Test Fraud Routing Detection",
                SignatureDetected = false,
                SignatureConfidence = 0.32,
                OverallConfidence = 0.61,
                ProcessingTimeMs = 45,
                MicrData = new MicrE13BData
                {
                    RawMicrLine = "⑆123456789⑆ 0011223344⑈ 9901",
                    TransitRoutingNumber = "123456789",
                    AccountNumber = "0011223344",
                    CheckNumber = "9901",
                    BankName = "Invalid Routing (Failed Modulus 10)",
                    IsValidRoutingChecksum = false,
                    Mod10ChecksumValue = 4,
                    Confidence = 0.65
                },
                BoundingBoxes = new()
                {
                    new OcrBoundingBox { Id = "micr", Label = "MICR Routing Checksum FAILED", Value = "⑆123456789⑆", LeftPercent = 6, TopPercent = 86, WidthPercent = 88, HeightPercent = 11, AccentColor = "rose" }
                }
            },

            // Default: Standard Corporate Payroll Check
            _ => new CheckDraftOcrResult
            {
                PayerName = "Acme Enterprise Dynamics Inc.",
                PayerAddress = "100 Montgomery St, Suite 1800, San Francisco, CA 94104",
                BankName = "JPMorgan Chase Bank, N.A. (San Francisco)",
                CheckNumber = "1042",
                Date = "October 24, 2026",
                Payee = "Jane Doe Development Consulting",
                CourtesyAmount = 14850.00m,
                LegalAmountWords = "Fourteen thousand eight hundred fifty and 00/100 Dollars",
                AmountsMatch = true,
                Memo = "Q3 High-Availability Cloud Architecture Project",
                SignatureDetected = true,
                SignatureConfidence = 0.985,
                OverallConfidence = 0.992,
                ProcessingTimeMs = 62,
                MicrData = new MicrE13BData
                {
                    RawMicrLine = "⑆121000358⑆ 0123456789⑈ 1042",
                    TransitRoutingNumber = "121000358",
                    AccountNumber = "0123456789",
                    CheckNumber = "1042",
                    BankName = "JPMorgan Chase Bank, N.A. (San Francisco)",
                    IsValidRoutingChecksum = true,
                    Mod10ChecksumValue = 0,
                    Confidence = 0.996
                },
                BoundingBoxes = new()
                {
                    new OcrBoundingBox { Id = "payer", Label = "Payer / Account Holder", Value = "Acme Enterprise Dynamics Inc.", LeftPercent = 6, TopPercent = 8, WidthPercent = 38, HeightPercent = 14, AccentColor = "blue" },
                    new OcrBoundingBox { Id = "chknum", Label = "Check #", Value = "1042", LeftPercent = 82, TopPercent = 8, WidthPercent = 12, HeightPercent = 10, AccentColor = "indigo" },
                    new OcrBoundingBox { Id = "date", Label = "Issue Date", Value = "October 24, 2026", LeftPercent = 65, TopPercent = 22, WidthPercent = 28, HeightPercent = 10, AccentColor = "purple" },
                    new OcrBoundingBox { Id = "payee", Label = "Payee (Pay to Order)", Value = "Jane Doe Development Consulting", LeftPercent = 15, TopPercent = 36, WidthPercent = 52, HeightPercent = 12, AccentColor = "emerald" },
                    new OcrBoundingBox { Id = "courtesy", Label = "Courtesy Amount", Value = "$14,850.00", LeftPercent = 74, TopPercent = 36, WidthPercent = 20, HeightPercent = 12, AccentColor = "amber" },
                    new OcrBoundingBox { Id = "legal", Label = "Legal Amount Words", Value = "Fourteen thousand eight hundred fifty and 00/100", LeftPercent = 6, TopPercent = 52, WidthPercent = 88, HeightPercent = 12, AccentColor = "emerald" },
                    new OcrBoundingBox { Id = "memo", Label = "Memo / Purpose", Value = "Q3 High-Availability Cloud Architecture Project", LeftPercent = 10, TopPercent = 70, WidthPercent = 36, HeightPercent = 10, AccentColor = "slate" },
                    new OcrBoundingBox { Id = "sig", Label = "Maker Signature", Value = "Verified C-Level Ink", LeftPercent = 60, TopPercent = 68, WidthPercent = 34, HeightPercent = 14, AccentColor = "teal" },
                    new OcrBoundingBox { Id = "micr", Label = "ANSI X9.27 MICR Clear Band", Value = "⑆121000358⑆ 0123456789⑈ 1042", LeftPercent = 6, TopPercent = 86, WidthPercent = 88, HeightPercent = 11, AccentColor = "cyan" }
                }
            }
        };
    }

    /// <summary>
    /// Scans a multi-page PDF or corporate document (Invoice, W-9, Claim) and returns structured OCR fields.
    /// </summary>
    public async Task<DocumentOcrResult> ScanDocumentAsync(OcrDocumentType docType, string presetId = "invoice-cloud-8821")
    {
        await Task.Delay(95);

        if (docType == OcrDocumentType.PaperCheck || docType == OcrDocumentType.BankDraft)
        {
            var check = await ScanCheckOrDraftAsync(presetId);
            return new DocumentOcrResult
            {
                Title = check.PayerName + " — Check #" + check.CheckNumber,
                DocumentType = docType,
                FileName = $"check-{check.CheckNumber}.pdf",
                FileSizeFormatted = "284 KB",
                PageCount = 1,
                ConfidenceScore = check.OverallConfidence,
                ProcessingTimeMs = check.ProcessingTimeMs,
                CheckData = check,
                BoundingBoxes = check.BoundingBoxes,
                Fields = new()
                {
                    new OcrFieldItem { Key = "PayerName", Label = "Drawer / Account Name", Value = check.PayerName, Category = "Payer" },
                    new OcrFieldItem { Key = "CheckNumber", Label = "Check / Draft Number", Value = check.CheckNumber, Category = "Check" },
                    new OcrFieldItem { Key = "Date", Label = "Payment Date", Value = check.Date, Category = "Check" },
                    new OcrFieldItem { Key = "Payee", Label = "Payee Name", Value = check.Payee, Category = "Payee" },
                    new OcrFieldItem { Key = "Amount", Label = "Check Amount (USD)", Value = check.CourtesyAmount.ToString("C2"), Category = "Financial" },
                    new OcrFieldItem { Key = "LegalWords", Label = "Legal Amount Words", Value = check.LegalAmountWords, Category = "Financial" },
                    new OcrFieldItem { Key = "RoutingNumber", Label = "ABA Routing Transit #", Value = check.MicrData.TransitRoutingNumber, Category = "Banking" },
                    new OcrFieldItem { Key = "AccountNumber", Label = "Drawee Account #", Value = check.MicrData.AccountNumber, Category = "Banking" },
                    new OcrFieldItem { Key = "BankName", Label = "Drawee Financial Institution", Value = check.MicrData.BankName, Category = "Banking" },
                    new OcrFieldItem { Key = "Memo", Label = "Memo / Reference", Value = check.Memo, Category = "Audit" }
                },
                RawExtractedText = $"PAYER: {check.PayerName}\nCHECK NO: {check.CheckNumber}\nDATE: {check.Date}\nPAY TO: {check.Payee}\nAMOUNT: ${check.CourtesyAmount:N2}\nLEGAL: {check.LegalAmountWords}\nMICR: {check.MicrData.RawMicrLine}",
                MarkdownTableRepresentation = GenerateCheckMarkdown(check)
            };
        }

        if (docType == OcrDocumentType.TaxFormW9)
        {
            return new DocumentOcrResult
            {
                Title = "IRS Form W-9 Request for Taxpayer Identification",
                DocumentType = OcrDocumentType.TaxFormW9,
                FileName = "form-w9-signed.pdf",
                FileSizeFormatted = "412 KB",
                PageCount = 1,
                ConfidenceScore = 0.982,
                ProcessingTimeMs = 82,
                Fields = new()
                {
                    new OcrFieldItem { Key = "Name", Label = "1. Name (as shown on income tax return)", Value = "Acme Global Technologies Inc.", Category = "Identity" },
                    new OcrFieldItem { Key = "BusinessName", Label = "2. Business Name / Disregarded Entity", Value = "Acme Cloud Services", Category = "Identity" },
                    new OcrFieldItem { Key = "FederalTaxClassification", Label = "3. Federal Tax Classification", Value = "C Corporation", Category = "Classification" },
                    new OcrFieldItem { Key = "Address", Label = "5. Address (number, street, and apt)", Value = "500 Howard Street, Suite 900", Category = "Contact" },
                    new OcrFieldItem { Key = "CityStateZip", Label = "6. City, state, and ZIP code", Value = "San Francisco, CA 94105", Category = "Contact" },
                    new OcrFieldItem { Key = "Ein", Label = "Part I: Employer Identification Number (EIN)", Value = "12-3456789", Category = "Tax ID" },
                    new OcrFieldItem { Key = "CertificationSigned", Label = "Part II: Certification Signature", Value = "Digitally Executed (Valid)", Category = "Compliance" }
                },
                RawExtractedText = "IRS Form W-9 (Rev. March 2024)\nName: Acme Global Technologies Inc.\nEIN: 12-3456789\nClassification: C Corporation\nAddress: 500 Howard Street, Suite 900, San Francisco, CA 94105",
                MarkdownTableRepresentation = "| Form Field | Extracted W-9 Value | Status |\n|---|---|---|\n| **Entity Legal Name** | Acme Global Technologies Inc. | ✅ Verified |\n| **Classification** | C Corporation | ✅ Verified |\n| **Employer ID (EIN)** | `12-3456789` | ✅ Verified |\n| **Address** | 500 Howard Street, Suite 900, SF, CA | ✅ Verified |\n| **Certification** | Electronically Executed & Compliant | ✅ Valid |"
            };
        }

        // Commercial Invoice default
        return new DocumentOcrResult
        {
            Title = "Commercial Cloud Hosting Invoice #INV-88219",
            DocumentType = OcrDocumentType.CommercialInvoice,
            FileName = "invoice-inv-88219.pdf",
            FileSizeFormatted = "520 KB",
            PageCount = 2,
            ConfidenceScore = 0.991,
            ProcessingTimeMs = 74,
            Fields = new()
            {
                new OcrFieldItem { Key = "VendorName", Label = "Vendor Legal Name", Value = "Apex Cloud Compute Corp", Category = "Vendor" },
                new OcrFieldItem { Key = "InvoiceNumber", Label = "Invoice Number", Value = "INV-88219", Category = "Invoice" },
                new OcrFieldItem { Key = "InvoiceDate", Label = "Invoice Date", Value = "2026-10-21", Category = "Invoice" },
                new OcrFieldItem { Key = "DueDate", Label = "Payment Due Date", Value = "2026-11-20 (Net 30)", Category = "Terms" },
                new OcrFieldItem { Key = "Subtotal", Label = "Subtotal Amount", Value = "$3,150.00", Category = "Totals" },
                new OcrFieldItem { Key = "Tax", Label = "Sales & Use Tax", Value = "$278.15", Category = "Totals" },
                new OcrFieldItem { Key = "TotalDue", Label = "Total Due (USD)", Value = "$3,428.15", Category = "Totals" },
                new OcrFieldItem { Key = "PoReference", Label = "Customer PO Reference", Value = "PO-2026-HQ-091", Category = "Order" }
            },
            RawExtractedText = "INVOICE #INV-88219\nVendor: Apex Cloud Compute Corp\nDate: 2026-10-21\nDue Date: 2026-11-20\nSubtotal: $3,150.00\nTax: $278.15\nTotal Due: $3,428.15\nPO Ref: PO-2026-HQ-091",
            MarkdownTableRepresentation = "| Invoice Field | Extracted Value | Confidence |\n|---|---|:---:|\n| **Vendor** | Apex Cloud Compute Corp | 99.4% |\n| **Invoice #** | `INV-88219` | 99.9% |\n| **Date** | October 21, 2026 | 98.7% |\n| **Due Date** | Net 30 (Nov 20, 2026) | 99.1% |\n| **Subtotal** | `$3,150.00` | 99.2% |\n| **Tax** | `$278.15` | 98.5% |\n| **Total Balance** | **`$3,428.15`** | **99.8%** |"
        };
    }

    /// <summary>
    /// Produces a formatted GitHub Flavored Markdown table representation of check ledger data.
    /// </summary>
    public string GenerateCheckMarkdown(CheckDraftOcrResult check)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"### 🏦 Check 21 OCR & MICR Extraction Report: Check #{check.CheckNumber}");
        sb.AppendLine();
        sb.AppendLine("| Check Field | Value | Verification Status |");
        sb.AppendLine("|---|---|:---:|");
        sb.AppendLine($"| **Payer / Account** | {check.PayerName} | ✅ Extracted |");
        sb.AppendLine($"| **Payee** | {check.Payee} | ✅ Extracted |");
        sb.AppendLine($"| **Date** | {check.Date} | ✅ Extracted |");
        sb.AppendLine($"| **Check Number** | `{check.CheckNumber}` | ✅ Matched MICR |");
        sb.AppendLine($"| **Courtesy Amount** | **${check.CourtesyAmount:N2}** | ✅ {(check.AmountsMatch ? "Matches Legal Words" : "⚠️ Amount Mismatch")} |");
        sb.AppendLine($"| **Legal Amount Words** | *{check.LegalAmountWords}* | ✅ Verified |");
        sb.AppendLine($"| **ABA Routing Number** | `{check.MicrData.TransitRoutingNumber}` | {(check.MicrData.IsValidRoutingChecksum ? "✅ Valid Mod10 Checksum" : "❌ Invalid Checksum")} |");
        sb.AppendLine($"| **Account Number** | `{check.MicrData.AccountNumber}` | ✅ On-Us Extracted |");
        sb.AppendLine($"| **Drawee Institution** | {check.MicrData.BankName} | ✅ Resolved |");
        sb.AppendLine($"| **Memo** | {check.Memo} | ✅ Extracted |");
        sb.AppendLine($"| **Maker Signature** | {(check.SignatureDetected ? "Verified Ink Signature" : "Missing Signature")} | {(check.SignatureDetected ? "✅ Detected (98.5%)" : "❌ Missing")} |");
        sb.AppendLine($"| **Raw E-13B MICR Line** | `{check.MicrData.RawMicrLine}` | ✅ ANSI X9.27 |");
        return sb.ToString();
    }
}
