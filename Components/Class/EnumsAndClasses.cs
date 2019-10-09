using System;
namespace MulTools.Components.Enums
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

    /// <summary>
    /// Windows Message codes.
    /// </summary>
    public static class WM
    {
        public const int GETICON = 0x7f;
        public const int SIZING = 0x214;
        public const int NCHITTEST = 0x84;
        public const int NCPAINT = 0x0085;
        public const int LBUTTONDOWN = 0x0201;
        public const int LBUTTONUP = 0x0202;
        public const int LBUTTONDBLCLK = 0x0203;
        public const int RBUTTONDOWN = 0x0204;
        public const int RBUTTONUP = 0x0205;
        public const int RBUTTONDBLCLK = 0x0206;
        public const int NCLBUTTONUP = 0x00A2;
        public const int NCLBUTTONDOWN = 0x00A1;
        public const int NCLBUTTONDBLCLK = 0x00A3;
        public const int NCRBUTTONUP = 0x00A5;
        public const int NCMOUSELEAVE = 0x02A2;
        public const int SYSCOMMAND = 0x0112;
        public const int GETTEXT = 0x000D;
        public const int GETTEXTLENGTH = 0x000E;
    }

    public static class WMSZ
    {
        public const int LEFT = 1;
        public const int RIGHT = 2;
        public const int TOP = 3;
        public const int BOTTOM = 6;
    }

    public static class HT
    {
        public const int TRANSPARENT = -1;
        public const int CLIENT = 1;
        public const int CAPTION = 2;
    }

    /// <summary>
    /// 权限
    /// </summary>
    public static class WPrivilege
    {
        internal const string SE_CREATE_TOKEN_NAME = "SeCreateTokenPrivilege";
        internal const string SE_ASSIGNPRIMARYTOKEN_NAME = "SeAssignPrimaryTokenPrivilege";
        internal const string SE_LOCK_MEMORY_NAME = "SeLockMemoryPrivilege";
        internal const string SE_INCREASE_QUOTA_NAME = "SeIncreaseQuotaPrivilege";
        internal const string SE_UNSOLICITED_INPUT_NAME = "SeUnsolicitedInputPrivilege";
        internal const string SE_MACHINE_ACCOUNT_NAME = "SeMachineAccountPrivilege";
        internal const string SE_TCB_NAME = "SeTcbPrivilege";
        internal const string SE_SECURITY_NAME = "SeSecurityPrivilege";
        internal const string SE_TAKE_OWNERSHIP_NAME = "SeTakeOwnershipPrivilege";
        internal const string SE_LOAD_DRIVER_NAME = "SeLoadDriverPrivilege";
        internal const string SE_SYSTEM_PROFILE_NAME = "SeSystemProfilePrivilege";
        internal const string SE_SYSTEMTIME_NAME = "SeSystemtimePrivilege";
        internal const string SE_PROF_SINGLE_PROCESS_NAME = "SeProfileSingleProcessPrivilege";
        internal const string SE_INC_BASE_PRIORITY_NAME = "SeIncreaseBasePriorityPrivilege";
        internal const string SE_CREATE_PAGEFILE_NAME = "SeCreatePagefilePrivilege";
        internal const string SE_CREATE_PERMANENT_NAME = "SeCreatePermanentPrivilege";
        internal const string SE_BACKUP_NAME = "SeBackupPrivilege";
        internal const string SE_RESTORE_NAME = "SeRestorePrivilege";
        internal const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
        internal const string SE_DEBUG_NAME = "SeDebugPrivilege";
        internal const string SE_AUDIT_NAME = "SeAuditPrivilege";
        internal const string SE_SYSTEM_ENVIRONMENT_NAME = "SeSystemEnvironmentPrivilege";
        internal const string SE_CHANGE_NOTIFY_NAME = "SeChangeNotifyPrivilege";
        internal const string SE_REMOTE_SHUTDOWN_NAME = "SeRemoteShutdownPrivilege";
        internal const string SE_UNDOCK_NAME = "SeUndockPrivilege";
        internal const string SE_SYNC_AGENT_NAME = "SeSyncAgentPrivilege";
        internal const string SE_ENABLE_DELEGATION_NAME = "SeEnableDelegationPrivilege";
        internal const string SE_MANAGE_VOLUME_NAME = "SeManageVolumePrivilege";
        internal const string SE_IMPERSONATE_NAME = "SeImpersonatePrivilege";
        internal const string SE_CREATE_GLOBAL_NAME = "SeCreateGlobalPrivilege";
        internal const string SE_TRUSTED_CREDMAN_ACCESS_NAME = "SeTrustedCredManAccessPrivilege";
        internal const string SE_RELABEL_NAME = "SeRelabelPrivilege";
        internal const string SE_INC_WORKING_SET_NAME = "SeIncreaseWorkingSetPrivilege";
        internal const string SE_TIME_ZONE_NAME = "SeTimeZonePrivilege";
        internal const string SE_CREATE_SYMBOLIC_LINK_NAME = "SeCreateSymbolicLinkPrivilege";
    }

    /// <summary>
    /// 关机
    /// </summary>
    public static class EWX
    {
        public const int EWX_LOGOFF = 0x00000000;//ExitWindowsEx的参数类型：关闭所有进程然后注销用户
        public const int EWX_SHUTDOWN = 0x00000001;//ExitWindowsEx的参数类型：关机
        public const int EWX_REBOOT = 0x00000002;//ExitWindowsEx的参数类型：重启
        public const int EWX_FORCE = 0x00000004;
        public const int EWX_POWEROFF = 0x00000008;//ExitWindowsEx的参数类型：关闭系统并关闭电源，该系统必须支持断电
        public const int EWX_FORCEIFHUNG = 0x00000010;
    }
}
