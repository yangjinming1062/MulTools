using System.Runtime.InteropServices;
using System.Drawing;

namespace MulTools.Components.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NRectangle
    {
        public NRectangle(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public NRectangle(System.Drawing.Rectangle rect)
        {
            Left = rect.X;
            Top = rect.Y;
            Right = rect.Right;
            Bottom = rect.Bottom;
        }

        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public int Width => Right - Left;
        public int Height => Bottom - Top;

        public System.Drawing.Rectangle ToRectangle() => new System.Drawing.Rectangle(Left, Top, Right - Left, Bottom - Top);

        public System.Drawing.Size Size => new System.Drawing.Size(Width, Height);

        public override string ToString() => string.Format("{{{0},{1},{2},{3}}}", Left, Top, Right, Bottom);
    }

    static class NRectangleExtensions
    {
        public static NRectangle ToNativeRectangle(this Size size) => new NRectangle(0, 0, size.Width, size.Height);
    }
}
