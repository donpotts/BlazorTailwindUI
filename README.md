# BlazorTailwindUI

<p align="center">
  <img src="docs/images/agui-studio-cloud-quota.png" alt="BlazorTailwindUI Adaptive Generative UI Studio" width="920" style="border-radius: 16px; box-shadow: 0 20px 25px -5px rgba(0, 0, 0, 0.2);" />
</p>

<p align="center">
  <strong>Next-Generation Enterprise Mobile-First UI Ecosystem & Adaptive Generative UI (AGUI) Engine</strong><br />
  Engineered for <strong>Pure .NET 11 RC WebAssembly</strong> and <strong>Tailwind CSS v3.4+</strong> with Zero Runtime CDN Dependencies.
</p>

<p align="center">
  <a href="https://dotnet.microsoft.com/"><img src="https://img.shields.io/badge/.NET-11.0_RC_WASM-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 11 WASM" /></a>
  <a href="https://tailwindcss.com/"><img src="https://img.shields.io/badge/Tailwind_CSS-v3.4+-06B6D4?style=for-the-badge&logo=tailwindcss&logoColor=white" alt="Tailwind CSS v3.4" /></a>
  <a href="docs/COMPONENT_CATALOG.md"><img src="https://img.shields.io/badge/Components-137_Production_Ready-3B82F6?style=for-the-badge" alt="137 Components" /></a>
  <a href="#-100-most-used-forms-standard-library"><img src="https://img.shields.io/badge/Forms_Catalog-100_Standard_Schemas-10B981?style=for-the-badge" alt="100 Forms" /></a>
  <a href="#-adaptive-generative-ui-agui--agentic-tool-calling"><img src="https://img.shields.io/badge/AGUI-Agentic_Tool_Calling-8B5CF6?style=for-the-badge" alt="AGUI & Tool Calling" /></a>
  <a href="LICENSE"><img src="https://img.shields.io/badge/License-MIT-F59E0B?style=for-the-badge" alt="MIT License" /></a>
</p>

---

## 🌟 Executive Overview

**BlazorTailwindUI** is an enterprise-grade component library, dynamic form engine, and **Adaptive Generative UI (AGUI)** workbench for Blazor WebAssembly. Built with modern C# and client-side WebAssembly SIMD performance, it pairs with a standalone, local Tailwind CSS compiler to deliver:

1. **137 Production-Ready Components** across 17 structured categories.
2. **Adaptive Generative UI (AGUI)**: Prompt-to-UI synthesis compiling natural language user intent into live, reactive interface trees.
3. **Dual-Plane Agentic Tool Calling (.NET 11)**: First-class client-side WebAssembly tools (`FrontendWasm`) and backend endpoints (`BackendApi`) with real-time latency monitoring and execution tracing.
4. **Smart Components Drop-in Suite**: Drop-in controls including `TwSmartPasteButton`, `TwSmartTextArea`, `TwSmartSearch`, and `TwSmartFilter`.
5. **100 Most Used Forms Library (`TwFormEngine` + `FormCatalogService` + `TwFormStudio`)**: 100 enterprise form schemas across 10 domains with live validation and instant C# code generation.
6. **Flagship Enterprise Business Suite**:
   - `TwCompanyPlanForm`: Annual Strategic Operating Plan (AOP) with OKRs and \$1M–\$100M capital budget sliders.
   - `TwProfitLossForm`: Reactive Income Statement modeler with real-time margin math and inline SVG financial waterfall charts.
   - `TwEmployeeAwardForm`: Spot bonuses and live embossed golden certificate generator.
   - `TwCompanyPartyForm`: Event budget allocation, entertainment multi-selection, and guest RSVP portal.
7. **Developer Studio Suite**:
   - Split-pane Markdown/HTML live editor with multi-format media drawer.
   - High-frequency Candlestick financial charts with volume histograms.
   - Squarified 2D valuation treemaps.
   - Cross-tabulation OLAP pivot grids.
   - Multi-pane IDE docking workspaces.
   - Reactive formula spreadsheet engines.
   - Vector SVG hierarchical organization charts.
   - Zero-dependency vector icons (`TwIcon`) and interactive emoji picker (`TwEmoji`).
