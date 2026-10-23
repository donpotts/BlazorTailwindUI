namespace BlazorTailwindUI.Models;

/// <summary>
/// Supported document types for OCR & Form Analysis.
/// </summary>
public enum OcrDocumentType
{
    PaperCheck,
    BankDraft,
    CommercialInvoice,
    TaxFormW9,
    MedicalClaim,
    CustomFormPdf
}

/// <summary>
/// Parsed E-13B MICR line data according to ANSI X9.27 / Check 21 standards.
/// </summary>
public class MicrE13BData
{
    public string RawMicrLine { get; set; } = string.Empty;
    public string TransitRoutingNumber { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string CheckNumber { get; set; } = string.Empty;
    public decimal? EmbeddedAmount { get; set; }
    public string BankName { get; set; } = string.Empty;
    public bool IsValidRoutingChecksum { get; set; }
    public int Mod10ChecksumValue { get; set; }
    public double Confidence { get; set; } = 0.99;

    /// <summary>
    /// Computes ABA 9-digit Routing Transit Number checksum:
    /// (3*(d1 + d4 + d7) + 7*(d2 + d5 + d8) + 1*(d3 + d6 + d9)) % 10 == 0
    /// </summary>
    public static (bool IsValid, int Checksum) ValidateAbaRouting(string routing)
    {
        if (string.IsNullOrWhiteSpace(routing)) return (false, -1);
        var digits = routing.Where(char.IsDigit).Select(c => c - '0').ToArray();
        if (digits.Length != 9) return (false, -1);

        int sum = 3 * (digits[0] + digits[3] + digits[6])
                + 7 * (digits[1] + digits[4] + digits[7])
                + 1 * (digits[2] + digits[5] + digits[8]);

        int mod = sum % 10;
        return (mod == 0, mod);
    }
}

/// <summary>
/// Comprehensive OCR extraction result for a paper check or bank draft.
/// </summary>
public class CheckDraftOcrResult
{
    public string PayerName { get; set; } = string.Empty;
    public string PayerAddress { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
    public string CheckNumber { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public string Payee { get; set; } = string.Empty;
    public decimal CourtesyAmount { get; set; }
    public string LegalAmountWords { get; set; } = string.Empty;
    public bool AmountsMatch { get; set; } = true;
    public string Memo { get; set; } = string.Empty;
    public bool SignatureDetected { get; set; } = true;
    public double SignatureConfidence { get; set; } = 0.98;
    public MicrE13BData MicrData { get; set; } = new();
    public double OverallConfidence { get; set; } = 0.985;
    public int ProcessingTimeMs { get; set; } = 64;
    public List<OcrBoundingBox> BoundingBoxes { get; set; } = new();
}

/// <summary>
/// A single recognized field in an OCR document with spatial coordinates.
/// </summary>
public class OcrFieldItem
{
    public string Key { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public double Confidence { get; set; } = 0.95;
    public string Category { get; set; } = "General";
    public bool IsVerified { get; set; } = true;
}

/// <summary>
/// Visual bounding box for UI overlay in document viewers.
/// Coordinates are expressed as percentages (0 - 100) of document bounds.
/// </summary>
public class OcrBoundingBox
{
    public string Id { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public double Confidence { get; set; } = 0.95;
    public double LeftPercent { get; set; }
    public double TopPercent { get; set; }
    public double WidthPercent { get; set; }
    public double HeightPercent { get; set; }
    public string AccentColor { get; set; } = "emerald";
}

/// <summary>
/// Master document OCR analysis model.
/// </summary>
public class DocumentOcrResult
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Title { get; set; } = string.Empty;
    public OcrDocumentType DocumentType { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string FileSizeFormatted { get; set; } = "342 KB";
    public int PageCount { get; set; } = 1;
    public double ConfidenceScore { get; set; } = 0.98;
    public int ProcessingTimeMs { get; set; } = 78;
    public List<OcrFieldItem> Fields { get; set; } = new();
    public List<OcrBoundingBox> BoundingBoxes { get; set; } = new();
    public CheckDraftOcrResult? CheckData { get; set; }
    public string RawExtractedText { get; set; } = string.Empty;
    public string MarkdownTableRepresentation { get; set; } = string.Empty;
}
