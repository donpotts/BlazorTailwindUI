# Changelog

All notable changes to BlazorTailwindUI are documented here. Version 1.0 has not been released: earlier internal labels of the form 1.x were renumbered to 0.x (for example 1.5.0 is now 0.5.0), so the library is in its 0.n.n line. The format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/) and the project uses [Semantic Versioning](https://semver.org/).

## [0.7.0]

### Added
- **Data grid** (`TwDataGrid`, `TwDataGridColumn`) rebuilt on the same parameters, with new opt-in features:
  - sortable headers are real buttons with `aria-sort`; Shift adds a second sort with priority numbers
  - grouping with counts and per-group summaries; footer totals (Count, Sum, Average, Min, Max) over all filtered rows
  - master-detail rows, inline row editing with validation (Enter saves, Escape cancels, errors announced), column chooser
  - CSV export of every filtered row and the visible columns, with spreadsheet-formula neutralisation
  - saved layout (`StateKey`: sort, search, filters, grouping, page size, visible columns), frozen column, sticky header with `MaxHeight`, conditional row and cell formatting
  - accessible by default: table caption, labelled checkboxes, `aria-current` paging, no clickable-only headers
- `GridAggregate` and `GridCsv` helpers; demo tab *Data Grid*; browser suite `tests/e2e/grid_e2e.py` (keyboard sorting, real CSV download, reload persistence, sticky column, mobile cards, axe-core).
- **Planning & Enterprise suite**, 15 new components (219 to 234): `TwScheduler`, `TwGantt`, `TwTreeList`, `TwToolbar`, `TwWindow`, `TwLoadingPanel`, `TwStackLayout`, `TwFormLayout`, `TwFormGroup`, `TwFormItem`, `TwListBox`, `TwDropDownBox`, `TwHtmlEditor`, `TwRangeSelector`, `TwBarGauge`. All are our own Tailwind implementations.
- `TwHtmlEditor` sanitizes in the browser with an allowlist (no scripts, handlers, styles, images or frames; only http, https and mailto links; pasted content becomes plain text).
- Demo tab *Planning & Enterprise* and the browser suite `tests/e2e/enterprise_e2e.py` (drag-and-drop, real mouse window drag, hostile-input sanitizer checks, axe-core).

## [0.6.0]

Agent-native release: human-in-the-loop agent components, a live AG-UI transport, and an accessibility layer. 193 to **219 components**. Targets .NET 10+ (`net10.0`).

### Added

**Agent Ops (human in the loop)**
- `AgentRunSession` and the `IAgentTransport` abstraction (an `IAsyncEnumerable<AgUiEvent>` modelled on the AG-UI event stream).
- Approval gates that genuinely block high-risk tool calls, with edited and validated JSON arguments, or rejection with a reason that reroutes the agent.
- Takeover and hand-back: the agent pauses before its next step and the human's edits to shared state change what it does next.
- Exportable JSON audit trail.
- Components: `TwAgentConsole`, `TwApprovalGate`, `TwToolCallCard`, `TwTakeoverBar`, `TwAgentStateInspector`, `TwAuditTrail`, `TwAgentRoster`.
- `SimulatedAgentTransport`: an offline refund-desk agent, so the demo needs no backend.

**Live AG-UI over server-sent events**
- `SseAgentTransport`, `SseParser` and `AgUiWireMapper`: POST the run, parse `text/event-stream`, map AG-UI wire events, and report approval decisions (with edited arguments) back so the server holds the run at the gate.
- `tests/e2e/agui_server.py`: a small reference agent.
- A *Live AG-UI endpoint* switch on the Agent Ops tab (`AgentOpsWorkspace`).

**Threads**
- `AgentThreadStore` / `IAgentThreadStore` (persisted to `localStorage`) and `TwThreadList` (search, new, rename, pin, archive, delete). `TwAgentConsole` gains `ShowThreads`, `Transport` and `TransportLabel`.

**Generative UI, voice and chat pieces**
- `TwA2uiSurface` with `A2uiSurface`: agent-described UI (A2UI v0.9) with data binding and button actions.
- `TwMcpAppFrame`: sandboxed MCP app host (opaque origin, locked-down CSP, `postMessage` bridge).
- `TwVoiceInput`, `TwLiveWaveform`, `TwChatSuggestions`, `TwFeedbackButtons`, `TwAttachmentQueue`, `TwMessageScroller`.

**Agent control plane**
- `TwHandoffPanel`, `TwLiveScreen`, `TwDryRunChanges`, `TwActivityLog`, `TwCommandOutput`, `TwRedactedValue` (with `RedactionService`), `TwGrantList`, `TwMemoryList`, `TwRoutinesList`, `TwQuestionnaire`, `TwAgentOrb`.

**Inputs and controls**
- `TwCalendar` (ARIA date-grid keyboard model), `TwTimePicker`, `TwRadioGroup<TValue>`, `TwTextArea`, `TwButtonGroup`, `TwSpinner`.

**Accessibility**
- High-contrast mode (theme-menu toggle or OS `prefers-contrast`, applied before first paint), `forced-colors` support, global reduced-motion handling, RTL-safe logical properties in the new components.

**Quality**
- bUnit/xUnit suite grown from 0 to 92 tests, including a catalog integrity test.
- Playwright browser suites (`tests/e2e/agent_ops_e2e.py`, `tests/e2e/agent_kit_e2e.py`) with axe-core WCAG 2.x A/AA audits and screenshots.

### Release artifacts
- `BlazorTailwindUI-0.6.0-x64-Setup.exe` (NSIS), `BlazorTailwindUI-0.6.0-x64-en-US.msi` (WiX) and `BlazorTailwindUI-WebDemo-v0.6.0.zip`,, with `SHA256SUMS.txt` (SHA-256 checksums).

### Credits
- Several components are modelled on patterns in [CopilotKit](https://github.com/CopilotKit/CopilotKit) and [OpenBot](https://github.com/CopilotKit/OpenBot) (both MIT). They are our own C# implementations. Only the credential-key redaction rules and the MCP sandbox CSP host-source pattern are adapted from CopilotKit source. `TwThreadList`, `SseAgentTransport` (including its approval-decision endpoint) and the form, input and time components are our own design. See `THIRD_PARTY_NOTICES.md`.

### Fixed
- The CRM dashboard leaked a `window` resize listener and threw once it was torn down.
- GridStack was referenced by `index.html` but never committed because `.gitignore` excludes `dist/`; version 12.3.3 is now vendored.
- Audit export mixed key casing; it is now camelCase throughout.
- Edited approval arguments carried over into the next run.

### Changed
- `docs/COMPONENT_CATALOG.md` is now generated from `ComponentCatalogService` (219 components, 43 categories, source links and parameter tables for all); a test fails when it is out of date.
- The README runtime badge now reads .NET 10+ to match the project target.
- Roadmap items renumbered so they are unique.

[0.7.0]: https://github.com/donpotts/BlazorTailwindUI/releases/tag/v0.7.0
[0.6.0]: https://github.com/donpotts/BlazorTailwindUI/releases/tag/v0.6.0
