# Blazor Tailwind UI — Component Catalog & Settings Reference

Comprehensive guide to all **86 components** in **BlazorTailwindUI** (.NET 11 RC WebAssembly, Tailwind CSS v3.4+, zero third-party commercial UI libraries).

---

## Table of Contents

- [Agent Ops & Human-in-the-Loop](#agent-ops--human-in-the-loop) (18 components)
- [Chat & Generative UI](#chat--generative-ui) (9 components)
- [Financial & Analytical Intelligence](#financial-analytical-intelligence) (3 components)
- [Developer Studio & Content Creation](#developer-studio-content-creation) (7 components)
- [Task-Purpose Enterprise Forms](#task-purpose-enterprise-forms) (8 components)
- [Layout & Application Shell](#layout-application-shell) (5 components)
- [Theme & Palette Customization](#theme-palette-customization) (5 components)
- [Code & Syntax Studio](#code-syntax-studio) (5 components)
- [Advanced Forms & Inputs](#advanced-forms-inputs) (7 components)
- [Typography, Badges & Keys](#typography-badges-keys) (8 components)
- [Buttons, Forms & Controls](#buttons-forms-controls) (12 components)
- [Cards, Grids & Bento Systems](#cards-grids-bento-systems) (10 components)
- [Enterprise Data & Tables](#enterprise-data-tables) (7 components)
- [Visualizations & Gauges](#visualizations-gauges) (8 components)
- [Media, Scanner & Signature](#media-scanner-signature) (6 components)
- [Navigation & Steppers](#navigation-steppers) (11 components)
- [Overlays & Popovers](#overlays-popovers) (7 components)
- [AI Chatbot & Reasoning](#ai-chatbot-reasoning) (3 components)
- [Showcase & Micro-Interactions](#showcase-micro-interactions) (7 components)

---

## Chat & Generative UI

Generated from the live catalog (`ComponentCatalogService`); every entry below is a real component with tests.

| Component | Purpose |
| --- | --- |
| `TwChatSuggestions` | Suggested follow-up prompts with a loading skeleton. |
| `TwFeedbackButtons` | Thumbs up / down with an optional reason. |
| `TwAttachmentQueue` | File staging with count, size and duplicate validation. |
| `TwMessageScroller` | Follows new messages; Jump to latest after scrolling up. |
| `TwVoiceInput` | Push-to-talk recording with level meter and optional transcription. |
| `TwLiveWaveform` | Audio level bars. |
| `TwQuestionnaire` | Structured questions from an agent, one at a time. |
| `TwA2uiSurface` | Agent-described UI (A2UI v0.9) with data binding and actions. |
| `TwMcpAppFrame` | Sandboxed MCP app host with CSP and postMessage bridge. |

### Agent Ops additions

`TwThreadList`, `TwDryRunChanges`, `TwActivityLog`, `TwCommandOutput`, `TwHandoffPanel`, `TwRoutinesList`, `TwMemoryList`, `TwGrantList`, `TwLiveScreen`, `TwAgentOrb`, `TwRedactedValue`.

### Controls and inputs additions

`TwSpinner`, `TwButtonGroup`, `TwRadioGroup<TValue>`, `TwTextArea` (Buttons, Forms & Controls); `TwCalendar`, `TwTimePicker` (Advanced Forms & Inputs).


## Agent Ops & Human-in-the-Loop

Agent-native components built around a transport-agnostic `AgentRunSession`: high-risk tool calls block until a human decides, takeover pauses the agent, and every action is audited. Plug your own agent in by implementing `IAgentTransport` (an `IAsyncEnumerable<AgUiEvent>`) and registering it before `AddBlazorTailwindUI()`.

---

### `TwAgentConsole`

**Location:** [`Components/UI/TwAgentConsole.razor`](../Components/UI/TwAgentConsole.razor)

Complete human-in-the-loop agent workspace: roster, streaming conversation with tool-call cards, an approval gate that genuinely blocks high-risk calls, takeover and hand-back controls, an editable shared-state inspector and an exportable audit trail. Drives any IAgentTransport; ships with an offline simulated refund-desk agent.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Class` | `string?` | `null` | Custom Tailwind CSS classes. |
| `Agents` | `IReadOnlyList<AgentProfile>?` | `one demo agent` | Agents shown in the roster. |
| `Session` | `AgentRunSession` | `n/a (read-only property)` | The live session, for host pages that read status or drive it. |

#### Razor Usage Example

```razor
<TwAgentConsole />
```

---

### `TwApprovalGate`

**Location:** [`Components/UI/TwApprovalGate.razor`](../Components/UI/TwApprovalGate.razor)

Blocking approval card for pending high-risk tool calls. The agent does not execute the call until a human approves, optionally with edited JSON arguments (validated), or rejects with a reason. Announces itself to screen readers via an assertive live region.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Session` | `AgentRunSession` | `required` | Session whose pending approvals are rendered. |
| `Class` | `string?` | `null` | Custom Tailwind CSS classes. |

#### Razor Usage Example

```razor
<TwApprovalGate Session="_session" />
```

---

### `TwToolCallCard`

**Location:** [`Components/UI/TwToolCallCard.razor`](../Components/UI/TwToolCallCard.razor)

Collapsible card for one agent tool call showing streamed arguments, result, duration, risk level and a text status (never colour alone). Pending-approval calls are visually emphasised.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Call` | `ToolCallRecord` | `required` | The tool call to render. |
| `Class` | `string?` | `null` | Custom Tailwind CSS classes. |

#### Razor Usage Example

```razor
<TwToolCallCard Call="toolCall" />
```

---

### `TwTakeoverBar`

**Location:** [`Components/UI/TwTakeoverBar.razor`](../Components/UI/TwTakeoverBar.razor)

Run status strip with Take over, Hand back and Stop controls. Takeover pauses the agent before its next step so a human can inspect and edit shared state; hand-back resumes it.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Session` | `AgentRunSession` | `required` | Session to display and control. |
| `Class` | `string?` | `null` | Custom Tailwind CSS classes. |

#### Razor Usage Example

```razor
<TwTakeoverBar Session="_session" />
```

---

### `TwAgentStateInspector`

**Location:** [`Components/UI/TwAgentStateInspector.razor`](../Components/UI/TwAgentStateInspector.razor)

Live view of the state the agent shares with the UI. Changed keys are highlighted; values become editable while the human is in control, and every edit is audited and visible to the agent's next action.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Session` | `AgentRunSession` | `required` | Session whose shared state is shown. |
| `Class` | `string?` | `null` | Custom Tailwind CSS classes. |

#### Razor Usage Example

```razor
<TwAgentStateInspector Session="_session" />
```

---

### `TwAuditTrail`

**Location:** [`Components/UI/TwAuditTrail.razor`](../Components/UI/TwAuditTrail.razor)

Append-only, filterable log of who did what (human, agent, system) with a one-click JSON export for compliance review.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Session` | `AgentRunSession` | `required` | Session whose audit events are shown. |
| `Class` | `string?` | `null` | Custom Tailwind CSS classes. |

#### Razor Usage Example

```razor
<TwAuditTrail Session="_session" />
```

---

### `TwAgentRoster`

**Location:** [`Components/UI/TwAgentRoster.razor`](../Components/UI/TwAgentRoster.razor)

Accessible list of available agents (nav with aria-current) showing role, description and the selected agent's run status.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Agents` | `IReadOnlyList<AgentProfile>` | `required` | Agents to list. |
| `SelectedId` | `string?` | `null` | Id of the selected agent. |
| `StatusText` | `string` | `"Idle"` | Run status shown on the selected agent. |
| `OnSelect` | `EventCallback<AgentProfile>` | `null` | Fired when an agent is chosen. |
| `Class` | `string?` | `null` | Custom Tailwind CSS classes. |

#### Razor Usage Example

```razor
<TwAgentRoster Agents="_agents" SelectedId="@_selected" OnSelect="a => _selected = a.Id" />
```

---

## Financial & Analytical Intelligence

### `TwFinancialChart`

**Location:** [`Components/UI/TwFinancialChart.razor`](../Components/UI/TwFinancialChart.razor)

High-frequency Candlestick and Area financial charting engine with real-time volume histogram, 20-period moving average line, crosshair hover HUD inspector, timeframe range presets (1W, 1M, 3M, YTD, 1Y, ALL), and zero-JS vector SVG rendering.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Ticker` | `string` | `"BLZR"` | Configures component behavior or styling. |
| `CompanyName` | `string` | `"Blazor Technologies Inc."` | Configures component behavior or styling. |
| `Exchange` | `string` | `"NASDAQ"` | Configures component behavior or styling. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `Data` | `List<FinancialCandle>?` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwFinancialChart Ticker="BLZR" CompanyName="Blazor Technologies Inc." Exchange="NASDAQ" />
```

---

### `TwTreemap`

**Location:** [`Components/UI/TwTreemap.razor`](../Components/UI/TwTreemap.razor)

Multi-dimensional area treemap and valuation heatmap visualizing hierarchical assets, portfolio market caps, and performance returns with squarified 2D tiling, dynamic drill-down breadcrumb, and color ramps.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `"Market Valuation Heatmap & Treemap"` | Header title or accessible label. |
| `Subtitle` | `string` | `"Hierarchical squarified area map of enterprise assets and percentage price shifts"` | Header title or accessible label. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `Items` | `List<TreemapItem>?` | `null` | Configures component behavior or styling. |
| `OnItemClick` | `EventCallback<TreemapItem>` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwTreemap Title="Market Valuation Heatmap & Treemap" Subtitle="Hierarchical squarified area map of enterprise assets and percentage price shifts" CustomClass="" />
```

---

### `TwPivotGrid`

**Location:** [`Components/UI/TwPivotGrid.razor`](../Components/UI/TwPivotGrid.razor)

Enterprise OLAP cross-tabulation matrix supporting dynamic row/column field pivoting, value aggregations (Sum, Average, Count), interactive field drop drawer, and hierarchical subtotal and grand total calculations.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `"Enterprise Financial Pivot Grid"` | Header title or accessible label. |
| `Subtitle` | `string` | `"Multi-dimensional cross-tabulation matrix with real-time grouping & aggregation"` | Header title or accessible label. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `Records` | `List<PivotRecord>?` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwPivotGrid Title="Enterprise Financial Pivot Grid" Subtitle="Multi-dimensional cross-tabulation matrix with real-time grouping & aggregation" CustomClass="" />
```

---

## Developer Studio & Content Creation

### `TwIconPicker`

**Location:** [`Components/UI/TwIconPicker.razor`](../Components/UI/TwIconPicker.razor)

Interactive search-and-select icon & emoji explorer with live filtering, outline/solid toggles, size previews, and one-click Razor component snippet copying.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `"Open Source Vector Icons & Emoji Studio"` | Header title or accessible label. |
| `Subtitle` | `string` | `"Zero-dependency pure C# WASM vector icons and emojis for enterprise dashboards and forms"` | Header title or accessible label. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwIconPicker Title="Open Source Vector Icons & Emoji Studio" Subtitle="Zero-dependency pure C# WASM vector icons and emojis for enterprise dashboards and forms" CustomClass="" />
```

---

### `TwIcon`

**Location:** [`Components/UI/TwIcon.razor`](../Components/UI/TwIcon.razor)

Zero-dependency pure C# WASM inline vector SVG icon engine supporting 100+ curated icons (Heroicons & Lucide paths), customizable sizes, stroke widths, outline/solid modes, and semantic color inheritance.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Name` | `string` | `"sparkles"` | Configures component behavior or styling. |
| `Size` | `ComponentSize` | `ComponentSize.Md` | Component sizing scale (Xs, Sm, Md, Lg). |
| `IsSolid` | `bool` | `false` | Configures component behavior or styling. |
| `StrokeWidth` | `double` | `1.75` | Configures component behavior or styling. |
| `Class` | `string` | `""` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwIcon Name="sparkles" Size="ComponentSize.Md" StrokeWidth="1.75" />
```

---

### `TwEmoji`

**Location:** [`Components/UI/TwEmoji.razor`](../Components/UI/TwEmoji.razor)

Modern emoji component with shortcode mapping (:rocket:, :fire:, :sparkles:), Unicode glyph parsing, hover scale physics, and click-to-copy clipboard integration.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Shortcode` | `string?` | `null` | Configures component behavior or styling. |
| `Glyph` | `string?` | `null` | Configures component behavior or styling. |
| `Size` | `ComponentSize` | `ComponentSize.Md` | Component sizing scale (Xs, Sm, Md, Lg). |
| `AnimateOnHover` | `bool` | `true` | Configures component behavior or styling. |
| `CopyOnClick` | `bool` | `false` | Callback invoked when state changes or item is selected. |
| `Class` | `string` | `""` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwEmoji Size="ComponentSize.Md" AnimateOnHover="true" Class="" />
```

---

### `TwMarkdownEditor`

**Location:** [`Components/UI/TwMarkdownEditor.razor`](../Components/UI/TwMarkdownEditor.razor)

Enterprise-grade dual Markdown and HTML editor featuring live pure C# WASM typography preview, split/edit/preview modes, toolbar actions (headings, lists, bold, italics, code, tables), fullscreen Zen focus, and media drawer supporting image, video, audio, and link embedding.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string?` | `null` | Header title or accessible label. |
| `Value` | `string` | `""` | Primary data value or two-way bound model property. |
| `ValueChanged` | `EventCallback<string>` | `null` | Callback invoked when state changes or item is selected. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwMarkdownEditor Value="" CustomClass="" />
```

---

### `TwDockManager`

**Location:** [`Components/UI/TwDockManager.razor`](../Components/UI/TwDockManager.razor)

Desktop-grade multi-pane docking studio layout engine featuring Solution Explorer tree, multi-tab central document workspace, bottom diagnostic terminal output, and collapsible properties inspector.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string?` | `null` | Header title or accessible label. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwDockManager CustomClass="" />
```

---

### `TwSpreadsheet`

**Location:** [`Components/UI/TwSpreadsheet.razor`](../Components/UI/TwSpreadsheet.razor)

Spreadsheet calculation engine with alphanumeric grid coordinates (A1..E10), formula bar, formula evaluation (=SUM, =AVG, arithmetic), direct cell inline editing, and formatted total readouts.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `"Enterprise Spreadsheet Matrix"` | Header title or accessible label. |
| `Subtitle` | `string` | `"Excel-compatible cell matrix with live arithmetic, range aggregations, and formula bar"` | Header title or accessible label. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwSpreadsheet Title="Enterprise Spreadsheet Matrix" Subtitle="Excel-compatible cell matrix with live arithmetic, range aggregations, and formula bar" CustomClass="" />
```

---

### `TwOrgChart`

**Location:** [`Components/UI/TwOrgChart.razor`](../Components/UI/TwOrgChart.razor)

Hierarchical organization tree visualizer with pure vector SVG orthogonal connector lines, search highlight filter, recursive branch expand/collapse toggles, and A-/A+ canvas zoom controls.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `"Enterprise Organization Tree"` | Header title or accessible label. |
| `Subtitle` | `string` | `"Executive leadership structure, reporting hierarchies, and departmental clusters"` | Header title or accessible label. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `Root` | `OrgNode?` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwOrgChart Title="Enterprise Organization Tree" Subtitle="Executive leadership structure, reporting hierarchies, and departmental clusters" CustomClass="" />
```

---

## Task-Purpose Enterprise Forms

### `TwUserRegistrationForm`

**Location:** [`Components/UI/TwUserRegistrationForm.razor`](../Components/UI/TwUserRegistrationForm.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `"Create Your Account"` | Header title or accessible label. |
| `Subtitle` | `string` | `"Deploy enterprise WebAssembly apps with instant Tailwind CSS parity"` | Header title or accessible label. |
| `ShowSocialLogins` | `bool` | `true` | Configures component behavior or styling. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `OnRegistered` | `EventCallback<RegistrationModel>` | `null` | Configures component behavior or styling. |
| `OnSsoRequested` | `EventCallback<string>` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwUserRegistrationForm Title="Create Your Account" Subtitle="Deploy enterprise WebAssembly apps with instant Tailwind CSS parity" ShowSocialLogins="true" />
```

---

### `TwUserEditForm`

**Location:** [`Components/UI/TwUserEditForm.razor`](../Components/UI/TwUserEditForm.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Model` | `UserProfileModel?` | `null` | Configures component behavior or styling. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `OnSaved` | `EventCallback<UserProfileModel>` | `null` | Configures component behavior or styling. |
| `OnDeactivate` | `EventCallback` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwUserEditForm CustomClass="" />
```

---

### `TwLoginForm`

**Location:** [`Components/UI/TwLoginForm.razor`](../Components/UI/TwLoginForm.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `"Sign in to Enterprise Hub"` | Header title or accessible label. |
| `Subtitle` | `string` | `"Access mission-critical dashboards, design tokens, and components"` | Header title or accessible label. |
| `ImageUrl` | `string` | `"https://images.unsplash.com/photo-1517694712202-14dd9538aa97?auto=format&fit=crop&w=1200&q=80"` | Configures component behavior or styling. |
| `QuoteText` | `string` | `"Simplicity is prerequisite for reliability."` | Configures component behavior or styling. |
| `QuoteAuthor` | `string` | `"Edsger W. Dijkstra"` | Configures component behavior or styling. |
| `QuoteCitation` | `string` | `"Turing Award Laureate"` | Configures component behavior or styling. |
| `ShowSocialLogins` | `bool` | `true` | Configures component behavior or styling. |
| `AllowRememberMe` | `bool` | `true` | Configures component behavior or styling. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `OnLogin` | `EventCallback<LoginCredentials>` | `null` | Configures component behavior or styling. |
| `OnSsoLogin` | `EventCallback<string>` | `null` | Configures component behavior or styling. |
| `OnForgotPassword` | `EventCallback` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwLoginForm Title="Sign in to Enterprise Hub" Subtitle="Access mission-critical dashboards, design tokens, and components" ImageUrl="https://images.unsplash.com/photo-1517694712202-14dd9538aa97?auto=format&fit=crop&w=1200&q=80" />
```

---

### `TwTermsOfUseForm`

**Location:** [`Components/UI/TwTermsOfUseForm.razor`](../Components/UI/TwTermsOfUseForm.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `"Enterprise Terms of Service"` | Header title or accessible label. |
| `Version` | `string` | `"v3.2"` | Configures component behavior or styling. |
| `LastUpdated` | `string` | `"October 2026"` | Configures component behavior or styling. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `OnAccepted` | `EventCallback<TermsAcceptanceModel>` | `null` | Configures component behavior or styling. |
| `OnDeclined` | `EventCallback` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwTermsOfUseForm Title="Enterprise Terms of Service" Version="v3.2" LastUpdated="October 2026" />
```

---

### `TwCookieConsent`

**Location:** [`Components/UI/TwCookieConsent.razor`](../Components/UI/TwCookieConsent.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `"Enterprise Cookie & Privacy Settings"` | Header title or accessible label. |
| `Description` | `string` | `"We use minimal first-party cookies to secure user sessions, maintain UI state, and measure performance latency. We never sell your personal data."` | Secondary descriptive caption. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `OnSaved` | `EventCallback<CookiePreferencesModel>` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwCookieConsent Title="Enterprise Cookie & Privacy Settings" Description="We use minimal first-party cookies to secure user sessions, maintain UI state, and measure performance latency. We never sell your personal data." CustomClass="" />
```

---

### `TwPrivacyPolicyForm`

**Location:** [`Components/UI/TwPrivacyPolicyForm.razor`](../Components/UI/TwPrivacyPolicyForm.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `"Enterprise Privacy & Data Governance"` | Header title or accessible label. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `OnExportRequested` | `EventCallback<string>` | `null` | Configures component behavior or styling. |
| `OnErasureRequested` | `EventCallback` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwPrivacyPolicyForm Title="Enterprise Privacy & Data Governance" CustomClass="" />
```

---

### `TwAboutMissionForm`

**Location:** [`Components/UI/TwAboutMissionForm.razor`](../Components/UI/TwAboutMissionForm.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `MissionHeading` | `string` | `"Empowering Modern Enterprises with Zero-Latency Blazor UI"` | Configures component behavior or styling. |
| `MissionStatement` | `string` | `"Our mission is to build the world's most performant, secure, and developer-delightful component library for .NET 11 WebAssembly, bridging modern Tailwind CSS agility with enterprise-grade reliability and zero third-party telemetry."` | Configures component behavior or styling. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `OnInquirySubmitted` | `EventCallback<ContactInquiryModel>` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwAboutMissionForm MissionHeading="Empowering Modern Enterprises with Zero-Latency Blazor UI" MissionStatement="Our mission is to build the world's most performant, secure, and developer-delightful component library for .NET 11 WebAssembly, bridging modern Tailwind CSS agility with enterprise-grade reliability and zero third-party telemetry." CustomClass="" />
```

---

### `TwPledgeForm`

**Location:** [`Components/UI/TwPledgeForm.razor`](../Components/UI/TwPledgeForm.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `"Enterprise Engineering & Ethics Pledge"` | Header title or accessible label. |
| `Subtitle` | `string` | `"Legally affirmed compliance with software supply chain integrity and responsible AI"` | Header title or accessible label. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `OnPledgeAffirmed` | `EventCallback<PledgeModel>` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwPledgeForm Title="Enterprise Engineering & Ethics Pledge" Subtitle="Legally affirmed compliance with software supply chain integrity and responsible AI" CustomClass="" />
```

---

## Layout & Application Shell

### `TwAppShell`

**Location:** [`Components/Layout/TwAppShell.razor`](../Components/Layout/TwAppShell.razor)

The root application shell supporting four dynamic layout variants: Sidebar (mobile drawer + desktop sidebar), TopNav (horizontal bar with mobile sheet), CompactRail (icon rail), and Stacked (single column).

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Layout` | `LayoutVariant` | `LayoutVariant.Sidebar` | Configures component behavior or styling. |
| `BrandContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `HeaderActions` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `SidebarContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `SidebarFooter` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `TopNavContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `RailContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `BottomNavContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |

#### Razor Usage Example

```razor
<TwAppShell Layout="LayoutVariant.Sidebar" />
```

---

### `TwContainer`

**Location:** [`Components/Layout/TwContainer.razor`](../Components/Layout/TwContainer.razor)

Responsive max-width container wrapper with automatic padding and breakpoint clamping (sm, md, lg, xl, 2xl, full).

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `MaxWidth` | `string` | `"7xl"` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwContainer MaxWidth="7xl" />
```

---

### `TwGrid`

**Location:** [`Components/Layout/TwGrid.razor`](../Components/Layout/TwGrid.razor)

Mobile-first responsive grid system with configurable column distributions (1-2-3, 1-2-4, 2-3-4, etc.) and gap scales.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Preset` | `string` | `"1-2-3"` | Configures component behavior or styling. |
| `Gap` | `string` | `"md"` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwGrid Preset="1-2-3" Gap="md" />
```

---

### `TwSplitter`

**Location:** [`Components/UI/TwSplitter.razor`](../Components/UI/TwSplitter.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Orientation` | `SplitOrientation` | `SplitOrientation.Horizontal` | Configures component behavior or styling. |
| `SplitPercentage` | `double` | `40` | Configures component behavior or styling. |
| `MinPercentage` | `double` | `15` | Configures component behavior or styling. |
| `MaxPercentage` | `double` | `85` | Configures component behavior or styling. |
| `MinHeight` | `int` | `280` | Configures component behavior or styling. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `PaneOne` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `PaneTwo` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `SplitPercentageChanged` | `EventCallback<double>` | `null` | Callback invoked when state changes or item is selected. |

#### Razor Usage Example

```razor
<TwSplitter Orientation="SplitOrientation.Horizontal" SplitPercentage="40" MinPercentage="15" />
```

---

### `TwBottomNav`

**Location:** [`Components/Layout/TwBottomNav.razor`](../Components/Layout/TwBottomNav.razor)

Fixed application bottom navigation bar for touch devices with active state indicators, notification badges, and haptic tap styling.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Items` | `IReadOnlyList<NavItem>` | `Array.Empty<NavItem>()` | Configures component behavior or styling. |
| `ActiveId` | `string?` | `null` | Configures component behavior or styling. |
| `OnSelect` | `EventCallback<string>` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwBottomNav Items="Array.Empty<NavItem>()" />
```

---

## Theme & Palette Customization

### `ThemeProvider`

**Location:** [`Components/Theme/ThemeProvider.razor`](../Components/Theme/ThemeProvider.razor)

Cascading state provider managing light, dark, and system color mode preferences with localStorage synchronization and zero-FOUC initialization.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |

#### Razor Usage Example

```razor
<ThemeProvider>
    <span>Content</span>
</ThemeProvider>
```

---

### `ThemeSwitcher`

**Location:** [`Components/Theme/ThemeSwitcher.razor`](../Components/Theme/ThemeSwitcher.razor)

Segmented mode selector with accent swatches for quick switching between Light, Dark, and OS System appearance.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Compact` | `bool` | `null` | Configures component behavior or styling. |
| `ShowAccentPicker` | `bool` | `true` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<ThemeSwitcher ShowAccentPicker="true" />
```

---

### `TwThemeSelector`

**Location:** [`Components/Theme/TwThemeSelector.razor`](../Components/Theme/TwThemeSelector.razor)

Modern comprehensive color dropdown selector featuring preset palette swatches and 16M+ custom hex color picker integration.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Compact` | `bool` | `null` | Configures component behavior or styling. |
| `Alignment` | `string` | `"right"` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwThemeSelector Alignment="right" />
```

---

### `TwThemeSwitcher`

**Location:** [`Components/Theme/TwThemeSwitcher.razor`](../Components/Theme/TwThemeSwitcher.razor)

Compact pill switcher for toggling between dark, light, and system themes.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Compact` | `bool` | `null` | Configures component behavior or styling. |
| `ShowAccentPicker` | `bool` | `true` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwThemeSwitcher ShowAccentPicker="true" />
```

---

### `TwColorPicker`

**Location:** [`Components/UI/TwColorPicker.razor`](../Components/UI/TwColorPicker.razor)

Interactive 16M+ hex and RGB color picker with preview swatch, hex validation, and opacity support.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Value` | `string` | `"#6366f1"` | Primary data value or two-way bound model property. |
| `ValueChanged` | `EventCallback<string>` | `null` | Callback invoked when state changes or item is selected. |
| `Label` | `string?` | `"Pick Accent Color"` | Configures component behavior or styling. |
| `ShowValueBadge` | `bool` | `true` | Primary data value or two-way bound model property. |
| `AllowCustom` | `bool` | `true` | Configures component behavior or styling. |
| `ShowCopy` | `bool` | `true` | Configures component behavior or styling. |
| `Inline` | `bool` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwColorPicker Value="#6366f1" Label="Pick Accent Color" ShowValueBadge="true" />
```

---

## Code & Syntax Studio

### `TwCodeFontModifier`

**Location:** [`Components/UI/TwCodeFontModifier.razor`](../Components/UI/TwCodeFontModifier.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `"Code Editor & Font Toolbar"` | Header title or accessible label. |
| `FontSize` | `int` | `13` | Component sizing scale (Xs, Sm, Md, Lg). |
| `FontSizeChanged` | `EventCallback<int>` | `null` | Component sizing scale (Xs, Sm, Md, Lg). |
| `FontFamily` | `string` | `"'JetBrains Mono', monospace"` | Configures component behavior or styling. |
| `LineHeight` | `string` | `"leading-normal"` | Configures component behavior or styling. |
| `EnableLigatures` | `bool` | `true` | Configures component behavior or styling. |
| `WordWrap` | `bool` | `false` | Configures component behavior or styling. |
| `ShowLineNumbers` | `bool` | `true` | Configures component behavior or styling. |
| `ThemePreset` | `string` | `"emerald"` | Configures component behavior or styling. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `SampleCode` | `string?` | `@"// High-performance Blazor Tailwind Engine
public sealed record ComponentSpec(string Name, string Category)
{
    public bool HasDarkModeSupport => true` | Configures component behavior or styling. |
| `OnSettingsChanged` | `EventCallback<CodeFontSettings>` | `null` | Callback invoked when state changes or item is selected. |

#### Razor Usage Example

```razor
<TwCodeFontModifier Title="Code Editor & Font Toolbar" FontSize="13" FontFamily="'JetBrains Mono', monospace" />
```

---

### `TwCodeTabs`

**Location:** [`Components/UI/TwCodeTabs.razor`](../Components/UI/TwCodeTabs.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Tabs` | `IReadOnlyList<CodeTab>` | `Array.Empty<CodeTab>()` | Configures component behavior or styling. |
| `ShowLineNumbers` | `bool` | `true` | Configures component behavior or styling. |
| `AllowCopy` | `bool` | `true` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwCodeTabs Tabs="Array.Empty<CodeTab>()" ShowLineNumbers="true" AllowCopy="true" />
```

---

### `TwCodeDiff`

**Location:** [`Components/UI/TwCodeDiff.razor`](../Components/UI/TwCodeDiff.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `FileName` | `string` | `"diff.razor"` | Configures component behavior or styling. |
| `Lines` | `IReadOnlyList<DiffLine>` | `Array.Empty<DiffLine>()` | Configures component behavior or styling. |
| `OldCode` | `string?` | `null` | Configures component behavior or styling. |
| `NewCode` | `string?` | `null` | Configures component behavior or styling. |
| `AllowCopy` | `bool` | `true` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwCodeDiff FileName="diff.razor" Lines="Array.Empty<DiffLine>()" AllowCopy="true" />
```

---

### `TwSnippet`

**Location:** [`Components/UI/TwSnippet.razor`](../Components/UI/TwSnippet.razor)

macOS terminal CLI command snippet container with prompt badges, window controls, and one-click copy transition.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Code` | `string` | `""` | Configures component behavior or styling. |
| `Prefix` | `string` | `"$"` | Configures component behavior or styling. |
| `Title` | `string?` | `null` | Header title or accessible label. |
| `ShowHeader` | `bool` | `true` | Configures component behavior or styling. |
| `ShowWindowControls` | `bool` | `true` | Configures component behavior or styling. |
| `ShowCopyButton` | `bool` | `true` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwSnippet Code="" Prefix="$" ShowHeader="true" />
```

---

### `TwCodeBlock`

**Location:** [`Components/UI/TwCodeBlock.razor`](../Components/UI/TwCodeBlock.razor)

Syntax code viewer with language badges, line numbers, and copy-to-clipboard button.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Code` | `string` | `string.Empty` | Configures component behavior or styling. |
| `Language` | `string?` | `"razor"` | Configures component behavior or styling. |
| `FileName` | `string?` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwCodeBlock Code="string.Empty" Language="razor" />
```

---

## Advanced Forms & Inputs

### `TwFilterBuilder`

**Location:** [`Components/UI/TwFilterBuilder.razor`](../Components/UI/TwFilterBuilder.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `"Visual Query & Filter Builder"` | Header title or accessible label. |
| `RootGroup` | `FilterGroup` | `new()` | Configures component behavior or styling. |
| `AvailableFields` | `List<FieldDefinition>` | `new()` | Configures component behavior or styling. |
| `ShowPreview` | `bool` | `true` | Configures component behavior or styling. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `OnFilterChanged` | `EventCallback<FilterGroup>` | `null` | Callback invoked when state changes or item is selected. |

#### Razor Usage Example

```razor
<TwFilterBuilder Title="Visual Query & Filter Builder" RootGroup="new()" AvailableFields="new()" />
```

---

### `TwDropzone`

**Location:** [`Components/UI/TwDropzone.razor`](../Components/UI/TwDropzone.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `AllowMultiple` | `bool` | `true` | Configures component behavior or styling. |
| `AcceptedExtensions` | `string` | `".png, .jpg, .pdf, .zip, .cs, .json"` | Configures component behavior or styling. |
| `MaxFileSizeMb` | `int` | `25` | Component sizing scale (Xs, Sm, Md, Lg). |
| `Files` | `List<DropzoneFile>` | `new()` | Configures component behavior or styling. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `FilesChanged` | `EventCallback<List<DropzoneFile>>` | `null` | Callback invoked when state changes or item is selected. |

#### Razor Usage Example

```razor
<TwDropzone AllowMultiple="true" AcceptedExtensions=".png, .jpg, .pdf, .zip, .cs, .json" MaxFileSizeMb="25" />
```

---

### `TwOtpInput`

**Location:** [`Components/UI/TwOtpInput.razor`](../Components/UI/TwOtpInput.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Length` | `int` | `6` | Configures component behavior or styling. |
| `Value` | `string` | `""` | Primary data value or two-way bound model property. |
| `ValueChanged` | `EventCallback<string>` | `null` | Callback invoked when state changes or item is selected. |
| `OnCompleted` | `EventCallback<string>` | `null` | Configures component behavior or styling. |
| `Masked` | `bool` | `null` | Configures component behavior or styling. |
| `Disabled` | `bool` | `null` | Disables user interaction and applies muted opacity styling. |
| `HasError` | `bool` | `null` | Configures component behavior or styling. |
| `ErrorMessage` | `string?` | `null` | Configures component behavior or styling. |
| `Label` | `string?` | `null` | Configures component behavior or styling. |
| `HelperText` | `string?` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwOtpInput Length="6" Value="" />
```

---

### `TwPasswordStrength`

**Location:** [`Components/UI/TwPasswordStrength.razor`](../Components/UI/TwPasswordStrength.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Value` | `string` | `""` | Primary data value or two-way bound model property. |
| `ValueChanged` | `EventCallback<string>` | `null` | Callback invoked when state changes or item is selected. |
| `Label` | `string` | `"Password"` | Configures component behavior or styling. |
| `Placeholder` | `string` | `"Enter a secure password..."` | Input placeholder hint. |
| `ShowChecklist` | `bool` | `true` | Configures component behavior or styling. |
| `Disabled` | `bool` | `null` | Disables user interaction and applies muted opacity styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwPasswordStrength Value="" Label="Password" Placeholder="Enter a secure password..." />
```

---

### `TwCombobox`

**Location:** [`Components/UI/TwCombobox.razor`](../Components/UI/TwCombobox.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Value` | `string` | `""` | Primary data value or two-way bound model property. |
| `ValueChanged` | `EventCallback<string>` | `null` | Callback invoked when state changes or item is selected. |
| `Items` | `IReadOnlyList<ComboboxItem>` | `Array.Empty<ComboboxItem>()` | Configures component behavior or styling. |
| `Label` | `string` | `""` | Configures component behavior or styling. |
| `Placeholder` | `string` | `"Select or search option..."` | Input placeholder hint. |
| `Disabled` | `bool` | `null` | Disables user interaction and applies muted opacity styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwCombobox Value="" Items="Array.Empty<ComboboxItem>()" Label="" />
```

---

### `TwTagsInput`

**Location:** [`Components/UI/TwTagsInput.razor`](../Components/UI/TwTagsInput.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Tags` | `List<string>` | `new()` | Configures component behavior or styling. |
| `TagsChanged` | `EventCallback<List<string>>` | `null` | Callback invoked when state changes or item is selected. |
| `Label` | `string` | `""` | Configures component behavior or styling. |
| `Placeholder` | `string` | `"Type tag and press Enter..."` | Input placeholder hint. |
| `HelperText` | `string?` | `null` | Configures component behavior or styling. |
| `MaxTags` | `int?` | `null` | Configures component behavior or styling. |
| `AllowDuplicates` | `bool` | `false` | Configures component behavior or styling. |
| `Disabled` | `bool` | `null` | Disables user interaction and applies muted opacity styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwTagsInput Tags="new()" Label="" Placeholder="Type tag and press Enter..." />
```

---

### `TwInputGroup`

**Location:** [`Components/UI/TwInputGroup.razor`](../Components/UI/TwInputGroup.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Value` | `string` | `""` | Primary data value or two-way bound model property. |
| `ValueChanged` | `EventCallback<string>` | `null` | Callback invoked when state changes or item is selected. |
| `Label` | `string` | `""` | Configures component behavior or styling. |
| `Type` | `string` | `"text"` | Configures component behavior or styling. |
| `Placeholder` | `string` | `""` | Input placeholder hint. |
| `PrependText` | `string?` | `null` | Configures component behavior or styling. |
| `AppendText` | `string?` | `null` | Configures component behavior or styling. |
| `PrependContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `AppendContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `HelperText` | `string?` | `null` | Configures component behavior or styling. |
| `ErrorMessage` | `string?` | `null` | Configures component behavior or styling. |
| `HasError` | `bool` | `null` | Configures component behavior or styling. |
| `Disabled` | `bool` | `null` | Disables user interaction and applies muted opacity styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwInputGroup Value="" Label="" Type="text" />
```

---

## Typography, Badges & Keys

### `TwPill`

**Location:** [`Components/UI/TwPill.razor`](../Components/UI/TwPill.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Text` | `string?` | `null` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Variant` | `string` | `"Soft"` | Semantic visual variant (e.g. Primary, Secondary, Outline). |
| `Color` | `string` | `"Brand"` | Configures component behavior or styling. |
| `Size` | `string` | `"md"` | Component sizing scale (Xs, Sm, Md, Lg). |
| `ShowDot` | `bool` | `false` | Configures component behavior or styling. |
| `PulseDot` | `bool` | `false` | Configures component behavior or styling. |
| `AvatarUrl` | `string?` | `null` | Configures component behavior or styling. |
| `Icon` | `string?` | `null` | Configures component behavior or styling. |
| `Count` | `int?` | `null` | Configures component behavior or styling. |
| `Removable` | `bool` | `false` | Configures component behavior or styling. |
| `Clickable` | `bool` | `false` | Configures component behavior or styling. |
| `Selected` | `bool` | `false` | Configures component behavior or styling. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `OnClick` | `EventCallback` | `null` | Callback invoked when state changes or item is selected. |
| `OnDismiss` | `EventCallback` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwPill Variant="Soft" Color="Brand" Size="md" />
```

---

### `TwPillGroup`

**Location:** [`Components/UI/TwPillGroup.razor`](../Components/UI/TwPillGroup.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Items` | `List<PillItem>` | `new()` | Configures component behavior or styling. |
| `SelectedValues` | `List<string>` | `new()` | Primary data value or two-way bound model property. |
| `SelectedValuesChanged` | `EventCallback<List<string>>` | `null` | Callback invoked when state changes or item is selected. |
| `MultiSelect` | `bool` | `false` | Configures component behavior or styling. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |

#### Razor Usage Example

```razor
<TwPillGroup Items="new()" SelectedValues="new()" CustomClass="" />
```

---

### `TwBadge`

**Location:** [`Components/UI/TwBadge.razor`](../Components/UI/TwBadge.razor)

Status and counter badge supporting semantic colors (Primary, Success, Warning, Danger, Info), rounded pill styling, and optional pulsing status dots.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Variant` | `SemanticVariant` | `SemanticVariant.Default` | Semantic visual variant (e.g. Primary, Secondary, Outline). |
| `ShowDot` | `bool` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwBadge Variant="SemanticVariant.Default" />
```

---

### `TwNotificationBadge`

**Location:** [`Components/UI/TwNotificationBadge.razor`](../Components/UI/TwNotificationBadge.razor)

Floating count badge designed to overlay icons or avatars for unread alerts and incoming message counters.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Visible` | `bool` | `true` | Configures component behavior or styling. |
| `DotOnly` | `bool` | `null` | Configures component behavior or styling. |
| `ShowPing` | `bool` | `null` | Configures component behavior or styling. |
| `Count` | `int` | `null` | Configures component behavior or styling. |
| `MaxCount` | `int` | `99` | Configures component behavior or styling. |
| `Variant` | `SemanticVariant` | `SemanticVariant.Danger` | Semantic visual variant (e.g. Primary, Secondary, Outline). |
| `Placement` | `BadgePlacement` | `BadgePlacement.TopRight` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwNotificationBadge Visible="true" MaxCount="99" Variant="SemanticVariant.Danger" />
```

---

### `TwChip`

**Location:** [`Components/UI/TwChip.razor`](../Components/UI/TwChip.razor)

Interactive tag chip with optional leading icon, selectable toggle state, and dismissible close button.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Text` | `string?` | `null` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `LeadingIcon` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `AvatarContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `Variant` | `SemanticVariant` | `SemanticVariant.Default` | Semantic visual variant (e.g. Primary, Secondary, Outline). |
| `Size` | `ComponentSize` | `ComponentSize.Sm` | Component sizing scale (Xs, Sm, Md, Lg). |
| `Outlined` | `bool` | `null` | Configures component behavior or styling. |
| `Selectable` | `bool` | `null` | Configures component behavior or styling. |
| `Selected` | `bool` | `null` | Configures component behavior or styling. |
| `SelectedChanged` | `EventCallback<bool>` | `null` | Callback invoked when state changes or item is selected. |
| `Removable` | `bool` | `null` | Configures component behavior or styling. |
| `OnRemove` | `EventCallback` | `null` | Configures component behavior or styling. |
| `OnClick` | `EventCallback` | `null` | Callback invoked when state changes or item is selected. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwChip Variant="SemanticVariant.Default" Size="ComponentSize.Sm" />
```

---

### `TwChipGroup`

**Location:** [`Components/UI/TwChipGroup.razor`](../Components/UI/TwChipGroup.razor)

Container for managing groups of filter chips with single-select or multi-select modes.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwChipGroup>
    <span>Content</span>
</TwChipGroup>
```

---

### `TwKbd`

**Location:** [`Components/UI/TwKbd.razor`](../Components/UI/TwKbd.razor)

3D-embossed tactile keyboard shortcut badge with automatic modifier symbol mapping (⌘, ⌥, ⇧, ⌃, ↵, ⎋, ←, →).

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Key` | `string?` | `null` | Configures component behavior or styling. |
| `Size` | `string` | `"md"` | Component sizing scale (Xs, Sm, Md, Lg). |
| `Variant` | `string` | `"default"` | Semantic visual variant (e.g. Primary, Secondary, Outline). |
| `Tooltip` | `string?` | `null` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwKbd Size="md" Variant="default" />
```

---

### `TwDivider`

**Location:** [`Components/UI/TwDivider.razor`](../Components/UI/TwDivider.razor)

Subtle horizontal or vertical divider with optional centered text or icon badge.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Text` | `string?` | `null` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwDivider>
    <span>Content</span>
</TwDivider>
```

---

## Buttons, Forms & Controls

### `TwDateRangePicker`

**Location:** [`Components/UI/TwDateRangePicker.razor`](../Components/UI/TwDateRangePicker.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Label` | `string?` | `"Date Range Selection"` | Configures component behavior or styling. |
| `StartDate` | `DateTime` | `DateTime.Today.AddDays(-14)` | Configures component behavior or styling. |
| `EndDate` | `DateTime` | `DateTime.Today` | Configures component behavior or styling. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwDateRangePicker Label="Date Range Selection" StartDate="DateTime.Today.AddDays(-14)" EndDate="DateTime.Today" />
```

---

### `TwButton`

**Location:** [`Components/UI/TwButton.razor`](../Components/UI/TwButton.razor)

Tactile interactive button featuring 44px touch targets, loading spinner state, semantic variants, and mobile full-width responsive expansion.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `LeadingIcon` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `TrailingIcon` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `Variant` | `ButtonVariant` | `ButtonVariant.Primary` | Semantic visual variant (e.g. Primary, Secondary, Outline). |
| `Size` | `ComponentSize` | `ComponentSize.Md` | Component sizing scale (Xs, Sm, Md, Lg). |
| `Type` | `string` | `"button"` | Configures component behavior or styling. |
| `Disabled` | `bool` | `null` | Disables user interaction and applies muted opacity styling. |
| `Loading` | `bool` | `null` | Displays animated loading spinner indicator. |
| `ResponsiveFullWidth` | `bool` | `null` | Configures component behavior or styling. |
| `FullWidth` | `bool` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |
| `OnClick` | `EventCallback<MouseEventArgs>` | `null` | Callback invoked when state changes or item is selected. |

#### Razor Usage Example

```razor
<TwButton Variant="ButtonVariant.Primary" Size="ComponentSize.Md" Type="button" />
```

---

### `TwInput`

**Location:** [`Components/UI/TwInput.razor`](../Components/UI/TwInput.razor)

Accessible text input with validation error states, helper text slots, leading/trailing icons, and clear button.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Label` | `string?` | `null` | Configures component behavior or styling. |
| `Value` | `string?` | `null` | Primary data value or two-way bound model property. |
| `ValueChanged` | `EventCallback<string?>` | `null` | Callback invoked when state changes or item is selected. |
| `Placeholder` | `string?` | `null` | Input placeholder hint. |
| `Type` | `string` | `"text"` | Configures component behavior or styling. |
| `HelperText` | `string?` | `null` | Configures component behavior or styling. |
| `ErrorText` | `string?` | `null` | Configures component behavior or styling. |
| `Required` | `bool` | `null` | Configures component behavior or styling. |
| `Disabled` | `bool` | `null` | Disables user interaction and applies muted opacity styling. |
| `PrefixContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `SuffixContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwInput Type="text" />
```

---

### `TwSelect`

**Location:** [`Components/UI/TwSelect.razor`](../Components/UI/TwSelect.razor)

Styled select dropdown with floating labels, option groups, and dark mode contrast.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Label` | `string?` | `null` | Configures component behavior or styling. |
| `Value` | `string?` | `null` | Primary data value or two-way bound model property. |
| `ValueChanged` | `EventCallback<string?>` | `null` | Callback invoked when state changes or item is selected. |
| `HelperText` | `string?` | `null` | Configures component behavior or styling. |
| `Disabled` | `bool` | `null` | Disables user interaction and applies muted opacity styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwSelect>
    <span>Content</span>
</TwSelect>
```

---

### `TwSwitch`

**Location:** [`Components/UI/TwSwitch.razor`](../Components/UI/TwSwitch.razor)

Accessible toggle switch with smooth spring transitions and screen-reader label binding.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Checked` | `bool` | `null` | Configures component behavior or styling. |
| `CheckedChanged` | `EventCallback<bool>` | `null` | Callback invoked when state changes or item is selected. |
| `Label` | `string?` | `null` | Configures component behavior or styling. |
| `Description` | `string?` | `null` | Secondary descriptive caption. |
| `Disabled` | `bool` | `null` | Disables user interaction and applies muted opacity styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwSwitch />
```

---

### `TwCheckbox`

**Location:** [`Components/UI/TwCheckbox.razor`](../Components/UI/TwCheckbox.razor)

Touch-friendly checkbox with animated checkmark and focus ring styling.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Checked` | `bool` | `null` | Configures component behavior or styling. |
| `CheckedChanged` | `EventCallback<bool>` | `null` | Callback invoked when state changes or item is selected. |
| `Label` | `string?` | `null` | Configures component behavior or styling. |
| `Description` | `string?` | `null` | Secondary descriptive caption. |
| `Disabled` | `bool` | `null` | Disables user interaction and applies muted opacity styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwCheckbox />
```

---

### `TwSlider`

**Location:** [`Components/UI/TwSlider.razor`](../Components/UI/TwSlider.razor)

Touch-friendly range slider with draggable thumb, track fill, and live value bubble readout.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Value` | `double` | `50` | Primary data value or two-way bound model property. |
| `ValueChanged` | `EventCallback<double>` | `null` | Callback invoked when state changes or item is selected. |
| `Min` | `double` | `0` | Configures component behavior or styling. |
| `Max` | `double` | `100` | Configures component behavior or styling. |
| `Step` | `double` | `1` | Configures component behavior or styling. |
| `Label` | `string?` | `null` | Configures component behavior or styling. |
| `ValueUnit` | `string?` | `"%"` | Primary data value or two-way bound model property. |
| `ShowValue` | `bool` | `true` | Primary data value or two-way bound model property. |
| `Disabled` | `bool` | `null` | Disables user interaction and applies muted opacity styling. |
| `HelperText` | `string?` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwSlider Value="50" Min="0" Max="100" />
```

---

### `TwNumeric`

**Location:** [`Components/UI/TwNumeric.razor`](../Components/UI/TwNumeric.razor)

Precise numeric stepper input with increment/decrement buttons, min/max clamping, and step intervals.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Value` | `double` | `null` | Primary data value or two-way bound model property. |
| `ValueChanged` | `EventCallback<double>` | `null` | Callback invoked when state changes or item is selected. |
| `Label` | `string?` | `null` | Configures component behavior or styling. |
| `HelperText` | `string?` | `null` | Configures component behavior or styling. |
| `Prefix` | `string?` | `null` | Configures component behavior or styling. |
| `Suffix` | `string?` | `null` | Configures component behavior or styling. |
| `Min` | `double` | `0` | Configures component behavior or styling. |
| `Max` | `double` | `100` | Configures component behavior or styling. |
| `Step` | `double` | `1` | Configures component behavior or styling. |
| `Required` | `bool` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwNumeric Min="0" Max="100" Step="1" />
```

---

### `TwDatePicker`

**Location:** [`Components/UI/TwDatePicker.razor`](../Components/UI/TwDatePicker.razor)

Accessible date picker with calendar popover, quick range presets, and international date formatting.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Value` | `DateTime?` | `null` | Primary data value or two-way bound model property. |
| `ValueChanged` | `EventCallback<DateTime?>` | `null` | Callback invoked when state changes or item is selected. |
| `Label` | `string?` | `null` | Configures component behavior or styling. |
| `Placeholder` | `string` | `"Select date..."` | Input placeholder hint. |
| `DateFormat` | `string` | `"MMM dd, yyyy"` | Configures component behavior or styling. |
| `AllowClear` | `bool` | `true` | Configures component behavior or styling. |
| `Required` | `bool` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwDatePicker Placeholder="Select date..." DateFormat="MMM dd, yyyy" AllowClear="true" />
```

---

### `TwFileUpload`

**Location:** [`Components/UI/TwFileUpload.razor`](../Components/UI/TwFileUpload.razor)

Drag-and-drop file upload zone with file size validation, mime type filtering, and upload progress visualization.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Label` | `string?` | `"Upload Documents or Media"` | Configures component behavior or styling. |
| `HelperText` | `string?` | `null` | Configures component behavior or styling. |
| `Required` | `bool` | `null` | Configures component behavior or styling. |
| `Multiple` | `bool` | `true` | Configures component behavior or styling. |
| `Accept` | `string` | `".png,.jpg,.jpeg,.svg,.pdf,.zip"` | Configures component behavior or styling. |
| `MaxFileSize` | `long` | `10 * 1024 * 1024` | Component sizing scale (Xs, Sm, Md, Lg). |
| `FilesChanged` | `EventCallback<IReadOnlyList<IBrowserFile>>` | `null` | Callback invoked when state changes or item is selected. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwFileUpload Label="Upload Documents or Media" Multiple="true" Accept=".png,.jpg,.jpeg,.svg,.pdf,.zip" />
```

---

### `TwSegmented`

**Location:** [`Components/UI/TwSegmented.razor`](../Components/UI/TwSegmented.razor)

iOS-style segmented control pill for switching between mutually exclusive views with sliding background highlight.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Items` | `IReadOnlyList<SegmentItem>` | `Array.Empty<SegmentItem>()` | Configures component behavior or styling. |
| `Value` | `string` | `""` | Primary data value or two-way bound model property. |
| `ValueChanged` | `EventCallback<string>` | `null` | Callback invoked when state changes or item is selected. |
| `FullWidth` | `bool` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwSegmented Items="Array.Empty<SegmentItem>()" Value="" />
```

---

### `TwRating`

**Location:** [`Components/UI/TwRating.razor`](../Components/UI/TwRating.razor)

Interactive star rating component supporting full and half-star ratings with hover preview and read-only display mode.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Value` | `int` | `4` | Primary data value or two-way bound model property. |
| `ValueChanged` | `EventCallback<int>` | `null` | Callback invoked when state changes or item is selected. |
| `MaxStars` | `int` | `5` | Configures component behavior or styling. |
| `ReadOnly` | `bool` | `null` | Configures component behavior or styling. |
| `ShowValueText` | `bool` | `true` | Primary data value or two-way bound model property. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwRating Value="4" MaxStars="5" ShowValueText="true" />
```

---

## Cards, Grids & Bento Systems

### `TwCard`

**Location:** [`Components/UI/TwCard.razor`](../Components/UI/TwCard.razor)

Modular card container with header, body, and footer slots, subtle hover lift, and glassmorphic borders.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string?` | `null` | Header title or accessible label. |
| `Subtitle` | `string?` | `null` | Header title or accessible label. |
| `Hoverable` | `bool` | `null` | Configures component behavior or styling. |
| `NoPadding` | `bool` | `null` | Configures component behavior or styling. |
| `HeaderContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `FooterContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwCard>
    <span>Content</span>
</TwCard>
```

---

### `TwBentoGrid`

**Location:** [`Components/UI/TwBentoGrid.razor`](../Components/UI/TwBentoGrid.razor)

Modern asymmetrical CSS grid for showcasing features with radial mouse-following spotlight gradients.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Cols` | `int` | `3` | Configures component behavior or styling. |
| `GapClass` | `string` | `"gap-4 sm:gap-6"` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |

#### Razor Usage Example

```razor
<TwBentoGrid Cols="3" GapClass="gap-4 sm:gap-6" />
```

---

### `TwBentoCard`

**Location:** [`Components/UI/TwBentoCard.razor`](../Components/UI/TwBentoCard.razor)

Card item for Bento grids with customizable column/row spans, glowing borders, and feature badge slots.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `ColSpan` | `int` | `1` | Configures component behavior or styling. |
| `RowSpan` | `int` | `1` | Configures component behavior or styling. |
| `Title` | `string?` | `null` | Header title or accessible label. |
| `Description` | `string?` | `null` | Secondary descriptive caption. |
| `Icon` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `Badge` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Footer` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `ShowDotPattern` | `bool` | `true` | Configures component behavior or styling. |
| `SpotlightColor` | `string` | `"rgba(99, 102, 241, 0.12)"` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwBentoCard ColSpan="1" RowSpan="1" ShowDotPattern="true" />
```

---

### `TwStatCard`

**Location:** [`Components/UI/TwStatCard.razor`](../Components/UI/TwStatCard.razor)

SaaS metric KPI card with sparklines, percentage change indicators, and target progress bars.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `""` | Header title or accessible label. |
| `Value` | `string` | `""` | Primary data value or two-way bound model property. |
| `Subtitle` | `string?` | `null` | Header title or accessible label. |
| `TrendText` | `string?` | `null` | Configures component behavior or styling. |
| `IsTrendPositive` | `bool` | `true` | Configures component behavior or styling. |
| `ProgressValue` | `int?` | `null` | Primary data value or two-way bound model property. |
| `IconContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `IconBgClass` | `string` | `"bg-brand-50 dark:bg-brand-500/10"` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwStatCard Title="" Value="" IsTrendPositive="true" />
```

---

### `TwKpiMetric`

**Location:** [`Components/UI/TwKpiMetric.razor`](../Components/UI/TwKpiMetric.razor)

Compact micro-metric card with live animated count-up and cubic ease-out transitions.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `string.Empty` | Header title or accessible label. |
| `Value` | `string` | `string.Empty` | Primary data value or two-way bound model property. |
| `Subtitle` | `string?` | `null` | Header title or accessible label. |
| `ChangePercentage` | `double?` | `null` | Configures component behavior or styling. |
| `SparklineData` | `IReadOnlyList<double>?` | `null` | Configures component behavior or styling. |
| `Color` | `string?` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwKpiMetric Title="string.Empty" Value="string.Empty" />
```

---

### `TwMediaCard`

**Location:** [`Components/UI/TwMediaCard.razor`](../Components/UI/TwMediaCard.razor)

Rich media card with 16:9 aspect ratio image header, category badges, author avatar, and reading time.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `""` | Header title or accessible label. |
| `Description` | `string?` | `null` | Secondary descriptive caption. |
| `ImageUrl` | `string?` | `null` | Configures component behavior or styling. |
| `ImageAlt` | `string` | `"Media cover"` | Configures component behavior or styling. |
| `CategoryBadge` | `string?` | `null` | Configures component behavior or styling. |
| `AuthorName` | `string?` | `null` | Configures component behavior or styling. |
| `AuthorInitials` | `string` | `"AM"` | Configures component behavior or styling. |
| `DateText` | `string?` | `null` | Configures component behavior or styling. |
| `Tags` | `IReadOnlyList<string>?` | `null` | Configures component behavior or styling. |
| `ActionContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `OnClick` | `EventCallback<MouseEventArgs>` | `null` | Callback invoked when state changes or item is selected. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwMediaCard Title="" ImageAlt="Media cover" AuthorInitials="AM" />
```

---

### `TwFeatureCard`

**Location:** [`Components/UI/TwFeatureCard.razor`](../Components/UI/TwFeatureCard.razor)

Service feature card with gradient background icon, bold headline, and subtle hover scale.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `""` | Header title or accessible label. |
| `Description` | `string` | `""` | Secondary descriptive caption. |
| `BadgeText` | `string?` | `null` | Configures component behavior or styling. |
| `LinkText` | `string?` | `"Explore feature"` | Configures component behavior or styling. |
| `IconGradientClass` | `string` | `"bg-gradient-to-tr from-brand-600 to-indigo-500"` | Configures component behavior or styling. |
| `IconContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `OnClick` | `EventCallback<MouseEventArgs>` | `null` | Callback invoked when state changes or item is selected. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwFeatureCard Title="" Description="" LinkText="Explore feature" />
```

---

### `TwSpotlightCard`

**Location:** [`Components/UI/TwSpotlightCard.razor`](../Components/UI/TwSpotlightCard.razor)

Interactive card that calculates cursor coordinates to project a dynamic radial spotlight beam across its surface.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `SpotlightColor` | `string` | `"rgba(99, 102, 241, 0.15)"` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwSpotlightCard SpotlightColor="rgba(99, 102, 241, 0.15)" />
```

---

### `TwPricingCard`

**Location:** [`Components/UI/TwPricingCard.razor`](../Components/UI/TwPricingCard.razor)

SaaS subscription pricing tier card with popular badge highlight, price per interval, and feature checklist.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `PlanName` | `string` | `"Pro"` | Configures component behavior or styling. |
| `Description` | `string?` | `null` | Secondary descriptive caption. |
| `Price` | `string` | `"$29"` | Configures component behavior or styling. |
| `Interval` | `string` | `"mo"` | Configures component behavior or styling. |
| `IsPopular` | `bool` | `null` | Configures component behavior or styling. |
| `Features` | `IReadOnlyList<string>?` | `null` | Configures component behavior or styling. |
| `CtaText` | `string` | `"Get Started"` | Configures component behavior or styling. |
| `OnClick` | `EventCallback<MouseEventArgs>` | `null` | Callback invoked when state changes or item is selected. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwPricingCard PlanName="Pro" Price="$29" Interval="mo" />
```

---

### `TwPricingTable`

**Location:** [`Components/UI/TwPricingTable.razor`](../Components/UI/TwPricingTable.razor)

Full billing cycle matrix comparing Free, Pro, and Enterprise tiers with monthly/annual toggle.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Tiers` | `List<PricingTier>` | `new()` | Configures component behavior or styling. |
| `OnSelectTier` | `EventCallback<PricingTier>` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwPricingTable Tiers="new()" />
```

---

## Enterprise Data & Tables

### `TwKanbanBoard`

**Location:** [`Components/UI/TwKanbanBoard.razor`](../Components/UI/TwKanbanBoard.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `"Sprint Workflow Kanban"` | Header title or accessible label. |
| `Columns` | `List<KanbanColumn>` | `new()` | Configures component behavior or styling. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `OnCardMoved` | `EventCallback<KanbanCard>` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwKanbanBoard Title="Sprint Workflow Kanban" Columns="new()" CustomClass="" />
```

---

### `TwDataGrid`

**Location:** [`Components/UI/TwDataGrid.razor`](../Components/UI/TwDataGrid.razor)

High-performance enterprise data grid with column sorting, per-column text filters, column width constraints, pagination, and row-level record actions.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Items` | `IEnumerable<TItem>` | `Enumerable.Empty<TItem>()` | Configures component behavior or styling. |
| `Columns` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `ActionsTemplate` | `RenderFragment<TItem>?` | `null` | Configures component behavior or styling. |
| `MobileCardTemplate` | `RenderFragment<TItem>?` | `null` | Configures component behavior or styling. |
| `BatchActionsTemplate` | `RenderFragment<IReadOnlyList<TItem>>?` | `null` | Configures component behavior or styling. |
| `ActionsTitle` | `string` | `"Actions"` | Header title or accessible label. |
| `EmptyText` | `string` | `"No records found matching your criteria."` | Configures component behavior or styling. |
| `Selectable` | `bool` | `null` | Configures component behavior or styling. |
| `ShowGlobalSearch` | `bool` | `true` | Configures component behavior or styling. |
| `SearchPlaceholder` | `string` | `"Search all records..."` | Input placeholder hint. |
| `SearchPredicate` | `Func<TItem, string, bool>?` | `null` | Configures component behavior or styling. |
| `AllowColumnFiltering` | `bool` | `true` | Configures component behavior or styling. |
| `ShowPagination` | `bool` | `true` | Configures component behavior or styling. |
| `PageSize` | `int` | `5` | Component sizing scale (Xs, Sm, Md, Lg). |
| `ShowPageSizeSelector` | `bool` | `true` | Component sizing scale (Xs, Sm, Md, Lg). |
| `CurrentPage` | `int` | `1` | Configures component behavior or styling. |
| `CurrentPageChanged` | `EventCallback<int>` | `null` | Callback invoked when state changes or item is selected. |
| `SelectionChanged` | `EventCallback<IReadOnlyList<TItem>>` | `null` | Callback invoked when state changes or item is selected. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwDataGrid Items="Enumerable.Empty<TItem>()" ActionsTitle="Actions" EmptyText="No records found matching your criteria." />
```

---

### `TwDataGridColumn`

**Location:** [`Components/UI/TwDataGridColumn.razor`](../Components/UI/TwDataGridColumn.razor)

Declarative column definition for TwDataGrid specifying field binding, title, sortable flag, and custom cell templates.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `""` | Header title or accessible label. |
| `Property` | `Func<TItem, object?>?` | `null` | Configures component behavior or styling. |
| `SortBy` | `Func<TItem, object?>?` | `null` | Configures component behavior or styling. |
| `Sortable` | `bool` | `true` | Configures component behavior or styling. |
| `Filterable` | `bool` | `true` | Configures component behavior or styling. |
| `FilterPlaceholder` | `string?` | `null` | Input placeholder hint. |
| `Width` | `string?` | `null` | Configures component behavior or styling. |
| `MinWidth` | `string?` | `null` | Configures component behavior or styling. |
| `MaxWidth` | `string?` | `null` | Configures component behavior or styling. |
| `Align` | `string` | `"left"` | Configures component behavior or styling. |
| `CellTemplate` | `RenderFragment<TItem>?` | `null` | Configures component behavior or styling. |
| `HeaderTemplate` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `FilterTemplate` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `HeaderClass` | `string?` | `null` | Configures component behavior or styling. |
| `CellClass` | `string?` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwDataGridColumn Title="" Sortable="true" Filterable="true" />
```

---

### `TwDataTable`

**Location:** [`Components/UI/TwDataTable.razor`](../Components/UI/TwDataTable.razor)

Generic table component that automatically transforms into touch-friendly stacked cards on mobile screens.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Items` | `IReadOnlyList<TItem>` | `Array.Empty<TItem>()` | Configures component behavior or styling. |
| `TableHeader` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `RowTemplate` | `RenderFragment<TItem>` | `default!` | Configures component behavior or styling. |
| `MobileTemplate` | `RenderFragment<TItem>?` | `null` | Configures component behavior or styling. |
| `EmptyText` | `string` | `"No records found"` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwDataTable Items="Array.Empty<TItem>()" RowTemplate="default!" EmptyText="No records found" />
```

---

### `TwPagination`

**Location:** [`Components/UI/TwPagination.razor`](../Components/UI/TwPagination.razor)

Responsive pagination control showing Prev/Next on mobile devices and numbered page pills on desktop.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `CurrentPage` | `int` | `1` | Configures component behavior or styling. |
| `TotalPages` | `int` | `1` | Configures component behavior or styling. |
| `CurrentPageChanged` | `EventCallback<int>` | `null` | Callback invoked when state changes or item is selected. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwPagination CurrentPage="1" TotalPages="1" />
```

---

### `TwTree`

**Location:** [`Components/UI/TwTree.razor`](../Components/UI/TwTree.razor)

Hierarchical tree view component with expandable/collapsible nodes and selection tracking.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `SelectedId` | `string?` | `null` | Configures component behavior or styling. |
| `SelectedIdChanged` | `EventCallback<string>` | `null` | Callback invoked when state changes or item is selected. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwTree>
    <span>Content</span>
</TwTree>
```

---

### `TwTreeItem`

**Location:** [`Components/UI/TwTreeItem.razor`](../Components/UI/TwTreeItem.razor)

Individual node item inside TwTree with custom icons and nested child rendering.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Id` | `string` | `Guid.NewGuid().ToString("N")` | Configures component behavior or styling. |
| `Text` | `string` | `""` | Configures component behavior or styling. |
| `Badge` | `string?` | `null` | Configures component behavior or styling. |
| `InitiallyExpanded` | `bool` | `null` | Configures component behavior or styling. |
| `IconContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwTreeItem Id="Guid.NewGuid().ToString(N)" Text="" />
```

---

## Visualizations & Gauges

### `TwSparkline`

**Location:** [`Components/UI/TwSparkline.razor`](../Components/UI/TwSparkline.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Type` | `SparklineType` | `SparklineType.Line` | Configures component behavior or styling. |
| `Points` | `List<double>` | `new() { 12, 18, 14, 22, 19, 28, 25, 34, 30, 42 }` | Configures component behavior or styling. |
| `Width` | `int` | `110` | Configures component behavior or styling. |
| `Height` | `int` | `28` | Configures component behavior or styling. |
| `StrokeWidth` | `double` | `2.0` | Configures component behavior or styling. |
| `Color` | `string` | `"brand"` | Configures component behavior or styling. |
| `ShowMinMaxDots` | `bool` | `true` | Configures component behavior or styling. |
| `ShowValueBadge` | `bool` | `false` | Primary data value or two-way bound model property. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwSparkline Type="SparklineType.Line" Points="new() { 12, 18, 14, 22, 19, 28, 25, 34, 30, 42 }" Width="110" />
```

---

### `TwProgressAdvanced`

**Location:** [`Components/UI/TwProgressAdvanced.razor`](../Components/UI/TwProgressAdvanced.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Type` | `ProgressType` | `ProgressType.Stacked` | Configures component behavior or styling. |
| `Title` | `string?` | `null` | Header title or accessible label. |
| `Label` | `string?` | `null` | Configures component behavior or styling. |
| `Value` | `double` | `65` | Primary data value or two-way bound model property. |
| `ShowHeader` | `bool` | `true` | Configures component behavior or styling. |
| `ShowLegend` | `bool` | `true` | Configures component behavior or styling. |
| `Color` | `string` | `"brand"` | Configures component behavior or styling. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `Segments` | `List<ProgressSegment>` | `new()
    {
        new ProgressSegment { Label = "Code & Engine", Percentage = 42, ColorClass = "bg-brand-500" },
        new ProgressSegment { Label = "Assets & Icons", Percentage = 28, ColorClass = "bg-emerald-500" },
        new ProgressSegment { Label = "Cached Data", Percentage = 18, ColorClass = "bg-amber-500" },
        new ProgressSegment { Label = "Free Memory", Percentage = 12, ColorClass = "bg-slate-300 dark:bg-slate-700" }
    }` | Configures component behavior or styling. |
| `RadialSize` | `int` | `100` | Component sizing scale (Xs, Sm, Md, Lg). |
| `RadialStrokeWidth` | `int` | `8` | Configures component behavior or styling. |
| `RadialContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `TotalSegments` | `int` | `15` | Configures component behavior or styling. |
| `Steps` | `List<string>` | `new() { "Initialize", "Validate", "Compile", "Deploy" }` | Configures component behavior or styling. |
| `CurrentStep` | `int` | `2` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwProgressAdvanced Type="ProgressType.Stacked" Value="65" ShowHeader="true" />
```

---

### `TwChart`

**Location:** [`Components/UI/TwChart.razor`](../Components/UI/TwChart.razor)

Native C# inline SVG visualization engine for donut charts, sparklines, and bar charts with zero external JS dependencies.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Type` | `ChartType` | `ChartType.Donut` | Configures component behavior or styling. |
| `Title` | `string?` | `null` | Header title or accessible label. |
| `Subtitle` | `string?` | `null` | Header title or accessible label. |
| `CenterValue` | `string` | `"100%"` | Primary data value or two-way bound model property. |
| `CenterLabel` | `string` | `"Total"` | Configures component behavior or styling. |
| `DataItems` | `IReadOnlyList<ChartDataItem>` | `Array.Empty<ChartDataItem>()` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwChart Type="ChartType.Donut" CenterValue="100%" CenterLabel="Total" />
```

---

### `TwGauge`

**Location:** [`Components/UI/TwGauge.razor`](../Components/UI/TwGauge.razor)

Zero-JS radial speedometer gauge rendering pure inline SVG arcs with stroke-dasharray calculations and CSS transitions.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Value` | `double` | `72` | Primary data value or two-way bound model property. |
| `Min` | `double` | `0` | Configures component behavior or styling. |
| `Max` | `double` | `100` | Configures component behavior or styling. |
| `Unit` | `string` | `"%"` | Configures component behavior or styling. |
| `Label` | `string?` | `"Efficiency"` | Configures component behavior or styling. |
| `Sublabel` | `string?` | `null` | Configures component behavior or styling. |
| `Color` | `string?` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwGauge Value="72" Min="0" Max="100" />
```

---

### `TwProgressBar`

**Location:** [`Components/UI/TwProgressBar.razor`](../Components/UI/TwProgressBar.razor)

Semantic progress bar with animated stripes, smooth transitions, and percentage labels.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Value` | `int` | `null` | Primary data value or two-way bound model property. |
| `Label` | `string?` | `null` | Configures component behavior or styling. |
| `ShowLabel` | `bool` | `true` | Configures component behavior or styling. |
| `Animated` | `bool` | `null` | Configures component behavior or styling. |
| `Variant` | `SemanticVariant` | `SemanticVariant.Primary` | Semantic visual variant (e.g. Primary, Secondary, Outline). |
| `Size` | `ComponentSize` | `ComponentSize.Md` | Component sizing scale (Xs, Sm, Md, Lg). |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwProgressBar ShowLabel="true" Variant="SemanticVariant.Primary" Size="ComponentSize.Md" />
```

---

### `TwCountUp`

**Location:** [`Components/UI/TwCountUp.razor`](../Components/UI/TwCountUp.razor)

Smooth numeric counter animation with customizable duration, prefix/suffix, and easing.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `StartValue` | `double` | `0` | Primary data value or two-way bound model property. |
| `EndValue` | `double` | `100` | Primary data value or two-way bound model property. |
| `DurationMs` | `int` | `1200` | Configures component behavior or styling. |
| `Decimals` | `int` | `0` | Configures component behavior or styling. |
| `Prefix` | `string?` | `null` | Configures component behavior or styling. |
| `Suffix` | `string?` | `null` | Configures component behavior or styling. |
| `AutoStart` | `bool` | `true` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwCountUp StartValue="0" EndValue="100" DurationMs="1200" />
```

---

### `TwAnimate`

**Location:** [`Components/UI/TwAnimate.razor`](../Components/UI/TwAnimate.razor)

Declarative CSS animation wrapper providing fade, zoom, bounce, and slide keyframes.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Type` | `AnimationType` | `AnimationType.FadeInUp` | Configures component behavior or styling. |
| `DurationMs` | `int` | `400` | Configures component behavior or styling. |
| `DelayMs` | `int` | `0` | Configures component behavior or styling. |
| `Infinite` | `bool` | `null` | Configures component behavior or styling. |
| `OnHover` | `bool` | `null` | Configures component behavior or styling. |
| `Play` | `bool` | `true` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwAnimate Type="AnimationType.FadeInUp" DurationMs="400" DelayMs="0" />
```

---

### `TwTransition`

**Location:** [`Components/UI/TwTransition.razor`](../Components/UI/TwTransition.razor)

Smooth enter/leave transition container for mounting and unmounting Blazor components.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Show` | `bool` | `true` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Enter` | `string` | `"transition duration-300 ease-out"` | Configures component behavior or styling. |
| `EnterFrom` | `string` | `"opacity-0 scale-95 -translate-y-2"` | Configures component behavior or styling. |
| `EnterTo` | `string` | `"opacity-100 scale-100 translate-y-0"` | Configures component behavior or styling. |
| `Leave` | `string` | `"transition duration-200 ease-in"` | Configures component behavior or styling. |
| `LeaveFrom` | `string` | `"opacity-100 scale-100 translate-y-0"` | Configures component behavior or styling. |
| `LeaveTo` | `string` | `"opacity-0 scale-95 -translate-y-2"` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |
| `Style` | `string?` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwTransition Show="true" Enter="transition duration-300 ease-out" EnterFrom="opacity-0 scale-95 -translate-y-2" />
```

---

## Media, Scanner & Signature

### `TwMediaPlayer`

**Location:** [`Components/UI/TwMediaPlayer.razor`](../Components/UI/TwMediaPlayer.razor)

Custom video and audio player with chapter markers, scrubber seek, playback speed selector (0.5x - 2x), Picture-in-Picture, volume control, and audio visualizer.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Src` | `string` | `string.Empty` | Configures component behavior or styling. |
| `Poster` | `string?` | `null` | Configures component behavior or styling. |
| `Title` | `string?` | `null` | Header title or accessible label. |
| `Subtitle` | `string?` | `null` | Header title or accessible label. |
| `Type` | `MediaKind` | `MediaKind.Video` | Configures component behavior or styling. |
| `Loop` | `bool` | `null` | Configures component behavior or styling. |
| `Chapters` | `List<MediaChapter>?` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwMediaPlayer Src="string.Empty" Type="MediaKind.Video" />
```

---

### `TwQrCode`

**Location:** [`Components/UI/TwQrCode.razor`](../Components/UI/TwQrCode.razor)

Vector SVG and PNG QR code generator supporting custom dot shapes (Square, Rounded, Circle), error correction levels, and center icon branding.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Value` | `string` | `"https://tailwindcss.com"` | Primary data value or two-way bound model property. |
| `Title` | `string?` | `null` | Header title or accessible label. |
| `Subtitle` | `string?` | `null` | Header title or accessible label. |
| `Size` | `int` | `200` | Component sizing scale (Xs, Sm, Md, Lg). |
| `ForegroundColor` | `string` | `"#0f172a"` | Configures component behavior or styling. |
| `BackgroundColor` | `string` | `"#ffffff"` | Configures component behavior or styling. |
| `DotShape` | `QrDotShape` | `QrDotShape.Rounded` | Configures component behavior or styling. |
| `CenterIcon` | `QrCenterIcon` | `QrCenterIcon.None` | Configures component behavior or styling. |
| `EccLevel` | `QrEccLevel` | `QrEccLevel.Q` | Configures component behavior or styling. |
| `ShowActions` | `bool` | `true` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwQrCode Value="https://tailwindcss.com" Size="200" ForegroundColor="#0f172a" />
```

---

### `TwBarcode`

**Location:** [`Components/UI/TwBarcode.razor`](../Components/UI/TwBarcode.razor)

High-density Code 128 1D vector barcode generator rendering sharp scalable SVG bars with human-readable text.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Value` | `string` | `"SKU-984210"` | Primary data value or two-way bound model property. |
| `Title` | `string?` | `null` | Header title or accessible label. |
| `Subtitle` | `string?` | `null` | Header title or accessible label. |
| `BarHeight` | `int` | `64` | Configures component behavior or styling. |
| `BarWidthMultiplier` | `int` | `2` | Configures component behavior or styling. |
| `ShowText` | `bool` | `true` | Configures component behavior or styling. |
| `QuietZone` | `bool` | `true` | Configures component behavior or styling. |
| `ForegroundColor` | `string` | `"#0f172a"` | Configures component behavior or styling. |
| `BackgroundColor` | `string` | `"#ffffff"` | Configures component behavior or styling. |
| `ShowActions` | `bool` | `true` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwBarcode Value="SKU-984210" BarHeight="64" BarWidthMultiplier="2" />
```

---

### `TwBarcodeScanner`

**Location:** [`Components/UI/TwBarcodeScanner.razor`](../Components/UI/TwBarcodeScanner.razor)

Live camera video and file barcode scanner supporting QR codes, Code 128, EAN, UPC, and Data Matrix with audio beep feedback.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `OnScan` | `EventCallback<BarcodeScanResult>` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwBarcodeScanner />
```

---

### `TwSignaturePad`

**Location:** [`Components/UI/TwSignaturePad.razor`](../Components/UI/TwSignaturePad.razor)

Digital canvas signature pad with smooth Bezier curve drawing, undo/redo history, background transparency, and export to PNG and SVG.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string?` | `null` | Header title or accessible label. |
| `Subtitle` | `string?` | `null` | Header title or accessible label. |
| `Height` | `int` | `220` | Configures component behavior or styling. |
| `ShowGuide` | `bool` | `true` | Configures component behavior or styling. |
| `PenColor` | `string` | `"#0f172a"` | Configures component behavior or styling. |
| `StrokeWidth` | `double` | `2.5` | Configures component behavior or styling. |
| `OnSave` | `EventCallback<string>` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwSignaturePad Height="220" ShowGuide="true" PenColor="#0f172a" />
```

---

### `TwImageCompare`

**Location:** [`Components/UI/TwImageCompare.razor`](../Components/UI/TwImageCompare.razor)

Interactive Before/After visual comparison slider with touch/pointer dragging, glassmorphic center handle, keyboard navigation, and dual badges.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `BeforeSrc` | `string` | `""` | Configures component behavior or styling. |
| `AfterSrc` | `string` | `""` | Configures component behavior or styling. |
| `BeforeAlt` | `string` | `"Before image"` | Configures component behavior or styling. |
| `AfterAlt` | `string` | `"After image"` | Configures component behavior or styling. |
| `BeforeLabel` | `string` | `"Before"` | Configures component behavior or styling. |
| `AfterLabel` | `string` | `"After"` | Configures component behavior or styling. |
| `Position` | `double` | `50.0` | Configures component behavior or styling. |
| `PositionChanged` | `EventCallback<double>` | `null` | Callback invoked when state changes or item is selected. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwImageCompare BeforeSrc="" AfterSrc="" BeforeAlt="Before image" />
```

---

## Navigation & Steppers

### `TwRibbon`

**Location:** [`Components/UI/TwRibbon.razor`](../Components/UI/TwRibbon.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Tabs` | `List<RibbonTab>` | `new()` | Configures component behavior or styling. |
| `ActiveTabIndex` | `int` | `0` | Configures component behavior or styling. |
| `IsCollapsed` | `bool` | `false` | Configures component behavior or styling. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `OnActionClicked` | `EventCallback<string>` | `null` | Callback invoked when state changes or item is selected. |
| `ActiveTabIndexChanged` | `EventCallback<int>` | `null` | Callback invoked when state changes or item is selected. |

#### Razor Usage Example

```razor
<TwRibbon Tabs="new()" ActiveTabIndex="0" CustomClass="" />
```

---

### `TwFloatingDock`

**Location:** [`Components/UI/TwFloatingDock.razor`](../Components/UI/TwFloatingDock.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Items` | `List<DockItem>` | `new()` | Configures component behavior or styling. |
| `ActiveId` | `string` | `"home"` | Configures component behavior or styling. |
| `Position` | `string` | `"bottom"` | Configures component behavior or styling. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `OnItemSelected` | `EventCallback<string>` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwFloatingDock Items="new()" ActiveId="home" Position="bottom" />
```

---

### `TwTabs`

**Location:** [`Components/UI/TwTabs.razor`](../Components/UI/TwTabs.razor)

Horizontal scrollable tabs with pill or underline variants and badge counters.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Tabs` | `IReadOnlyList<TabDefinition>` | `Array.Empty<TabDefinition>()` | Configures component behavior or styling. |
| `ActiveTabKey` | `string?` | `null` | Configures component behavior or styling. |
| `ActiveTabKeyChanged` | `EventCallback<string>` | `null` | Callback invoked when state changes or item is selected. |
| `Variant` | `string` | `"underline"` | Semantic visual variant (e.g. Primary, Secondary, Outline). |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwTabs Tabs="Array.Empty<TabDefinition>()" Variant="underline" />
```

---

### `TwSlidingTabs`

**Location:** [`Components/UI/TwSlidingTabs.razor`](../Components/UI/TwSlidingTabs.razor)

Fluid tab strip with an animated gliding background pill that follows the active selection.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Tabs` | `List<TabItem>` | `new()` | Configures component behavior or styling. |
| `ActiveTabId` | `string` | `string.Empty` | Configures component behavior or styling. |
| `ActiveTabIdChanged` | `EventCallback<string>` | `null` | Callback invoked when state changes or item is selected. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwSlidingTabs Tabs="new()" ActiveTabId="string.Empty" />
```

---

### `TwBreadcrumb`

**Location:** [`Components/UI/TwBreadcrumb.razor`](../Components/UI/TwBreadcrumb.razor)

Accessible breadcrumb trail with custom separators and truncated intermediate paths.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Items` | `IReadOnlyList<BreadcrumbItem>` | `Array.Empty<BreadcrumbItem>()` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwBreadcrumb Items="Array.Empty<BreadcrumbItem>()" />
```

---

### `TwStepper`

**Location:** [`Components/UI/TwStepper.razor`](../Components/UI/TwStepper.razor)

Multi-step onboarding wizard with completed step indicators and compact mobile layout.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Steps` | `IReadOnlyList<StepItem>` | `Array.Empty<StepItem>()` | Configures component behavior or styling. |
| `CurrentStep` | `int` | `1` | Configures component behavior or styling. |
| `CurrentStepChanged` | `EventCallback<int>` | `null` | Callback invoked when state changes or item is selected. |
| `Clickable` | `bool` | `true` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwStepper Steps="Array.Empty<StepItem>()" CurrentStep="1" Clickable="true" />
```

---

### `TwTimeline`

**Location:** [`Components/UI/TwTimeline.razor`](../Components/UI/TwTimeline.razor)

Vertical activity timeline container for audit logs, delivery tracking, and project milestones.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Position` | `TimelinePosition` | `TimelinePosition.Start` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwTimeline Position="TimelinePosition.Start" />
```

---

### `TwTimelineItem`

**Location:** [`Components/UI/TwTimelineItem.razor`](../Components/UI/TwTimelineItem.razor)

Individual timeline entry with status dot, icon, timestamp, and card description.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string?` | `null` | Header title or accessible label. |
| `Subtitle` | `string?` | `null` | Header title or accessible label. |
| `Timestamp` | `string?` | `null` | Configures component behavior or styling. |
| `Variant` | `SemanticVariant` | `SemanticVariant.Primary` | Semantic visual variant (e.g. Primary, Secondary, Outline). |
| `Pulse` | `bool` | `null` | Configures component behavior or styling. |
| `IsLast` | `bool` | `null` | Configures component behavior or styling. |
| `DotContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwTimelineItem Variant="SemanticVariant.Primary" />
```

---

### `TwScrollToTop`

**Location:** [`Components/UI/TwScrollToTop.razor`](../Components/UI/TwScrollToTop.razor)

Floating smooth scroll-to-top button with scroll position threshold and mobile safe-area clearance.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Variant` | `ScrollToTopVariant` | `ScrollToTopVariant.Vertical` | Semantic visual variant (e.g. Primary, Secondary, Outline). |
| `Label` | `string` | `"TOP"` | Configures component behavior or styling. |
| `ShowProgress` | `bool` | `true` | Configures component behavior or styling. |
| `Threshold` | `int` | `150` | Configures component behavior or styling. |
| `AlwaysVisible` | `bool` | `null` | Configures component behavior or styling. |
| `PositionClass` | `string` | `"bottom-36 sm:bottom-24 right-4 sm:right-6"` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwScrollToTop Variant="ScrollToTopVariant.Vertical" Label="TOP" ShowProgress="true" />
```

---

### `TwSpeedDial`

**Location:** [`Components/UI/TwSpeedDial.razor`](../Components/UI/TwSpeedDial.razor)

Floating action button that expands into a radial or vertical speed-dial menu of quick actions.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Actions` | `IReadOnlyList<SpeedDialAction>` | `Array.Empty<SpeedDialAction>()` | Configures component behavior or styling. |
| `OnActionSelected` | `EventCallback<string>` | `null` | Configures component behavior or styling. |
| `PositionClass` | `string` | `"bottom-20 sm:bottom-8 left-4 sm:left-8"` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwSpeedDial Actions="Array.Empty<SpeedDialAction>()" PositionClass="bottom-20 sm:bottom-8 left-4 sm:left-8" />
```

---

### `TwTour`

**Location:** [`Components/UI/TwTour.razor`](../Components/UI/TwTour.razor)

Interactive guided walkthrough coaching tour with spotlight backdrop, step popovers, and automatic restart lifecycle.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `IsOpen` | `bool` | `null` | Two-way bindable visibility flag. |
| `IsOpenChanged` | `EventCallback<bool>` | `null` | Two-way bindable visibility flag. |
| `Steps` | `IReadOnlyList<TourStep>` | `Array.Empty<TourStep>()` | Configures component behavior or styling. |
| `OnCompleted` | `EventCallback` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwTour Steps="Array.Empty<TourStep>()" />
```

---

## Overlays & Popovers

### `TwContextMenu`

**Location:** [`Components/UI/TwContextMenu.razor`](../Components/UI/TwContextMenu.razor)

Reusable Blazor WebAssembly component styled with Tailwind CSS.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Items` | `List<ContextMenuItem>` | `new()` | Configures component behavior or styling. |
| `PreventDefaultContextMenu` | `bool` | `true` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `CustomClass` | `string` | `""` | Configures component behavior or styling. |
| `OnItemSelected` | `EventCallback<string>` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwContextMenu Items="new()" PreventDefaultContextMenu="true" CustomClass="" />
```

---

### `TwModal`

**Location:** [`Components/UI/TwModal.razor`](../Components/UI/TwModal.razor)

Accessible dialog that presents as a bottom sheet on mobile screens and a centered modal dialog on desktop.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `IsOpen` | `bool` | `null` | Two-way bindable visibility flag. |
| `IsOpenChanged` | `EventCallback<bool>` | `null` | Two-way bindable visibility flag. |
| `Title` | `string?` | `null` | Header title or accessible label. |
| `Description` | `string?` | `null` | Secondary descriptive caption. |
| `MaxWidth` | `string` | `"md"` | Configures component behavior or styling. |
| `CloseOnBackdropClick` | `bool` | `true` | Configures component behavior or styling. |
| `HeaderContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `FooterContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwModal MaxWidth="md" CloseOnBackdropClick="true" />
```

---

### `TwDrawer`

**Location:** [`Components/UI/TwDrawer.razor`](../Components/UI/TwDrawer.razor)

Off-canvas sliding drawer supporting Left, Right, and Bottom slide orientations with backdrop blur.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `IsOpen` | `bool` | `null` | Two-way bindable visibility flag. |
| `IsOpenChanged` | `EventCallback<bool>` | `null` | Two-way bindable visibility flag. |
| `Title` | `string?` | `null` | Header title or accessible label. |
| `Subtitle` | `string?` | `null` | Header title or accessible label. |
| `Placement` | `DrawerPlacement` | `DrawerPlacement.Right` | Configures component behavior or styling. |
| `Width` | `string` | `"max-w-md"` | Configures component behavior or styling. |
| `CloseOnBackdropClick` | `bool` | `true` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `FooterContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwDrawer Placement="DrawerPlacement.Right" Width="max-w-md" CloseOnBackdropClick="true" />
```

---

### `TwDropdown`

**Location:** [`Components/UI/TwDropdown.razor`](../Components/UI/TwDropdown.razor)

Click-outside popover menu with keyboard navigation and position alignment (Left, Right, Center).

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `TriggerContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Alignment` | `string` | `"right"` | Configures component behavior or styling. |
| `CloseOnSelect` | `bool` | `true` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwDropdown Alignment="right" CloseOnSelect="true" />
```

---

### `TwTooltip`

**Location:** [`Components/UI/TwTooltip.razor`](../Components/UI/TwTooltip.razor)

Hover and tap tooltip popover with auto-flipping placement and arrow indicator.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Text` | `string` | `""` | Configures component behavior or styling. |
| `Placement` | `string` | `"top"` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwTooltip Text="" Placement="top" />
```

---

### `TwAccordion`

**Location:** [`Components/UI/TwAccordion.razor`](../Components/UI/TwAccordion.razor)

Collapsible accordion container with single-expand or multi-expand modes.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `AllowMultiple` | `bool` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwAccordion>
    <span>Content</span>
</TwAccordion>
```

---

### `TwAccordionItem`

**Location:** [`Components/UI/TwAccordionItem.razor`](../Components/UI/TwAccordionItem.razor)

Individual accordion panel with smooth height transition and animated chevron.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `""` | Header title or accessible label. |
| `InitiallyOpen` | `bool` | `null` | Configures component behavior or styling. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwAccordionItem Title="" />
```

---

## AI Chatbot & Reasoning

### `TwChatBot`

**Location:** [`Components/UI/TwChatBot.razor`](../Components/UI/TwChatBot.razor)

Intelligent conversational chatbot interface with streaming message bubbles, thinking progress checklists, and code snippet copying.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `BotName` | `string` | `"NexusAI"` | Configures component behavior or styling. |
| `SelectedModel` | `string` | `"Gemini 2.0 Flash"` | Configures component behavior or styling. |
| `ShowCloseButton` | `bool` | `null` | Configures component behavior or styling. |
| `OnClose` | `EventCallback` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |
| `StarterPrompts` | `IReadOnlyList<StarterPrompt>` | `new List<StarterPrompt>
    {
        new("Explain Architecture", "Explain how mobile-first Blazor WASM and TailwindCSS work together with zero FOUC."),
        new("Generate Code", "Write a reusable C# Blazor component for animated radial progress with Tailwind classes."),
        new("Deep Reasoning Demo", "Solve a complex algorithm step-by-step with multi-stage reasoning checklist progress."),
        new("Compare Performance", "Compare Blazor WebAssembly AOT compilation vs JIT performance on mobile phones.")
    }` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwChatBot BotName="NexusAI" SelectedModel="Gemini 2.0 Flash" StarterPrompts="new List<StarterPrompt>
    {
        new(Explain Architecture, Explain how mobile-first Blazor WASM and TailwindCSS work together with zero FOUC.),
        new(Generate Code, Write a reusable C# Blazor component for animated radial progress with Tailwind classes.),
        new(Deep Reasoning Demo, Solve a complex algorithm step-by-step with multi-stage reasoning checklist progress.),
        new(Compare Performance, Compare Blazor WebAssembly AOT compilation vs JIT performance on mobile phones.)
    }" />
```

---

### `TwChatWidget`

**Location:** [`Components/UI/TwChatWidget.razor`](../Components/UI/TwChatWidget.razor)

Floating launcher button that expands into an interactive AI assistant window (or bottom sheet on mobile).

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `BotName` | `string` | `"NexusAI"` | Configures component behavior or styling. |
| `SelectedModel` | `string` | `"Gemini 2.0 Flash"` | Configures component behavior or styling. |
| `PositionClass` | `string` | `"bottom-20 sm:bottom-6 right-4 sm:right-6"` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwChatWidget BotName="NexusAI" SelectedModel="Gemini 2.0 Flash" PositionClass="bottom-20 sm:bottom-6 right-4 sm:right-6" />
```

---

### `TwAiReasoningProgress`

**Location:** [`Components/UI/TwAiReasoningProgress.razor`](../Components/UI/TwAiReasoningProgress.razor)

Multi-phase thinking checklist component displaying animated progress indicators during AI reasoning tasks.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `IsThinking` | `bool` | `true` | Configures component behavior or styling. |
| `DurationSeconds` | `double` | `2.4` | Configures component behavior or styling. |
| `ThinkingLabel` | `string` | `"Reasoning step-by-step..."` | Configures component behavior or styling. |
| `ReasoningText` | `string?` | `null` | Configures component behavior or styling. |
| `Steps` | `IReadOnlyList<ReasoningStep>?` | `null` | Configures component behavior or styling. |
| `DefaultExpanded` | `bool` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwAiReasoningProgress IsThinking="true" DurationSeconds="2.4" ThinkingLabel="Reasoning step-by-step..." />
```

---

### `TwAguiFormCanvas`

**Location:** [`Components/UI/TwAguiFormCanvas.razor`](../Components/UI/TwAguiFormCanvas.razor)

Adaptive Generative UI (AG-UI) form engine compiling dynamic fields (inputs, textareas, sliders, toggles, selects, radio groups, date pickers) from an `AguiFormSchema` with real-time conditional branching, AI confidence chips, two-way diff tracking, and Human-in-the-Loop (HITL) approval gates.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Schema` | `AguiFormSchema?` | `null` | The synthesized AG-UI form definition containing fields, initial values, risk tier, and agent attribution. |
| `Class` | `string` | `""` | Additional custom Tailwind CSS utility classes. |
| `OnSubmit` | `EventCallback<AguiFormSubmission>` | `null` | Event callback triggered when the human reviewer approves the form; delivers type-safe parameter payload. |
| `OnCancel` | `EventCallback<string>` | `null` | Event callback triggered when the form is dismissed or rejected. |

#### Razor Usage Example

```razor
<TwAguiFormCanvas Schema="@formSchema" 
                  OnSubmit="HandleApproval" 
                  OnCancel="HandleRejection" />
```

---

### `TwPwaInstallButton`

**Location:** [`Components/UI/TwPwaInstallButton.razor`](../Components/UI/TwPwaInstallButton.razor)

Progressive Web App (PWA) 1-click install button and standalone status indicator. Automatically captures the browser's `beforeinstallprompt` event and opens an interactive cross-platform guide modal for browsers without native prompt support (like iOS Safari).

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Class` | `string` | `""` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwPwaInstallButton />
```

---

## Showcase & Micro-Interactions

### `TwMarquee`

**Location:** [`Components/UI/TwMarquee.razor`](../Components/UI/TwMarquee.razor)

Infinite continuous horizontal scrolling ticker with CSS keyframes, pause-on-hover, and edge gradient masks.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `DurationSeconds` | `int` | `25` | Configures component behavior or styling. |
| `Reverse` | `bool` | `false` | Configures component behavior or styling. |
| `PauseOnHover` | `bool` | `true` | Configures component behavior or styling. |
| `FadeEdges` | `bool` | `true` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |
| `TrackClass` | `string?` | `null` | Configures component behavior or styling. |

#### Razor Usage Example

```razor
<TwMarquee DurationSeconds="25" PauseOnHover="true" FadeEdges="true" />
```

---

### `TwConfetti`

**Location:** [`Components/UI/TwConfetti.razor`](../Components/UI/TwConfetti.razor)

Canvas physics celebratory particle explosion system with gravity, air resistance, and 3D rotation.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `FullScreen` | `bool` | `false` | Configures component behavior or styling. |
| `AutoFire` | `bool` | `false` | Configures component behavior or styling. |
| `ParticleCount` | `int` | `85` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwConfetti ParticleCount="85" />
```

---

### `TwSkeleton`

**Location:** [`Components/UI/TwSkeleton.razor`](../Components/UI/TwSkeleton.razor)

Animated shimmer placeholder for cards, tables, text, and avatars during asynchronous data loading.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Variant` | `string` | `"text"` | Semantic visual variant (e.g. Primary, Secondary, Outline). |
| `Width` | `string?` | `null` | Configures component behavior or styling. |
| `Height` | `string?` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwSkeleton Variant="text" />
```

---

### `TwEmptyState`

**Location:** [`Components/UI/TwEmptyState.razor`](../Components/UI/TwEmptyState.razor)

Illustrated zero-data state placeholder with title, description, and call-to-action button.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `"No items found"` | Header title or accessible label. |
| `Description` | `string?` | `null` | Secondary descriptive caption. |
| `IconContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `ActionContent` | `RenderFragment?` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwEmptyState Title="No items found" />
```

---

### `TwBanner`

**Location:** [`Components/UI/TwBanner.razor`](../Components/UI/TwBanner.razor)

Full-width announcement banner with dismiss button and action link.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Text` | `string` | `string.Empty` | Configures component behavior or styling. |
| `BadgeText` | `string?` | `null` | Configures component behavior or styling. |
| `ActionText` | `string?` | `null` | Configures component behavior or styling. |
| `OnAction` | `EventCallback` | `null` | Configures component behavior or styling. |
| `Dismissible` | `bool` | `true` | Configures component behavior or styling. |
| `IsSticky` | `bool` | `false` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwBanner Text="string.Empty" Dismissible="true" />
```

---

### `TwAlert`

**Location:** [`Components/UI/TwAlert.razor`](../Components/UI/TwAlert.razor)

Dismissible inline feedback alert with semantic variants (Success, Warning, Danger, Info).

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string?` | `null` | Header title or accessible label. |
| `ChildContent` | `RenderFragment?` | `null` | Child content or nested markup rendered inside the component slot. |
| `Variant` | `SemanticVariant` | `SemanticVariant.Info` | Semantic visual variant (e.g. Primary, Secondary, Outline). |
| `Dismissible` | `bool` | `null` | Configures component behavior or styling. |
| `OnDismiss` | `EventCallback` | `null` | Configures component behavior or styling. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwAlert Variant="SemanticVariant.Info" />
```

---

### `TwToastContainer`

**Location:** [`Components/UI/TwToastContainer.razor`](../Components/UI/TwToastContainer.razor)

Fixed container managing reactive floating toast alert notifications.

#### Razor Usage Example

```razor
<TwToastContainer />
```

---

## 🚀 Roadmap Innovations & Morale Suite (v1.1.0 Quick Wins)

### `TwPrizeWheel`

**Location:** [`Components/UI/TwPrizeWheel.razor`](../Components/UI/TwPrizeWheel.razor)

Interactive SVG spinning fortune wheel designed for agile team sprint retrospectives, all-hands town halls, and team morale prize giveaways. Features cubic-bezier deceleration physics, audio tick sound effects, confetti particle bursts, and customizable prize sectors.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Prizes` | `List<TwPrizeWheel.PrizeItem>?` | `Default 8 Prizes` | Sectors with titles, emojis, colors, and descriptions. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |
| `OnPrizeWon` | `EventCallback<TwPrizeWheel.PrizeItem>` | `null` | Fired when the wheel finishes spinning and lands on a slice. |

#### Razor Usage Example

```razor
<TwPrizeWheel OnPrizeWon="HandlePrizeWon" />

@code {
    private void HandlePrizeWon(TwPrizeWheel.PrizeItem prize)
    {
        Console.WriteLine($"Winner! {prize.Emoji} {prize.Title}");
    }
}
```

---

### `TwCelebrationEditor`

**Location:** [`Components/UI/TwCelebrationEditor.razor`](../Components/UI/TwCelebrationEditor.razor)

Visual particle physics calibration sandbox. Lets developers and designers adjust confetti count, blast velocity, spread angle, gravity decay, and particle shapes (ribbons, sparkles, stars, balloons, coins) live in HTML5 Canvas, with 1-click Razor markup and C# trigger code export.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwCelebrationEditor />
```

---

### `TwRewardsCenter`

**Location:** [`Components/UI/TwRewardsCenter.razor`](../Components/UI/TwRewardsCenter.razor)

Employee perks & recognition marketplace. Displays points wallet balance, multi-category filtering (All, Tech, Food, Wellness, Time Off, Learning), instant search, and a digital voucher modal with verification codes and barcode display upon redemption.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `InitialBalance` | `int` | `1250` | Initial employee points balance. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |
| `OnVoucherRedeemed` | `EventCallback<TwRewardsCenter.RewardOffer>` | `null` | Event callback triggered when an employee claims an award. |

#### Razor Usage Example

```razor
<TwRewardsCenter InitialBalance="1500" OnVoucherRedeemed="HandleRedeem" />
```

---

### `TwMfaAuthSuite`

**Location:** [`Components/UI/TwMfaAuthSuite.razor`](../Components/UI/TwMfaAuthSuite.razor)

Enterprise-grade Zero-Trust Multi-Factor Authentication enrollment and verification suite. Supports:
1. **TOTP Authenticator Apps**: Dynamic vector QR code generation, secret key manual entry, and auto-focus 6-digit verification code.
2. **SMS / Email OTP**: One-time passcode dispatch simulation with resend cooldown timer.
3. **Passkeys / FIDO2**: Biometric WebAuthn (Touch ID, Windows Hello, YubiKey) enrollment flow.
4. **Emergency Recovery Codes**: 8 single-use cryptographically strong backup codes with copy-to-clipboard and text download.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `UserEmail` | `string` | `"alex.chen@enterprise.io"` | Target user identity displayed in enrollment QR codes. |
| `Issuer` | `string` | `"Enterprise Cloud"` | Service name displayed inside authenticator apps. |
| `SecretKey` | `string` | `"JBSWY3DPEHPK3PXP"` | Base32 TOTP secret key seed. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwMfaAuthSuite UserEmail="dev@company.com" Issuer="Acme Platform" />
```

---

### `TwMediaRecorder`

**Location:** [`Components/UI/TwMediaRecorder.razor`](../Components/UI/TwMediaRecorder.razor)

Native browser media recording studio with real-time SVG frequency waveform visualizer and VU meters. Supports voice memo audio recording and camera video standups with live timer, pause/resume, playback review, and file download exporter.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwMediaRecorder />
```

---

### `TwScrollCraft`

**Location:** [`Components/UI/TwScrollCraft.razor`](../Components/UI/TwScrollCraft.razor)

Viewport-driven object animation scrubber with multi-layer ambient parallax depth, focal transformations, and kinetic scrub tracks. Links graphic state and scale smoothly to step progress without heavy external JavaScript animation libraries.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `"Interactive Lifecycle Scrubber"` | Component header title. |
| `Class` | `string?` | `null` | Additional custom Tailwind CSS utility classes. |

#### Razor Usage Example

```razor
<TwScrollCraft Title="Agentic AI Execution Lifecycle" />
```

---

## Form / PDF OCR & Check MICR Detection

### `TwMicrCheckReader`

**Location:** [`Components/UI/TwMicrCheckReader.razor`](../Components/UI/TwMicrCheckReader.razor)

Production-ready Check 21 Remote Deposit Capture (RDC) paper check & bank draft reader powered by 100% local, offline Tesseract WebAssembly (`wwwroot/lib/tesseract/` — zero CDN dependencies). Features ANSI X9.27 / ISO 1004 E-13B magnetic ink clear band decoding, universal Federal Reserve Modulus-10 routing checksum validation with auto-correction, 150+ verified NACHA Bank Routing Directory lookup across all 12 Federal Reserve Districts, and ChoETL.NACHA-compliant 94-character fixed-width ACH batch file generation (`.ach`).

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Class` | `string` | `""` | Additional Tailwind CSS classes. |
| `OnCheckScanned` | `EventCallback<CheckDraftOcrResult>` | `null` | Fired when check OCR extraction completes. |
| `OnInsertMarkdown` | `EventCallback<string>` | `null` | Fired when check ledger Markdown table is exported. |
| `OnDepositApproved` | `EventCallback<CheckDraftOcrResult>` | `null` | Fired when remote deposit capture (RDC) is approved and cleared. |
| `OnNachaExported` | `EventCallback<string>` | `null` | Fired when 94-character fixed-width NACHA ACH batch file (`.ach`) is exported. |
| `OnJsonExported` | `EventCallback<string>` | `null` | Fired when Check 21 structured JSON payload is exported. |

#### Razor Usage Example

```razor
<TwMicrCheckReader OnCheckScanned="HandleCheckScanned"
                   OnDepositApproved="HandleDepositApproved"
                   OnNachaExported="HandleNachaExported"
                   OnJsonExported="HandleJsonExported" />
```

---

### `TwDocumentOcrStudio`

**Location:** [`Components/UI/TwDocumentOcrStudio.razor`](../Components/UI/TwDocumentOcrStudio.razor)

Full-featured Form & PDF OCR Studio supporting paper checks, official bank drafts, commercial invoices, and IRS Form W-9 with real-time spatial bounding boxes, confidence badges, structured key-value extraction, and 1-click Markdown table generation.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Class` | `string` | `""` | Additional Tailwind CSS classes. |
| `OnMarkdownExtracted` | `EventCallback<string>` | `null` | Fired when the extracted Markdown table is copied or exported. |

#### Razor Usage Example

```razor
<TwDocumentOcrStudio OnMarkdownExtracted="HandleMarkdownExtracted" />
```

---

### `TwSmartOcrButton`

**Location:** [`Components/UI/TwSmartOcrButton.razor`](../Components/UI/TwSmartOcrButton.razor)

Drop-in Smart Component button that triggers instant client-side OCR for paper checks (MICR E-13B), commercial invoices, and tax forms, returning typed entity mappings directly into forms or editors.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Class` | `string` | `""` | Additional Tailwind CSS classes. |
| `OnDocumentScanned` | `EventCallback<DocumentOcrResult>` | `null` | Fired when a document is scanned and entities are extracted. |
| `OnCheckScanned` | `EventCallback<CheckDraftOcrResult>` | `null` | Fired when a paper check or bank draft is scanned. |

#### Razor Usage Example

```razor
<TwSmartOcrButton OnDocumentScanned="HandleDocumentScanned" OnCheckScanned="HandleCheckScanned" />
```

---

### `TwChatStudio`

**Location:** [`Components/UI/TwChatStudio.razor`](../Components/UI/TwChatStudio.razor)

Full-featured modern conversational AI chat studio featuring auto-growing multiline composer, staged file attachment preview chips, quick reply suggestion pills, feedback reactions (thumbs up/down), copy to clipboard, and live harmonic typing status.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string` | `"AI Enterprise Studio"` | Chat studio header title. |
| `ModelBadge` | `string` | `".NET 11 WASM"` | Model identification badge text. |
| `StatusSubtitle` | `string` | `"Active • Ready for enterprise workloads"` | Subtitle status text. |
| `Messages` | `List<ChatMessage>` | `new()` | Chronological chat message stream. |
| `Suggestions` | `List<string>` | `new()` | Quick reply suggestion chips above composer. |
| `IsTyping` | `bool` | `false` | Whether the harmonic typing indicator is active. |
| `TypingStatusText` | `string` | `"AI is thinking..."` | Status message displayed next to typing dots. |
| `OnMessageSent` | `EventCallback<ChatMessage>` | `-` | Fired when a prompt is sent with staged attachments. |
| `OnRegenerate` | `EventCallback<ChatMessage>` | `-` | Fired when prompt regeneration is requested. |

#### Razor Usage Example

```razor
<TwChatStudio Title="Copilot Workspace"
              ModelBadge=".NET 11 WASM"
              Messages="_messages"
              Suggestions="_prompts"
              IsTyping="_isThinking"
              OnMessageSent="HandleSend"
              OnRegenerate="HandleRegen" />
```

---

### `TwPopover`

**Location:** [`Components/UI/TwPopover.razor`](../Components/UI/TwPopover.razor)

Anchored contextual floating popover with directional pointer arrow, 8-way placement (`Top`, `Bottom`, `Left`, `Right`, `TopStart`, `TopEnd`, etc.), click or hover triggers, keyboard Escape dismiss, and optional header/footer slots.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string?` | `null` | Optional header title text. |
| `Placement` | `TwPopoverPlacement` | `TwPopoverPlacement.Bottom` | Placement relative to anchor. |
| `Trigger` | `TwPopoverTrigger` | `TwPopoverTrigger.Click` | Activation trigger mode (Click, Hover, Manual). |
| `ShowArrow` | `bool` | `true` | Render pointer arrow pointing to anchor. |
| `Width` | `string` | `"w-72"` | Flyout container width utility. |
| `IsOpen` | `bool` | `false` | Two-way bindable open state (`@bind-IsOpen`). |

#### Razor Usage Example

```razor
<TwPopover Title="Display Filters" Placement="TwPopoverPlacement.Bottom" @bind-IsOpen="_isOpen">
    <AnchorContent>
        <button class="btn">Configure Metrics</button>
    </AnchorContent>
    <ChildContent>
        <p>Telemetry settings...</p>
    </ChildContent>
</TwPopover>
```

---

### `TwSnackbar`

**Location:** [`Components/UI/TwSnackbar.razor`](../Components/UI/TwSnackbar.razor)

Actionable bottom floating notification snackbar with action trigger callback, animated progress auto-dismiss countdown bar, pause on hover, and semantic color variants.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Message` | `string` | `""` | Notification message text. |
| `ActionText` | `string?` | `null` | Optional action button label (e.g. Undo, Retry). |
| `DurationMs` | `int` | `4000` | Auto-dismiss duration in ms (0 for persistent). |
| `ShowProgress` | `bool` | `true` | Whether to render the animated countdown progress bar. |
| `Variant` | `SemanticVariant` | `SemanticVariant.Default` | Color theme (Default, Success, Warning, Danger, Info). |
| `Position` | `TwSnackbarPosition` | `TwSnackbarPosition.BottomCenter` | Viewport anchoring position. |
| `OnAction` | `EventCallback` | `-` | Fired when the action button is clicked. |

#### Razor Usage Example

```razor
<TwSnackbar Message="File moved to trash" ActionText="Undo" Variant="SemanticVariant.Default" @bind-IsOpen="_showSnack" OnAction="HandleUndo" />
```

---

### `TwPickList<TItem>`

**Location:** [`Components/UI/TwPickList.razor`](../Components/UI/TwPickList.razor)

Dual-listbox item transfer picker with instant dual-list search filtering, move selected/all transfer actions, target list reordering, and item count badges.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Source` | `IEnumerable<TItem>?` | `null` | Source available items collection. |
| `Target` | `IList<TItem>` | `new List<TItem>()` | Selected target items collection (`@bind-Target`). |
| `SourceTitle` | `string` | `"Available Items"` | Left panel header title. |
| `TargetTitle` | `string` | `"Selected Items"` | Right panel header title. |
| `AllowFiltering` | `bool` | `true` | Show real-time filter search input on both lists. |
| `ShowMoveAll` | `bool` | `true` | Show transfer all (`>>` and `<<`) buttons. |
| `ShowReorder` | `bool` | `true` | Show up/down reorder buttons in target list. |
| `Height` | `string` | `"h-72"` | Height utility for list scroll containers. |
| `OnTransfer` | `EventCallback<List<TItem>>` | `-` | Fired when items are moved between lists. |

#### Razor Usage Example

```razor
<TwPickList TItem="string" Source="_roles" @bind-Target="_assigned" SourceTitle="Roles" TargetTitle="Assigned" />
```

---

### `TwTimeSpanPicker`

**Location:** [`Components/UI/TwTimeSpanPicker.razor`](../Components/UI/TwTimeSpanPicker.razor)

Structured duration and timespan picker with Days, Hours, Minutes, Seconds input blocks, step increments, reset trigger, and quick preset duration pills.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Value` | `TimeSpan` | `TimeSpan.Zero` | Two-way bindable duration value (`@bind-Value`). |
| `Label` | `string?` | `null` | Optional form label. |
| `AllowDays` | `bool` | `true` | Whether to show the Days stepper unit. |
| `AllowSeconds` | `bool` | `true` | Whether to show the Seconds stepper unit. |
| `ShowPresets` | `bool` | `true` | Show quick duration preset buttons (15m, 1h, 1d, etc.). |
| `ShowReset` | `bool` | `true` | Show zero-reset button. |

#### Razor Usage Example

```razor
<TwTimeSpanPicker Label="SLA Duration" @bind-Value="_sla" ShowPresets="true" />
```

---

### `TwVirtualKeyboard`

**Location:** [`Components/UI/TwVirtualKeyboard.razor`](../Components/UI/TwVirtualKeyboard.razor)

On-screen virtual keyboard for kiosks, touch displays, POS terminals, and anti-keylogger secure PIN entry with QWERTY, Numeric, and scrambled PIN modes.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Value` | `string` | `""` | Two-way bindable typed text/PIN value (`@bind-Value`). |
| `Mode` | `VirtualKeyboardMode` | `VirtualKeyboardMode.Qwerty` | Key layout mode (Qwerty, Numeric, Pin). |
| `IsPassword` | `bool` | `false` | Mask display output with bullet points. |
| `ShowDisplay` | `bool` | `true` | Show top value display bar with clear button. |
| `AllowModeSwitch` | `bool` | `true` | Show mode switcher tabs. |
| `MaxLength` | `int?` | `null` | Optional maximum character length. |
| `OnSubmit` | `EventCallback` | `-` | Callback invoked when Enter / Submit key is pressed. |

#### Razor Usage Example

```razor
<TwVirtualKeyboard @bind-Value="_enteredPin" Mode="TwVirtualKeyboard.VirtualKeyboardMode.Pin" IsPassword="true" OnSubmit="HandlePinSubmit" />
```

---

### `TwFileManager`

**Location:** [`Components/UI/TwFileManager.razor`](../Components/UI/TwFileManager.razor)

Enterprise cloud and asset file manager with folder tree navigation, breadcrumbs, grid/table view modes, search, storage quota meter, and upload/delete actions.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Items` | `List<FileItem>` | `new()` | Files and folders collection. |
| `CurrentPath` | `string` | `"/"` | Current active directory path (`@bind-CurrentPath`). |
| `OnFileSelected` | `EventCallback<FileItem>` | `-` | Fired when a file or folder is selected. |
| `OnFileOpened` | `EventCallback<FileItem>` | `-` | Fired when a file or folder is double-clicked. |
| `OnUpload` | `EventCallback` | `-` | Fired when the user triggers an upload action. |

#### Razor Usage Example

```razor
<TwFileManager Items="_files" CurrentPath="/" OnFileSelected="HandleFileSelected" />
```

---

### `TwWordCloud`

**Location:** [`Components/UI/TwWordCloud.razor`](../Components/UI/TwWordCloud.razor)

Pure SVG weighted term and keyword frequency cloud with Archimedean spiral positioning, harmonic color palettes, hover scaling, and click callbacks.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Words` | `IReadOnlyList<WordCloudItem>` | `[]` | Weighted words collection with `Text` and `Weight`. |
| `Title` | `string?` | `"Keyword Density & Term Frequency"` | Chart header title text. |
| `Width` | `int` | `640` | SVG viewBox width. |
| `Height` | `int` | `320` | SVG viewBox height. |
| `MinFontSize` | `double` | `12` | Smallest font size in points. |
| `MaxFontSize` | `double` | `42` | Largest font size in points. |
| `OnWordClick` | `EventCallback<WordCloudItem>` | `-` | Fired when the user clicks any keyword. |

#### Razor Usage Example

```razor
<TwWordCloud Words="_keywords" Title="Keyword Density" OnWordClick="HandleWordClick" />
```

---

### `TwSankeyChart`

**Location:** [`Components/UI/TwSankeyChart.razor`](../Components/UI/TwSankeyChart.razor)

Pure SVG flow and migration diagram rendering source/target nodes and cubic bezier ribbons with thickness proportional to flow volume.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Nodes` | `IReadOnlyList<SankeyNode>` | `[]` | Nodes collection with `Id`, `Label`, and `Color`. |
| `Links` | `IReadOnlyList<SankeyLink>` | `[]` | Ribbon links collection with `SourceId`, `TargetId`, and `Value`. |
| `Title` | `string?` | `"Enterprise Pipeline & Resource Flow"` | Chart header title text. |
| `Width` | `int` | `700` | SVG viewBox width. |
| `Height` | `int` | `360` | SVG viewBox height. |
| `OnNodeClick` | `EventCallback<SankeyNode>` | `-` | Callback invoked when a node is clicked. |

#### Razor Usage Example

```razor
<TwSankeyChart Nodes="_nodes" Links="_links" Title="Workload Flow" OnNodeClick="HandleNodeClick" />
```

---

### `TwSpatialCard`

**Location:** [`Components/UI/TwSpatialCard.razor`](../Components/UI/TwSpatialCard.razor)

2027 volumetric 3D card featuring real-time gyroscopic mouse tilt, dynamic specular refraction glare, multi-layer Z-depth elevation, and tactile organic blur.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Title` | `string?` | `null` | Card title text. |
| `Subtitle` | `string?` | `null` | Card subtitle description. |
| `BadgeText` | `string?` | `null` | Elevated 3D pill badge text. |
| `MaxTiltDeg` | `double` | `12.0` | Maximum 3D rotation angle in degrees. |
| `CardBackgroundClass` | `string` | `"bg-white/80 dark:bg-slate-900/80"` | Backdrop blur surface class. |
| `GlowGradient` | `string` | `"from-brand-500 to-indigo-600"` | Tailwind gradient classes for dynamic ambient aura. |
| `ChildContent` | `RenderFragment?` | `null` | Elevated 3D body content. |
| `HeaderExtra` | `RenderFragment?` | `null` | Optional header action controls. |

#### Razor Usage Example

```razor
<TwSpatialCard Title="Quantum Enclave" Subtitle="HSM Tier 0" BadgeText="Volumetric 3D" MaxTiltDeg="14">
    <p>Elevated foreground content with specular cursor glare.</p>
</TwSpatialCard>
```

---

### `TwFluidMesh`

**Location:** [`Components/UI/TwFluidMesh.razor`](../Components/UI/TwFluidMesh.razor)

Tactile generative fluid gradient shader with organic motion and real-time psychological emotional state resonance tuning (`DeepFocus`, `CreativeAurora`, `HighAlert`, `ZenCalm`).

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Mood` | `EmotionalState` | `EmotionalState.DeepFocus` | Active emotional and cognitive resonance frequency preset. |
| `MoodChanged` | `EventCallback<EmotionalState>` | `-` | Callback invoked when operator changes sentiment mood. |
| `ChildContent` | `RenderFragment?` | `null` | Optional content overlaid on the fluid mesh. |

#### Razor Usage Example

```razor
<TwFluidMesh @bind-Mood="_operatorMood" />
```

---

### `TwPredictiveIntent`

**Location:** [`Components/UI/TwPredictiveIntent.razor`](../Components/UI/TwPredictiveIntent.razor)

2027 anticipatory state machine demonstrating "States over Pages" zero-click UX: gaze focal tracking, tactile biometric pulse sensor, and automated intent action synthesis.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Class` | `string` | `""` | Optional CSS classes for outer container. |

#### Razor Usage Example

```razor
<TwPredictiveIntent />
```

---

### `TwVectorMath`

**Location:** [`Components/UI/TwVectorMath.razor`](../Components/UI/TwVectorMath.razor)

Hardware-accelerated WebAssembly SIMD and .NET Runtime Intrinsics (`Vector128<float>` / `Vector<float>`) vector math engine. Benchmarks real-time floating point operations (Vector Dot Product, Vector Sum & Mean, Euclidean Norm) on datasets up to 5,000,000 elements (20 MB), comparing standard scalar execution against hardware vector instructions with mathematical equivalence assertion and telemetry JSON export.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Class` | `string?` | `null` | Optional CSS utility classes. |

#### Razor Usage Example

```razor
<TwVectorMath />
```

---

### `TwAspireHub`

**Location:** [`Components/UI/TwAspireHub.razor`](../Components/UI/TwAspireHub.razor)

.NET Aspire 11 cloud-native orchestration cockpit providing a real-time topology dashboard, active port health probing (e.g. against WebAssembly local dev server :5128), microservice environment variable inspection, structured log streaming, and instant 1-click downloads for production-ready `Program.cs` Aspire AppHost and `docker-compose.yml` multi-container deployment stacks.

#### Parameters & Settings

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Class` | `string?` | `null` | Optional CSS utility classes. |

#### Razor Usage Example

```razor
<TwAspireHub />
```

---