8. **Coaching & Training Masterclass**:
   - Full 1080p high-definition walkthrough video with interactive HyperFrames chapter seeking.
   - Keyboard-driven command palette (`TwCommandPalette`, `Ctrl+K`) and interactive onboarding tour (`TwTour`).

---

## 📸 Visual Showcase

| AGUI & Tool Calling Workbench | 100-Form Standard Library Studio |
|:---:|:---:|
| <img src="docs/images/agui-studio-cloud-quota.png" width="450" /> | <img src="docs/images/form-studio-overview.png" width="450" /> |

| Reactive P&L Income Statement Modeler | Annual Strategic Operating Plan (AOP) |
|:---:|:---:|
| <img src="docs/images/form-profit-loss.png" width="450" /> | <img src="docs/images/form-company-plan.png" width="450" /> |

| Smart Components Interactive Sandbox | Employee Recognition & Golden Certificate |
|:---:|:---:|
| <img src="docs/images/smart-components-sandbox.png" width="450" /> | <img src="docs/images/form-employee-awards.png" width="450" /> |

| High-Frequency Financial Ticker AGUI | Split Markdown/HTML Editor & Media Drawer |
|:---:|:---:|
| <img src="docs/images/agui-studio-financial-ticker.png" width="450" /> | <img src="docs/images/studio-markdown-editor-split-dark.png" width="450" /> |

---

## 🤖 Adaptive Generative UI (AGUI) & Agentic Tool Calling

BlazorTailwindUI implements **dual-plane tool calling** for agentic systems:

```
┌────────────────────────────────────────────────────────┐
│                   Natural Language Prompt              │
│   "Query cloud cluster in us-east and render sentinel" │
└───────────────────────────┬────────────────────────────┘
                            │
               ┌────────────┴────────────┐
               ▼                         ▼
   ┌───────────────────────┐ ┌───────────────────────┐
   │    Backend API Tool   │ │   Frontend WASM Tool  │
   │ sys_cloud_quota_check │ │    tw_render_widget   │
   │ (Simulated / REST)    │ │ (Direct DOM Mutation) │
   └───────────┬───────────┘ └───────────┬───────────┘
               │                         │
               └────────────┬────────────┘
                            ▼
              ┌───────────────────────────┐
              │  Live TwAguiCanvas Render │
              │  Latency: 84ms | Reactive │
              └───────────────────────────┘
```

### C# .NET 11 Tool Invocation Snippet

```csharp
@using BlazorTailwindUI.Services
@using BlazorTailwindUI.Models
@inject AgenticToolRegistry ToolRegistry
@inject ThemeService Theme

@code {
    // 1. Invoke Backend API Tool (e.g. Cluster Telemetry Query)
    var backendResult = await ToolRegistry.ExecuteToolAsync(
        "sys_cloud_quota_check", 
        new() { ["region"] = "us-east-1", ["clusterId"] = "k8s-prod-primary" }
    );

    // 2. Invoke Frontend WASM Tool (e.g. Client-side Theme Mutation)
    var frontendResult = await ToolRegistry.ExecuteToolAsync(
        "tw_theme_switch", 
        new() { ["mode"] = "dark", ["accent"] = "cyan" }
    );

    // 3. Dynamically Compile & Mount AGUI Widget
    var widgetSchema = new AguiWidgetSchema {
        Title = "Cloud Infrastructure Sentinel",
        WidgetType = "metric",
        AccentColor = "cyan",
        Metrics = new() {
            new() { Label = "vCPU Usage", Value = "38 / 48 Cores", Delta = "+4.2%" },
            new() { Label = "Memory Allocated", Value = "142 / 192 GB", Delta = "-2.1%" }
        }
    };
}
```

---

## ⚡ Smart Components Drop-in Suite

