using System;
using System.Runtime.InteropServices;

namespace EMFAssembly {
    public class RecordType {
        // Enhanced metafile record types.

        public const int EMR_HEADER = 1;
        public const int EMR_POLYBEZIER = 2;
        public const int EMR_POLYGON = 3;
        public const int EMR_POLYLINE = 4;
        public const int EMR_POLYBEZIERTO = 5;
        public const int EMR_POLYLINETO = 6;
        public const int EMR_POLYPOLYLINE = 7;
        public const int EMR_POLYPOLYGON = 8;
        public const int EMR_SETWINDOWEXTEX = 9;
        public const int EMR_SETWINDOWORGEX = 10;
        public const int EMR_SETVIEWPORTEXTEX = 11;
        public const int EMR_SETVIEWPORTORGEX = 12;
        public const int EMR_SETBRUSHORGEX = 13;
        public const int EMR_EOF = 14;
        public const int EMR_SETPIXELV = 15;
        public const int EMR_SETMAPPERFLAGS = 16;
        public const int EMR_SETMAPMODE = 17;
        public const int EMR_SETBKMODE = 18;
        public const int EMR_SETPOLYFILLMODE = 19;
        public const int EMR_SETROP2 = 20;
        public const int EMR_SETSTRETCHBLTMODE = 21;
        public const int EMR_SETTEXTALIGN = 22;
        public const int EMR_SETCOLORADJUSTMENT = 23;
        public const int EMR_SETTEXTCOLOR = 24;
        public const int EMR_SETBKCOLOR = 25;
        public const int EMR_OFFSETCLIPRGN = 26;
        public const int EMR_MOVETOEX = 27;
        public const int EMR_SETMETARGN = 28;
        public const int EMR_EXCLUDECLIPRECT = 29;
        public const int EMR_INTERSECTCLIPRECT = 30;
        public const int EMR_SCALEVIEWPORTEXTEX = 31;
        public const int EMR_SCALEWINDOWEXTEX = 32;
        public const int EMR_SAVEDC = 33;
        public const int EMR_RESTOREDC = 34;
        public const int EMR_SETWORLDTRANSFORM = 35;
        public const int EMR_MODIFYWORLDTRANSFORM = 36;
        public const int EMR_SELECTOBJECT = 37;
        public const int EMR_CREATEPEN = 38;
        public const int EMR_CREATEBRUSHINDIRECT = 39;
        public const int EMR_DELETEOBJECT = 40;
        public const int EMR_ANGLEARC = 41;
        public const int EMR_ELLIPSE = 42;
        public const int EMR_RECTANGLE = 43;
        public const int EMR_ROUNDRECT = 44;
        public const int EMR_ARC = 45;
        public const int EMR_CHORD = 46;
        public const int EMR_PIE = 47;
        public const int EMR_SELECTPALETTE = 48;
        public const int EMR_CREATEPALETTE = 49;
        public const int EMR_SETPALETTEENTRIES = 50;
        public const int EMR_RESIZEPALETTE = 51;
        public const int EMR_REALIZEPALETTE = 52;
        public const int EMR_EXTFLOODFILL = 53;
        public const int EMR_LINETO = 54;
        public const int EMR_ARCTO = 55;
        public const int EMR_POLYDRAW = 56;
        public const int EMR_SETARCDIRECTION = 57;
        public const int EMR_SETMITERLIMIT = 58;
        public const int EMR_BEGINPATH = 59;
        public const int EMR_ENDPATH = 60;
        public const int EMR_CLOSEFIGURE = 61;
        public const int EMR_FILLPATH = 62;
        public const int EMR_STROKEANDFILLPATH = 63;
        public const int EMR_STROKEPATH = 64;
        public const int EMR_FLATTENPATH = 65;
        public const int EMR_WIDENPATH = 66;
        public const int EMR_SELECTCLIPPATH = 67;
        public const int EMR_ABORTPATH = 68;

