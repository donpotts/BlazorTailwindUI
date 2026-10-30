# Changelog

All notable changes to BlazorTailwindUI are documented here. The format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/) and the project uses [Semantic Versioning](https://semver.org/).

## [1.6.0]

Agent-native release: human-in-the-loop agent components, a live AG-UI transport, and an accessibility layer. 193 to **219 components**. Targets .NET 10 (`net10.0`).

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

**From CopilotKit**
- `TwA2uiSurface` with `A2uiSurface`: agent-described UI (A2UI v0.9) with data binding and button actions.
- `TwMcpAppFrame`: sandboxed MCP app host (opaque origin, locked-down CSP, `postMessage` bridge).
- `TwVoiceInput`, `TwLiveWaveform`, `TwChatSuggestions`, `TwFeedbackButtons`, `TwAttachmentQueue`, `TwMessageScroller`.

**From OpenBot**
- `TwHandoffPanel`, `TwLiveScreen`, `TwDryRunChanges`, `TwActivityLog`, `TwCommandOutput`, `TwRedactedValue` (with `RedactionService`), `TwGrantList`, `TwMemoryList`, `TwRoutinesList`, `TwQuestionnaire`, `TwAgentOrb`.

**From Blazor Toolkit**
- `TwCalendar` (ARIA date-grid keyboard model), `TwTimePicker`, `TwRadioGroup<TValue>`, `TwTextArea`, `TwButtonGroup`, `TwSpinner`.

**Accessibility**
- High-contrast mode (theme-menu toggle or OS `prefers-contrast`, applied before first paint), `forced-colors` support, global reduced-motion handling, RTL-safe logical properties in the new components.

**Quality**
- bUnit/xUnit suite grown from 0 to 92 tests, including a catalog integrity test.
- Playwright browser suites (`tests/e2e/agent_ops_e2e.py`, `tests/e2e/agent_kit_e2e.py`) with axe-core WCAG 2.x A/AA audits and screenshots.

### Fixed
- The CRM dashboard leaked a `window` resize listener and threw once it was torn down.
- GridStack was referenced by `index.html` but never committed because `.gitignore` excludes `dist/`; version 12.3.3 is now vendored.
- Audit export mixed key casing; it is now camelCase throughout.
- Edited approval arguments carried over into the next run.

### Changed
- The README runtime badge now reads .NET 10 to match the project target.
- Roadmap items renumbered so they are unique.

[1.6.0]: https://github.com/donpotts/BlazorTailwindUI/compare/v1.5.0...v1.6.0
