using System.Runtime.InteropServices;

namespace MulTools.Components.Struct
{
    // 这个结构体将会传递给API。使用StructLayout 
    //(...特性，确保其中的成员是按顺序排列的，C#编译器不会对其进行调整。
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    /// <summary>
    /// LUID_AND_ATTRIBUTES结构
    /// </summary>
    public struct TokPriv1Luid
    {
        public int PrivilegeCount;
        public long Luid;
        public int Attr;
    }
}