        public const int EMR_GDICOMMENT = 70;
        public const int EMR_FILLRGN = 71;
        public const int EMR_FRAMERGN = 72;
        public const int EMR_INVERTRGN = 73;
        public const int EMR_PAINTRGN = 74;
        public const int EMR_EXTSELECTCLIPRGN = 75;
        public const int EMR_BITBLT = 76;
        public const int EMR_STRETCHBLT = 77;
        public const int EMR_MASKBLT = 78;
        public const int EMR_PLGBLT = 79;
        public const int EMR_SETDIBITSTODEVICE = 80;
        public const int EMR_STRETCHDIBITS = 81;
        public const int EMR_EXTCREATEFONTINDIRECTW = 82;
        public const int EMR_EXTTEXTOUTA = 83;
        public const int EMR_EXTTEXTOUTW = 84;
        public const int EMR_POLYBEZIER16 = 85;
        public const int EMR_POLYGON16 = 86;
        public const int EMR_POLYLINE16 = 87;
        public const int EMR_POLYBEZIERTO16 = 88;
        public const int EMR_POLYLINETO16 = 89;
        public const int EMR_POLYPOLYLINE16 = 90;
        public const int EMR_POLYPOLYGON16 = 91;
        public const int EMR_POLYDRAW16 = 92;
        public const int EMR_CREATEMONOBRUSH = 93;
        public const int EMR_CREATEDIBPATTERNBRUSHPT = 94;
        public const int EMR_EXTCREATEPEN = 95;
        public const int EMR_POLYTEXTOUTA = 96;
        public const int EMR_POLYTEXTOUTW = 97;
        public const int EMR_SETICMMODE = 98;
        public const int EMR_CREATECOLORSPACE = 99;
        public const int EMR_SETCOLORSPACE = 100;
        public const int EMR_DELETECOLORSPACE = 101;

        public const int EMR_MIN = 1;

        public const int EMR_MAX = 97;


        public const uint GDICOMMENT_IDENTIFIER = 0x43494447;
        public const uint GDICOMMENT_WINDOWS_METAFILE = 0x80000001;
        public const uint GDICOMMENT_BEGINGROUP = 0x00000002;
        public const uint GDICOMMENT_ENDGROUP = 0x00000003;
        public const uint GDICOMMENT_MULTIFORMATS = 0x40000004;
        public const uint EPS_SIGNATURE = 0x46535045;
    }

    enum PenStyle {
        PS_COSMETIC = 0x00000000,
        PS_GEOMETRIC = 0x00010000,
        PS_ENDCAP_ROUND = 0x00000000,
        PS_ENDCAP_SQUARE = 0x00000100,
        PS_ENDCAP_FLAT = 0x00000200,
        PS_JOIN_ROUND = 0x00000000,
        PS_JOIN_BEVEL = 0x00001000,
        PS_JOIN_MITER = 0x00002000,
        PS_SOLID = 0x00000000,
        PS_DASH = 0x00000001,
        PS_DOT = 0x00000002,
        PS_DASHDOT = 0x00000003,
        PS_DASHDOTDOT = 0x00000004,
        PS_NULL = 0x00000005,
        PS_INSIDEFRAME = 0x00000006,
        PS_USERSTYLE = 0x00000007,
        PS_ALTERNATE = 0x00000008,
    }

    public enum StockObjects : uint {
        WHITE_BRUSH = 0x80000000,
        LTGRAY_BRUSH = 0x80000001,
        GRAY_BRUSH = 0x80000002,
        DKGRAY_BRUSH = 0x80000003,
        BLACK_BRUSH = 0x80000004,
        NULL_BRUSH = 0x80000005,
        HOLLOW_BRUSH = 0x80000005,
        WHITE_PEN = 0x80000006,
        BLACK_PEN = 0x80000007,
        NULL_PEN = 0x80000008,
        OEM_FIXED_FONT = 0x8000000A,
        ANSI_FIXED_FONT = 0x8000000B,
        ANSI_VAR_FONT = 0x8000000C,
        SYSTEM_FONT = 0x8000000D,
        DEVICE_DEFAULT_FONT = 0x8000000E,
        DEFAULT_PALETTE = 0x8000000F,
        SYSTEM_FIXED_FONT = 0x80000010,
        DEFAULT_GUI_FONT = 0x80000011,
        DC_BRUSH = 0x80000012,
        DC_PEN = 0x80000013
    }

    public enum BackgroundMode {
        TRANSPARENT = 0x0001,
        OPAQUE = 0x0002
    }

    enum BrushStyle {
        BS_SOLID = 0x0000,
        BS_NULL = 0x0001,
        BS_HATCHED = 0x0002,
        BS_PATTERN = 0x0003,
        BS_INDEXED = 0x0004,
        BS_DIBPATTERN = 0x0005,
        BS_DIBPATTERNPT = 0x0006,
        BS_PATTERN8X8 = 0x0007,
        BS_DIBPATTERN8X8 = 0x0008,
        BS_MONOPATTERN = 0x0009
    }

