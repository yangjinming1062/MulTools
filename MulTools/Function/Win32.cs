using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MulTools.Function
{
    internal class Win32
    {
        #region 权限
        // 这个结构体将会传递给API。使用StructLayout 
        //(...特性，确保其中的成员是按顺序排列的，C#编译器不会对其进行调整。
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        /// <summary>
        /// LUID_AND_ATTRIBUTES结构
        /// </summary>
        internal struct TokPriv1Luid { public int PrivilegeCount; public long Luid; public int Attr; }

        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GetCurrentProcess();

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);

        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool LookupPrivilegeValue(string host, string newPrivileges, ref long pluid);

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall, ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);

        internal const int SE_PRIVILEGE_ENABLED = 0x00000002;
        internal const int TOKEN_QUERY = 0x00000008;
        internal const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;

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

        public static string[] PrivilegesList = { SE_CREATE_TOKEN_NAME, SE_ASSIGNPRIMARYTOKEN_NAME, SE_LOCK_MEMORY_NAME, SE_INCREASE_QUOTA_NAME, SE_UNSOLICITED_INPUT_NAME, SE_MACHINE_ACCOUNT_NAME
                                  ,SE_TCB_NAME,SE_SECURITY_NAME,SE_TAKE_OWNERSHIP_NAME,SE_LOAD_DRIVER_NAME,SE_SYSTEM_PROFILE_NAME,SE_SYSTEMTIME_NAME,SE_PROF_SINGLE_PROCESS_NAME,
                                  SE_INC_BASE_PRIORITY_NAME,SE_CREATE_PAGEFILE_NAME,SE_CREATE_PERMANENT_NAME,SE_BACKUP_NAME,SE_RESTORE_NAME,SE_SHUTDOWN_NAME,SE_DEBUG_NAME,SE_AUDIT_NAME,
                                  SE_SYSTEM_ENVIRONMENT_NAME,SE_CHANGE_NOTIFY_NAME,SE_REMOTE_SHUTDOWN_NAME,SE_UNDOCK_NAME,SE_SYNC_AGENT_NAME,SE_ENABLE_DELEGATION_NAME,SE_MANAGE_VOLUME_NAME,
                                  SE_IMPERSONATE_NAME,SE_CREATE_GLOBAL_NAME,SE_TRUSTED_CREDMAN_ACCESS_NAME,SE_RELABEL_NAME,SE_INC_WORKING_SET_NAME,SE_TIME_ZONE_NAME,SE_CREATE_SYMBOLIC_LINK_NAME};
        #endregion

        #region 热键
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);//注册热键

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);//取消注册热键

        public const int WM_HOTKEY = 0x312;//热键
        #endregion

        #region 关机
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool ExitWindowsEx(int flg, int rea);//关机

        internal const int EWX_LOGOFF = 0x00000000;//ExitWindowsEx的参数类型：关闭所有进程然后注销用户
        internal const int EWX_SHUTDOWN = 0x00000001;//ExitWindowsEx的参数类型：关机
        internal const int EWX_REBOOT = 0x00000002;//ExitWindowsEx的参数类型：重启
        internal const int EWX_FORCE = 0x00000004;
        internal const int EWX_POWEROFF = 0x00000008;//ExitWindowsEx的参数类型：关闭系统并关闭电源，该系统必须支持断电
        internal const int EWX_FORCEIFHUNG = 0x00000010;
        #endregion
    }
}
