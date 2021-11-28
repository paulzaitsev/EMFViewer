using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;

namespace EMFAssembly {
    [StructLayout(LayoutKind.Sequential), CLSCompliant(false)]
    public struct COLORREF {
        uint _ColorRef;
        public COLORREF(Color aValue) {
            int lRGB = aValue.ToArgb();
            int n0 = (lRGB & 0xff) << 16;
            lRGB = lRGB & 0xffff00;
            lRGB = (lRGB | (lRGB >> 16 & 0xff));
            lRGB = (lRGB & 0xffff);
            lRGB = (lRGB | n0);
            _ColorRef = (uint) lRGB;
        }
        public Color ToColor() {
            int r = (int) _ColorRef & 0xff;
            int g = ((int) _ColorRef >> 8) & 0xff;
            int b = ((int) _ColorRef >> 16) & 0xff;
            return Color.FromArgb(r, g, b);
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class LOGFONT {
        public int lfHeight;
        public int lfWidth;
        public int lfEscapement;
        public int lfOrientation;
        public int lfWeight;
        public byte lfItalic;
        public byte lfUnderline;
        public byte lfStrikeOut;
        public byte lfCharSet;
        public byte lfOutPrecision;
        public byte lfClipPrecision;
        public byte lfQuality;
        public byte lfPitchAndFamily;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string lfFaceName = null;
    }

    public struct POINTS {
        public short x;
        public short y;
        public Point ToPoint() => new Point(x, y);
    }

    public struct RECT {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public RECT(int l, int t, int r, int b) {
            Left = l;
            Top = t;
            Right = r;
            Bottom = b;
        }

        public RECT(Rectangle r) {
            Left = r.Left;
            Top = r.Top;
            Right = r.Right;
            Bottom = r.Bottom;
        }
        [SecuritySafeCritical]
        public static RECT FromLParam(IntPtr lParam) => (RECT)Marshal.PtrToStructure(lParam, typeof(RECT));
        public IntPtr StructureToPtr() {
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(this));
            Marshal.StructureToPtr(this, ptr, false);
            return ptr;
        }
        public override string ToString() => $"x:{Left},y:{Top},width:{Right - Left},height:{Bottom - Top}";
    }

    public static class GDI {
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        internal static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);
        [SecuritySafeCritical]
        public delegate int ENHMFENUMPROC(IntPtr hdc, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
                                          IntPtr[] lpht, IntPtr lpmr, int nHandles, [In, Optional] int data);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        public static extern int ExtTextOut(IntPtr hdc, int x, int y, int options, ref Rectangle clip, string str, int len, [In, MarshalAs(UnmanagedType.LPArray)] int[] widths);
        [DllImport("gdi32.dll")]
        public static extern int SetBkMode(IntPtr hdc, int mode);
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern bool EnumEnhMetaFile([In, Optional] IntPtr hdc, IntPtr hmf, ENHMFENUMPROC proc, [In, Optional] IntPtr param, [In, Optional] IntPtr lpRect);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteEnhMetaFile(IntPtr hemf);
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern IntPtr CreateEnhMetaFile(IntPtr hdcRef, string lpFilename, IntPtr lpRect, string lpDescription);
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern IntPtr CloseEnhMetaFile(IntPtr hdc);
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern bool DeleteDC(IntPtr hdc);
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern IntPtr DeleteObject(IntPtr hDc);
        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        public static extern IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr hgdiobj);
        [DllImport("gdi32", EntryPoint = "GetEnhMetaFile")]
        public static extern IntPtr GetEnhMetaFileA(string lpszMetaFile);
        [DllImport("gdi32")]
        public static extern IntPtr GdiComment(IntPtr hDC, int cbSize, [In, MarshalAs(UnmanagedType.LPArray)] byte[] lpData);
        [DllImport("gdi32.dll")]
        public static extern bool PlayEnhMetaFile(IntPtr hdc, IntPtr hemf, ref RECT lpRect);
    }
}