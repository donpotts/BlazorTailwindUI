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

## 5. Summary Checklist for Production Readiness

- [x] All touch targets >= 44px.
- [x] Safe-area insets configured on mobile bars.
- [x] Zero external CDN links in index.html (self-contained fonts, scripts, videos).
- [x] Local Tailwind CLI compiled and minified (`npm run build:css`).
- [x] Zero commercial third-party brand dependencies.
- [x] Dark mode verified with zero white flashes on page reload.