| Component | Class | Description |
|---|---|---|
| **`TwSmartPasteButton`** | [`Components/UI/TwSmartPasteButton.razor`](Components/UI/TwSmartPasteButton.razor) | Entity extraction modal parsing unstructured emails/receipts into form fields with confidence percentages. |
| **`TwSmartTextArea`** | [`Components/UI/TwSmartTextArea.razor`](Components/UI/TwSmartTextArea.razor) | Textarea with autocomplete ghost text (`Tab` to complete), tone switcher (*Executive, Technical, Concise*), and clarity enhancer. |
| **`TwSmartSearch`** | [`Components/UI/TwSmartSearch.razor`](Components/UI/TwSmartSearch.razor) | Semantic vector search input with cosine similarity ranking and query expansion chips. |
| **`TwSmartFilter`** | [`Components/UI/TwSmartFilter.razor`](Components/UI/TwSmartFilter.razor) | Natural language filter translator that converts free-form sentences into dismissible DataGrid predicate chips. |

---

## 📋 100 Most Used Forms Standard Library

The centralized [`FormCatalogService`](Services/FormCatalogService.cs) provides 100 production-ready form schemas across 10 enterprise domains (10 forms per category):

1. **Authentication & Identity**: User Login & SSO, Multi-Factor Auth, Password Reset, Magic Link, SAML Domain Claim, API Key Generator, Device Authorization, Session Unlock, etc.
2. **User Profiles & Account Settings**: Personal Profile, Security Credentials, Notification Preferences, Billing Address, Connected Accounts, Avatar Upload, etc.
3. **E-Commerce & Transactions**: Multi-Step Checkout, Shipping Address, Payment Method, Return / RMA Request, Gift Card Redemption, Subscription Pause, etc.
4. **SaaS & Cloud Operations**: Workspace Creation, Team Invite, Plan Upgrade, Webhook Config, Audit Log Filter, Custom Domain DNS, Service Limits, etc.
5. **Enterprise & Business Operations**: Expense Reimbursement, Purchase Order, Vendor Onboarding, NDA Sign-Off, Capital Expenditure Request, Asset Requisition, etc.
6. **Human Resources & Workplace**: Job Application, PTO Time-Off Request, Performance Review, Equipment Request, Exit Interview, Referral Submission, etc.
7. **Feedback & Customer Support**: Support Ticket, CSAT Survey, Bug Report with Repro Steps, Feature Request, Feedback Portal, Cancellation Survey, etc.
8. **Marketing & Lead Generation**: Enterprise Demo Request, Contact Sales, Newsletter Signup, Webinar Registration, Whitepaper Download, Event RSVP, etc.
9. **Security, Legal & Compliance**: GDPR Data Subject Request (DSR), Right to be Forgotten, Cookie Preferences, Terms Acceptance, IP Whitelist, etc.
10. **Content & Media Publishing**: Article Authoring, Media Upload, Event Submission, Press Release Pitch, Podcast Intake, Editorial Review, etc.

---

## 🎬 1080p Video Masterclass & Interactive Tour

Blazor Tailwind UI includes a full 1080p masterclass coaching video (`wwwroot/videos/demo-video.mp4`, 2m 52s) directly embedded in the showcase and playable offline:

| Chapter | Time | Title | Key Architectural Highlights |
|---|---|---|---|
| **0** | `0:00` | **Intro & Architecture** | .NET 11 WebAssembly, 137 native controls, zero runtime CDNs |
| **1** | `0:15` | **Adaptive Generative UI (AGUI)** | Dynamic UI synthesis, dual-plane tool dispatching, real-time latency meters |
| **2** | `0:33` | **Smart Components Suite** | Smart Paste entity extractor, ghost text autocomplete, semantic search |
| **3** | `0:52` | **100 Web Dev Forms Library** | Dynamic JSON/C# schema engine across 10 functional domains |
| **4** | `1:08` | **Enterprise Business Operations** | Flagship Annual Plan, P&L waterfalls, Employee Awards, Party RSVP |
| **5** | `1:26` | **Developer Studio Suite** | Multi-pane Dock Manager, formula Spreadsheet, Org Chart, Markdown editor |
| **6** | `1:41` | **Financial Intelligence** | Candlestick charting with MA20 & volume, Treemaps, OLAP Pivot Grids |
| **7** | `1:55` | **Vector Icon & Emoji Studio** | 100+ SVG paths, emoji shortcodes, outline/solid toggles, Razor generator |
| **8** | `2:09` | **DataGrid & SVG Charts** | Sub-millisecond sorting, per-column filters, mobile cards, 60fps SVG charts |
| **9** | `2:23` | **Barcodes & Signatures** | QR generator, Code 128 barcodes, camera scanner, Bezier signature pad |
| **10** | `2:36` | **Open Source Release** | Light/dark mode verification, zero prohibited brand names, MIT license |

