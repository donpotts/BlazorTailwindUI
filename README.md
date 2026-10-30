# BlazorTailwindUI

<p align="center">
  <img src="docs/images/agui-studio-cloud-quota.png" alt="BlazorTailwindUI" width="840" style="border-radius: 12px; box-shadow: 0 10px 30px rgba(0,0,0,0.15);" />
</p>

<p align="center">
  <strong>A modern, mobile-first component library and Adaptive Generative UI (AGUI) engine for Blazor WebAssembly and Tailwind CSS.</strong>
</p>

<p align="center">
  <a href="https://dotnet.microsoft.com/"><img src="https://img.shields.io/badge/.NET-11.0_WASM-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt=".NET 11" /></a>
  <a href="https://tailwindcss.com/"><img src="https://img.shields.io/badge/Tailwind_CSS-v3.4+-06B6D4?style=flat-square&logo=tailwindcss&logoColor=white" alt="Tailwind CSS" /></a>
  <a href="docs/COMPONENT_CATALOG.md"><img src="https://img.shields.io/badge/Components-193_Ready-3B82F6?style=flat-square" alt="193 Components" /></a>
  <a href="LICENSE"><img src="https://img.shields.io/badge/License-MIT-F59E0B?style=flat-square" alt="MIT License" /></a>
</p>

<p align="center">
  <a href="#-quick-start">Quick Start</a> •
  <a href="#-component-examples">Examples</a> •
  <a href="#-component-catalog-193-components">Component Catalog</a> •
  <a href="docs/COMPONENT_CATALOG.md">Full API Docs</a> •
  <a href="wwwroot/videos/hyperframes_masterclass.html">1080p Video Tour</a>
</p>

---

## ⚡ Features