    public enum TextAlignment {
        TA_NOUPDATECP = 0x0000,
        TA_LEFT = 0x0000,
        TA_TOP = 0x0000,
        TA_UPDATECP = 0x0001,
        TA_RIGHT = 0x0002,
        TA_CENTER = 0x0006,
        TA_BOTTOM = 0x0008,
        TA_BASELINE = 0x0018,
        TA_RTLREADING = 0x0100
    }

    public enum EmfPlusObjectType {
        ObjectTypeInvalid = 0x00000000,
        ObjectTypeBrush = 0x00000001,
        ObjectTypePen = 0x00000002,
        ObjectTypePath = 0x00000003,
        ObjectTypeRegion = 0x00000004,
        ObjectTypeImage = 0x00000005,
        ObjectTypeFont = 0x00000006,
        ObjectTypeStringFormat = 0x00000007,
        ObjectTypeImageAttributes = 0x00000008,
        ObjectTypeCustomLineCap = 0x00000009
    }

    enum HatchStyle {
        HS_NONE_BECAUSE_SOLID = 0x0000,
        HS_NONE_BECAUSE_NULL = 0x0001,
        HS_SOLIDCLR = 0x0006,
        HS_DITHEREDCLR = 0x0007,
        HS_SOLIDTEXTCLR = 0x0008,
        HS_DITHEREDTEXTCLR = 0x0009,
        HS_SOLIDBKCLR = 0x000A,
        HS_DITHEREDBKCLR = 0x000B
    }

    public enum BrushType {
        BrushTypeSolidColor = 0x00000000,
        BrushTypeHatchFill = 0x00000001,
        BrushTypeTextureFill = 0x00000002,
        BrushTypePathGradient = 0x00000003,
        BrushTypeLinearGradient = 0x00000004
    }

    public enum UnitType {
        UnitTypeWorld = 0x00,
        UnitTypeDisplay = 0x01,
        UnitTypePixel = 0x02,
        UnitTypePoint = 0x03,
        UnitTypeInch = 0x04,
        UnitTypeDocument = 0x05,
        UnitTypeMillimeter = 0x06
    }

    public enum VerticalTextAlignment {
        VTA_TOP = 0x0000,
        VTA_RIGHT = 0x0000,
        VTA_BOTTOM = 0x0002,
        VTA_CENTER = 0x0006,
        VTA_LEFT = 0x0008,
        VTA_BASELINE = 0x0018
    }

    public enum StringDigitSubstitution {
        StringDigitSubstitutionUser = 0x00000000,
        StringDigitSubstitutionNone = 0x00000001,
        StringDigitSubstitutionNational = 0x00000002,
        StringDigitSubstitutionTraditional = 0x00000003
    }

