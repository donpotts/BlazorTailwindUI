// Auto-generated Component Catalog Service for all BlazorTailwindUI components
using System.Collections.Generic;
using System.Linq;
using BlazorTailwindUI.Models;

namespace BlazorTailwindUI.Services;

public class ComponentCatalogService
{
    private static readonly List<ComponentDocItem> _items = new()
    {
        new ComponentDocItem
        {
            Name = "TwMfaAuthSuite",
            Category = "Security & Compliance",
            Description = "Enterprise-grade multi-factor authentication suite supporting TOTP authenticator app QR setup, SMS/Email 6-digit OTP with auto-advancing segmented inputs, FIDO2 / WebAuthn biometric passkeys, and single-use emergency recovery codes.",
            RazorSnippet = "<TwMfaAuthSuite OnEnrollmentChanged=\"(isEnrolled) => { /* Handle state */ }\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Class", "string?", "null", "Custom Tailwind CSS classes."),
                new ComponentParameterDoc("OnEnrollmentChanged", "EventCallback<bool>", "null", "Callback fired when user enrolls or updates 2FA status.")
            }
        },
        new ComponentDocItem
        {
            Name = "TwPrizeWheel",
            Category = "Gamification & Celebrations",
            Description = "Interactive SVG spinning fortune prize wheel with realistic deceleration physics, top pointer tick indicator, customizable prize wedges, celebratory confetti burst, and winner announcement banner for team morale boosts and party giveaways.",
            RazorSnippet = "<TwPrizeWheel OnPrizeWon=\"(prize) => { /* Handle prize */ }\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Class", "string?", "null", "Custom Tailwind CSS classes."),
                new ComponentParameterDoc("Title", "string", "\"Spin to Win!\"", "Component header title."),
                new ComponentParameterDoc("Prizes", "List<PrizeItem>", "Default 8 wedges", "List of prize wedges with titles, emojis, colors, and descriptions (inspired by MyWheel)."),
                new ComponentParameterDoc("OnPrizeWon", "EventCallback<PrizeItem>", "null", "Fired upon completion of deceleration on the winning wedge.")
            }
        },
        new ComponentDocItem
        {
            Name = "TwCelebrationEditor",
            Category = "Gamification & Celebrations",
            Description = "Visual workbench for configuring canvas particle celebrations and confetti bursts. Sliders for particle count, velocity, spread angle, gravity, and origin height with instant live testing and copyable C#/Razor markup.",
            RazorSnippet = "<TwCelebrationEditor />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Class", "string?", "null", "Custom Tailwind CSS classes.")
            }
        },
        new ComponentDocItem
        {
            Name = "TwRewardsCenter",
            Category = "Enterprise & Workplace Operations",
            Description = "Employee perks and recognition rewards catalog with category filtering (Gift Cards, Swag, Workplace Flexibility, Learning, Wellness), points wallet ledger, search bar, and digital voucher redemption modal.",
            RazorSnippet = "<TwRewardsCenter />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Class", "string?", "null", "Custom Tailwind CSS classes.")
            }
        },
        new ComponentDocItem
        {
            Name = "TwScrollCraft",
            Category = "Animation & Micro-Interactions",
            Description = "Scroll-driven object animation container with parallax depth layers, focal zone reading fades, and pinned illustration scrubbers linked to viewport progress.",
            RazorSnippet = "<TwScrollCraft Title=\"Content Scroll Scrubbing\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"Content Scroll Scrubbing\"", "Stage title."),
                new ComponentParameterDoc("Steps", "List<ScrollStep>", "Default 4 steps", "List of steps with title, description, badge, and icon."),
                new ComponentParameterDoc("Class", "string?", "null", "Custom Tailwind CSS classes.")
            }
        },
        new ComponentDocItem
        {
            Name = "TwMediaRecorder",
            Category = "Hardware & Media Interop",
            Description = "In-browser microphone and HD webcam media recorder with live SVG audio frequency visualizer, recording status pulse, VU meters, playback preview via TwMediaPlayer, and local file download.",
            RazorSnippet = "<TwMediaRecorder OnRecordingCompleted=\"(duration) => { /* Handle duration */ }\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Class", "string?", "null", "Custom Tailwind CSS classes."),
                new ComponentParameterDoc("OnRecordingCompleted", "EventCallback<int>", "null", "Fired when user completes a recording with the elapsed seconds.")
            }
        },
        new ComponentDocItem
        {
            Name = "TwFinancialChart",
            Category = "Financial & Analytical Intelligence",
            Description = "High-frequency Candlestick and Area financial charting engine with real-time volume histogram, 20-period moving average line, crosshair hover HUD inspector, timeframe range presets (1W, 1M, 3M, YTD, 1Y, ALL), and zero-JS vector SVG rendering.",
            RazorSnippet = "<TwFinancialChart Ticker=\"BLZR\" CompanyName=\"Blazor Technologies Inc.\" Exchange=\"NASDAQ\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Ticker", "string", "\"BLZR\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("CompanyName", "string", "\"Blazor Technologies Inc.\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Exchange", "string", "\"NASDAQ\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Data", "List<FinancialCandle>?", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwTreemap",
            Category = "Financial & Analytical Intelligence",
            Description = "Multi-dimensional area treemap and valuation heatmap visualizing hierarchical assets, portfolio market caps, and performance returns with squarified 2D tiling, dynamic drill-down breadcrumb, and color ramps.",
            RazorSnippet = "<TwTreemap Title=\"Market Valuation Heatmap & Treemap\" Subtitle=\"Hierarchical squarified area map of enterprise assets and percentage price shifts\" CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"Market Valuation Heatmap & Treemap\"", "Header title or accessible label."),
                new ComponentParameterDoc("Subtitle", "string", "\"Hierarchical squarified area map of enterprise assets and percentage price shifts\"", "Header title or accessible label."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Items", "List<TreemapItem>?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnItemClick", "EventCallback<TreemapItem>", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwPivotGrid",
            Category = "Financial & Analytical Intelligence",
            Description = "Enterprise OLAP cross-tabulation matrix supporting dynamic row/column field pivoting, value aggregations (Sum, Average, Count), interactive field drop drawer, and hierarchical subtotal and grand total calculations.",
            RazorSnippet = "<TwPivotGrid Title=\"Enterprise Financial Pivot Grid\" Subtitle=\"Multi-dimensional cross-tabulation matrix with real-time grouping & aggregation\" CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"Enterprise Financial Pivot Grid\"", "Header title or accessible label."),
                new ComponentParameterDoc("Subtitle", "string", "\"Multi-dimensional cross-tabulation matrix with real-time grouping & aggregation\"", "Header title or accessible label."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Records", "List<PivotRecord>?", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwIconPicker",
            Category = "Developer Studio & Content Creation",
            Description = "Interactive search-and-select icon & emoji explorer with live filtering, outline/solid toggles, size previews, and one-click Razor component snippet copying.",
            RazorSnippet = "<TwIconPicker Title=\"Open Source Vector Icons & Emoji Studio\" Subtitle=\"Zero-dependency pure C# WASM vector icons and emojis for enterprise dashboards and forms\" CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"Open Source Vector Icons & Emoji Studio\"", "Header title or accessible label."),
                new ComponentParameterDoc("Subtitle", "string", "\"Zero-dependency pure C# WASM vector icons and emojis for enterprise dashboards and forms\"", "Header title or accessible label."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwIcon",
            Category = "Developer Studio & Content Creation",
            Description = "Zero-dependency pure C# WASM inline vector SVG icon engine supporting 100+ curated icons (Heroicons & Lucide paths), customizable sizes, stroke widths, outline/solid modes, and semantic color inheritance.",
            RazorSnippet = "<TwIcon Name=\"sparkles\" Size=\"ComponentSize.Md\" StrokeWidth=\"1.75\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Name", "string", "\"sparkles\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Size", "ComponentSize", "ComponentSize.Md", "Component sizing scale (Xs, Sm, Md, Lg)."),
                new ComponentParameterDoc("IsSolid", "bool", "false", "Configures component behavior or styling."),
                new ComponentParameterDoc("StrokeWidth", "double", "1.75", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string", "\"\"", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwEmoji",
            Category = "Developer Studio & Content Creation",
            Description = "Modern emoji component with shortcode mapping (:rocket:, :fire:, :sparkles:), Unicode glyph parsing, hover scale physics, and click-to-copy clipboard integration.",
            RazorSnippet = "<TwEmoji Size=\"ComponentSize.Md\" AnimateOnHover=\"true\" Class=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Shortcode", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Glyph", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Size", "ComponentSize", "ComponentSize.Md", "Component sizing scale (Xs, Sm, Md, Lg)."),
                new ComponentParameterDoc("AnimateOnHover", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("CopyOnClick", "bool", "false", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Class", "string", "\"\"", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwMarkdownEditor",
            Category = "Developer Studio & Content Creation",
            Description = "Enterprise-grade dual Markdown and HTML editor featuring live pure C# WASM typography preview, split/edit/preview modes, toolbar actions (headings, lists, bold, italics, code, tables), fullscreen Zen focus, and media drawer supporting image, video, audio, and link embedding.",
            RazorSnippet = "<TwMarkdownEditor Value=\"\" CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("Value", "string", "\"\"", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("ValueChanged", "EventCallback<string>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwDockManager",
            Category = "Developer Studio & Content Creation",
            Description = "Desktop-grade multi-pane docking studio layout engine featuring Solution Explorer tree, multi-tab central document workspace, bottom diagnostic terminal output, and collapsible properties inspector.",
            RazorSnippet = "<TwDockManager CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwSpreadsheet",
            Category = "Developer Studio & Content Creation",
            Description = "Spreadsheet calculation engine with alphanumeric grid coordinates (A1..E10), formula bar, formula evaluation (=SUM, =AVG, arithmetic), direct cell inline editing, and formatted total readouts.",
            RazorSnippet = "<TwSpreadsheet Title=\"Enterprise Spreadsheet Matrix\" Subtitle=\"Excel-compatible cell matrix with live arithmetic, range aggregations, and formula bar\" CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"Enterprise Spreadsheet Matrix\"", "Header title or accessible label."),
                new ComponentParameterDoc("Subtitle", "string", "\"Excel-compatible cell matrix with live arithmetic, range aggregations, and formula bar\"", "Header title or accessible label."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwOrgChart",
            Category = "Developer Studio & Content Creation",
            Description = "Hierarchical organization tree visualizer with pure vector SVG orthogonal connector lines, search highlight filter, recursive branch expand/collapse toggles, and A-/A+ canvas zoom controls.",
            RazorSnippet = "<TwOrgChart Title=\"Enterprise Organization Tree\" Subtitle=\"Executive leadership structure, reporting hierarchies, and departmental clusters\" CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"Enterprise Organization Tree\"", "Header title or accessible label."),
                new ComponentParameterDoc("Subtitle", "string", "\"Executive leadership structure, reporting hierarchies, and departmental clusters\"", "Header title or accessible label."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Root", "OrgNode?", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwUserRegistrationForm",
            Category = "Task-Purpose Enterprise Forms",
            Description = "Turnkey enterprise user registration form featuring full name, username, corporate email, role selector, real-time password strength meter, terms consent, and federated SSO options.",
            RazorSnippet = "<TwUserRegistrationForm Title=\"Create Your Account\" Subtitle=\"Deploy enterprise WebAssembly apps with instant Tailwind CSS parity\" ShowSocialLogins=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"Create Your Account\"", "Header title or accessible label."),
                new ComponentParameterDoc("Subtitle", "string", "\"Deploy enterprise WebAssembly apps with instant Tailwind CSS parity\"", "Header title or accessible label."),
                new ComponentParameterDoc("ShowSocialLogins", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnRegistered", "EventCallback<RegistrationModel>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnSsoRequested", "EventCallback<string>", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwUserEditForm",
            Category = "Task-Purpose Enterprise Forms",
            Description = "Comprehensive profile and security management form featuring interactive avatar selection, corporate role attributes, 2FA toggle, session management, and audited account deactivation.",
            RazorSnippet = "<TwUserEditForm CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Model", "UserProfileModel?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnSaved", "EventCallback<UserProfileModel>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnDeactivate", "EventCallback", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwLoginForm",
            Category = "Task-Purpose Enterprise Forms",
            Description = "Split-screen enterprise authentication form featuring curated Unsplash architectural imagery, inspiring technical quotes, federated SSO buttons, password visibility toggle, and remember-me persistence.",
            RazorSnippet = "<TwLoginForm Title=\"Sign in to Enterprise Hub\" Subtitle=\"Access mission-critical dashboards, design tokens, and components\" ImageUrl=\"https://images.unsplash.com/photo-1517694712202-14dd9538aa97?auto=format&fit=crop&w=1200&q=80\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"Sign in to Enterprise Hub\"", "Header title or accessible label."),
                new ComponentParameterDoc("Subtitle", "string", "\"Access mission-critical dashboards, design tokens, and components\"", "Header title or accessible label."),
                new ComponentParameterDoc("ImageUrl", "string", "\"https://images.unsplash.com/photo-1517694712202-14dd9538aa97?auto=format&fit=crop&w=1200&q=80\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("QuoteText", "string", "\"Simplicity is prerequisite for reliability.\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("QuoteAuthor", "string", "\"Edsger W. Dijkstra\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("QuoteCitation", "string", "\"Turing Award Laureate\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowSocialLogins", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("AllowRememberMe", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnLogin", "EventCallback<LoginCredentials>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnSsoLogin", "EventCallback<string>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnForgotPassword", "EventCallback", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwTermsOfUseForm",
            Category = "Task-Purpose Enterprise Forms",
            Description = "Executive legal terms agreement viewer with section jump pills, PDF export, review progress tracking, signatory name/company binding, and tamper-evident SHA-256 hash stamp.",
            RazorSnippet = "<TwTermsOfUseForm Title=\"Enterprise Terms of Service\" Version=\"v3.2\" LastUpdated=\"October 2026\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"Enterprise Terms of Service\"", "Header title or accessible label."),
                new ComponentParameterDoc("Version", "string", "\"v3.2\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("LastUpdated", "string", "\"October 2026\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnAccepted", "EventCallback<TermsAcceptanceModel>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnDeclined", "EventCallback", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwCookieConsent",
            Category = "Task-Purpose Enterprise Forms",
            Description = "GDPR and CCPA compliant cookie preference manager featuring strictly necessary lock, customizable functional/telemetry/marketing toggles, and instant preferences persistence.",
            RazorSnippet = "<TwCookieConsent Title=\"Enterprise Cookie & Privacy Settings\" Description=\"We use minimal first-party cookies to secure user sessions, maintain UI state, and measure performance latency. We never sell your personal data.\" CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"Enterprise Cookie & Privacy Settings\"", "Header title or accessible label."),
                new ComponentParameterDoc("Description", "string", "\"We use minimal first-party cookies to secure user sessions, maintain UI state, and measure performance latency. We never sell your personal data.\"", "Secondary descriptive caption."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnSaved", "EventCallback<CookiePreferencesModel>", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwPrivacyPolicyForm",
            Category = "Task-Purpose Enterprise Forms",
            Description = "Enterprise privacy charter featuring zero-CDN data guarantees and an automated self-service Data Subject Request (DSR) portal for machine-readable JSON/ZIP exports and audited account erasure.",
            RazorSnippet = "<TwPrivacyPolicyForm Title=\"Enterprise Privacy & Data Governance\" CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"Enterprise Privacy & Data Governance\"", "Header title or accessible label."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnExportRequested", "EventCallback<string>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnErasureRequested", "EventCallback", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwAboutMissionForm",
            Category = "Task-Purpose Enterprise Forms",
            Description = "Enterprise vision and architectural charter banner with live performance metrics, engineering pillars, leadership team cards, and an interactive executive consultation inquiry form.",
            RazorSnippet = "<TwAboutMissionForm MissionHeading=\"Empowering Modern Enterprises with Zero-Latency Blazor UI\" MissionStatement=\"Our mission is to build the world's most performant, secure, and developer-delightful component library for .NET 11 WebAssembly, bridging modern Tailwind CSS agility with enterprise-grade reliability and zero third-party telemetry.\" CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("MissionHeading", "string", "\"Empowering Modern Enterprises with Zero-Latency Blazor UI\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("MissionStatement", "string", "\"Our mission is to build the world's most performant, secure, and developer-delightful component library for .NET 11 WebAssembly, bridging modern Tailwind CSS agility with enterprise-grade reliability and zero third-party telemetry.\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnInquirySubmitted", "EventCallback<ContactInquiryModel>", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwPledgeForm",
            Category = "Task-Purpose Enterprise Forms",
            Description = "Official Code of Conduct, security compliance, and supply chain integrity pledge form with three sworn adherence principles, signatory details, and digital signature capture.",
            RazorSnippet = "<TwPledgeForm Title=\"Enterprise Engineering & Ethics Pledge\" Subtitle=\"Legally affirmed compliance with software supply chain integrity and responsible AI\" CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"Enterprise Engineering & Ethics Pledge\"", "Header title or accessible label."),
                new ComponentParameterDoc("Subtitle", "string", "\"Legally affirmed compliance with software supply chain integrity and responsible AI\"", "Header title or accessible label."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnPledgeAffirmed", "EventCallback<PledgeModel>", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwAppShell",
            Category = "Layout & Application Shell",
            Description = "The root application shell supporting four dynamic layout variants: Sidebar (mobile drawer + desktop sidebar), TopNav (horizontal bar with mobile sheet), CompactRail (icon rail), and Stacked (single column).",
            RazorSnippet = "<TwAppShell Layout=\"LayoutVariant.Sidebar\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Layout", "LayoutVariant", "LayoutVariant.Sidebar", "Configures component behavior or styling."),
                new ComponentParameterDoc("BrandContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("HeaderActions", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("SidebarContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("SidebarFooter", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("TopNavContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("RailContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("BottomNavContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwContainer",
            Category = "Layout & Application Shell",
            Description = "Responsive max-width container wrapper with automatic padding and breakpoint clamping (sm, md, lg, xl, 2xl, full).",
            RazorSnippet = "<TwContainer MaxWidth=\"7xl\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("MaxWidth", "string", "\"7xl\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwGrid",
            Category = "Layout & Application Shell",
            Description = "Mobile-first responsive grid system with configurable column distributions (1-2-3, 1-2-4, 2-3-4, etc.) and gap scales.",
            RazorSnippet = "<TwGrid Preset=\"1-2-3\" Gap=\"md\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Preset", "string", "\"1-2-3\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Gap", "string", "\"md\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwSplitter",
            Category = "Layout & Application Shell",
            Description = "Enterprise resizable split layout container supporting horizontal and vertical orientations, draggable divider handle, and one-click collapse/reset buttons.",
            RazorSnippet = "<TwSplitter Orientation=\"SplitOrientation.Horizontal\" SplitPercentage=\"40\" MinPercentage=\"15\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Orientation", "SplitOrientation", "SplitOrientation.Horizontal", "Configures component behavior or styling."),
                new ComponentParameterDoc("SplitPercentage", "double", "40", "Configures component behavior or styling."),
                new ComponentParameterDoc("MinPercentage", "double", "15", "Configures component behavior or styling."),
                new ComponentParameterDoc("MaxPercentage", "double", "85", "Configures component behavior or styling."),
                new ComponentParameterDoc("MinHeight", "int", "280", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("PaneOne", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("PaneTwo", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("SplitPercentageChanged", "EventCallback<double>", "null", "Callback invoked when state changes or item is selected."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwBottomNav",
            Category = "Layout & Application Shell",
            Description = "Fixed application bottom navigation bar for touch devices with active state indicators, notification badges, and haptic tap styling.",
            RazorSnippet = "<TwBottomNav Items=\"Array.Empty<NavItem>()\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Items", "IReadOnlyList<NavItem>", "Array.Empty<NavItem>()", "Configures component behavior or styling."),
                new ComponentParameterDoc("ActiveId", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnSelect", "EventCallback<string>", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "ThemeProvider",
            Category = "Theme & Palette Customization",
            Description = "Cascading state provider managing light, dark, and system color mode preferences with localStorage synchronization and zero-FOUC initialization.",
            RazorSnippet = "<ThemeProvider>\n    <span>Content</span>\n</ThemeProvider>",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
            }
        },
        new ComponentDocItem
        {
            Name = "ThemeSwitcher",
            Category = "Theme & Palette Customization",
            Description = "Segmented mode selector with accent swatches for quick switching between Light, Dark, and OS System appearance.",
            RazorSnippet = "<ThemeSwitcher ShowAccentPicker=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Compact", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowAccentPicker", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwThemeSelector",
            Category = "Theme & Palette Customization",
            Description = "Modern comprehensive color dropdown selector featuring preset palette swatches and 16M+ custom hex color picker integration.",
            RazorSnippet = "<TwThemeSelector Alignment=\"right\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Compact", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Alignment", "string", "\"right\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwThemeSwitcher",
            Category = "Theme & Palette Customization",
            Description = "Compact pill switcher for toggling between dark, light, and system themes.",
            RazorSnippet = "<TwThemeSwitcher ShowAccentPicker=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Compact", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowAccentPicker", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwColorPicker",
            Category = "Theme & Palette Customization",
            Description = "Interactive 16M+ hex and RGB color picker with preview swatch, hex validation, and opacity support.",
            RazorSnippet = "<TwColorPicker Value=\"#6366f1\" Label=\"Pick Accent Color\" ShowValueBadge=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Value", "string", "\"#6366f1\"", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("ValueChanged", "EventCallback<string>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Label", "string?", "\"Pick Accent Color\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowValueBadge", "bool", "true", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("AllowCustom", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowCopy", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Inline", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwCodeFontModifier",
            Category = "Code & Syntax Studio",
            Description = "Enterprise code editor toolbar with interactive font sizer (A-/A+), monospace font switcher (JetBrains, Fira Code, Cascadia), ligatures toggle, line height stepper, word wrap, and syntax theme presets.",
            RazorSnippet = "<TwCodeFontModifier Title=\"Code Editor & Font Toolbar\" FontSize=\"13\" FontFamily=\"'JetBrains Mono', monospace\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"Code Editor & Font Toolbar\"", "Header title or accessible label."),
                new ComponentParameterDoc("FontSize", "int", "13", "Component sizing scale (Xs, Sm, Md, Lg)."),
                new ComponentParameterDoc("FontSizeChanged", "EventCallback<int>", "null", "Component sizing scale (Xs, Sm, Md, Lg)."),
                new ComponentParameterDoc("FontFamily", "string", "\"'JetBrains Mono', monospace\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("LineHeight", "string", "\"leading-normal\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("EnableLigatures", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("WordWrap", "bool", "false", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowLineNumbers", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("ThemePreset", "string", "\"emerald\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("SampleCode", "string?", "@\"// High-performance Blazor Tailwind Engine\npublic sealed record ComponentSpec(string Name, string Category)\n{\n    public bool HasDarkModeSupport => true", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnSettingsChanged", "EventCallback<CodeFontSettings>", "null", "Callback invoked when state changes or item is selected."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwCodeTabs",
            Category = "Code & Syntax Studio",
            Description = "Multi-file tabbed code viewer with window controls, active file tabs, language icons, line numbers, and one-click clipboard copy.",
            RazorSnippet = "<TwCodeTabs Tabs=\"Array.Empty<CodeTab>()\" ShowLineNumbers=\"true\" AllowCopy=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Tabs", "IReadOnlyList<CodeTab>", "Array.Empty<CodeTab>()", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowLineNumbers", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("AllowCopy", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwCodeDiff",
            Category = "Code & Syntax Studio",
            Description = "Git-style visual code diff viewer highlighting additions and deletions with side-by-side line numbering, syntax color coding, and stats.",
            RazorSnippet = "<TwCodeDiff FileName=\"diff.razor\" Lines=\"Array.Empty<DiffLine>()\" AllowCopy=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("FileName", "string", "\"diff.razor\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Lines", "IReadOnlyList<DiffLine>", "Array.Empty<DiffLine>()", "Configures component behavior or styling."),
                new ComponentParameterDoc("OldCode", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("NewCode", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("AllowCopy", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwSnippet",
            Category = "Code & Syntax Studio",
            Description = "macOS terminal CLI command snippet container with prompt badges, window controls, and one-click copy transition.",
            RazorSnippet = "<TwSnippet Code=\"\" Prefix=\"$\" ShowHeader=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Code", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Prefix", "string", "\"$\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Title", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("ShowHeader", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowWindowControls", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowCopyButton", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwCodeBlock",
            Category = "Code & Syntax Studio",
            Description = "Syntax code viewer with language badges, line numbers, and copy-to-clipboard button.",
            RazorSnippet = "<TwCodeBlock Code=\"string.Empty\" Language=\"razor\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Code", "string", "string.Empty", "Configures component behavior or styling."),
                new ComponentParameterDoc("Language", "string?", "\"razor\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("FileName", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwFilterBuilder",
            Category = "Advanced Forms & Inputs",
            Description = "Visual query and filter builder supporting nested boolean AND/OR criteria trees, comparison operators, typed values, and LINQ/SQL predicate generation.",
            RazorSnippet = "<TwFilterBuilder Title=\"Visual Query & Filter Builder\" RootGroup=\"new()\" AvailableFields=\"new()\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"Visual Query & Filter Builder\"", "Header title or accessible label."),
                new ComponentParameterDoc("RootGroup", "FilterGroup", "new()", "Configures component behavior or styling."),
                new ComponentParameterDoc("AvailableFields", "List<FieldDefinition>", "new()", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowPreview", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnFilterChanged", "EventCallback<FilterGroup>", "null", "Callback invoked when state changes or item is selected."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwDropzone",
            Category = "Advanced Forms & Inputs",
            Description = "Enterprise multi-file drag-and-drop ingestion zone with animated focus border, file extension badges, individual upload progress bars, and queue management.",
            RazorSnippet = "<TwDropzone AllowMultiple=\"true\" AcceptedExtensions=\".png, .jpg, .pdf, .zip, .cs, .json\" MaxFileSizeMb=\"25\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("AllowMultiple", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("AcceptedExtensions", "string", "\".png, .jpg, .pdf, .zip, .cs, .json\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("MaxFileSizeMb", "int", "25", "Component sizing scale (Xs, Sm, Md, Lg)."),
                new ComponentParameterDoc("Files", "List<DropzoneFile>", "new()", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("FilesChanged", "EventCallback<List<DropzoneFile>>", "null", "Callback invoked when state changes or item is selected."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwOtpInput",
            Category = "Advanced Forms & Inputs",
            Description = "Segmented 6-digit one-time password / PIN verification input with auto-advance, backspace navigation, mobile numeric keypad, paste support, and dot masking.",
            RazorSnippet = "<TwOtpInput Length=\"6\" Value=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Length", "int", "6", "Configures component behavior or styling."),
                new ComponentParameterDoc("Value", "string", "\"\"", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("ValueChanged", "EventCallback<string>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("OnCompleted", "EventCallback<string>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Masked", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Disabled", "bool", "null", "Disables user interaction and applies muted opacity styling."),
                new ComponentParameterDoc("HasError", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ErrorMessage", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Label", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("HelperText", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwPasswordStrength",
            Category = "Advanced Forms & Inputs",
            Description = "Interactive password input with toggleable eye visibility, 4-stage color-coded entropy bar (Weak, Fair, Good, Strong), and real-time live requirements checklist.",
            RazorSnippet = "<TwPasswordStrength Value=\"\" Label=\"Password\" Placeholder=\"Enter a secure password...\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Value", "string", "\"\"", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("ValueChanged", "EventCallback<string>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Label", "string", "\"Password\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Placeholder", "string", "\"Enter a secure password...\"", "Input placeholder hint."),
                new ComponentParameterDoc("ShowChecklist", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Disabled", "bool", "null", "Disables user interaction and applies muted opacity styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwCombobox",
            Category = "Advanced Forms & Inputs",
            Description = "Searchable autocomplete dropdown with real-time filtering, keyboard arrow navigation, enter-to-select, clear button, and empty filter fallback.",
            RazorSnippet = "<TwCombobox Value=\"\" Items=\"Array.Empty<ComboboxItem>()\" Label=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Value", "string", "\"\"", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("ValueChanged", "EventCallback<string>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Items", "IReadOnlyList<ComboboxItem>", "Array.Empty<ComboboxItem>()", "Configures component behavior or styling."),
                new ComponentParameterDoc("Label", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Placeholder", "string", "\"Select or search option...\"", "Input placeholder hint."),
                new ComponentParameterDoc("Disabled", "bool", "null", "Disables user interaction and applies muted opacity styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwTagsInput",
            Category = "Advanced Forms & Inputs",
            Description = "Interactive token tag creator that adds chips on Enter/Comma, supports backspace removal, removable badge pills, and max tags limit.",
            RazorSnippet = "<TwTagsInput Tags=\"new()\" Label=\"\" Placeholder=\"Type tag and press Enter...\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Tags", "List<string>", "new()", "Configures component behavior or styling."),
                new ComponentParameterDoc("TagsChanged", "EventCallback<List<string>>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Label", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Placeholder", "string", "\"Type tag and press Enter...\"", "Input placeholder hint."),
                new ComponentParameterDoc("HelperText", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("MaxTags", "int?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("AllowDuplicates", "bool", "false", "Configures component behavior or styling."),
                new ComponentParameterDoc("Disabled", "bool", "null", "Disables user interaction and applies muted opacity styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwInputGroup",
            Category = "Advanced Forms & Inputs",
            Description = "Composite input field with seamless prepended and appended text, icon slots, and dropdown buttons (currency, protocol, domain).",
            RazorSnippet = "<TwInputGroup Value=\"\" Label=\"\" Type=\"text\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Value", "string", "\"\"", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("ValueChanged", "EventCallback<string>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Label", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Type", "string", "\"text\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Placeholder", "string", "\"\"", "Input placeholder hint."),
                new ComponentParameterDoc("PrependText", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("AppendText", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("PrependContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("AppendContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("HelperText", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ErrorMessage", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("HasError", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Disabled", "bool", "null", "Disables user interaction and applies muted opacity styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwPill",
            Category = "Typography, Badges & Keys",
            Description = "Modern pill badge supporting glowing pulse dots, mini avatars, counter badges, dismissible close buttons, and semantic variants (Soft, Solid, Outline, Glow).",
            RazorSnippet = "<TwPill Variant=\"Soft\" Color=\"Brand\" Size=\"md\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Text", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Variant", "string", "\"Soft\"", "Semantic visual variant (e.g. Primary, Secondary, Outline)."),
                new ComponentParameterDoc("Color", "string", "\"Brand\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Size", "string", "\"md\"", "Component sizing scale (Xs, Sm, Md, Lg)."),
                new ComponentParameterDoc("ShowDot", "bool", "false", "Configures component behavior or styling."),
                new ComponentParameterDoc("PulseDot", "bool", "false", "Configures component behavior or styling."),
                new ComponentParameterDoc("AvatarUrl", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Icon", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Count", "int?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Removable", "bool", "false", "Configures component behavior or styling."),
                new ComponentParameterDoc("Clickable", "bool", "false", "Configures component behavior or styling."),
                new ComponentParameterDoc("Selected", "bool", "false", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnClick", "EventCallback", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("OnDismiss", "EventCallback", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwPillGroup",
            Category = "Typography, Badges & Keys",
            Description = "Segmented pill filter collection for single or multi-select filtering with smooth active transitions.",
            RazorSnippet = "<TwPillGroup Items=\"new()\" SelectedValues=\"new()\" CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Items", "List<PillItem>", "new()", "Configures component behavior or styling."),
                new ComponentParameterDoc("SelectedValues", "List<string>", "new()", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("SelectedValuesChanged", "EventCallback<List<string>>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("MultiSelect", "bool", "false", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwBadge",
            Category = "Typography, Badges & Keys",
            Description = "Status and counter badge supporting semantic colors (Primary, Success, Warning, Danger, Info), rounded pill styling, and optional pulsing status dots.",
            RazorSnippet = "<TwBadge Variant=\"SemanticVariant.Default\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Variant", "SemanticVariant", "SemanticVariant.Default", "Semantic visual variant (e.g. Primary, Secondary, Outline)."),
                new ComponentParameterDoc("ShowDot", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwNotificationBadge",
            Category = "Typography, Badges & Keys",
            Description = "Floating count badge designed to overlay icons or avatars for unread alerts and incoming message counters.",
            RazorSnippet = "<TwNotificationBadge Visible=\"true\" MaxCount=\"99\" Variant=\"SemanticVariant.Danger\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Visible", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("DotOnly", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowPing", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Count", "int", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("MaxCount", "int", "99", "Configures component behavior or styling."),
                new ComponentParameterDoc("Variant", "SemanticVariant", "SemanticVariant.Danger", "Semantic visual variant (e.g. Primary, Secondary, Outline)."),
                new ComponentParameterDoc("Placement", "BadgePlacement", "BadgePlacement.TopRight", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwChip",
            Category = "Typography, Badges & Keys",
            Description = "Interactive tag chip with optional leading icon, selectable toggle state, and dismissible close button.",
            RazorSnippet = "<TwChip Variant=\"SemanticVariant.Default\" Size=\"ComponentSize.Sm\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Text", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("LeadingIcon", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("AvatarContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Variant", "SemanticVariant", "SemanticVariant.Default", "Semantic visual variant (e.g. Primary, Secondary, Outline)."),
                new ComponentParameterDoc("Size", "ComponentSize", "ComponentSize.Sm", "Component sizing scale (Xs, Sm, Md, Lg)."),
                new ComponentParameterDoc("Outlined", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Selectable", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Selected", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("SelectedChanged", "EventCallback<bool>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Removable", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnRemove", "EventCallback", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnClick", "EventCallback", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwChipGroup",
            Category = "Typography, Badges & Keys",
            Description = "Container for managing groups of filter chips with single-select or multi-select modes.",
            RazorSnippet = "<TwChipGroup>\n    <span>Content</span>\n</TwChipGroup>",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwKbd",
            Category = "Typography, Badges & Keys",
            Description = "3D-embossed tactile keyboard shortcut badge with automatic modifier symbol mapping (⌘, ⌥, ⇧, ⌃, ↵, ⎋, ←, →).",
            RazorSnippet = "<TwKbd Size=\"md\" Variant=\"default\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Key", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Size", "string", "\"md\"", "Component sizing scale (Xs, Sm, Md, Lg)."),
                new ComponentParameterDoc("Variant", "string", "\"default\"", "Semantic visual variant (e.g. Primary, Secondary, Outline)."),
                new ComponentParameterDoc("Tooltip", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwDivider",
            Category = "Typography, Badges & Keys",
            Description = "Subtle horizontal or vertical divider with optional centered text or icon badge.",
            RazorSnippet = "<TwDivider>\n    <span>Content</span>\n</TwDivider>",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Text", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwDateRangePicker",
            Category = "Buttons, Forms & Controls",
            Description = "Dual-month calendar popover with quick range presets (Today, 7 Days, 30 Days, This Month, YTD), continuous selection range highlighting, and manual date input.",
            RazorSnippet = "<TwDateRangePicker Label=\"Date Range Selection\" StartDate=\"DateTime.Today.AddDays(-14)\" EndDate=\"DateTime.Today\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Label", "string?", "\"Date Range Selection\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("StartDate", "DateTime", "DateTime.Today.AddDays(-14)", "Configures component behavior or styling."),
                new ComponentParameterDoc("EndDate", "DateTime", "DateTime.Today", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwButton",
            Category = "Buttons, Forms & Controls",
            Description = "Tactile interactive button featuring 44px touch targets, loading spinner state, semantic variants, and mobile full-width responsive expansion.",
            RazorSnippet = "<TwButton Variant=\"ButtonVariant.Primary\" Size=\"ComponentSize.Md\" Type=\"button\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("LeadingIcon", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("TrailingIcon", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Variant", "ButtonVariant", "ButtonVariant.Primary", "Semantic visual variant (e.g. Primary, Secondary, Outline)."),
                new ComponentParameterDoc("Size", "ComponentSize", "ComponentSize.Md", "Component sizing scale (Xs, Sm, Md, Lg)."),
                new ComponentParameterDoc("Type", "string", "\"button\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Disabled", "bool", "null", "Disables user interaction and applies muted opacity styling."),
                new ComponentParameterDoc("Loading", "bool", "null", "Displays animated loading spinner indicator."),
                new ComponentParameterDoc("ResponsiveFullWidth", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("FullWidth", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
                new ComponentParameterDoc("OnClick", "EventCallback<MouseEventArgs>", "null", "Callback invoked when state changes or item is selected."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwInput",
            Category = "Buttons, Forms & Controls",
            Description = "Accessible text input with validation error states, helper text slots, leading/trailing icons, and clear button.",
            RazorSnippet = "<TwInput Type=\"text\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Label", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Value", "string?", "null", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("ValueChanged", "EventCallback<string?>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Placeholder", "string?", "null", "Input placeholder hint."),
                new ComponentParameterDoc("Type", "string", "\"text\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("HelperText", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ErrorText", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Required", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Disabled", "bool", "null", "Disables user interaction and applies muted opacity styling."),
                new ComponentParameterDoc("PrefixContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("SuffixContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwSelect",
            Category = "Buttons, Forms & Controls",
            Description = "Styled select dropdown with floating labels, option groups, and dark mode contrast.",
            RazorSnippet = "<TwSelect>\n    <span>Content</span>\n</TwSelect>",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Label", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Value", "string?", "null", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("ValueChanged", "EventCallback<string?>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("HelperText", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Disabled", "bool", "null", "Disables user interaction and applies muted opacity styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwSwitch",
            Category = "Buttons, Forms & Controls",
            Description = "Accessible toggle switch with smooth spring transitions and screen-reader label binding.",
            RazorSnippet = "<TwSwitch />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Checked", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("CheckedChanged", "EventCallback<bool>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Label", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Description", "string?", "null", "Secondary descriptive caption."),
                new ComponentParameterDoc("Disabled", "bool", "null", "Disables user interaction and applies muted opacity styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwCheckbox",
            Category = "Buttons, Forms & Controls",
            Description = "Touch-friendly checkbox with animated checkmark and focus ring styling.",
            RazorSnippet = "<TwCheckbox />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Checked", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("CheckedChanged", "EventCallback<bool>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Label", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Description", "string?", "null", "Secondary descriptive caption."),
                new ComponentParameterDoc("Disabled", "bool", "null", "Disables user interaction and applies muted opacity styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwSlider",
            Category = "Buttons, Forms & Controls",
            Description = "Touch-friendly range slider with draggable thumb, track fill, and live value bubble readout.",
            RazorSnippet = "<TwSlider Value=\"50\" Min=\"0\" Max=\"100\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Value", "double", "50", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("ValueChanged", "EventCallback<double>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Min", "double", "0", "Configures component behavior or styling."),
                new ComponentParameterDoc("Max", "double", "100", "Configures component behavior or styling."),
                new ComponentParameterDoc("Step", "double", "1", "Configures component behavior or styling."),
                new ComponentParameterDoc("Label", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ValueUnit", "string?", "\"%\"", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("ShowValue", "bool", "true", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("Disabled", "bool", "null", "Disables user interaction and applies muted opacity styling."),
                new ComponentParameterDoc("HelperText", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwNumeric",
            Category = "Buttons, Forms & Controls",
            Description = "Precise numeric stepper input with increment/decrement buttons, min/max clamping, and step intervals.",
            RazorSnippet = "<TwNumeric Min=\"0\" Max=\"100\" Step=\"1\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Value", "double", "null", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("ValueChanged", "EventCallback<double>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Label", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("HelperText", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Prefix", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Suffix", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Min", "double", "0", "Configures component behavior or styling."),
                new ComponentParameterDoc("Max", "double", "100", "Configures component behavior or styling."),
                new ComponentParameterDoc("Step", "double", "1", "Configures component behavior or styling."),
                new ComponentParameterDoc("Required", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwDatePicker",
            Category = "Buttons, Forms & Controls",
            Description = "Accessible date picker with calendar popover, quick range presets, and international date formatting.",
            RazorSnippet = "<TwDatePicker Placeholder=\"Select date...\" DateFormat=\"MMM dd, yyyy\" AllowClear=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Value", "DateTime?", "null", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("ValueChanged", "EventCallback<DateTime?>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Label", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Placeholder", "string", "\"Select date...\"", "Input placeholder hint."),
                new ComponentParameterDoc("DateFormat", "string", "\"MMM dd, yyyy\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("AllowClear", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Required", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwFileUpload",
            Category = "Buttons, Forms & Controls",
            Description = "Drag-and-drop file upload zone with file size validation, mime type filtering, and upload progress visualization.",
            RazorSnippet = "<TwFileUpload Label=\"Upload Documents or Media\" Multiple=\"true\" Accept=\".png,.jpg,.jpeg,.svg,.pdf,.zip\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Label", "string?", "\"Upload Documents or Media\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("HelperText", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Required", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Multiple", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Accept", "string", "\".png,.jpg,.jpeg,.svg,.pdf,.zip\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("MaxFileSize", "long", "10 * 1024 * 1024", "Component sizing scale (Xs, Sm, Md, Lg)."),
                new ComponentParameterDoc("FilesChanged", "EventCallback<IReadOnlyList<IBrowserFile>>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwSegmented",
            Category = "Buttons, Forms & Controls",
            Description = "iOS-style segmented control pill for switching between mutually exclusive views with sliding background highlight.",
            RazorSnippet = "<TwSegmented Items=\"Array.Empty<SegmentItem>()\" Value=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Items", "IReadOnlyList<SegmentItem>", "Array.Empty<SegmentItem>()", "Configures component behavior or styling."),
                new ComponentParameterDoc("Value", "string", "\"\"", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("ValueChanged", "EventCallback<string>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("FullWidth", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwRating",
            Category = "Buttons, Forms & Controls",
            Description = "Interactive star rating component supporting full and half-star ratings with hover preview and read-only display mode.",
            RazorSnippet = "<TwRating Value=\"4\" MaxStars=\"5\" ShowValueText=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Value", "int", "4", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("ValueChanged", "EventCallback<int>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("MaxStars", "int", "5", "Configures component behavior or styling."),
                new ComponentParameterDoc("ReadOnly", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowValueText", "bool", "true", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwCard",
            Category = "Cards, Grids & Bento Systems",
            Description = "Modular card container with header, body, and footer slots, subtle hover lift, and glassmorphic borders.",
            RazorSnippet = "<TwCard>\n    <span>Content</span>\n</TwCard>",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("Subtitle", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("Hoverable", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("NoPadding", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("HeaderContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("FooterContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwBentoGrid",
            Category = "Cards, Grids & Bento Systems",
            Description = "Modern asymmetrical CSS grid for showcasing features with radial mouse-following spotlight gradients.",
            RazorSnippet = "<TwBentoGrid Cols=\"3\" GapClass=\"gap-4 sm:gap-6\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Cols", "int", "3", "Configures component behavior or styling."),
                new ComponentParameterDoc("GapClass", "string", "\"gap-4 sm:gap-6\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwBentoCard",
            Category = "Cards, Grids & Bento Systems",
            Description = "Card item for Bento grids with customizable column/row spans, glowing borders, and feature badge slots.",
            RazorSnippet = "<TwBentoCard ColSpan=\"1\" RowSpan=\"1\" ShowDotPattern=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("ColSpan", "int", "1", "Configures component behavior or styling."),
                new ComponentParameterDoc("RowSpan", "int", "1", "Configures component behavior or styling."),
                new ComponentParameterDoc("Title", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("Description", "string?", "null", "Secondary descriptive caption."),
                new ComponentParameterDoc("Icon", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Badge", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Footer", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowDotPattern", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("SpotlightColor", "string", "\"rgba(99, 102, 241, 0.12)\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwStatCard",
            Category = "Cards, Grids & Bento Systems",
            Description = "SaaS metric KPI card with sparklines, percentage change indicators, and target progress bars.",
            RazorSnippet = "<TwStatCard Title=\"\" Value=\"\" IsTrendPositive=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"\"", "Header title or accessible label."),
                new ComponentParameterDoc("Value", "string", "\"\"", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("Subtitle", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("TrendText", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("IsTrendPositive", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("ProgressValue", "int?", "null", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("IconContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("IconBgClass", "string", "\"bg-brand-50 dark:bg-brand-500/10\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwKpiMetric",
            Category = "Cards, Grids & Bento Systems",
            Description = "Compact micro-metric card with live animated count-up and cubic ease-out transitions.",
            RazorSnippet = "<TwKpiMetric Title=\"string.Empty\" Value=\"string.Empty\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "string.Empty", "Header title or accessible label."),
                new ComponentParameterDoc("Value", "string", "string.Empty", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("Subtitle", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("ChangePercentage", "double?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("SparklineData", "IReadOnlyList<double>?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Color", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwMediaCard",
            Category = "Cards, Grids & Bento Systems",
            Description = "Rich media card with 16:9 aspect ratio image header, category badges, author avatar, and reading time.",
            RazorSnippet = "<TwMediaCard Title=\"\" ImageAlt=\"Media cover\" AuthorInitials=\"AM\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"\"", "Header title or accessible label."),
                new ComponentParameterDoc("Description", "string?", "null", "Secondary descriptive caption."),
                new ComponentParameterDoc("ImageUrl", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ImageAlt", "string", "\"Media cover\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("CategoryBadge", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("AuthorName", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("AuthorInitials", "string", "\"AM\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("DateText", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Tags", "IReadOnlyList<string>?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ActionContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnClick", "EventCallback<MouseEventArgs>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwFeatureCard",
            Category = "Cards, Grids & Bento Systems",
            Description = "Service feature card with gradient background icon, bold headline, and subtle hover scale.",
            RazorSnippet = "<TwFeatureCard Title=\"\" Description=\"\" LinkText=\"Explore feature\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"\"", "Header title or accessible label."),
                new ComponentParameterDoc("Description", "string", "\"\"", "Secondary descriptive caption."),
                new ComponentParameterDoc("BadgeText", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("LinkText", "string?", "\"Explore feature\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("IconGradientClass", "string", "\"bg-gradient-to-tr from-brand-600 to-indigo-500\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("IconContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnClick", "EventCallback<MouseEventArgs>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwSpotlightCard",
            Category = "Cards, Grids & Bento Systems",
            Description = "Interactive card that calculates cursor coordinates to project a dynamic radial spotlight beam across its surface.",
            RazorSnippet = "<TwSpotlightCard SpotlightColor=\"rgba(99, 102, 241, 0.15)\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("SpotlightColor", "string", "\"rgba(99, 102, 241, 0.15)\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwPricingCard",
            Category = "Cards, Grids & Bento Systems",
            Description = "SaaS subscription pricing tier card with popular badge highlight, price per interval, and feature checklist.",
            RazorSnippet = "<TwPricingCard PlanName=\"Pro\" Price=\"$29\" Interval=\"mo\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("PlanName", "string", "\"Pro\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Description", "string?", "null", "Secondary descriptive caption."),
                new ComponentParameterDoc("Price", "string", "\"$29\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Interval", "string", "\"mo\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("IsPopular", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Features", "IReadOnlyList<string>?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("CtaText", "string", "\"Get Started\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnClick", "EventCallback<MouseEventArgs>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwPricingTable",
            Category = "Cards, Grids & Bento Systems",
            Description = "Full billing cycle matrix comparing Free, Pro, and Enterprise tiers with monthly/annual toggle.",
            RazorSnippet = "<TwPricingTable Tiers=\"new()\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Tiers", "List<PricingTier>", "new()", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnSelectTier", "EventCallback<PricingTier>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwKanbanBoard",
            Category = "Enterprise Data & Tables",
            Description = "Interactive workflow Kanban board with customizable columns, WIP limit thresholds, task cards, priority indicators, subtask checklists, and lane transition buttons.",
            RazorSnippet = "<TwKanbanBoard Title=\"Sprint Workflow Kanban\" Columns=\"new()\" CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"Sprint Workflow Kanban\"", "Header title or accessible label."),
                new ComponentParameterDoc("Columns", "List<KanbanColumn>", "new()", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnCardMoved", "EventCallback<KanbanCard>", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwDataGrid",
            Category = "Enterprise Data & Tables",
            Description = "High-performance enterprise data grid with column sorting, per-column text filters, column width constraints, pagination, and row-level record actions.",
            RazorSnippet = "<TwDataGrid Items=\"Enumerable.Empty<TItem>()\" ActionsTitle=\"Actions\" EmptyText=\"No records found matching your criteria.\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Items", "IEnumerable<TItem>", "Enumerable.Empty<TItem>()", "Configures component behavior or styling."),
                new ComponentParameterDoc("Columns", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ActionsTemplate", "RenderFragment<TItem>?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("MobileCardTemplate", "RenderFragment<TItem>?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("BatchActionsTemplate", "RenderFragment<IReadOnlyList<TItem>>?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ActionsTitle", "string", "\"Actions\"", "Header title or accessible label."),
                new ComponentParameterDoc("EmptyText", "string", "\"No records found matching your criteria.\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Selectable", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowGlobalSearch", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("SearchPlaceholder", "string", "\"Search all records...\"", "Input placeholder hint."),
                new ComponentParameterDoc("SearchPredicate", "Func<TItem, string, bool>?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("AllowColumnFiltering", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowPagination", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("PageSize", "int", "5", "Component sizing scale (Xs, Sm, Md, Lg)."),
                new ComponentParameterDoc("ShowPageSizeSelector", "bool", "true", "Component sizing scale (Xs, Sm, Md, Lg)."),
                new ComponentParameterDoc("CurrentPage", "int", "1", "Configures component behavior or styling."),
                new ComponentParameterDoc("CurrentPageChanged", "EventCallback<int>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("SelectionChanged", "EventCallback<IReadOnlyList<TItem>>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwDataGridColumn",
            Category = "Enterprise Data & Tables",
            Description = "Declarative column definition for TwDataGrid specifying field binding, title, sortable flag, and custom cell templates.",
            RazorSnippet = "<TwDataGridColumn Title=\"\" Sortable=\"true\" Filterable=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"\"", "Header title or accessible label."),
                new ComponentParameterDoc("Property", "Func<TItem, object?>?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("SortBy", "Func<TItem, object?>?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Sortable", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Filterable", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("FilterPlaceholder", "string?", "null", "Input placeholder hint."),
                new ComponentParameterDoc("Width", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("MinWidth", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("MaxWidth", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Align", "string", "\"left\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("CellTemplate", "RenderFragment<TItem>?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("HeaderTemplate", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("FilterTemplate", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("HeaderClass", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("CellClass", "string?", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwDataTable",
            Category = "Enterprise Data & Tables",
            Description = "Generic table component that automatically transforms into touch-friendly stacked cards on mobile screens.",
            RazorSnippet = "<TwDataTable Items=\"Array.Empty<TItem>()\" RowTemplate=\"default!\" EmptyText=\"No records found\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Items", "IReadOnlyList<TItem>", "Array.Empty<TItem>()", "Configures component behavior or styling."),
                new ComponentParameterDoc("TableHeader", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("RowTemplate", "RenderFragment<TItem>", "default!", "Configures component behavior or styling."),
                new ComponentParameterDoc("MobileTemplate", "RenderFragment<TItem>?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("EmptyText", "string", "\"No records found\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwPagination",
            Category = "Enterprise Data & Tables",
            Description = "Responsive pagination control showing Prev/Next on mobile devices and numbered page pills on desktop.",
            RazorSnippet = "<TwPagination CurrentPage=\"1\" TotalPages=\"1\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("CurrentPage", "int", "1", "Configures component behavior or styling."),
                new ComponentParameterDoc("TotalPages", "int", "1", "Configures component behavior or styling."),
                new ComponentParameterDoc("CurrentPageChanged", "EventCallback<int>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwTree",
            Category = "Enterprise Data & Tables",
            Description = "Hierarchical tree view component with expandable/collapsible nodes and selection tracking.",
            RazorSnippet = "<TwTree>\n    <span>Content</span>\n</TwTree>",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("SelectedId", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("SelectedIdChanged", "EventCallback<string>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwTreeItem",
            Category = "Enterprise Data & Tables",
            Description = "Individual node item inside TwTree with custom icons and nested child rendering.",
            RazorSnippet = "<TwTreeItem Id=\"Guid.NewGuid().ToString(N)\" Text=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Id", "string", "Guid.NewGuid().ToString(\"N\")", "Configures component behavior or styling."),
                new ComponentParameterDoc("Text", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Badge", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("InitiallyExpanded", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("IconContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwSparkline",
            Category = "Visualizations & Gauges",
            Description = "Zero-dependency pure C# inline SVG micro-chart engine supporting Line, Area, Bar, and Win/Loss modes for table cells and executive KPI widgets.",
            RazorSnippet = "<TwSparkline Type=\"SparklineType.Line\" Points=\"new() { 12, 18, 14, 22, 19, 28, 25, 34, 30, 42 }\" Width=\"110\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Type", "SparklineType", "SparklineType.Line", "Configures component behavior or styling."),
                new ComponentParameterDoc("Points", "List<double>", "new() { 12, 18, 14, 22, 19, 28, 25, 34, 30, 42 }", "Configures component behavior or styling."),
                new ComponentParameterDoc("Width", "int", "110", "Configures component behavior or styling."),
                new ComponentParameterDoc("Height", "int", "28", "Configures component behavior or styling."),
                new ComponentParameterDoc("StrokeWidth", "double", "2.0", "Configures component behavior or styling."),
                new ComponentParameterDoc("Color", "string", "\"brand\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowMinMaxDots", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowValueBadge", "bool", "false", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwProgressAdvanced",
            Category = "Visualizations & Gauges",
            Description = "Advanced enterprise progress visualization supporting 5 styles: Multi-segment stacked bar with tooltips, SVG circular radial ring, flowing striped animated bar, discrete LED audio-meter bar, and milestone step tracker.",
            RazorSnippet = "<TwProgressAdvanced Type=\"ProgressType.Stacked\" Value=\"65\" ShowHeader=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Type", "ProgressType", "ProgressType.Stacked", "Configures component behavior or styling."),
                new ComponentParameterDoc("Title", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("Label", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Value", "double", "65", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("ShowHeader", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowLegend", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Color", "string", "\"brand\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Segments", "List<ProgressSegment>", "new()\n    {\n        new ProgressSegment { Label = \"Code & Engine\", Percentage = 42, ColorClass = \"bg-brand-500\" },\n        new ProgressSegment { Label = \"Assets & Icons\", Percentage = 28, ColorClass = \"bg-emerald-500\" },\n        new ProgressSegment { Label = \"Cached Data\", Percentage = 18, ColorClass = \"bg-amber-500\" },\n        new ProgressSegment { Label = \"Free Memory\", Percentage = 12, ColorClass = \"bg-slate-300 dark:bg-slate-700\" }\n    }", "Configures component behavior or styling."),
                new ComponentParameterDoc("RadialSize", "int", "100", "Component sizing scale (Xs, Sm, Md, Lg)."),
                new ComponentParameterDoc("RadialStrokeWidth", "int", "8", "Configures component behavior or styling."),
                new ComponentParameterDoc("RadialContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("TotalSegments", "int", "15", "Configures component behavior or styling."),
                new ComponentParameterDoc("Steps", "List<string>", "new() { \"Initialize\", \"Validate\", \"Compile\", \"Deploy\" }", "Configures component behavior or styling."),
                new ComponentParameterDoc("CurrentStep", "int", "2", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwChart",
            Category = "Visualizations & Gauges",
            Description = "Native C# inline SVG visualization engine for donut charts, sparklines, and bar charts with zero external JS dependencies.",
            RazorSnippet = "<TwChart Type=\"ChartType.Donut\" CenterValue=\"100%\" CenterLabel=\"Total\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Type", "ChartType", "ChartType.Donut", "Configures component behavior or styling."),
                new ComponentParameterDoc("Title", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("Subtitle", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("CenterValue", "string", "\"100%\"", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("CenterLabel", "string", "\"Total\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("DataItems", "IReadOnlyList<ChartDataItem>", "Array.Empty<ChartDataItem>()", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwGauge",
            Category = "Visualizations & Gauges",
            Description = "Zero-JS radial speedometer gauge rendering pure inline SVG arcs with stroke-dasharray calculations and CSS transitions.",
            RazorSnippet = "<TwGauge Value=\"72\" Min=\"0\" Max=\"100\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Value", "double", "72", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("Min", "double", "0", "Configures component behavior or styling."),
                new ComponentParameterDoc("Max", "double", "100", "Configures component behavior or styling."),
                new ComponentParameterDoc("Unit", "string", "\"%\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Label", "string?", "\"Efficiency\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Sublabel", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Color", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwProgressBar",
            Category = "Visualizations & Gauges",
            Description = "Semantic progress bar with animated stripes, smooth transitions, and percentage labels.",
            RazorSnippet = "<TwProgressBar ShowLabel=\"true\" Variant=\"SemanticVariant.Primary\" Size=\"ComponentSize.Md\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Value", "int", "null", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("Label", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowLabel", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Animated", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Variant", "SemanticVariant", "SemanticVariant.Primary", "Semantic visual variant (e.g. Primary, Secondary, Outline)."),
                new ComponentParameterDoc("Size", "ComponentSize", "ComponentSize.Md", "Component sizing scale (Xs, Sm, Md, Lg)."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwCountUp",
            Category = "Visualizations & Gauges",
            Description = "Smooth numeric counter animation with customizable duration, prefix/suffix, and easing.",
            RazorSnippet = "<TwCountUp StartValue=\"0\" EndValue=\"100\" DurationMs=\"1200\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("StartValue", "double", "0", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("EndValue", "double", "100", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("DurationMs", "int", "1200", "Configures component behavior or styling."),
                new ComponentParameterDoc("Decimals", "int", "0", "Configures component behavior or styling."),
                new ComponentParameterDoc("Prefix", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Suffix", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("AutoStart", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwAnimate",
            Category = "Visualizations & Gauges",
            Description = "Declarative CSS animation wrapper providing fade, zoom, bounce, and slide keyframes.",
            RazorSnippet = "<TwAnimate Type=\"AnimationType.FadeInUp\" DurationMs=\"400\" DelayMs=\"0\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Type", "AnimationType", "AnimationType.FadeInUp", "Configures component behavior or styling."),
                new ComponentParameterDoc("DurationMs", "int", "400", "Configures component behavior or styling."),
                new ComponentParameterDoc("DelayMs", "int", "0", "Configures component behavior or styling."),
                new ComponentParameterDoc("Infinite", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnHover", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Play", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwTransition",
            Category = "Visualizations & Gauges",
            Description = "Smooth enter/leave transition container for mounting and unmounting Blazor components.",
            RazorSnippet = "<TwTransition Show=\"true\" Enter=\"transition duration-300 ease-out\" EnterFrom=\"opacity-0 scale-95 -translate-y-2\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Show", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Enter", "string", "\"transition duration-300 ease-out\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("EnterFrom", "string", "\"opacity-0 scale-95 -translate-y-2\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("EnterTo", "string", "\"opacity-100 scale-100 translate-y-0\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Leave", "string", "\"transition duration-200 ease-in\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("LeaveFrom", "string", "\"opacity-100 scale-100 translate-y-0\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("LeaveTo", "string", "\"opacity-0 scale-95 -translate-y-2\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
                new ComponentParameterDoc("Style", "string?", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwMediaPlayer",
            Category = "Media, Scanner & Signature",
            Description = "Custom video and audio player with chapter markers, scrubber seek, playback speed selector (0.5x - 2x), Picture-in-Picture, volume control, and audio visualizer.",
            RazorSnippet = "<TwMediaPlayer Src=\"string.Empty\" Type=\"MediaKind.Video\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Src", "string", "string.Empty", "Configures component behavior or styling."),
                new ComponentParameterDoc("Poster", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Title", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("Subtitle", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("Type", "MediaKind", "MediaKind.Video", "Configures component behavior or styling."),
                new ComponentParameterDoc("Loop", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Chapters", "List<MediaChapter>?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwQrCode",
            Category = "Media, Scanner & Signature",
            Description = "Vector SVG and PNG QR code generator supporting custom dot shapes (Square, Rounded, Circle), error correction levels, and center icon branding.",
            RazorSnippet = "<TwQrCode Value=\"https://tailwindcss.com\" Size=\"200\" ForegroundColor=\"#0f172a\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Value", "string", "\"https://tailwindcss.com\"", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("Title", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("Subtitle", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("Size", "int", "200", "Component sizing scale (Xs, Sm, Md, Lg)."),
                new ComponentParameterDoc("ForegroundColor", "string", "\"#0f172a\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("BackgroundColor", "string", "\"#ffffff\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("DotShape", "QrDotShape", "QrDotShape.Rounded", "Configures component behavior or styling."),
                new ComponentParameterDoc("CenterIcon", "QrCenterIcon", "QrCenterIcon.None", "Configures component behavior or styling."),
                new ComponentParameterDoc("EccLevel", "QrEccLevel", "QrEccLevel.Q", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowActions", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwBarcode",
            Category = "Media, Scanner & Signature",
            Description = "High-density Code 128 1D vector barcode generator rendering sharp scalable SVG bars with human-readable text.",
            RazorSnippet = "<TwBarcode Value=\"SKU-984210\" BarHeight=\"64\" BarWidthMultiplier=\"2\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Value", "string", "\"SKU-984210\"", "Primary data value or two-way bound model property."),
                new ComponentParameterDoc("Title", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("Subtitle", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("BarHeight", "int", "64", "Configures component behavior or styling."),
                new ComponentParameterDoc("BarWidthMultiplier", "int", "2", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowText", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("QuietZone", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("ForegroundColor", "string", "\"#0f172a\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("BackgroundColor", "string", "\"#ffffff\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowActions", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwBarcodeScanner",
            Category = "Media, Scanner & Signature",
            Description = "Live camera video and file barcode scanner supporting QR codes, Code 128, EAN, UPC, and Data Matrix with audio beep feedback.",
            RazorSnippet = "<TwBarcodeScanner />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("OnScan", "EventCallback<BarcodeScanResult>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwSignaturePad",
            Category = "Media, Scanner & Signature",
            Description = "Digital canvas signature pad with smooth Bezier curve drawing, undo/redo history, background transparency, and export to PNG and SVG.",
            RazorSnippet = "<TwSignaturePad Height=\"220\" ShowGuide=\"true\" PenColor=\"#0f172a\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("Subtitle", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("Height", "int", "220", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowGuide", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("PenColor", "string", "\"#0f172a\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("StrokeWidth", "double", "2.5", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnSave", "EventCallback<string>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwImageCompare",
            Category = "Media, Scanner & Signature",
            Description = "Interactive Before/After visual comparison slider with touch/pointer dragging, glassmorphic center handle, keyboard navigation, and dual badges.",
            RazorSnippet = "<TwImageCompare BeforeSrc=\"\" AfterSrc=\"\" BeforeAlt=\"Before image\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("BeforeSrc", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("AfterSrc", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("BeforeAlt", "string", "\"Before image\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("AfterAlt", "string", "\"After image\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("BeforeLabel", "string", "\"Before\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("AfterLabel", "string", "\"After\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Position", "double", "50.0", "Configures component behavior or styling."),
                new ComponentParameterDoc("PositionChanged", "EventCallback<double>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwRibbon",
            Category = "Navigation & Steppers",
            Description = "Award-winning enterprise Ribbon navigation bar featuring tabbed strips, Quick Access Toolbar (QAT), grouped action clusters, large/small buttons, and collapsible drawer.",
            RazorSnippet = "<TwRibbon Tabs=\"new()\" ActiveTabIndex=\"0\" CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Tabs", "List<RibbonTab>", "new()", "Configures component behavior or styling."),
                new ComponentParameterDoc("ActiveTabIndex", "int", "0", "Configures component behavior or styling."),
                new ComponentParameterDoc("IsCollapsed", "bool", "false", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnActionClicked", "EventCallback<string>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("ActiveTabIndexChanged", "EventCallback<int>", "null", "Callback invoked when state changes or item is selected."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwFloatingDock",
            Category = "Navigation & Steppers",
            Description = "Modern floating glassmorphism dock navigation bar with hover magnification scale, active pill indicators, notification badges, and smooth tooltips.",
            RazorSnippet = "<TwFloatingDock Items=\"new()\" ActiveId=\"home\" Position=\"bottom\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Items", "List<DockItem>", "new()", "Configures component behavior or styling."),
                new ComponentParameterDoc("ActiveId", "string", "\"home\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Position", "string", "\"bottom\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnItemSelected", "EventCallback<string>", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwTabs",
            Category = "Navigation & Steppers",
            Description = "Horizontal scrollable tabs with pill or underline variants and badge counters.",
            RazorSnippet = "<TwTabs Tabs=\"Array.Empty<TabDefinition>()\" Variant=\"underline\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Tabs", "IReadOnlyList<TabDefinition>", "Array.Empty<TabDefinition>()", "Configures component behavior or styling."),
                new ComponentParameterDoc("ActiveTabKey", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ActiveTabKeyChanged", "EventCallback<string>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Variant", "string", "\"underline\"", "Semantic visual variant (e.g. Primary, Secondary, Outline)."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwSlidingTabs",
            Category = "Navigation & Steppers",
            Description = "Fluid tab strip with an animated gliding background pill that follows the active selection.",
            RazorSnippet = "<TwSlidingTabs Tabs=\"new()\" ActiveTabId=\"string.Empty\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Tabs", "List<TabItem>", "new()", "Configures component behavior or styling."),
                new ComponentParameterDoc("ActiveTabId", "string", "string.Empty", "Configures component behavior or styling."),
                new ComponentParameterDoc("ActiveTabIdChanged", "EventCallback<string>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwBreadcrumb",
            Category = "Navigation & Steppers",
            Description = "Accessible breadcrumb trail with custom separators and truncated intermediate paths.",
            RazorSnippet = "<TwBreadcrumb Items=\"Array.Empty<BreadcrumbItem>()\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Items", "IReadOnlyList<BreadcrumbItem>", "Array.Empty<BreadcrumbItem>()", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwStepper",
            Category = "Navigation & Steppers",
            Description = "Multi-step onboarding wizard with completed step indicators and compact mobile layout.",
            RazorSnippet = "<TwStepper Steps=\"Array.Empty<StepItem>()\" CurrentStep=\"1\" Clickable=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Steps", "IReadOnlyList<StepItem>", "Array.Empty<StepItem>()", "Configures component behavior or styling."),
                new ComponentParameterDoc("CurrentStep", "int", "1", "Configures component behavior or styling."),
                new ComponentParameterDoc("CurrentStepChanged", "EventCallback<int>", "null", "Callback invoked when state changes or item is selected."),
                new ComponentParameterDoc("Clickable", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwTimeline",
            Category = "Navigation & Steppers",
            Description = "Vertical activity timeline container for audit logs, delivery tracking, and project milestones.",
            RazorSnippet = "<TwTimeline Position=\"TimelinePosition.Start\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Position", "TimelinePosition", "TimelinePosition.Start", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwTimelineItem",
            Category = "Navigation & Steppers",
            Description = "Individual timeline entry with status dot, icon, timestamp, and card description.",
            RazorSnippet = "<TwTimelineItem Variant=\"SemanticVariant.Primary\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("Subtitle", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("Timestamp", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Variant", "SemanticVariant", "SemanticVariant.Primary", "Semantic visual variant (e.g. Primary, Secondary, Outline)."),
                new ComponentParameterDoc("Pulse", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("IsLast", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("DotContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwScrollToTop",
            Category = "Navigation & Steppers",
            Description = "Floating smooth scroll-to-top button with scroll position threshold and mobile safe-area clearance.",
            RazorSnippet = "<TwScrollToTop Variant=\"ScrollToTopVariant.Vertical\" Label=\"TOP\" ShowProgress=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Variant", "ScrollToTopVariant", "ScrollToTopVariant.Vertical", "Semantic visual variant (e.g. Primary, Secondary, Outline)."),
                new ComponentParameterDoc("Label", "string", "\"TOP\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowProgress", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Threshold", "int", "150", "Configures component behavior or styling."),
                new ComponentParameterDoc("AlwaysVisible", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("PositionClass", "string", "\"bottom-36 sm:bottom-24 right-4 sm:right-6\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwSpeedDial",
            Category = "Navigation & Steppers",
            Description = "Floating action button that expands into a radial or vertical speed-dial menu of quick actions.",
            RazorSnippet = "<TwSpeedDial Actions=\"Array.Empty<SpeedDialAction>()\" PositionClass=\"bottom-20 sm:bottom-8 left-4 sm:left-8\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Actions", "IReadOnlyList<SpeedDialAction>", "Array.Empty<SpeedDialAction>()", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnActionSelected", "EventCallback<string>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("PositionClass", "string", "\"bottom-20 sm:bottom-8 left-4 sm:left-8\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwTour",
            Category = "Navigation & Steppers",
            Description = "Interactive guided walkthrough coaching tour with spotlight backdrop, step popovers, and automatic restart lifecycle.",
            RazorSnippet = "<TwTour Steps=\"Array.Empty<TourStep>()\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("IsOpen", "bool", "null", "Two-way bindable visibility flag."),
                new ComponentParameterDoc("IsOpenChanged", "EventCallback<bool>", "null", "Two-way bindable visibility flag."),
                new ComponentParameterDoc("Steps", "IReadOnlyList<TourStep>", "Array.Empty<TourStep>()", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnCompleted", "EventCallback", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwContextMenu",
            Category = "Overlays & Popovers",
            Description = "Desktop-grade right-click context menu and anchored flyout callout featuring nested submenus, keyboard shortcut badges, icons, and click-outside dismissal.",
            RazorSnippet = "<TwContextMenu Items=\"new()\" PreventDefaultContextMenu=\"true\" CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Items", "List<ContextMenuItem>", "new()", "Configures component behavior or styling."),
                new ComponentParameterDoc("PreventDefaultContextMenu", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnItemSelected", "EventCallback<string>", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwModal",
            Category = "Overlays & Popovers",
            Description = "Accessible dialog that presents as a bottom sheet on mobile screens and a centered modal dialog on desktop.",
            RazorSnippet = "<TwModal MaxWidth=\"md\" CloseOnBackdropClick=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("IsOpen", "bool", "null", "Two-way bindable visibility flag."),
                new ComponentParameterDoc("IsOpenChanged", "EventCallback<bool>", "null", "Two-way bindable visibility flag."),
                new ComponentParameterDoc("Title", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("Description", "string?", "null", "Secondary descriptive caption."),
                new ComponentParameterDoc("MaxWidth", "string", "\"md\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("CloseOnBackdropClick", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("HeaderContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("FooterContent", "RenderFragment?", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwDrawer",
            Category = "Overlays & Popovers",
            Description = "Off-canvas sliding drawer supporting Left, Right, and Bottom slide orientations with backdrop blur.",
            RazorSnippet = "<TwDrawer Placement=\"DrawerPlacement.Right\" Width=\"max-w-md\" CloseOnBackdropClick=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("IsOpen", "bool", "null", "Two-way bindable visibility flag."),
                new ComponentParameterDoc("IsOpenChanged", "EventCallback<bool>", "null", "Two-way bindable visibility flag."),
                new ComponentParameterDoc("Title", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("Subtitle", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("Placement", "DrawerPlacement", "DrawerPlacement.Right", "Configures component behavior or styling."),
                new ComponentParameterDoc("Width", "string", "\"max-w-md\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("CloseOnBackdropClick", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("FooterContent", "RenderFragment?", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwDropdown",
            Category = "Overlays & Popovers",
            Description = "Click-outside popover menu with keyboard navigation and position alignment (Left, Right, Center).",
            RazorSnippet = "<TwDropdown Alignment=\"right\" CloseOnSelect=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("TriggerContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Alignment", "string", "\"right\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("CloseOnSelect", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwTooltip",
            Category = "Overlays & Popovers",
            Description = "Hover and tap tooltip popover with auto-flipping placement and arrow indicator.",
            RazorSnippet = "<TwTooltip Text=\"\" Placement=\"top\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Text", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Placement", "string", "\"top\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwAccordion",
            Category = "Overlays & Popovers",
            Description = "Collapsible accordion container with single-expand or multi-expand modes.",
            RazorSnippet = "<TwAccordion>\n    <span>Content</span>\n</TwAccordion>",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("AllowMultiple", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwAccordionItem",
            Category = "Overlays & Popovers",
            Description = "Individual accordion panel with smooth height transition and animated chevron.",
            RazorSnippet = "<TwAccordionItem Title=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"\"", "Header title or accessible label."),
                new ComponentParameterDoc("InitiallyOpen", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwChatBot",
            Category = "AI Chatbot & Reasoning",
            Description = "Intelligent conversational chatbot interface with streaming message bubbles, thinking progress checklists, and code snippet copying.",
            RazorSnippet = "<TwChatBot BotName=\"NexusAI\" SelectedModel=\"Gemini 2.0 Flash\" StarterPrompts=\"new List<StarterPrompt>\n    {\n        new(Explain Architecture, Explain how mobile-first Blazor WASM and TailwindCSS work together with zero FOUC.),\n        new(Generate Code, Write a reusable C# Blazor component for animated radial progress with Tailwind classes.),\n        new(Deep Reasoning Demo, Solve a complex algorithm step-by-step with multi-stage reasoning checklist progress.),\n        new(Compare Performance, Compare Blazor WebAssembly AOT compilation vs JIT performance on mobile phones.)\n    }\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("BotName", "string", "\"NexusAI\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("SelectedModel", "string", "\"Gemini 2.0 Flash\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowCloseButton", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnClose", "EventCallback", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
                new ComponentParameterDoc("StarterPrompts", "IReadOnlyList<StarterPrompt>", "new List<StarterPrompt>\n    {\n        new(\"Explain Architecture\", \"Explain how mobile-first Blazor WASM and TailwindCSS work together with zero FOUC.\"),\n        new(\"Generate Code\", \"Write a reusable C# Blazor component for animated radial progress with Tailwind classes.\"),\n        new(\"Deep Reasoning Demo\", \"Solve a complex algorithm step-by-step with multi-stage reasoning checklist progress.\"),\n        new(\"Compare Performance\", \"Compare Blazor WebAssembly AOT compilation vs JIT performance on mobile phones.\")\n    }", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwChatWidget",
            Category = "AI Chatbot & Reasoning",
            Description = "Floating launcher button that expands into an interactive AI assistant window (or bottom sheet on mobile).",
            RazorSnippet = "<TwChatWidget BotName=\"NexusAI\" SelectedModel=\"Gemini 2.0 Flash\" PositionClass=\"bottom-20 sm:bottom-6 right-4 sm:right-6\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("BotName", "string", "\"NexusAI\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("SelectedModel", "string", "\"Gemini 2.0 Flash\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("PositionClass", "string", "\"bottom-20 sm:bottom-6 right-4 sm:right-6\"", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwAiReasoningProgress",
            Category = "AI Chatbot & Reasoning",
            Description = "Multi-phase thinking checklist component displaying animated progress indicators during AI reasoning tasks.",
            RazorSnippet = "<TwAiReasoningProgress IsThinking=\"true\" DurationSeconds=\"2.4\" ThinkingLabel=\"Reasoning step-by-step...\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("IsThinking", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("DurationSeconds", "double", "2.4", "Configures component behavior or styling."),
                new ComponentParameterDoc("ThinkingLabel", "string", "\"Reasoning step-by-step...\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("ReasoningText", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Steps", "IReadOnlyList<ReasoningStep>?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("DefaultExpanded", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwMarquee",
            Category = "Showcase & Micro-Interactions",
            Description = "Infinite continuous horizontal scrolling ticker with CSS keyframes, pause-on-hover, and edge gradient masks.",
            RazorSnippet = "<TwMarquee DurationSeconds=\"25\" PauseOnHover=\"true\" FadeEdges=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("DurationSeconds", "int", "25", "Configures component behavior or styling."),
                new ComponentParameterDoc("Reverse", "bool", "false", "Configures component behavior or styling."),
                new ComponentParameterDoc("PauseOnHover", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("FadeEdges", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
                new ComponentParameterDoc("TrackClass", "string?", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwConfetti",
            Category = "Showcase & Micro-Interactions",
            Description = "Canvas physics celebratory particle explosion system with gravity, air resistance, and 3D rotation.",
            RazorSnippet = "<TwConfetti ParticleCount=\"85\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("FullScreen", "bool", "false", "Configures component behavior or styling."),
                new ComponentParameterDoc("AutoFire", "bool", "false", "Configures component behavior or styling."),
                new ComponentParameterDoc("ParticleCount", "int", "85", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwSkeleton",
            Category = "Showcase & Micro-Interactions",
            Description = "Animated shimmer placeholder for cards, tables, text, and avatars during asynchronous data loading.",
            RazorSnippet = "<TwSkeleton Variant=\"text\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Variant", "string", "\"text\"", "Semantic visual variant (e.g. Primary, Secondary, Outline)."),
                new ComponentParameterDoc("Width", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Height", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwEmptyState",
            Category = "Showcase & Micro-Interactions",
            Description = "Illustrated zero-data state placeholder with title, description, and call-to-action button.",
            RazorSnippet = "<TwEmptyState Title=\"No items found\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"No items found\"", "Header title or accessible label."),
                new ComponentParameterDoc("Description", "string?", "null", "Secondary descriptive caption."),
                new ComponentParameterDoc("IconContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ActionContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwBanner",
            Category = "Showcase & Micro-Interactions",
            Description = "Full-width announcement banner with dismiss button and action link.",
            RazorSnippet = "<TwBanner Text=\"string.Empty\" Dismissible=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Text", "string", "string.Empty", "Configures component behavior or styling."),
                new ComponentParameterDoc("BadgeText", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ActionText", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnAction", "EventCallback", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Dismissible", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("IsSticky", "bool", "false", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwAlert",
            Category = "Showcase & Micro-Interactions",
            Description = "Dismissible inline feedback alert with semantic variants (Success, Warning, Danger, Info).",
            RazorSnippet = "<TwAlert Variant=\"SemanticVariant.Info\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string?", "null", "Header title or accessible label."),
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Child content or nested markup rendered inside the component slot."),
                new ComponentParameterDoc("Variant", "SemanticVariant", "SemanticVariant.Info", "Semantic visual variant (e.g. Primary, Secondary, Outline)."),
                new ComponentParameterDoc("Dismissible", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnDismiss", "EventCallback", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Additional custom Tailwind CSS utility classes."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwToastContainer",
            Category = "Showcase & Micro-Interactions",
            Description = "Fixed container managing reactive floating toast alert notifications.",
            RazorSnippet = "<TwToastContainer />",
            Parameters = new List<ComponentParameterDoc>
            {
            }
        },
        new ComponentDocItem
        {
            Name = "TwAguiCanvas",
            Category = "Other Components",
            Description = "Reusable Blazor WebAssembly component styled with Tailwind CSS.",
            RazorSnippet = "<TwAguiCanvas Class=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Schema", "AguiWidgetSchema?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnActionTriggered", "EventCallback<AguiActionItem>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string", "\"\"", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwAguiStudio",
            Category = "Other Components",
            Description = "Reusable Blazor WebAssembly component styled with Tailwind CSS.",
            RazorSnippet = "<TwAguiStudio Class=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Class", "string", "\"\"", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwAvatar",
            Category = "Other Components",
            Description = "Reusable Blazor WebAssembly component styled with Tailwind CSS.",
            RazorSnippet = "<TwAvatar Initials=\"UI\" Alt=\"Avatar\" Size=\"ComponentSize.Md\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("ImageUrl", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Initials", "string", "\"UI\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Alt", "string", "\"Avatar\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Size", "ComponentSize", "ComponentSize.Md", "Configures component behavior or styling."),
                new ComponentParameterDoc("StatusColor", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwAvatarGroup",
            Category = "Other Components",
            Description = "Reusable Blazor WebAssembly component styled with Tailwind CSS.",
            RazorSnippet = "<TwAvatarGroup Avatars=\"new()\" Max=\"4\" Size=\"ComponentSize.Md\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Avatars", "List<AvatarItem>", "new()", "Configures component behavior or styling."),
                new ComponentParameterDoc("Max", "int", "4", "Configures component behavior or styling."),
                new ComponentParameterDoc("Size", "ComponentSize", "ComponentSize.Md", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwCarousel",
            Category = "Other Components",
            Description = "Reusable Blazor WebAssembly component styled with Tailwind CSS.",
            RazorSnippet = "<TwCarousel AutoCycle=\"true\" IntervalSeconds=\"4\" ShowArrows=\"true\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ActiveIndex", "int", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ActiveIndexChanged", "EventCallback<int>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("AutoCycle", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("IntervalSeconds", "int", "4", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowArrows", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowIndicators", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwCarouselSlide",
            Category = "Other Components",
            Description = "Reusable Blazor WebAssembly component styled with Tailwind CSS.",
            RazorSnippet = "<TwCarouselSlide>\n    <span>Content</span>\n</TwCarouselSlide>",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("ChildContent", "RenderFragment?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string?", "null", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwCommandPalette",
            Category = "Other Components",
            Description = "Reusable Blazor WebAssembly component styled with Tailwind CSS.",
            RazorSnippet = "<TwCommandPalette Items=\"new()\" Placeholder=\"Type a command, component name, or search...\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("IsOpen", "bool", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("IsOpenChanged", "EventCallback<bool>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Items", "List<CommandPaletteItem>", "new()", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnItemSelected", "EventCallback<CommandPaletteItem>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Placeholder", "string", "\"Type a command, component name, or search...\"", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwCompanyPartyForm",
            Category = "Other Components",
            Description = "Reusable Blazor WebAssembly component styled with Tailwind CSS.",
            RazorSnippet = "<TwCompanyPartyForm Model=\"new()\" Rsvp=\"new()\" CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Model", "PartyModel", "new()", "Configures component behavior or styling."),
                new ComponentParameterDoc("Rsvp", "GuestRsvpModel", "new()", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnPartySaved", "EventCallback<PartyModel>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnRsvpSubmitted", "EventCallback<GuestRsvpModel>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwCompanyPlanForm",
            Category = "Other Components",
            Description = "Reusable Blazor WebAssembly component styled with Tailwind CSS.",
            RazorSnippet = "<TwCompanyPlanForm Model=\"new()\" CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Model", "CompanyPlanModel", "new()", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnPlanSubmitted", "EventCallback<CompanyPlanModel>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwDocsExplorer",
            Category = "Other Components",
            Description = "Reusable Blazor WebAssembly component styled with Tailwind CSS.",
            RazorSnippet = "<TwDocsExplorer />",
            Parameters = new List<ComponentParameterDoc>
            {
            }
        },
        new ComponentDocItem
        {
            Name = "TwEmployeeAwardForm",
            Category = "Other Components",
            Description = "Reusable Blazor WebAssembly component styled with Tailwind CSS.",
            RazorSnippet = "<TwEmployeeAwardForm Model=\"new()\" CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Model", "EmployeeAwardModel", "new()", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnAwardNominated", "EventCallback<EmployeeAwardModel>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwFormEngine",
            Category = "Other Components",
            Description = "Reusable Blazor WebAssembly component styled with Tailwind CSS.",
            RazorSnippet = "<TwFormEngine ShowHeader=\"true\" ShowCardWrapper=\"true\" Class=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Schema", "FormSchema?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnSubmit", "EventCallback<FormSubmissionResult>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnChange", "EventCallback<Dictionary<string, object?>>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowHeader", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("ShowCardWrapper", "bool", "true", "Configures component behavior or styling."),
                new ComponentParameterDoc("ReadOnly", "bool", "false", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string", "\"\"", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwFormStudio",
            Category = "Other Components",
            Description = "Reusable Blazor WebAssembly component styled with Tailwind CSS.",
            RazorSnippet = "<TwFormStudio />",
            Parameters = new List<ComponentParameterDoc>
            {
            }
        },
        new ComponentDocItem
        {
            Name = "TwProfitLossForm",
            Category = "Other Components",
            Description = "Reusable Blazor WebAssembly component styled with Tailwind CSS.",
            RazorSnippet = "<TwProfitLossForm Model=\"new()\" CustomClass=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Model", "ProfitLossModel", "new()", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnStatementSaved", "EventCallback<ProfitLossModel>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("CustomClass", "string", "\"\"", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwSmartFilter",
            Category = "Other Components",
            Description = "Reusable Blazor WebAssembly component styled with Tailwind CSS.",
            RazorSnippet = "<TwSmartFilter Class=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("OnFilterChanged", "EventCallback<Dictionary<string, string>>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string", "\"\"", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwSmartPasteButton",
            Category = "Other Components",
            Description = "Reusable Blazor WebAssembly component styled with Tailwind CSS.",
            RazorSnippet = "<TwSmartPasteButton Class=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("OnApplied", "EventCallback<Dictionary<string, string>>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string", "\"\"", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwSmartSearch",
            Category = "Other Components",
            Description = "Reusable Blazor WebAssembly component styled with Tailwind CSS.",
            RazorSnippet = "<TwSmartSearch SearchQuery=\"\" Placeholder=\"Semantic natural language search (e.g. 'high salary engineers in cloud')...\" Class=\"\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("SearchQuery", "string", "\"\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("SearchQueryChanged", "EventCallback<string>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("OnSearchSubmitted", "EventCallback<string>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Placeholder", "string", "\"Semantic natural language search (e.g. 'high salary engineers in cloud')...\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string", "\"\"", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwSmartTextArea",
            Category = "Other Components",
            Description = "Reusable Blazor WebAssembly component styled with Tailwind CSS.",
            RazorSnippet = "<TwSmartTextArea Value=\"We are thrilled to announce our next-generation WebAssembly architecture which reduces client latency by over 80 percent across all devices.\" Placeholder=\"Start typing and watch smart completions appear...\" Rows=\"4\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Label", "string?", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Value", "string", "\"We are thrilled to announce our next-generation WebAssembly architecture which reduces client latency by over 80 percent across all devices.\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("ValueChanged", "EventCallback<string>", "null", "Configures component behavior or styling."),
                new ComponentParameterDoc("Placeholder", "string", "\"Start typing and watch smart completions appear...\"", "Configures component behavior or styling."),
                new ComponentParameterDoc("Rows", "int", "4", "Configures component behavior or styling."),
                new ComponentParameterDoc("Class", "string", "\"\"", "Configures component behavior or styling."),
            }
        },
        new ComponentDocItem
        {
            Name = "TwMicrCheckReader",
            Category = "Financial & OCR",
            Description = "Check 21 paper check & draft reader with ANSI X9.27 E-13B MICR decoding, Mod-10 ABA routing checksum validation, and courtesy-to-legal amount cross-checking.",
            RazorSnippet = "<TwMicrCheckReader OnCheckScanned=\"HandleCheck\" OnInsertMarkdown=\"HandleInsert\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Class", "string", "\"\"", "Optional CSS classes."),
                new ComponentParameterDoc("OnCheckScanned", "EventCallback<CheckDraftOcrResult>", "null", "Callback fired when a check or draft is scanned."),
                new ComponentParameterDoc("OnInsertMarkdown", "EventCallback<string>", "null", "Callback fired when Markdown ledger table is exported.")
            }
        },
        new ComponentDocItem
        {
            Name = "TwDocumentOcrStudio",
            Category = "Financial & OCR",
            Description = "Full Form & PDF OCR Studio supporting paper checks, official bank drafts, commercial invoices, and IRS Form W-9 with spatial bounding boxes and Markdown table generation.",
            RazorSnippet = "<TwDocumentOcrStudio OnMarkdownExtracted=\"HandleMarkdown\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Class", "string", "\"\"", "Optional CSS classes."),
                new ComponentParameterDoc("OnMarkdownExtracted", "EventCallback<string>", "null", "Fired when extracted markdown report is copied or exported.")
            }
        },
        new ComponentDocItem
        {
            Name = "TwSmartOcrButton",
            Category = "Smart Components",
            Description = "Drop-in Smart Component button that triggers instant client-side OCR for paper checks, invoices, and PDF forms.",
            RazorSnippet = "<TwSmartOcrButton OnDocumentScanned=\"HandleDoc\" OnCheckScanned=\"HandleCheck\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Class", "string", "\"\"", "Optional CSS classes."),
                new ComponentParameterDoc("OnDocumentScanned", "EventCallback<DocumentOcrResult>", "null", "Fired when a document is scanned and entities are extracted."),
                new ComponentParameterDoc("OnCheckScanned", "EventCallback<CheckDraftOcrResult>", "null", "Fired when a paper check or bank draft is scanned.")
            }
        },
        new ComponentDocItem
        {
            Name = "TwStreamingGrid",
            Category = "Fullstack .NET 11",
            Description = "High-throughput streaming DataGrid consuming IAsyncEnumerable<TItem> server streams with real-time row pulse animations and 1M row virtualization.",
            RazorSnippet = "<TwStreamingGrid Title=\"Real-time Telemetry\" MaxBufferCapacity=\"5000\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"High-Throughput Streaming Engine (IAsyncEnumerable)\"", "Grid title in header toolbar."),
                new ComponentParameterDoc("Subtitle", "string", "\"Real-time telemetry pipeline consuming asynchronous server streams...\"", "Toolbar subtitle."),
                new ComponentParameterDoc("MaxBufferCapacity", "int", "5000", "Maximum items kept in memory before circular eviction."),
                new ComponentParameterDoc("Class", "string", "\"\"", "Optional CSS classes.")
            }
        },
        new ComponentDocItem
        {
            Name = "TwHydratedView",
            Category = "Fullstack .NET 11",
            Description = "Universal zero-flicker SSR hydration container eliminating duplicate database queries and visual layout shift between prerender and client hydration.",
            RazorSnippet = "<TwHydratedView IsRestored=\"@_isRestored\" IsLoading=\"@_loading\"><p>Hydrated Content</p></TwHydratedView>",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("ChildContent", "RenderFragment", "null", "The hydrated content to render."),
                new ComponentParameterDoc("SkeletonTemplate", "RenderFragment", "null", "Custom skeleton placeholder to show during initial async load."),
                new ComponentParameterDoc("IsLoading", "bool", "false", "Whether the component is actively fetching initial state."),
                new ComponentParameterDoc("IsRestored", "bool", "false", "Whether the component state was restored from SSR prerender cache."),
                new ComponentParameterDoc("ShowHydrationBadge", "bool", "true", "Displays subtle SSR/Hydrated badge indicator in top right."),
                new ComponentParameterDoc("Class", "string", "\"\"", "Optional CSS classes.")
            }
        },
        new ComponentDocItem
        {
            Name = "TwFullstackForm",
            Category = "Fullstack .NET 11",
            Description = "Dual-mode enterprise form engine supporting Static SSR Enhanced Form POST (zero JS) and Interactive Auto Client RPC seamlessly.",
            RazorSnippet = "<TwFullstackForm Title=\"Universal Fullstack Form\" />",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("Title", "string", "\"Universal Fullstack Form Engine\"", "Form card title."),
                new ComponentParameterDoc("Subtitle", "string", "\"Dual-mode form handling supporting Static SSR and Interactive Auto...\"", "Form card subtitle."),
                new ComponentParameterDoc("Class", "string", "\"\"", "Optional CSS classes.")
            }
        },
        new ComponentDocItem
        {
            Name = "TwFullstackHub",
            Category = "Fullstack .NET 11",
            Description = "Full-stack developer architecture explorer, zero-flicker hydration workbench, and streaming playground for .NET 11 Web Apps.",
            RazorSnippet = "<TwFullstackHub />",
            Parameters = new List<ComponentParameterDoc>()
        },
        new ComponentDocItem
        {
            Name = "TwUnionBoundary",
            Category = "Fullstack .NET 11",
            Description = "C# 15 Discriminated Union boundary rendering exhaustive states (Loading, Success, Empty, Failure) with compile-time branch safety.",
            RazorSnippet = "<TwUnionBoundary TItem=\"string\" State=\"@state\"><Success Context=\"d\">@d</Success></TwUnionBoundary>",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("State", "UiState<TItem>", "required", "Active algebraic union UI state."),
                new ComponentParameterDoc("Loading", "RenderFragment", "null", "Template rendered during loading state."),
                new ComponentParameterDoc("Success", "RenderFragment<TItem>", "null", "Template rendered on successful state with typed item context."),
                new ComponentParameterDoc("Empty", "RenderFragment", "null", "Template rendered on empty collection or record set."),
                new ComponentParameterDoc("Failure", "RenderFragment<UiState<TItem>.Failure>", "null", "Template rendered on error with failure details context.")
            }
        },
        new ComponentDocItem
        {
            Name = "TwDonutCache",
            Category = "Fullstack .NET 11",
            Description = "Blazor Donut Caching container that edge-caches 95%+ of static SSR page markup while dynamically perforating personalized donut holes.",
            RazorSnippet = "<TwDonutCache CacheKey=\"catalog\" Tags=\"@([\"catalog\"])\"><DynamicHole>...</DynamicHole></TwDonutCache>",
            Parameters = new List<ComponentParameterDoc>
            {
                new ComponentParameterDoc("CacheKey", "string", "\"default_donut\"", "Unique cache key for the static shell segment."),
                new ComponentParameterDoc("Duration", "TimeSpan", "5 minutes", "Cache expiration time-to-live."),
                new ComponentParameterDoc("Tags", "List<string>", "[\"catalog\"]", "Cache invalidation tags for programmatic cache busting."),
                new ComponentParameterDoc("StaticContent", "RenderFragment", "null", "Static markup cached at the edge across users."),
                new ComponentParameterDoc("DynamicHole", "RenderFragment", "null", "Dynamic personalized slot evaluated per-request.")
            }
        },
        new ComponentDocItem
        {
            Name = "TwPostQuantumVault",
            Category = "Fullstack .NET 11",
            Description = "Post-Quantum Cryptography secure enclave implementing NIST FIPS 203 ML-KEM-768 key encapsulation and zero-trust authenticated encryption.",
            RazorSnippet = "<TwPostQuantumVault />",
            Parameters = new List<ComponentParameterDoc>()
        },
        new ComponentDocItem
        {
            Name = "TwTelemetryDashboard",
            Category = "Fullstack .NET 11",
            Description = "Native OpenTelemetry (OTel) developer cockpit rendering real-time ActivitySource lifecycle spans, render latency waterfalls, and heap telemetry.",
            RazorSnippet = "<TwTelemetryDashboard />",
            Parameters = new List<ComponentParameterDoc>()
        },
    };

    public IReadOnlyList<ComponentDocItem> GetAll() => _items;
    public IReadOnlyList<string> GetCategories() => _items.Select(i => i.Category).Distinct().ToList();
    public ComponentDocItem? GetByName(string name) => _items.FirstOrDefault(i => i.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
}