- **193 Native Components** — Built with C# and Tailwind CSS v3.4+. Pure WebAssembly, zero third-party commercial UI dependencies.
- **Mobile-First by Default** — 44px touch targets, bottom sheets, swipe gestures, and responsive DataGrid mobile cards.
- **Adaptive Generative UI (AGUI)** — Runtime prompt-to-UI synthesis with dual-plane tool calling (Frontend WASM + Backend API).
- **Agent Ops (human-in-the-loop)** — A transport-agnostic agent session with approval gates that genuinely block high-risk tool calls, takeover and hand-back, an editable shared-state inspector and an exportable audit trail. See [Agent Ops](#-agent-ops-approvals-takeover--audit).
- **Accessible by Default** — High-contrast mode (toggle or OS `prefers-contrast`), `forced-colors` support, reduced motion, RTL-safe layout, and axe-core WCAG 2.x A/AA checks in the browser tests.
- **Zero-FOUC Theme Engine** — Instant dark mode and 12 curated color presets (Indigo, Emerald, Violet, Rose, Cyan, Amber, etc.) with custom hex palette generation.
- **Enterprise Flagships** — CRM Draggable Dashboard (`GridStack`), Flattened PDF Contract Signer with SHA-256 sealing, C# 15 Discriminated Union boundary, 100% offline Tesseract WebAssembly OCR (`wwwroot/lib/tesseract/`), 150+ NACHA Bank Routing resolver, and ChoETL.NACHA 94-character fixed-width ACH exporter.

---

## 🚀 Quick Start

### 1. Register Services
Add BlazorTailwindUI services in `Program.cs`:

```csharp
builder.Services.AddBlazorTailwindUI();
```

### 2. Include Assets
Add the stylesheet and scripts to `wwwroot/index.html`:

```html
<link rel="stylesheet" href="css/app.min.css" />
<script src="js/theme.js"></script>
<script src="js/kanban.js"></script>
```

### 3. Import Namespaces
Add to your `_Imports.razor`:

```razor
@using BlazorTailwindUI.Components.UI
@using BlazorTailwindUI.Models
```

---

## 💡 Component Examples

### Buttons & Badges
```razor
<TwButton Variant="ButtonVariant.Primary" Size="ComponentSize.Md" OnClick="HandleSubmit">
    Submit Request
</TwButton>

<TwBadge Variant="SemanticVariant.Success" Size="ComponentSize.Sm" ShowDot="true">
    Active
</TwBadge>
```

### Responsive DataGrid
```razor
<TwDataGrid TItem="UserRecord" Items="@Users" Selectable="true" PageSize="10">
    <Columns>
        <TwDataGridColumn TItem="UserRecord" Title="Name" Property="u => u.Name" SortBy="u => u.Name" />
        <TwDataGridColumn TItem="UserRecord" Title="Role" Property="u => u.Role" />
        <TwDataGridColumn TItem="UserRecord" Title="Status">
            <CellTemplate Context="user">
                <TwBadge Variant="@(user.IsActive ? SemanticVariant.Success : SemanticVariant.Default)" ShowDot="true">
                    @(user.IsActive ? "Active" : "Offline")
                </TwBadge>
            </CellTemplate>
        </TwDataGridColumn>
    </Columns>
</TwDataGrid>
```

### Responsive Modal & Bottom Sheet
```razor
<TwButton OnClick="() => _isOpen = true">Open Dialog</TwButton>

<TwModal @bind-IsOpen="_isOpen" Title="Confirm Action" Description="Desktop centered dialog, mobile bottom sheet.">
    <p class="text-sm text-slate-600 dark:text-slate-400">Are you sure you want to proceed?</p>
    <FooterContent>
        <TwButton Variant="ButtonVariant.Ghost" OnClick="() => _isOpen = false">Cancel</TwButton>
        <TwButton Variant="ButtonVariant.Primary" OnClick="Save">Confirm</TwButton>
    </FooterContent>
</TwModal>
```

### Modern Progress & Activity Rings
```razor
<!-- Apple Fitness style concentric activity rings -->
<TwModernProgress Type="TwModernProgress.ProgressType.ConcentricMultiRing"
                  Value="85" SecondaryValue="68" TertiaryValue="94" />

<!-- Speedometer dashboard arc gauge -->
<TwModernProgress Type="TwModernProgress.ProgressType.SpeedometerArc"
                  Value="84" Label="Velocity" />
```

### Check 21 MICR & Local Tesseract OCR
```razor
<TwMicrCheckReader OnCheckScanned="HandleScanned"
                   OnDepositApproved="HandleApproved"
                   OnNachaExported="HandleNachaExport"
                   OnJsonExported="HandleJsonExport" />
```

---

## 🛡️ Agent Ops: Approvals, Takeover & Audit

Drop in a complete human-in-the-loop agent workspace:

```razor
<TwAgentConsole />
```

<p align="center">
  <img src="docs/images/agent-ops-2-approval-gate.png" alt="Agent blocked on a high-risk refund, waiting for human approval" width="760" />
</p>

What it does (all of it is real behavior, exercised by unit and browser tests):

- **Approval gates block.** A tool call marked as requiring approval is held until a human approves (optionally with edited, validated JSON arguments) or rejects with a reason. A rejection reroutes the agent; it is not a notification.
- **Takeover pauses the agent.** The agent stops before its next step; the human edits shared state, and the edit changes what the agent does next. Hand back resumes it.
- **Everything is audited.** Human, agent and system events are recorded in order and can be exported as JSON.

| Approval gate | Rejected, agent escalated | Takeover |
| :---: | :---: | :---: |
| ![Approval gate](docs/images/agent-ops-2-approval-gate.png) | ![Rejected](docs/images/agent-ops-4-rejected.png) | ![Takeover](docs/images/agent-ops-5-takeover.png) |

### Drive your own agent

The console runs on `AgentRunSession`, which consumes an `IAgentTransport`, an `IAsyncEnumerable<AgUiEvent>` modelled on the [AG-UI](https://github.com/ag-ui-protocol/ag-ui) event stream (text deltas, tool call start/args/end/result, state deltas). The session pulls events lazily, so anything your transport does between two yields is held back while the run is paused or awaiting approval.

```csharp
public sealed class MyAgentTransport : IAgentTransport
{
    public async IAsyncEnumerable<AgUiEvent> RunAsync(string prompt, AgentRunContext context,
        [EnumeratorCancellation] CancellationToken ct)
    {
        yield return new AgUiEvent(AgUiEventType.ToolCallStart, "call_1", "issue_refund",
            Risk: ToolRisk.High, RequiresApproval: true);
        yield return new AgUiEvent(AgUiEventType.ToolCallArgs, "call_1", Text: "{\"amount\":\"249.00\"}");
        yield return new AgUiEvent(AgUiEventType.ToolCallEnd, "call_1");

        // The session has already waited for the human; read the decision.
        if (context.DecisionFor("call_1") is { Approved: true } decision)
            yield return new AgUiEvent(AgUiEventType.ToolCallResult, "call_1", Text: "Refund issued.");
    }
}

builder.Services.AddScoped<IAgentTransport, MyAgentTransport>(); // before AddBlazorTailwindUI()
builder.Services.AddBlazorTailwindUI();
```

Compose the pieces yourself with `TwApprovalGate`, `TwToolCallCard`, `TwTakeoverBar`, `TwAgentStateInspector`, `TwAuditTrail` and `TwAgentRoster`, each taking the same `AgentRunSession`. The default transport is an offline simulated refund-desk agent, so the demo runs with no backend.

---

## ♿ Accessibility

- **High contrast:** toggle it in the theme menu, or let it follow the OS `prefers-contrast` setting. It sets `data-contrast="high"` on `<html>` before first paint (no flash), turns borders solid, strengthens muted text and focus rings, and drops shadows and blur.
- **Forced colors / Windows High Contrast:** system colors win; focus, pressed and disabled states stay visible.
- **Reduced motion:** `prefers-reduced-motion` disables animations and transitions globally.
- **RTL:** the Agent Ops components use logical properties and mirror correctly under `dir="rtl"`.
- **Verified in a browser:** the E2E suite runs axe-core (WCAG 2.0/2.1/2.2 A and AA) against the agent console.

| High contrast | RTL | Forced colors |
| :---: | :---: | :---: |
| ![High contrast](docs/images/agent-ops-6-high-contrast.png) | ![RTL](docs/images/agent-ops-7-rtl-high-contrast.png) | ![Forced colors](docs/images/agent-ops-8-forced-colors.png) |

---

## 🧪 Testing

```bash
# Unit + component tests (xUnit + bUnit): session logic, gating, takeover, audit, theme contrast, UI behavior
dotnet test tests/BlazorTailwindUI.Tests

# Browser E2E with screenshots and an axe-core audit
npm install
npm run build:css
dotnet run --no-launch-profile --urls http://127.0.0.1:5199
python tests/e2e/agent_ops_e2e.py http://127.0.0.1:5199
```

The E2E run drives the real UI (approve with edited arguments, reject, takeover and state edit, audit export, contrast, RTL, forced colors), asserts the outcomes, fails on any console error, and writes screenshots to `docs/images/`.

---

## 📦 Component Catalog (193 Components)

All components are documented with parameters and copy-paste snippets in the [Full Component Catalog](docs/COMPONENT_CATALOG.md).

| Category | Components | Description |
| :--- | :--- | :--- |
| **Actions & Buttons** | `TwButton`, `TwButtonGroup`, `TwSplitButton`, `TwDropdown`, `TwSegmentedControl` | Touch-friendly triggers with loading spinners, icons, and variants. |
| **Forms & Inputs** | `TwInput`, `TwSelect`, `TwCheckbox`, `TwRadioGroup`, `TwToggle`, `TwTextarea`, `TwDatePicker`, `TwTimeSpanPicker`, `TwColorPicker` | Two-way data binding, validation states, and floating labels. |
| **Data & Tables** | `TwDataGrid`, `TwDataGridColumn`, `TwKanbanBoard`, `TwVirtualGrid`, `TwPickList`, `TwTreeTable` | Sorting, multi-column search, batch actions, and mobile cards. |
| **Feedback & Badges** | `TwBadge`, `TwAlert`, `TwToast`, `TwSkeleton`, `TwProgressBar`, `TwModernProgress` | Status chips, alerts, shimmers, radial rings, and concentric gauges. |
| **Modals & Overlays** | `TwModal`, `TwBottomSheet`, `TwDrawer`, `TwPopover`, `TwTooltip`, `TwContextMenu` | Accessible dialogs with mobile bottom-sheet fallback. |
| **Navigation** | `TwNavbar`, `TwSidebar`, `TwTabs`, `TwBottomNav`, `TwBreadcrumb`, `TwPagination`, `TwScrollToTop` | Responsive multi-tier navigation bars and tabs. |
| **Cards & Layout** | `TwCard`, `TwGrid`, `TwSplitter`, `TwAccordion`, `TwTimeline`, `TwStatCard` | Bento grids, collapsible panels, and responsive containers. |
| **Agent Ops** | `TwAgentConsole`, `TwApprovalGate`, `TwToolCallCard`, `TwTakeoverBar`, `TwAgentStateInspector`, `TwAuditTrail`, `TwAgentRoster` | Blocking approvals, takeover/hand-back, shared state and audit trail for any AG-UI-style agent. |
| **AI & AG-UI** | `TwAguiStudio`, `TwAguiCanvas`, `TwChatbot`, `TwVoiceRecorder`, `TwCopilot` | Generative UI prompt synthesis and dual-plane tool calling. |
| **Enterprise Studios** | `TwDashboard`, `TwPdfFormFiller`, `TwUnionBoundary`, `TwFinancialChart`, `TwTreemap`, `TwPivotTable`, `TwMarkdownEditor` | Draggable CRM dashboards, sealed PDFs, and financial charts. |
| **Media & Scanner** | `TwMediaPlayer`, `TwQrScanner`, `TwBarcodeScanner`, `TwSignaturePad`, `TwMicrCheckReader`, `TwDocumentOcrStudio` | 100% Local Tesseract OCR WASM, Check 21 MICR reading, 150+ NACHA bank directory, and audio/video players. |

---

## 📚 Documentation & Guides

- 📖 **[Component Catalog (193 Components)](docs/COMPONENT_CATALOG.md)** — Complete parameter tables, variants, and API reference.
- 🎓 **[Developer Coaching & Architecture Principles](docs/DEVELOPER_COACHING.md)** — Mobile-first design patterns, zero-FOUC theming, and performance tips.
- 🎬 **[HyperFrames 1080p Video Masterclass](wwwroot/videos/hyperframes_masterclass.html)** — Interactive 18-chapter video walkthrough.
- 🗺️ **[Release Roadmap & Changelog](docs/ROADMAP.md)** — Feature milestones and version history.

---

## 📄 License

BlazorTailwindUI is licensed under the [MIT License](LICENSE).
