namespace BlazorTailwindUI.Models;

public enum ThemeMode
{
    Light,
    Dark,
    System
}

public enum ContrastMode
{
    /// <summary>Follow the operating system's prefers-contrast setting</summary>
    System,
    Standard,
    High
}

public enum AccentTheme
{
    Indigo,
    Emerald,
    Rose,
    Amber,
    Violet,
    Sky,
    Cyan,
    Teal,
    Fuchsia,
    Pink,
    Orange,
    Slate
}

public enum LayoutVariant
{
    /// <summary>Off-canvas drawer on mobile, persistent sidebar on desktop + mobile bottom nav</summary>
    Sidebar,
    /// <summary>Sticky horizontal top navigation bar with hamburger drawer on mobile</summary>
    TopNav,
    /// <summary>Compact icon-only rail on tablet/desktop + bottom nav on mobile</summary>
    CompactRail,
    /// <summary>Centered stacked single-column container layout</summary>
    Stacked
}

public enum ButtonVariant
{
    Primary,
    Secondary,
    Outline,
    Ghost,
    Destructive
}

public enum ComponentSize
{
    Xs,
    Sm,
    Md,
    Lg,
    Xl
}

public enum SemanticVariant
{
    Default,
    Primary,
    Success,
    Warning,
    Danger,
    Info
}

public enum DrawerPlacement
{
    Left,
    Right,
    Bottom
}

public enum TwPopoverPlacement
{
    Top,
    TopStart,
    TopEnd,
    Bottom,
    BottomStart,
    BottomEnd,
    Left,
    Right
}

public enum TwPopoverTrigger
{
    Click,
    Hover,
    Manual
}

public enum TwPopoverStrategy
{
    Fixed,
    Absolute
}

public enum TwSnackbarPosition
{
    BottomCenter,
    BottomLeft,
    BottomRight,
    TopCenter,
    TopLeft,
    TopRight
}

public enum WordBalloonShape
{
    PillCapsule,
    ComicBurst,
    SpeechBubble,
    CyberHexagon,
    CloudPuff
}

public enum WordBalloonEffect
{
    Bold,
    Outlined,
    PowEffect,
    NeonGlow,
    GradientChrome
}

public enum WordBalloonTheme
{
    IndigoViolet,
    ComicYellow,
    CrimsonBurst,
    EmeraldTech,
    CyberCyan
}
