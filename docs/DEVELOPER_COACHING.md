# Blazor Tailwind UI — Developer Coaching & Best Practices Guide

This guide provides practical architectural principles, patterns, and code recipes for building maintainable, high-performance, mobile-first WebAssembly applications using **BlazorTailwindUI** (.NET 11 RC and Tailwind CSS v3.4+).

---

## 1. The Mobile-First Paradigm

### Core Tenet
Desktop interfaces are easy to expand; mobile interfaces fail when desktop tables, modals, or hover states are shrunk down without layout restructuring.

### Best Practices:
1. **Minimum 44px Hit Targets**:
   - All interactive touch targets (buttons, inputs, bottom navigation tabs, drawer close buttons) must maintain a minimum touch area of 44×44 pixels (`min-h-[44px] min-w-[44px]`).
   - Use responsive sizing: `class="min-h-[44px] sm:min-h-[38px] px-4 py-2.5 sm:py-2 text-sm"`.
2. **Safe-Area Insets for Notches and Home Bars**:
   - iOS devices feature bottom home indicator bars and top notches.
   - Fixed elements (such as `TwBottomNav`) must declare safe-area insets: `pb-[calc(0.75rem+env(safe-area-inset-bottom))]`.
3. **Stacked Card Fallback for Tables**:
   - Data grids with 6+ columns cause severe horizontal blowouts on phone screens.
   - `TwDataTable` and `TwDataGrid` detect viewport breakpoints to render compact, swipeable, or stacked touch cards on small screens, switching to tabular format on `md:` (768px) and above.
4. **Adaptive Modals to Bottom Sheets**:
   - `TwModal` automatically presents as an iOS/Android-style sliding **Bottom Sheet** on viewports under 640px (`fixed bottom-0 inset-x-0 rounded-t-3xl`) and transitions into a centered dialog on tablets and desktop (`sm:rounded-3xl sm:max-w-xl sm:my-8`).

---

## 2. Zero-FOUC State Management & Theming

### The Problem
When Blazor WebAssembly boots, there is an asynchronous initialization period while Mono/WASM binaries load. If theme classes are applied inside C# `OnInitializedAsync`, the user experiences a jarring white-to-dark flash (Flash of Unstyled Content).

### The Solution:
1. **Synchronous Bootloader in `index.html`**:
   A tiny 10-line inline script executes in `<head>` *before* the DOM renders:
   ```javascript
   (function() {
     const mode = localStorage.getItem('btui-theme-mode') || 'system';
     const isDark = mode === 'dark' || (mode === 'system' && window.matchMedia('(prefers-color-scheme: dark)').matches);
     if (isDark) document.documentElement.classList.add('dark');
   })();
   ```
2. **Real-time OS Theme Listener**:
   When set to "System", the application listens to `window.matchMedia('(prefers-color-scheme: dark)')` and dynamically switches without page refresh:
   ```csharp
   [JSInvokable]
   public void OnSystemThemeChanged(bool isDark)
   {
       IsDarkMode = isDark;
       NotifyThemeChanged();
   }
   ```
3. **Dynamic CSS Variable Accents**:
   Tailwind utility classes are mapped to RGB variables:
   ```css
   :root {
     --color-brand-500: 99 102 241; /* Indigo default */
   }
   ```
   Switching accents updates `--color-brand-500` dynamically, re-coloring buttons, links, rings, and badges instantly across the entire DOM with 0 re-renders.

---

## 3. Native Visualizations vs Heavy JavaScript Libraries

### Why Avoid External Charting Bundles:
External JS charting libraries (Chart.js, Highcharts, ApexCharts) add 300KB–1MB of extra bundle weight, require complex interop lifecycles, and break responsive SVG scaling.

### The BlazorTailwindUI Approach:
- **Pure C# Inline SVG**: `TwChart` and `TwGauge` compute stroke-dasharray and trigonometry in C# and render SVG paths directly into the Blazor DOM:
  ```csharp
  double pct = Math.Clamp((Value - Min) / (Max - Min), 0.0, 1.0);
  double totalArc = Math.PI * 80;
  double dashOffset = totalArc - (pct * totalArc);
  ```
