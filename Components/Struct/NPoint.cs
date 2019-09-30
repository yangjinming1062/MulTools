using System.Runtime.InteropServices;

namespace MulTools.Components.Struct
{
    /// <summary>
    /// Native Point structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NPoint
    {
        public int X, Y;

        public NPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public NPoint(NPoint copy)
        {
            X = copy.X;
            Y = copy.Y;
        }

        public static NPoint FromPoint(System.Drawing.Point point) => new NPoint(point.X, point.Y);

        public System.Drawing.Point ToPoint() => new System.Drawing.Point(X, Y);

        public override string ToString() => "{" + X + "," + Y + "}";
    }
}