---

## 🖥️ TAUI Cross-Platform Desktop Installers

Blazor Tailwind UI ships with native desktop packaging powered by **TAUI (Tauri v2)** and .NET 11 WebAssembly, giving you full native window management, offline operation, and native installers:

| Operating System | Package Type | Artifact Name | Description |
|---|---|---|---|
| **Windows** | **NSIS Setup (.exe)** | `BlazorTailwindUI-1.0.0-x64-Setup.exe` | Standard Windows executable wizard installer (~20 MB) |
| **Windows** | **Windows Installer (.msi)** | `BlazorTailwindUI-1.0.0-x64-en-US.msi` | Enterprise WiX MSI package for silent / GPO rollout (~21 MB) |
| **macOS** | **Apple Disk Image (.dmg)** | `BlazorTailwindUI-1.0.0-universal.dmg` | Drag-and-drop macOS Universal Binary (Apple Silicon + Intel) |
| **Linux** | **Debian Package (.deb)** | `blazor-tailwind-ui_1.0.0_amd64.deb` | Ubuntu / Debian package with desktop launcher entry |
| **Linux** | **AppImage (.AppImage)** | `BlazorTailwindUI-1.0.0-x86_64.AppImage` | Single-file zero-install portable Linux executable |
| **Cross-Platform** | **Web Demo (.zip)** | `BlazorTailwindUI-WebDemo-v1.0.0.zip` | Standalone offline web demo with 1-click `start-demo` scripts |

### Build Desktop Installers Locally
```bash
# 1. Install TAUI CLI & dependencies
npm install

# 2. Build production assets & publish WASM
npm run build:dist

# 3. Build native desktop installer for current OS
npm run tauri:build
```

---

## 🚀 Quick Start Guide

### Prerequisites
- [.NET 11 SDK](https://dotnet.microsoft.com/download) (or .NET 11 RC)
- [Node.js v18+](https://nodejs.org/) (for Tailwind CSS standalone CLI build)

### Step 1: Clone the Repository
```bash
git clone https://github.com/donpotts/BlazorTailwindUI.git
cd BlazorTailwindUI
```

### Step 2: Install Node Dependencies & Build Tailwind CSS
```bash
npm install
npm run build:css
```

### Step 3: Run the Application
```bash
dotnet run
```

Open your browser and navigate to `http://localhost:5128` (or the URL printed to your terminal).

---

## 📚 Complete Documentation Suite

- **[docs/COMPONENT_CATALOG.md](docs/COMPONENT_CATALOG.md)**: Exhaustive API specifications, parameter tables, defaults, and Razor markup examples for all **137 components**.
- **[docs/DEVELOPER_COACHING.md](docs/DEVELOPER_COACHING.md)**: Mobile-first architectural best practices, 44px minimum tap targets, zero-FOUC theme synchronization, and WCAG AA compliance.
- **[docs/HELP_AND_GUIDE.md](docs/HELP_AND_GUIDE.md)**: Keyboard shortcuts reference (`Ctrl+K` Command Palette), global recipes, and troubleshooting FAQ.

---

## 🛡️ Privacy & Zero Telemetry Certified

- **Zero Remote CDN Calls**: All stylesheets, JavaScript interop scripts, SVGs, and fonts are locally self-hosted.
- **Zero Third-Party Trackers**: No analytics beacons, tracking cookies, or external surveillance scripts.
- **Air-Gap Compatible**: Built to run in secure enterprise intranets, offline government enclaves, and sovereign clouds.

---

## 📄 License

This project is licensed under the [MIT License](LICENSE) - free for personal, commercial, and enterprise deployment.