- **Hardware-Accelerated CSS Transitions**: Path morphing uses `class="transition-all duration-700 ease-out"`, delivering fluid 60fps animations with 0KB external JS dependencies.
- **Canvas Physics for Micro-Interactions**: `TwConfetti` and `TwSignaturePad` utilize lightweight HTML5 Canvas 2D contexts for particle physics and Bezier smoothing.

---

## 4. Keyboard Shortcuts & Command Palettes

### Best Practices:
1. **Global Hotkeys**:
   - Quick Search: <kbd>⌘K</kbd> / <kbd>Ctrl+K</kbd>
   - Guided Coaching Tour: <kbd>Shift+T</kbd>
   - 1080p Video Masterclass: <kbd>Shift+V</kbd>
   - Celebration Confetti: <kbd>Shift+C</kbd>
2. **Accessible Keyboard Navigation**:
   - `TwCommandPalette` supports ArrowUp / ArrowDown cycling and Enter selection.
   - `TwImageCompare` supports Left / Right arrow keys with `role="slider"` and `aria-valuenow`.
   - Modals and Drawers trap focus and dismiss on <kbd>Escape</kbd>.

---

## 5. HyperFrames 1080p Video Masterclass Syllabus

The included interactive training video (`wwwroot/videos/demo-video.mp4`, 2m 52s) features 11 synchronized chapters with voice narration and chapter seeking:

| # | Start Time | Chapter Title | Badge | Key Architectural Concepts Covered |
|---|------------|---------------|-------|-----------------------------------|
| 0 | `0:00` (0.0s) | Intro & Architecture | `.NET 11 WASM` | Zero-CDN standalone architecture, 137 native controls, mobile-first design. |
| 1 | `0:15` (15.5s) | Adaptive Generative UI (AGUI) | `AGUI Engine` | Dynamic widget synthesis, dual-plane tool dispatching, real-time latency monitoring. |
| 2 | `0:33` (33.3s) | Smart Components Suite | `Smart Controls` | Smart Paste with entity extraction, ghost text autocomplete, semantic search & filters. |
| 3 | `0:52` (52.1s) | 100 Web Dev Forms Library | `100 Forms` | Dynamic schema form engine, 10 functional domains, one-click C# code generation. |
| 4 | `1:08` (68.4s) | Flagship Business Operations | `Enterprise Ops` | Company Plan sliders, P&L statement waterfalls, Employee Awards, Party RSVP. |
| 5 | `1:26` (86.2s) | Developer Studio Suite | `Developer IDE` | Multi-pane Dock Manager, formula Spreadsheet, Org Chart, Markdown & HTML editor. |
| 6 | `1:41` (101.2s) | Financial Intelligence | `Market Intel` | Candlestick charting with MA20 & volume, Squarified Treemaps, OLAP Pivot Grids. |
| 7 | `1:55` (115.1s) | Vector Icon & Emoji Studio | `Vector Studio` | 100+ SVG paths, emoji shortcodes, outline/solid toggles, Razor generator. |
| 8 | `2:09` (128.8s) | Enterprise DataGrid & SVG Charts | `Enterprise Data` | Sub-millisecond sorting, per-column filters, mobile cards, 60fps SVG charts. |
| 9 | `2:23` (142.9s) | Barcodes & Signatures | `Hardware Interop` | QR generator, Code 128 barcodes, camera scanner, Bezier signature pad. |
| 10 | `2:36` (156.0s) | Production Ready & Open Source | `MIT Open Source` | Light/dark mode verification, zero prohibited brand names, MIT license. |

---

## 6. Adaptive Generative UI (AGUI) & Dual-Plane Tool Calling

