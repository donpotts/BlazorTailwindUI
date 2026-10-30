# Third-party notices

BlazorTailwindUI is MIT licensed. Portions below are adapted from, or modelled on, other MIT-licensed projects.

## CopilotKit

<https://github.com/CopilotKit/CopilotKit>. Adapted: the credential-key classification rules in `Services/RedactionService.cs` (from the `learning` package) and the CSP host-source pattern and sandbox flags in `Components/UI/TwMcpAppFrame.razor` (from the `mcp-apps-renderer` package). Components modelled on, but not copied from, its `react-ui` chat components: `TwChatSuggestions`, `TwFeedbackButtons`, `TwAttachmentQueue`.

```
The MIT License

Copyright (c) Atai Barkai

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
```

## OpenBot

<https://github.com/CopilotKit/OpenBot>. UI concepts only (activity log, command output, handoff, live screen, grants, memory, routines, questionnaire, orb, waveform, message scroller, dry-run). The C# components are our own implementations and contain no OpenBot code. Its license, for reference:

```
MIT License

Copyright (c) 2026 CopilotKit
```

## AG-UI and A2UI

The event stream implemented by `SseAgentTransport` follows the AG-UI protocol (<https://github.com/ag-ui-protocol/ag-ui>). `A2uiSurface` follows the A2UI v0.9 message model. Both are independent C# implementations.

## GridStack

Vendored at `wwwroot/lib/gridstack` (version 12.3.3), MIT, <https://github.com/gridstack/gridstack.js>.
