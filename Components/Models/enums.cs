using System;
namespace MulTools.Components
{
    public enum ScreenPosition
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
        Center
    }

    public enum GetWindowMode : uint
    {
        GW_HWNDFIRST = 0,
        GW_HWNDLAST = 1,
        GW_HWNDNEXT = 2,
        GW_HWNDPREV = 3,
        GW_OWNER = 4,
        GW_CHILD = 5,
        GW_ENABLEDPOPUP = 6
    }

    public enum WindowLong
    {
        WndProc = (-4),
        HInstance = (-6),
        HwndParent = (-8),
        Style = (-16),
        ExStyle = (-20),
        UserData = (-21),
        Id = (-12)
    }

    [Flags]
    public enum WindowStyles : long
    {
        None = 0,
        Child = 0x40000000L,
        Disabled = 0x8000000L,
        Minimize = 0x20000000L,
        MinimizeBox = 0x20000L,
        Visible = 0x10000000L
    }

    [Flags]
    public enum WindowExStyles : long
    {
        AppWindow = 0x40000,
        Layered = 0x80000,
        NoActivate = 0x8000000L,
        ToolWindow = 0x80,
        TopMost = 8,
        Transparent = 0x20
    }

    [Flags]
    public enum SendMessageTimeoutFlags : uint
    {
        AbortIfHung = 2,
        Block = 1,
        Normal = 0
    }

    public enum ClassLong
    {
        Icon = -14,
        IconSmall = -34
    }

    public enum Cols
    {
        文件名,
        文件类型,
        MD5
    }
}