    public struct ENHMETARECORD {
        public uint iType; // Record type EMR_XXX
        public uint nSize; // Record size in bytes
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SIZEL {
        public int cx;
        public int cy;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINTL {
        public int x;
        public int y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XFORM {
        public float eM11;
        public float eM12;
        public float eM21;
        public float eM22;
        public float eDx;
        public float eDy;

        public XFORM(float eM11, float eM12, float eM21, float eM22, float eDx, float eDy) {
            this.eM11 = eM11;
            this.eM12 = eM12;
            this.eM21 = eM21;
            this.eM22 = eM22;
            this.eDx = eDx;
            this.eDy = eDy;
        }

        /// <summary>
        ///   Allows implicit converstion to a managed transformation matrix.
        /// </summary>
        public static implicit operator System.Drawing.Drawing2D.Matrix(XFORM xf) {
            return new System.Drawing.Drawing2D.Matrix(xf.eM11, xf.eM12, xf.eM21, xf.eM22, xf.eDx, xf.eDy);
        }

        /// <summary>
        ///   Allows implicit converstion from a managed transformation matrix.
        /// </summary>
        public static implicit operator XFORM(System.Drawing.Drawing2D.Matrix m) {
            float[] elems = m.Elements;
            return new XFORM(elems[0], elems[1], elems[2], elems[3], elems[4], elems[5]);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRCOMMENT {
        public uint iType;
        public uint nSize;
        public uint DataSize;
        public CommentRecordBuffer CommentRecordBuffer;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CommentRecordBuffer {
        public uint CommentIdentifier;
        //public byte[] CommentRecordParam;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ENHMETAHEADER {
        public uint iType; // Record type EMR_HEADER
        public uint nSize; // Record size in bytes.  This may be greater
        // than the sizeof(ENHMETAHEADER).
        public RECTL rclBounds; // Inclusive-inclusive bounds in device units
        public RECTL rclFrame; // Inclusive-inclusive Picture Frame of metafile in .01 mm units
        public uint dSignature; // Signature.  Must be ENHMETA_SIGNATURE.
        public uint nVersion; // Version number
        public uint nbytes; // Size of the metafile in bytes
        public uint nRecords; // Number of records in the metafile
        public ushort nHandles; // Number of handles in the handle table
        // Handle index zero is reserved.
        public ushort sReserved; // Reserved.  Must be zero.
        public uint nDescription; // Number of chars in the unicode description string
        // This is 0 if there is no description string
        public uint offDescription; // Offset to the metafile description record.
        // This is 0 if there is no description string
        public uint nPalEntries; // Number of entries in the metafile palette.
        public SIZEL szlDevice; // Size of the reference device in pels
        public SIZEL szlMillimeters; // Size of the reference device in millimeters
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMR {
        public uint iType; // Enhanced metafile record type
        public uint nSize; // Length of the record in bytes.
        // This must be a multiple of 4.
    }

    // Base text record type for the enhanced metafile.
    [StructLayout(LayoutKind.Sequential)]
    public struct EMRTEXT {
        public POINTL ptlReference;
        public uint nChars;
        public uint offString; // Offset to the string
        public uint fOptions;
        public RECTL rcl;
        public uint offDx; // Offset to the inter-character spacing array.
        // This is always given.
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct EMRSELECTCLIPPATH {
        public EMR emr;
        public uint iMode;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRSETMITERLIMIT {
        public EMR emr;
        public float eMiterLimit;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRRESTOREDC {
        public EMR emr;
        public int iRelative; // Specifies a relative instance
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRSETARCDIRECTION {
        public EMR emr;
        public uint iArcDirection; // Specifies the arc direction in the
        // advanced graphics mode.
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRSETMAPPERFLAGS {
        public EMR emr;
        public uint dwFlags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRSETTEXTCOLOR {
        public EMR emr;
        public COLORREF crColor;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRSELECTOBJECT {
        public EMR emr;
        public uint ihObject; // Object handle index
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRSELECTCOLORSPACE {
        public EMR emr;
        public uint ihCS; // ColorSpace handle index
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRSELECTPALETTE {
        public EMR emr;
        public uint ihPal; // Palette handle index, background mode only
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRRESIZEPALETTE {
        public EMR emr;
        public uint ihPal; // Palette handle index
        public uint cEntries;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRGDICOMMENT {
        public EMR emr;
        public uint cbData; // Size of data in bytes
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I1, SizeConst = 64)]
        public byte[] Data;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMREOF {
        public EMR emr;
        public uint nPalEntries; // Number of palette entries
        public uint offPalEntries; // Offset to the palette entries
        public uint nSizeLast; // Same as nSize and must be the last uint
        // of the record.  The palette entries,
        // if exist, precede this field.
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRLINETO {
        public EMR emr;
        public POINTL ptl;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMROFFSETCLIPRGN {
        public EMR emr;
        public POINTL ptlOffset;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRFILLPATH {
        public EMR emr;
        public RECTL rclBounds; // Inclusive-inclusive bounds in device units
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMREXCLUDECLIPRECT {
        public EMR emr;
        public RECTL rclClip;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRSETVIEWPORTORGEX {
        public EMR emr;
        public POINTL ptlOrigin;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRSETVIEWPORTEXTEX {
        public EMR emr;
        public SIZEL szlExtent;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRSCALEVIEWPORTEXTEX {
        public EMR emr;
        public int xNum;
        public int xDenom;
        public int yNum;
        public int yDenom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRSETWORLDTRANSFORM {
        public EMR emr;
        public XFORM xform;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRMODIFYWORLDTRANSFORM {
        public EMR emr;
        public XFORM xform;
        public uint iMode;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRSETPIXELV {
        public EMR emr;
        public POINTL ptlPixel;
        public COLORREF crColor;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMREXTFLOODFILL {
        public EMR emr;
        public POINTL ptlStart;
        public COLORREF crColor;
        public uint iMode;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRELLIPSE {
        public EMR emr;
        public RECTL rclBox; // Inclusive-inclusive bounding rectangle
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRROUNDRECT {
        public EMR emr;
        public RECTL rclBox; // Inclusive-inclusive bounding rectangle
        public SIZEL szlCorner;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRARC {
        public EMR emr;
        public RECTL rclBox; // Inclusive-inclusive bounding rectangle
        public POINTL ptlStart;
        public POINTL ptlEnd;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRANGLEARC {
        public EMR emr;
        public POINTL ptlCenter;
        public uint nRadius;
        public float eStartAngle;
        public float eSweepAngle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRPOLYLINE {
        public EMR emr;
        public RECTL rclBounds; // Inclusive-inclusive bounds in device units
        public uint cptl;
        public POINTL[] aptl;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRPOLYLINE16 {
        public EMR emr;
        public RECTL rclBounds; // Inclusive-inclusive bounds in device units
        public uint cpts;
        public IntPtr apts;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRPOLYDRAW {
        public EMR emr;
        public RECTL rclBounds; // Inclusive-inclusive bounds in device units
        public uint cptl; // Number of points
        public POINTL[] aptl; // Array of points
        public byte[] abTypes; // Array of point types
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRPOLYDRAW16 {
        public EMR emr;
        public RECTL rclBounds; // Inclusive-inclusive bounds in device units
        public uint cpts; // Number of points
        public POINTS[] apts; // Array of points
        public byte[] abTypes; // Array of point types
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRPOLYPOLYLINE {
        public EMR emr;
        public RECTL rclBounds; // Inclusive-inclusive bounds in device units
        public uint nPolys; // Number of polys
        public uint cptl; // Total number of points in all polys
        uint[] aPolyCounts; // Array of point counts for each poly
        public POINTL[] aptl; // Array of points
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRPOLYPOLYLINE16 {
        public EMR emr;
        public RECTL rclBounds; // Inclusive-inclusive bounds in device units
        public uint nPolys; // Number of polys
        public uint cpts; // Total number of points in all polys
        uint[] aPolyCounts; // Array of point counts for each poly
        public POINTS[] apts; // Array of points
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRINVERTRGN {
        public EMR emr;
        public RECTL rclBounds; // Inclusive-inclusive bounds in device units
        public uint cbRgnData; // Size of region data in bytes
        public byte[] RgnData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRFILLRGN {
        public EMR emr;
        public RECTL rclBounds; // Inclusive-inclusive bounds in device units
        public uint cbRgnData; // Size of region data in bytes
        public uint ihBrush; // Brush handle index
        public byte[] RgnData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRFRAMERGN {
        public EMR emr;
        public RECTL rclBounds; // Inclusive-inclusive bounds in device units
        public uint cbRgnData; // Size of region data in bytes
        public uint ihBrush; // Brush handle index
        public SIZEL szlStroke;
        public byte[] RgnData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMREXTSELECTCLIPRGN {
        public EMR emr;
        public uint cbRgnData; // Size of region data in bytes
        public uint iMode;
        public byte[] RgnData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMREXTTEXTOUTA {
        public EMR emr;
        public RECTL rclBounds; // Inclusive-inclusive bounds in device units
        public uint iGraphicsMode; // Current graphics mode
        public float exScale; // X and Y scales from Page units to .01mm units
        public float eyScale; //   if graphics mode is GM_COMPATIBLE.
        public EMRTEXT emrtext; // This is followed by the string and spacing
        // array
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRPOLYTEXTOUT {
        public EMR emr;
        public RECTL rclBounds; // Inclusive-inclusive bounds in device units
        public uint iGraphicsMode; // Current graphics mode
        public float exScale; // X and Y scales from Page units to .01mm units
        public float eyScale; //   if graphics mode is GM_COMPATIBLE.
        public int cStrings;
        public EMRTEXT[] aemrtext; // Array of EMRTEXT structures.  This is
        // followed by the strings and spacing arrays.
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRBITBLT {
        public EMR emr;
        public RECTL rclBounds; // Inclusive-inclusive bounds in device units
        public int xDest;
        public int yDest;
        public int cxDest;
        public int cyDest;
        public uint dwRop;
        public int xSrc;
        public int ySrc;
        public XFORM xformSrc; // Source DC transform
        public COLORREF crBkColorSrc; // Source DC BkColor in RGB
        public uint iUsageSrc; // Source bitmap info color table usage
        // (DIB_RGB_COLORS)
        public uint offBmiSrc; // Offset to the source BITMAPINFO structure
        public uint cbBmiSrc; // Size of the source BITMAPINFO structure
        public uint offBitsSrc; // Offset to the source bitmap bits
        public uint cbBitsSrc; // Size of the source bitmap bits
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPINFOHEADER {
        public uint biSize;
        public int biWidth;
        public int biHeight;
        public ushort biPlanes;
        public ushort biBitCount;
        public uint biCompression;
        public uint biSizeImage;
        public int biXPelsPerMeter;
        public int biYPelsPerMeter;
        public uint biClrUsed;
        public uint biClrImportant;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RGBQUAD {
        public byte rgbBlue;
        public byte rgbGreen;
        public byte rgbRed;
        public byte rgbReserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPINFO {
        BITMAPINFOHEADER bmiHeader;
        RGBQUAD[] bmiColors;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRSTRETCHBLT {
        public EMR emr;
        public RECTL rclBounds; // Inclusive-inclusive bounds in device units
        public int xDest;
        public int yDest;
        public int cxDest;
        public int cyDest;
        public uint dwRop;
        public int xSrc;
        public int ySrc;
        public XFORM xformSrc; // Source DC transform
        public COLORREF crBkColorSrc; // Source DC BkColor in RGB
        public uint iUsageSrc; // Source bitmap info color table usage
        // (DIB_RGB_COLORS)
        public uint offBmiSrc; // Offset to the source BITMAPINFO structure
        public uint cbBmiSrc; // Size of the source BITMAPINFO structure
        public uint offBitsSrc; // Offset to the source bitmap bits
        public uint cbBitsSrc; // Size of the source bitmap bits
        public int cxSrc;
        public int cySrc;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRMASKBLT {
        public EMR emr;
        public RECTL rclBounds; // Inclusive-inclusive bounds in device units
        public int xDest;
        public int yDest;
        public int cxDest;
        public int cyDest;
        public uint dwRop;
        public int xSrc;
        public int ySrc;
        public XFORM xformSrc; // Source DC transform
        public COLORREF crBkColorSrc; // Source DC BkColor in RGB
        public uint iUsageSrc; // Source bitmap info color table usage
        // (DIB_RGB_COLORS)
        public uint offBmiSrc; // Offset to the source BITMAPINFO structure
        public uint cbBmiSrc; // Size of the source BITMAPINFO structure
        public uint offBitsSrc; // Offset to the source bitmap bits
        public uint cbBitsSrc; // Size of the source bitmap bits
        public int xMask;
        public int yMask;
        public uint iUsageMask; // Mask bitmap info color table usage
        public uint offBmiMask; // Offset to the mask BITMAPINFO structure if any
        public uint cbBmiMask; // Size of the mask BITMAPINFO structure if any
        public uint offBitsMask; // Offset to the mask bitmap bits if any
        public uint cbBitsMask; // Size of the mask bitmap bits if any
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRPLGBLT {
        public EMR emr;
        public RECTL rclBounds; // Inclusive-inclusive bounds in device units
        public POINTL[] aptlDest;
        public int xSrc;
        public int ySrc;
        public int cxSrc;
        public int cySrc;
        public XFORM xformSrc; // Source DC transform
        public COLORREF crBkColorSrc; // Source DC BkColor in RGB
        public uint iUsageSrc; // Source bitmap info color table usage
        // (DIB_RGB_COLORS)
        public uint offBmiSrc; // Offset to the source BITMAPINFO structure
        public uint cbBmiSrc; // Size of the source BITMAPINFO structure
        public uint offBitsSrc; // Offset to the source bitmap bits
        public uint cbBitsSrc; // Size of the source bitmap bits
        public int xMask;
        public int yMask;
        public uint iUsageMask; // Mask bitmap info color table usage
        public uint offBmiMask; // Offset to the mask BITMAPINFO structure if any
        public uint cbBmiMask; // Size of the mask BITMAPINFO structure if any
        public uint offBitsMask; // Offset to the mask bitmap bits if any
        public uint cbBitsMask; // Size of the mask bitmap bits if any
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRSETDIBITSTODEVICE {
        public EMR emr;
        public RECTL rclBounds; // Inclusive-inclusive bounds in device units
        public int xDest;
        public int yDest;
        public int xSrc;
        public int ySrc;
        public int cxSrc;
        public int cySrc;
        public uint offBmiSrc; // Offset to the source BITMAPINFO structure
        public uint cbBmiSrc; // Size of the source BITMAPINFO structure
        public uint offBitsSrc; // Offset to the source bitmap bits
        public uint cbBitsSrc; // Size of the source bitmap bits
        public uint iUsageSrc; // Source bitmap info color table usage
        public uint iStartScan;
        public uint cScans;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRSTRETCHDIBITS {
        public EMR emr;
        public RECTL rclBounds; // Inclusive-inclusive bounds in device units
        public int xDest;
        public int yDest;
        public int xSrc;
        public int ySrc;
        public int cxSrc;
        public int cySrc;
        public uint offBmiSrc; // Offset to the source BITMAPINFO structure
        public uint cbBmiSrc; // Size of the source BITMAPINFO structure
        public uint offBitsSrc; // Offset to the source bitmap bits
        public uint cbBitsSrc; // Size of the source bitmap bits
        public uint iUsageSrc; // Source bitmap info color table usage
        public uint dwRop;
        public int cxDest;
        public int cyDest;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMREXTCREATEFONTINDIRECT {
        public EMR emr;
        public uint ihFont; // Font handle index
        public EXTLOGFONT elfw;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRCREATEPEN {
        public EMR emr;
        public uint ihPen; // Pen handle index
        public LOGPEN lopn;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LOGPEN {
        public uint lopnStyle;
        public POINTL lopnWidth;
        public COLORREF lopnColor;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMREXTCREATEPEN {
        public EMR emr;
        public uint ihPen; // Pen handle index
        public uint offBmi; // Offset to the BITMAPINFO structure if any
        public uint cbBmi; // Size of the BITMAPINFO structure if any
        // The bitmap info is followed by the bitmap
        // bits to form a packed DIB.
        public uint offBits; // Offset to the brush bitmap bits if any
        public uint cbBits; // Size of the brush bitmap bits if any
        public EXTLOGPEN elp; // The extended pen with the style array.
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRCREATEBRUSHINDIRECT {
        public EMR emr;
        public uint ihBrush; // Brush handle index
        public LOGBRUSH lb; // The style must be BS_SOLID, BS_HOLLOW,
        // BS_NULL or BS_HATCHED.
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EXTLOGPEN {
        public uint elpPenStyle;
        public uint elpWidth;
        public uint elpBrushStyle;
        readonly COLORREF elpColor;
        public int elpHatch;
        public uint elpNumEntries;
        public uint[] elpStyleEntry;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRCREATEMONOBRUSH {
        public EMR emr;
        public uint ihBrush; // Brush handle index
        public uint iUsage; // Bitmap info color table usage
        public uint offBmi; // Offset to the BITMAPINFO structure
        public uint cbBmi; // Size of the BITMAPINFO structure
        public uint offBits; // Offset to the bitmap bits
        public uint cbBits; // Size of the bitmap bits
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LOGBRUSH {
        public uint lbStyle;
        public COLORREF lbColor;
        public int lbHatch;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRCREATEDIBPATTERNBRUSHPT {
        public EMR emr;
        public uint ihBrush; // Brush handle index
        public uint iUsage; // Bitmap info color table usage
        public uint offBmi; // Offset to the BITMAPINFO structure
        public uint cbBmi; // Size of the BITMAPINFO structure
        // The bitmap info is followed by the bitmap
        // bits to form a packed DIB.
        public uint offBits; // Offset to the bitmap bits
        public uint cbBits; // Size of the bitmap bits
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRFORMAT {
        public uint dSignature; // Format signature, e.g. ENHMETA_SIGNATURE.
        public uint nVersion; // Format version number.
        public uint cbData; // Size of data in bytes.
        public uint offData; // Offset to data from GDICOMMENT_IDENTIFIER.
        // It must begin at a public uint offset.
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct EXTLOGFONT {
        public LOGFONT elfLogFont;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string elfFullName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string elfStyle;
        public int elfVersion;
        public int elfStyleSize;
        public int elfMatch;
        public int elfReserved;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I1, SizeConst = 4)]
        public byte[] elfVendorId;
        public int elfCulture;
        public PANOSE elfPanose;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PANOSE {
        public byte bFamilyType;
        public byte bSerifStyle;
        public byte bWeight;
        public byte bProportion;
        public byte bContrast;
        public byte bStrokeVariation;
        public byte bArmStyle;
        public byte bLetterform;
        public byte bMidline;
        public byte bXHeight;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECTL {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
}