### Architecture Overview
Blazor Tailwind UI provides an **Adaptive Generative UI (AGUI)** engine that parses dynamic declarative schemas into interactive Blazor components at runtime:
- **`TwAguiCanvas`**: Parses an `AguiWidgetSchema` and renders live interactive cards, metric counters, form controls, charts, and action buttons.
- **`TwAguiStudio`**: Provides a split-pane developer workbench with natural language prompt execution, live latency traces, and Razor markup export.
- **Dual-Plane Execution**:
  - **Frontend WASM Tools** (`ToolSource.FrontendWasm`): Execute in-memory on the client WebAssembly thread (e.g., UI theme toggling, confetti bursts, client-side notifications, form model hydration) with sub-millisecond execution times (<5ms).
  - **Backend API Tools** (`ToolSource.BackendApi`): Execute against cloud infrastructure endpoints (e.g., quota checks, financial tickers, security audits, database queries) with realistic network latency telemetry.

### Registering Custom Tools
```csharp
// Register in Dependency Injection via AgenticToolRegistry:
var registry = new AgenticToolRegistry();

registry.RegisterTool(new AgentToolDefinition
{
    Name = "custom_inventory_lookup",
    Description = "Look up warehouse inventory count for a given SKU",
    Category = "Operations",
    Source = ToolSource.BackendApi,
    Parameters = new()
    {
        new("sku", "string", "Product SKU code", IsRequired: true)
    },
    Executor = async (args) =>
    {
        var sku = args.GetValueOrDefault("sku")?.ToString() ?? "";
        return new Dictionary<string, object>
        {
            ["sku"] = sku,
            ["in_stock"] = 1420,
            ["warehouse"] = "US-West-Primary"
        };
    }
});
```

---

## 7. Smart Components Suite

The library includes four drop-in AI-enhanced smart components:

1. **`TwSmartPasteButton`**:
   - Analyzes pasted clipboard text or receipts and extracts structured entities (names, emails, amounts, dates, line items) into strongly-typed form models.
   - Displays confidence scores for each extracted field before writing to the model.
2. **`TwSmartTextArea`**:
   - Provides predictive ghost-text completion (`Tab` to accept).
   - Instant tone re-writing (*Executive, Technical, Concise, Friendly*).
3. **`TwSmartSearch`**:
   - Semantic vector search bar with cosine similarity ranking.
4. **`TwSmartFilter`**:
   - Translates natural language queries (e.g., *"Show active enterprise accounts with ARR over $50k"*) into strongly-typed DataGrid filter predicates.

---

## 8. 100 Most Used Web Dev Forms Library

The `FormCatalogService` provides 100 production-ready form schemas grouped into 10 industry domains:
1. **Authentication & Identity** (Login, MFA, Passkey, OAuth Consent...)
2. **Billing & Subscriptions** (Checkout, Tier Upgrade, Payment Methods...)
3. **Customer Support** (Ticket submission, Feedback, RMA, Knowledgebase...)
4. **Human Resources** (Job Application, Time-Off, Performance Review...)
5. **Healthcare & Medical** (Patient Intake, HIPAA Consent, Telehealth...)
6. **Finance & Banking** (Loan Application, Wire Transfer, Tax Exemption...)
7. **Legal & Compliance** (GDPR Data Request, NDA, IP Assignment...)
8. **Real Estate** (Lease Agreement, Maintenance Request, Property Valuation...)
9. **Event Management** (Conference Registration, RSVP, Speaker Proposal...)
10. **Operations & Logistics** (Work Order, Shipping Manifest, Safety Audit...)

Every form includes schema definition, validation rules, live preview, and one-click copyable C# Blazor code.

---

## 9. Summary Checklist for Production Readiness

- [x] All touch targets >= 44px.
- [x] Safe-area insets configured on mobile bars.
- [x] Zero external CDN links in index.html (self-contained fonts, scripts, videos).
- [x] Local Tailwind CLI compiled and minified (`npm run build:css`).
- [x] Zero commercial third-party brand dependencies.
- [x] Dark mode verified with zero white flashes on page reload.
- [x] Full 1080p HyperFrames Masterclass Video (172s, 11 chapters) embedded and seekable.
- [x] Over 137 native Blazor components verified and documented.
