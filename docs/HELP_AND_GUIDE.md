# Blazor Tailwind UI — Help, Quick Reference & Troubleshooting Guide

This guide is designed for developers, architects, and teams building and maintaining modern Blazor WebAssembly applications with **BlazorTailwindUI**.

---

## 1. Quick Reference & Cheatsheet

### Global Keyboard Shortcuts
| Shortcut | Action | Description |
|---|---|---|
| <kbd>⌘K</kbd> / <kbd>Ctrl+K</kbd> | Open Command Palette | Global quick navigation, action execution, and component search. |
| <kbd>Shift+V</kbd> | Watch 1080p Video Tour | Opens full HD video masterclass modal with chapter scrubber. |
| <kbd>Shift+T</kbd> | Launch Coaching Tour | Starts 8-step guided interactive walkthrough. |
| <kbd>Shift+C</kbd> | Fire Celebration Confetti | Triggers celebratory canvas particle burst. |
| <kbd>Esc</kbd> | Close Modal / Drawer | Cleanly dismisses any active overlay dialog or drawer. |

---

## 2. Common Recipes

### Recipe A: Adding a Draggable Before/After Image Comparison Slider
```razor
@using BlazorTailwindUI.Components.UI

<TwImageCompare BeforeSrc="images/compare-before.jpg"
                AfterSrc="images/compare-after.jpg"
                BeforeLabel="Original"
                AfterLabel="Enhanced"
                @bind-Position="_sliderPos"
                Class="aspect-video max-h-[450px]" />

<div class="mt-2 text-xs text-slate-500">
    Position: @_sliderPos.ToString("F0")%
</div>

@code {
    private double _sliderPos = 50.0;
}
```

### Recipe B: Continuous Infinite Logo / Tech Marquee
```razor
@using BlazorTailwindUI.Components.UI

<TwMarquee DurationSeconds="20" PauseOnHover="true" FadeEdges="true">
    <div class="flex items-center gap-2 px-4 py-2 rounded-xl bg-slate-100 dark:bg-slate-800">
        <span>⚡</span>
        <span class="font-bold text-sm">Blazor WASM .NET 11</span>
    </div>
    <div class="flex items-center gap-2 px-4 py-2 rounded-xl bg-slate-100 dark:bg-slate-800">
        <span>🎨</span>
        <span class="font-bold text-sm">Tailwind CSS v3.4+</span>
    </div>
</TwMarquee>
```

### Recipe C: Digital Canvas Signature Pad with PNG Export
```razor
@using BlazorTailwindUI.Components.UI

<TwSignaturePad Title="Customer Verification Signature"
                Height="220"
                ShowGuide="true"
                OnSave="HandleSignatureSaved" />

@code {
    private string? _savedSignaturePng;

    private void HandleSignatureSaved(string dataUrl)
    {
        _savedSignaturePng = dataUrl;
        // Submit dataUrl or save to backend API
    }
}
```

### Recipe D: Vector QR Code & Code 128 Barcode Generation
```razor
@using BlazorTailwindUI.Components.UI

<!-- 2D QR Code with Custom Center Icon & Rounded Dots -->
<TwQrCode Value="https://example.com/checkout"
          Title="Secure Payment QR"
          Size="200"
          DotShape="TwQrCode.QrDotShape.Rounded"
          CenterIcon="TwQrCode.QrCenterIcon.Bolt" />

<!-- 1D Logistics Barcode -->
<TwBarcode Value="PKG-982410-USA"
           Title="Tracking Code 128"
           BarHeight="64"
           ShowText="true" />
```

### Recipe E: Celebrating Milestones with Canvas Confetti
```razor
@using BlazorTailwindUI.Components.UI

<TwButton Variant="ButtonVariant.Primary" OnClick="Celebrate">
    Submit Order 🎉
</TwButton>

<TwConfetti @ref="_confetti" FullScreen="true" />

@code {
    private TwConfetti? _confetti;

    private async Task Celebrate()
    {
        // Process logic...
        if (_confetti != null)
        {
            await _confetti.FireAsync(0.5, 0.4, 120);
        }
    }
}
```

---

## 3. Troubleshooting & FAQs

### Q: Why do I see an HTTP 416 (Range Not Satisfiable) error on video playback?
**Cause**: When replacing a video or media file on disk while the ASP.NET Core DevServer is running, the server caches the previous file size in memory. When the browser makes a byte-range request for the old file length, a 416 status occurs.  
**Fix**: Restart the development server (`dotnet run`) after changing static media files in `wwwroot/`.

### Q: Why does the Guided Coaching Tour show a blank modal when launched a second time?
**Cause**: When `TwTour` finishes, its internal step index is at the end. Without a lifecycle hook, reopening leaves the step index at the terminal state.  
**Fix**: `TwTour.razor` implements `OnParametersSet()` to automatically reset `CurrentStepIndex = 0` whenever `IsOpen` transitions from `false` to `true`.

### Q: How do I compile new custom Tailwind classes?
Run the standalone Tailwind CLI:
```bash
npm run build:css
```
This scans all `.razor` and `.cs` files and compiles minified CSS to `wwwroot/css/app.min.css`.

---

## 4. Architectural Rules Summary
1. **Zero Prohibited Commercial Brands**: Strictly vendor-neutral.
2. **Strict .NET 11 RC WebAssembly**: No server-side rendering dependencies for components.
3. **Pure Mobile-First**: 44px min touch targets, adaptive card fallbacks, and safe-area padding.
