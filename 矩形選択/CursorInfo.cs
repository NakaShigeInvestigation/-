using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace 矩形選択
{
    public static class CursorInfo
    {
        private struct POINT
        {
            public UInt32 X;
            public UInt32 Y;
        }

        [DllImport("user32.dll")]
        private static extern void GetCursorPos(out POINT pt);

        [DllImport("user32.dll")]
        private static extern int ScreenToClient(IntPtr hwnd, ref POINT pt);

        public static Point GetNowPosition(Visual v)
        {
            POINT pt;
            GetCursorPos(out pt);

            var source = HwndSource.FromVisual(v) as HwndSource;
            var hwnd = source.Handle;

            ScreenToClient(hwnd, ref pt);
            return new Point(pt.X, pt.Y);
        }
    }
}
