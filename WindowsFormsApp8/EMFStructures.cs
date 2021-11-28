using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace EmfProcessor {
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

    enum PolygonFillMode {
        ALTERNATE = 0x01,
        WINDING = 0x02
    }

    enum TextAlignment {
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

    enum ExtTextOutOptions {
        ETO_OPAQUE = 0x0002,
        ETO_CLIPPED = 0x0004,
        ETO_GLYPH_INDEX = 0x0010,
        ETO_RTLREADING = 0x0080,
        ETO_NUMERICSLOCAL = 0x0400,
        ETO_NUMERICSLATIN = 0x0800,
        ETO_PDY = 0x2000
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
    enum BackgroundMode {
        TRANSPARENT = 0x0001,
        OPAQUE = 0x0002
    }

    enum CommentType {
        EMR_COMMENT_EMFSPOOL = 0x00000000,
        EMR_COMMENT_EMFPLUS = 0x2B464D45,
        EMR_COMMENT_PUBLIC = 0x43494447,
    }

    public enum FormatSignature {
        ENHMETA_SIGNATURE = 0x464D4520,
        EPS_SIGNATURE = 0x46535045
    }

    public enum GraphicsMode {
        GM_COMPATIBLE = 0x00000001,
        GM_ADVANCED = 0x00000002
    }

    public enum GraphicsVersion {
        GraphicsVersion1 = 0x0001,
        GraphicsVersion1_1 = 0x0002
    }

    #region Generic structures

    [StructLayout(LayoutKind.Sequential)]
    public struct POINTS {
        public short X;
        public short Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINTL {
        public int X;
        public int Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SIZES {
        public short Width;
        public short Height;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SIZEL {
        public int Width;
        public int Height;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECTL {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct XFORM {
        public float M11;
        public float M12;
        public float M21;
        public float M22;
        public float Dx;
        public float Dy;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct COLOR {
        public byte Red;
        public byte Green;
        public byte Blue;
        public byte Reserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LOGPALENTRY {
        public byte Reserved;
        public byte Blue;
        public byte Green;
        public byte Red;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LOGPENEX {
        public uint Style;
        public uint Width;
        public uint BrushStyle;
        public COLOR ColorRef;
        public uint Hatch;
        public uint StyleEntriesN;
        public UInt32[] StyleEntries;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LOGBRUSH {
        public uint Style;
        public COLOR ColorRef;
        public uint Hatch;
    }

    public struct LOGFONT {
        public int Height;
        public int Width;
        public int Escapement;
        public int Orientation;
        public int Weight;
        public byte Italic;
        public byte Underline;
        public byte StrikeOut;
        public byte CharSet;
        public byte OutPrecision;
        public byte ClipPrecision;
        public byte Quality;
        public byte PitchAndFamily;
        public char[] Facename;
    }

    #endregion Generic structures

    #region Basic emf structures

    [StructLayout(LayoutKind.Sequential)]
    public struct emfPOINTF {
        public float X;
        public float Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emfRECTS {
        public short X;
        public short Y;
        public short Width;
        public short Height;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emfRECTF {
        public float X;
        public float Y;
        public float Width;
        public float Height;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMRSELECTOBJECT {
        public uint HandleIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EMR {
        public uint Type;
        public uint Size;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emrEMFHEADER {
        public RECTL Bounds;
        public RECTL Frame;
        public uint Signature;
        public uint Version;
        public ushort VersionMajor {
            get { return (UInt16) (Version >> 16); }
        }
        public ushort VersionMinor {
            get { return (UInt16) (Version & 0xFFFF); }
        }
        public uint Bytes;
        public uint Records;
        public ushort Handles;
        public ushort Reserved;
        public uint DescriptionN;
        public uint DescriptionOff;
        public uint PalEntriesN;
        public SIZEL Device;
        public SIZEL Millimeters;
        public uint PixelFormatCB;
        public uint PixelFormatOff;
        public uint OpenGL;
        public SIZEL Micrometers;
        public static int Index_DescriptionN = 52;
        public static int Index_DescriptionOff = 56;
        public static int Index_Records = 44;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LOGFONTW {
        public LOGFONT LogFont;
        public char[] Fullname;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emrTEXT {
        public POINTL Reference;
        public uint CharsN;
        public uint StringOff;
        public uint Options;
        public RECTL ClipBounds;
        public uint DxOff;
        public char[] UnusedChars;
        public char[] Chars;
        public Byte[] UnusedDx;
        public Byte[] Dx;
    }

    #endregion Basic emf structures

    #region Emr structures

    [StructLayout(LayoutKind.Sequential)]
    public struct emrPOLYGON16 {
        public RECTL Bounds;
        public uint Count;
        public POINTS[] Points;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emrPOLYBEZIER16 {
        public RECTL Bounds;
        public uint Count;
        public POINTS[] Points;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emrEXTCREATEPEN {
        public uint IhPen;
        public uint DibHeaderOff;
        public uint DibHeaderSize;
        public uint DibBitsOff;
        public uint DibBitsSize;
        public LOGPENEX LogPen;
        public Byte[] BitmapBuffer;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emrCREATEBRUSHINDIRECT {
        public uint IhBrush;
        public LOGBRUSH LogBrush;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emrEXTTEXTOUTW {
        public RECTL Bounds;
        public uint GraphicsMode;
        public float ExScale;
        public float EyScale;
        public emrTEXT Text;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emrCOMMENT {
        public uint DataSize;

        public Byte[] CommentData;

        public uint CommentTypeIdentifier {
            get { return (DataSize >= 4 ? BitConverter.ToUInt32(CommentData, 0) : 0); }
        }

        public string CommentTypeName {
            get {
                if(DataSize <= 0)
                    return string.Empty;

                string result = "";
                for(int index = 0; index < 4; index++)
                    result += (char) CommentData[index];
                return result;
            }
        }

        public bool CommentIdentifierIsEmfPlus {
            get { return (DataSize >= 4 ? BitConverter.ToUInt32(CommentData, 0) == 0x2B464D45 : false); }
        }

        public bool CommentIdentifierIsEmfPublic {
            get { return (DataSize > 4 ? BitConverter.ToUInt32(CommentData, 0) == 0x43494447 : false); }
        }

        public bool CommentIdentifierIsEmfSpool {
            get { return (DataSize > 4 ? BitConverter.ToUInt32(CommentData, 0) == 0x00000000 : false); }
        }

        public ushort EmfPlusPreviewType(int recordStart) {
            return (DataSize >= 6 ? BitConverter.ToUInt16(CommentData, recordStart + 4) : (UInt16) 0);
        }

        public ushort EmfPlusPreviewFlags(int recordStart) {
            return (DataSize >= 8 ? BitConverter.ToUInt16(CommentData, recordStart + 6) : (UInt16) 0);
        }

        public uint EmfPlusPreviewRecordSize(int recordStart) {
            return (DataSize >= 12 ? BitConverter.ToUInt32(CommentData, recordStart + 8) : (UInt32) 0);
        }

        public uint EmfPlusPreviewTotalObjectSize(int recordStart) {
            return (DataSize >= 16 ? BitConverter.ToUInt32(CommentData, recordStart + 12) : (UInt32) 0);
        }

        public emfPlusObject EmfPlusObject(int start) {
            emfPlusObject obj = new emfPlusObject();
            if(DataSize - start < 16)
                return obj;

            // Bytes 0...3 are the comment identifier.
            obj.Type = BitConverter.ToUInt16(CommentData, start + 4);
            obj.Flags = BitConverter.ToUInt16(CommentData, start + 6);
            obj.Continued = (CommentData[start + 7] & 0x80) != 0;
            obj.ObjectType = (Byte) (CommentData[start + 7] & (Byte) 0x7F);
            obj.ObjectID = CommentData[start + 6];
            obj.RecordSize = BitConverter.ToUInt32(CommentData, start + 8);
            // The 'obj.RecordSize' includes the 12 Bytes that have been used until to this point.
            obj.TotalObjectSize = BitConverter.ToUInt32(CommentData, start + 12);
            int offset = (obj.Continued ? start + 16 : start + 12);
            obj.DataSize = BitConverter.ToUInt32(CommentData, offset);

            obj.ObjectData = new byte[obj.DataSize];
            for(int index = 0; index < obj.DataSize; index++)
                obj.ObjectData[index] += CommentData[(offset + 4) + index];

            return obj;
        }

        public emfPlusDrawRects EmfPlusDrawRects(int start) {
            emfPlusDrawRects dr = new emfPlusDrawRects();
            if(DataSize - start < 20)
                return dr;

            dr.Type = BitConverter.ToUInt16(CommentData, start + 4);
            dr.Flags = BitConverter.ToUInt16(CommentData, start + 6);
            dr.ObjectReserved0 = (CommentData[start + 7] & 0x80) != 0;
            dr.ObjectIsCompressed = (CommentData[start + 7] & 0x40) != 0;
            dr.ObjectID = CommentData[start + 6];
            dr.RecordSize = BitConverter.ToUInt32(CommentData, start + 8);
            dr.DataSize = BitConverter.ToUInt32(CommentData, start + 12);
            dr.Count = BitConverter.ToUInt32(CommentData, start + 16);

            // Check consistency
            if(dr.Count * (dr.ObjectIsCompressed ? 8 : 16) + 16 != dr.RecordSize)
                throw new DataMisalignedException("RecordSize doesn't match.");
            if(dr.Count * (dr.ObjectIsCompressed ? 8 : 16) + 4 != dr.DataSize)
                throw new DataMisalignedException("DataSize doesn't match.");

            dr.RectData = new byte[DataSize - (start + 20)];
            for(int index = 0; (start + 20) + index < DataSize; index++)
                dr.RectData[index] += CommentData[(start + 20) + index];

            return dr;
        }

        public emfPlusFillRects EmfPlusFillRects(int start) {
            emfPlusFillRects fr = new emfPlusFillRects();
            if(DataSize - start < 24)
                return fr;

            fr.Type = BitConverter.ToUInt16(CommentData, start + 4);
            fr.Flags = BitConverter.ToUInt16(CommentData, start + 6);
            fr.ObjectIsRgb = (CommentData[start + 7] & 0x80) != 0;
            fr.ObjectIsCompressed = (CommentData[start + 7] & 0x40) != 0;
            fr.RecordSize = BitConverter.ToUInt32(CommentData, start + 8);
            fr.DataSize = BitConverter.ToUInt32(CommentData, start + 12);
            fr.BrushIDOrColor = BitConverter.ToUInt32(CommentData, start + 16);
            fr.Count = BitConverter.ToUInt32(CommentData, start + 20);

            // Check consistency
            if(fr.Count * (fr.ObjectIsCompressed ? 8 : 16) + 20 != fr.RecordSize)
                throw new DataMisalignedException("RecordSize doesn't match.");
            if(fr.Count * (fr.ObjectIsCompressed ? 8 : 16) + 8 != fr.DataSize)
                throw new DataMisalignedException("DataSize doesn't match.");

            fr.RectData = new byte[DataSize - (start + 24)];
            for(int index = 0; (start + 24) + index < DataSize; index++)
                fr.RectData[index] += CommentData[(start + 24) + index];

            return fr;
        }

        public emfPlusDrawEllipse EmfPlusDrawEllipse(int start) {
            emfPlusDrawEllipse de = new emfPlusDrawEllipse();
            if(DataSize - start < 16)
                return de;

            de.Type = BitConverter.ToUInt16(CommentData, start + 4);
            de.Flags = BitConverter.ToUInt16(CommentData, start + 6);
            de.ObjectReserved0 = (CommentData[start + 7] & 0x80) != 0;
            de.ObjectIsCompressed = (CommentData[start + 7] & 0x40) != 0;
            de.ObjectID = CommentData[start + 6];
            de.RecordSize = BitConverter.ToUInt32(CommentData, start + 8);
            de.DataSize = BitConverter.ToUInt32(CommentData, start + 12);

            de.RectData = new byte[DataSize - (start + 16)];
            for(int index = 0; (start + 16) + index < DataSize; index++)
                de.RectData[index] += CommentData[(start + 16) + index];

            return de;
        }

        public emfPlusFillEllipse EmfPlusFillEllipse(int start) {
            emfPlusFillEllipse fe = new emfPlusFillEllipse();
            if(DataSize - start < 20)
                return fe;

            fe.Type = BitConverter.ToUInt16(CommentData, start + 4);
            fe.Flags = BitConverter.ToUInt16(CommentData, start + 6);
            fe.ObjectIsRgb = (CommentData[start + 7] & 0x80) != 0;
            fe.ObjectIsCompressed = (CommentData[start + 7] & 0x40) != 0;
            fe.Reserved3 = (CommentData[start + 7] & 0x20) != 0;
            fe.Reserved4 = (CommentData[start + 7] & 0x10) != 0;
            fe.Reserved5 = (Byte) (CommentData[start + 7] & 0x0F);
            fe.RecordSize = BitConverter.ToUInt32(CommentData, start + 8);
            fe.DataSize = BitConverter.ToUInt32(CommentData, start + 12);
            fe.BrushIDOrColor = BitConverter.ToUInt32(CommentData, start + 16);

            fe.RectData = new byte[DataSize - (start + 20)];
            for(int index = 0; (start + 20) + index < DataSize; index++)
                fe.RectData[index] += CommentData[(start + 20) + index];

            return fe;
        }

        public emfPlusDrawLines EmfPlusDrawLines(int start) {
            emfPlusDrawLines dl = new emfPlusDrawLines();
            if(DataSize - start < 20)
                return dl;

            dl.Type = BitConverter.ToUInt16(CommentData, start + 4);
            dl.Flags = BitConverter.ToUInt16(CommentData, start + 6);
            dl.ObjectIsCompressed = (CommentData[start + 7] & 0x40) != 0;
            dl.ObjectIsClosed = (CommentData[start + 7] & 0x20) != 0;
            dl.ObjectIsRelative = (CommentData[start + 7] & 0x08) != 0;
            dl.RecordSize = BitConverter.ToUInt32(CommentData, start + 8);
            dl.DataSize = BitConverter.ToUInt32(CommentData, start + 12);
            dl.Count = BitConverter.ToUInt32(CommentData, start + 16);

            // Check consistency
            if((dl.ObjectIsRelative ? dl.Count * 2 + 16 : (dl.ObjectIsCompressed ? dl.Count * 4 + 16 : dl.Count * 8 + 16)) != dl.RecordSize)
                throw new DataMisalignedException("RecordSize doesn't match.");
            if((dl.ObjectIsRelative ? dl.Count * 2 + 4 : (dl.ObjectIsCompressed ? dl.Count * 4 + 4 : dl.Count * 8 + 4)) != dl.DataSize)
                throw new DataMisalignedException("DataSize doesn't match.");

            dl.PointData = new byte[DataSize - (start + 20)];
            for(int index = 0; (start + 20) + index < DataSize; index++)
                dl.PointData[index] += CommentData[(start + 20) + index];

            return dl;
        }

        public emfPlusFillPolygon EmfPlusFillPolygon(int start) {
            emfPlusFillPolygon fp = new emfPlusFillPolygon();
            if(DataSize - start < 24)
                return fp;

            fp.Type = BitConverter.ToUInt16(CommentData, start + 4);
            fp.Flags = BitConverter.ToUInt16(CommentData, start + 6);
            fp.ObjectIsRgb = (CommentData[start + 7] & 0x80) != 0;
            fp.ObjectIsCompressed = (CommentData[start + 7] & 0x40) != 0;
            fp.ObjectIsRelative = (CommentData[start + 7] & 0x08) != 0;
            fp.RecordSize = BitConverter.ToUInt32(CommentData, start + 8);
            fp.DataSize = BitConverter.ToUInt32(CommentData, start + 12);
            fp.BrushIDOrColor = BitConverter.ToUInt32(CommentData, start + 16);
            fp.Count = BitConverter.ToUInt32(CommentData, start + 20);

            // Check consistency
            if((fp.ObjectIsRelative ? ((uint) (((fp.Count * 2) + 20 + 3) / 4)) * 4 : (fp.ObjectIsCompressed ? fp.Count * 4 + 20 : fp.Count * 8 + 20)) != fp.RecordSize)
                throw new DataMisalignedException("RecordSize doesn't match.");
            if((fp.ObjectIsRelative ? ((uint) (((fp.Count * 2) + 8 + 3) / 4)) * 4 : (fp.ObjectIsCompressed ? fp.Count * 4 + 8 : fp.Count * 8 + 8)) != fp.DataSize)
                throw new DataMisalignedException("DataSize doesn't match.");

            fp.PointData = new byte[DataSize - (start + 24)];
            for(int index = 0; (start + 24) + index < DataSize; index++)
                fp.PointData[index] += CommentData[(start + 24) + index];

            return fp;
        }

        //public emfPlusDrawString EmfPlusDrawString(int start) {
        //    emfPlusDrawString ds = new emfPlusDrawString();
        //    if(DataSize - start < 44)
        //        return ds;

        //    ds.Type = BitConverter.ToUInt16(CommentData, start + 4);
        //    ds.Flags = BitConverter.ToUInt16(CommentData, start + 6);
        //    ds.ObjectIsRgb = (CommentData[start + 7] & 0x80) != 0;
        //    ds.ObjectID = CommentData[start + 6];
        //    ds.RecordSize = BitConverter.ToUInt32(CommentData, start + 8);
        //    ds.DataSize = BitConverter.ToUInt32(CommentData, start + 12);
        //    ds.BrushIDOrColor = BitConverter.ToUInt32(CommentData, start + emfPlusDrawString.Index_BrushIDOrColor);
        //    // The highest possible index within the 'EMF+ Object Table' is  byte.Max.
        //    uint formatID = BitConverter.ToUInt32(CommentData, start + emfPlusDrawString.Index_FormatID);
        //    ds.FormatID = (byte) formatID;
        //    ds.Length = BitConverter.ToUInt32(CommentData, start + 24);
        //    ds.LayoutRect = BitConverterWithLimitCheck.MsbByteArrayToRECTF(CommentData, start + 28);

        //    ds.StringData = new char[ds.Length];
        //    for(int index = 0; index < ds.Length; index++)
        //        ds.StringData[index] += (Char) BitConverterWithLimitCheck.ToUInt16(CommentData, (start + 44) + index * 2);

        //    return ds;
        //}

        public emfPlusEndOfFile EmfPlusEndOfFile(int start) {
            emfPlusEndOfFile eof = new emfPlusEndOfFile();
            if(DataSize - start < 16)
                return eof;

            eof.Type = BitConverter.ToUInt16(CommentData, start + 4);
            eof.Flags = BitConverter.ToUInt16(CommentData, start + 6);
            eof.RecordSize = BitConverter.ToUInt32(CommentData, start + 8);
            eof.DataSize = BitConverter.ToUInt32(CommentData, start + 12);

            return eof;
        }

        public emfPlusHeader EmfPlusHeader(int start) {
            emfPlusHeader hd = new emfPlusHeader();
            if(DataSize - start < 32)
                return hd;

            hd.Type = BitConverter.ToUInt16(CommentData, start + 4);
            hd.Flags = BitConverter.ToUInt16(CommentData, start + 6);
            hd.RecordSize = BitConverter.ToUInt32(CommentData, start + 8);
            hd.DataSize = BitConverter.ToUInt32(CommentData, start + 12);
            hd.Version = BitConverter.ToUInt32(CommentData, start + 16);
            hd.EmfPlusFlags = BitConverter.ToUInt32(CommentData, start + emfPlusHeader.Index_EmfPlusFlags);
            hd.LogicalDpiX = BitConverter.ToUInt32(CommentData, start + emfPlusHeader.Index_LogicalDpiX);
            hd.LogicalDpiY = BitConverter.ToUInt32(CommentData, start + emfPlusHeader.Index_LogicalDpiY);

            return hd;
        }

        public emfPlusTranslateWorldTransform EmfPlusTranslateWorldTransform(int start) {
            emfPlusTranslateWorldTransform tr = new emfPlusTranslateWorldTransform();
            if(DataSize - start < 24)
                return tr;

            tr.Type = BitConverter.ToUInt16(CommentData, start + 4);
            tr.Flags = BitConverter.ToUInt16(CommentData, start + 6);
            tr.RecordSize = BitConverter.ToUInt32(CommentData, start + 8);
            tr.DataSize = BitConverter.ToUInt32(CommentData, start + 12);
            tr.Dx = BitConverter.ToSingle(CommentData, start + 16);
            tr.Dy = BitConverter.ToSingle(CommentData, start + 20);

            return tr;
        }

        public emfPlusScaleWorldTransform EmfPlusScaleWorldTransform(int start) {
            emfPlusScaleWorldTransform tr = new emfPlusScaleWorldTransform();
            if(DataSize - start < 24)
                return tr;

            tr.Type = BitConverter.ToUInt16(CommentData, start + 4);
            tr.Flags = BitConverter.ToUInt16(CommentData, start + 6);
            tr.RecordSize = BitConverter.ToUInt32(CommentData, start + 8);
            tr.DataSize = BitConverter.ToUInt32(CommentData, start + 12);
            tr.Sx = BitConverter.ToSingle(CommentData, start + 16);
            tr.Sy = BitConverter.ToSingle(CommentData, start + 20);

            return tr;
        }

        //public emfPlusSetClipRect EmfPlusSetClipRect(int start) {
        //    emfPlusSetClipRect cr = new emfPlusSetClipRect();
        //    if(DataSize - start < 32)
        //        return cr;

        //    cr.Type = BitConverter.ToUInt16(CommentData, start + 4);
        //    cr.Flags = BitConverter.ToUInt16(CommentData, start + 6);
        //    cr.RecordSize = BitConverter.ToUInt32(CommentData, start + 8);
        //    cr.DataSize = BitConverter.ToUInt32(CommentData, start + 12);
        //    cr.ClipRect = new emfRECTF();

        //    cr.ClipRect.X = BitConverterWithLimitCheck.ToSingle(CommentData, start + 16);
        //    cr.ClipRect.Y = BitConverterWithLimitCheck.ToSingle(CommentData, start + 20);
        //    cr.ClipRect.Width = BitConverterWithLimitCheck.ToSingle(CommentData, start + 24);
        //    cr.ClipRect.Height = BitConverterWithLimitCheck.ToSingle(CommentData, start + 28);

        //    return cr;
        //}
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emrEXTCREATEFONTINDIRECTW {
        public uint ElwSize;

        public uint IhFont;

        public LOGFONT LogFontRef;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emrEOF {
        public uint PalEntriesN;

        public uint PalEntriesOff;

        public LOGPALENTRY[] PaletteBuffer;

        public uint SizeLast;
    }

    #endregion Emr structures

    #region Emf structures

    [StructLayout(LayoutKind.Sequential)]
    public struct emfPlusHeader {
        public ushort Type;

        public ushort Flags;

        public uint RecordSize;

        public uint DataSize;

        public uint Version;

        public uint MetafileSignature {
            get { return (Version & 0xFFFFF000) >> 12; }
        }

        public GraphicsVersion GraphicsVersion {
            get { return (GraphicsVersion) (Version & 0x00000FFF); }
        }

        public uint EmfPlusFlags;

        public bool IsVideoDisplay {
            get { return (EmfPlusFlags & 0x01) != 0; }
        }

        public uint LogicalDpiX;

        public uint LogicalDpiY;

        public static int Index_EmfPlusFlags = 20;

        public static int Index_LogicalDpiX = 24;

        public static int Index_LogicalDpiY = 28;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emfPlusTranslateWorldTransform {
        public ushort Type;

        public ushort Flags;

        public uint RecordSize;

        public uint DataSize;

        public float Dx;

        public float Dy;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emfPlusScaleWorldTransform {
        public ushort Type;

        public ushort Flags;

        public uint RecordSize;

        public uint DataSize;

        public float Sx;

        public float Sy;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emfPlusSetClipRect {
        public ushort Type;

        public ushort Flags;

        public uint RecordSize;

        public uint DataSize;

        public emfRECTF ClipRect;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emfPlusObject {
        public ushort Type;

        public ushort Flags;

        public Boolean Continued;

        public byte ObjectType;

        public byte ObjectID;

        public uint RecordSize;

        public uint TotalObjectSize;

        public uint DataSize;

        public Byte[] ObjectData;

        public Boolean ObjectPreviewIsSerialized {
            get { return (DataSize >= 2 ? BitConverter.ToUInt16(ObjectData, 0) == 0x4038 : false); }
        }

        public emfPlusPenObject Pen {
            get {
                emfPlusPenObject pen = new emfPlusPenObject();
                if(DataSize < 8)
                    return pen;

                pen.Version = BitConverter.ToUInt32(ObjectData, 0);
                pen.Type = BitConverter.ToUInt32(ObjectData, 4);

                pen.PenAndBrushData = new byte[DataSize - 8];
                for(int index = 0; 8 + index < DataSize; index++)
                    pen.PenAndBrushData[index] += ObjectData[8 + index];

                return pen;
            }
        }

        public emfPlusBrushObject Brush {
            get {
                emfPlusBrushObject brush = new emfPlusBrushObject();
                if(DataSize < 8)
                    return brush;

                brush.Version = BitConverter.ToUInt32(ObjectData, 0);
                brush.Type = BitConverter.ToUInt32(ObjectData, 4);

                brush.BrushData = new byte[DataSize - 8];
                for(int index = 0; 8 + index < DataSize; index++)
                    brush.BrushData[index] += ObjectData[8 + index];

                return brush;
            }
        }

        //public emfPlusFontObject Font {
        //    get {
        //        emfPlusFontObject font = new emfPlusFontObject();
        //        if(DataSize < 24)
        //            return font;

        //        font.Version = BitConverter.ToUInt32(ObjectData, 0);
        //        font.EmSize = BitConverter.ToSingle(ObjectData, 4);
        //        font.SizeUnit = BitConverter.ToUInt32(ObjectData, 8);
        //        font.StyleFlags = BitConverter.ToUInt32(ObjectData, 12);
        //        font.Reserved = BitConverter.ToUInt32(ObjectData, 16);
        //        font.Length = BitConverter.ToUInt32(ObjectData, 20);

        //        font.FamilyName = new char[font.Length];
        //        for(int index = 0; index < font.Length; index++)
        //            font.FamilyName[index] += (Char) BitConverterWithLimitCheck.ToUInt16(ObjectData, 24 + index * 2);

        //        // If 'font.Length' is odd, we typically have one character extra data to match the 32Byte boundary.
        //        int extraN = (int) ((ObjectData.Length - 24 - font.Length * 2) / 2);
        //        font.AlignmentPadding = new char[extraN];
        //        for(int index = 0; index < extraN; index++)
        //            font.AlignmentPadding[index] += (Char) BitConverterWithLimitCheck.ToUInt16(ObjectData, (int) (24 + font.Length * 2 + index * 2));

        //        return font;
        //    }
        //}

        public emfPlusStringFormatObject StringFormat {
            get {
                emfPlusStringFormatObject stringFormat = new emfPlusStringFormatObject();
                if(DataSize < 60)
                    return stringFormat;

                stringFormat.Version = BitConverter.ToUInt32(ObjectData, 0);
                stringFormat.StringFormatFlags = BitConverter.ToUInt32(ObjectData, 4);
                stringFormat.Language = BitConverter.ToUInt32(ObjectData, 8);
                stringFormat.StringAlignment = BitConverter.ToUInt32(ObjectData, 12);
                stringFormat.LineAlign = BitConverter.ToUInt32(ObjectData, 16);
                stringFormat.DigitSubstitution = BitConverter.ToUInt32(ObjectData, 20);
                stringFormat.DigitLanguage = BitConverter.ToUInt32(ObjectData, 24);
                stringFormat.FirstTabOffset = BitConverter.ToSingle(ObjectData, 28);
                stringFormat.HotkeyPrefix = BitConverter.ToInt32(ObjectData, 32);
                stringFormat.LeadingMargin = BitConverter.ToSingle(ObjectData, 36);
                stringFormat.TrailingMargin = BitConverter.ToSingle(ObjectData, 40);
                stringFormat.Tracking = BitConverter.ToSingle(ObjectData, 44);
                stringFormat.Trimming = BitConverter.ToUInt32(ObjectData, 48);
                stringFormat.TabStopCount = BitConverter.ToInt32(ObjectData, 52);
                stringFormat.RangeCount = BitConverter.ToInt32(ObjectData, 56);

                stringFormat.TabStopData = new Byte[stringFormat.TabStopCount];
                for(int index = 0; index < stringFormat.TabStopCount; index++)
                    stringFormat.TabStopData[index] = ObjectData[60 + index];

                stringFormat.CharRange = new Byte[stringFormat.RangeCount];
                for(int index = 0; index < stringFormat.RangeCount; index++)
                    stringFormat.CharRange[index] = ObjectData[60 + stringFormat.TabStopCount + index];

                return stringFormat;
            }
        }

        // EmfPlusCustomLineCap
        // EmfPlusImage
        // EmfPlusImageAttributes
        // EmfPlusPath
        // EmfPlusRegion
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emfPlusPenObject {
        public uint Version;

        public uint Type;

        public Byte[] PenAndBrushData;

        //public uint PenDataFlags {
        //    get { return BitConverterWithLimitCheck.ToUInt32(PenAndBrushData, 0); }
        //}

        //public uint PenUnit {
        //    get { return BitConverterWithLimitCheck.ToUInt32(PenAndBrushData, 4); }
        //}

        //public uint PenWidth {
        //    get { return BitConverterWithLimitCheck.ToUInt32(PenAndBrushData, 8); }
        //}
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emfPlusBrushObject {
        public uint Version;

        public uint Type;

        public Byte[] BrushData;

        //public COLOR SolidBrushColor {
        //    get { return BitConverterWithLimitCheck.MsbByteArrayToCOLOR(BrushData, 0); }
        //}
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emfPlusFontObject {
        public uint Version;

        public float EmSize;

        public uint SizeUnit;

        public uint StyleFlags;

        public uint Reserved;

        public uint Length;

        public char[] FamilyName;

        public char[] AlignmentPadding;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EmfPlusCharacterRange {
        public int First;

        public int Length;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emfPlusStringFormatObject {
        public uint Version;

        public uint StringFormatFlags;

        public uint Language;

        public uint StringAlignment;

        public uint LineAlign;

        public uint DigitSubstitution;
        public uint DigitLanguage;

        public float FirstTabOffset;
        public int HotkeyPrefix;

        public float LeadingMargin;

        public float TrailingMargin;
        public float Tracking;
        public uint Trimming;

        public int TabStopCount;

        public int RangeCount;

        public Byte[] TabStopData;

        public Byte[] CharRange;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emfPlusDrawString {
        public ushort Type;

        public ushort Flags;

        public Boolean ObjectIsRgb;

        public byte ObjectID;

        public uint RecordSize;

        public uint DataSize;

        public uint BrushIDOrColor;

        public byte FormatID;

        public uint Length;

        public emfRECTF LayoutRect;

        public char[] StringData;

        public char[] AlignmentPadding;

        public static int Index_BrushIDOrColor = 16;

        public static int Index_FormatID = 20;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emfPlusDrawLines {
        public ushort Type;

        public ushort Flags;

        public Boolean ObjectIsCompressed;

        public Boolean ObjectIsClosed;

        public Boolean ObjectIsRelative;

        public uint RecordSize;

        public uint DataSize;

        public uint Count;

        public Byte[] PointData;

        public POINTS GetPointR(int index) {
            POINTS p = new POINTS();
            if(index < 0 || index >= Count)
                return p;

            int startOffset = 0;
            for(int count = 0; count < Count; count++) {
                if((PointData[startOffset] & 0x80) == 0) {
                    p.X = (Int16) (PointData[startOffset + 0] & 0x7F);
                    startOffset++;
                }
                else // ((PointData[startOffset] & 0x80) != 0)
                {
                    p.X = (Int16) ((PointData[startOffset + 0] & 0x7F) + PointData[startOffset + 1] * 256);
                    startOffset += 2;
                }

                if((PointData[startOffset] & 0x80) == 0) {
                    p.Y = (Int16) (PointData[startOffset + 0] & 0x7F);
                    startOffset++;
                }
                else // ((PointData[startOffset] & 0x80) != 0)
                {
                    p.Y = (Int16) ((PointData[startOffset + 0] & 0x7F) + PointData[startOffset + 1] * 256);
                    startOffset += 2;
                }

                if(count == index)
                    return p;
            }

            return p;
        }

        //public POINTS GetPointS(int index) {
        //    POINTS p = new POINTS();
        //    if(index < 0 || index >= Count)
        //        return p;

        //    int startOffset = index * 2;
        //    p.X = BitConverterWithLimitCheck.ToInt16(PointData, startOffset + 0);
        //    p.Y = BitConverterWithLimitCheck.ToInt16(PointData, startOffset + 2);

        //    return p;
        //}

        //public emfPOINTF GetPointF(int index) {
        //    emfPOINTF p = new emfPOINTF();
        //    if(index < 0 || index >= Count)
        //        return p;

        //    int startOffset = index * 4;
        //    p.X = BitConverterWithLimitCheck.ToSingle(PointData, startOffset + 0);
        //    p.Y = BitConverterWithLimitCheck.ToSingle(PointData, startOffset + 4);

        //    return p;
        //}
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emfPlusFillPolygon {
        public ushort Type;

        public ushort Flags;

        public Boolean ObjectIsRgb;

        public Boolean ObjectIsCompressed;

        public Boolean ObjectIsRelative;

        public uint RecordSize;

        public uint DataSize;

        public uint BrushIDOrColor;

        public uint Count;

        public Byte[] PointData;

        public POINTS GetPointR(int index) {
            POINTS p = new POINTS();
            if(index < 0 || index >= Count)
                return p;

            int startOffset = 0;
            for(int count = 0; count < Count; count++) {
                if((PointData[startOffset] & 0x80) == 0) {
                    p.X = (Int16) (PointData[startOffset + 0] & 0x7F);
                    startOffset++;
                }
                else // ((PointData[startOffset] & 0x80) != 0)
                {
                    p.X = (Int16) ((PointData[startOffset + 0] & 0x7F) + PointData[startOffset + 1] * 256);
                    startOffset += 2;
                }

                if((PointData[startOffset] & 0x80) == 0) {
                    p.Y = (Int16) (PointData[startOffset + 0] & 0x7F);
                    startOffset++;
                }
                else // ((PointData[startOffset] & 0x80) != 0)
                {
                    p.Y = (Int16) ((PointData[startOffset + 0] & 0x7F) + PointData[startOffset + 1] * 256);
                    startOffset += 2;
                }

                if(count == index)
                    return p;
            }

            return p;
        }

        //public POINTS GetPointS(int index) {
        //    POINTS p = new POINTS();
        //    if(index < 0 || index >= Count)
        //        return p;

        //    int startOffset = index * 2;
        //    p.X = BitConverterWithLimitCheck.ToInt16(PointData, startOffset + 0);
        //    p.Y = BitConverterWithLimitCheck.ToInt16(PointData, startOffset + 2);

        //    return p;
        //}

        //public emfPOINTF GetPointF(int index) {
        //    emfPOINTF p = new emfPOINTF();
        //    if(index < 0 || index >= Count)
        //        return p;

        //    int startOffset = index * 4;
        //    p.X = BitConverterWithLimitCheck.ToSingle(PointData, startOffset + 0);
        //    p.Y = BitConverterWithLimitCheck.ToSingle(PointData, startOffset + 4);

        //    return p;
        //}
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emfPlusDrawRects {
        public ushort Type;

        public ushort Flags;

        public Boolean ObjectReserved0;

        public bool ObjectIsCompressed;

        public byte ObjectID;

        public uint RecordSize;

        public uint DataSize;

        public uint Count;

        public Byte[] RectData;

        //public emfRECTS GetRectS(int index) {
        //    emfRECTS r = new emfRECTS();
        //    if(index < 0 || index >= Count)
        //        return r;

        //    int startOffset = index * 8;
        //    r.X = BitConverterWithLimitCheck.ToInt16(RectData, startOffset);
        //    r.Y = BitConverterWithLimitCheck.ToInt16(RectData, startOffset + 2);
        //    r.Width = BitConverterWithLimitCheck.ToInt16(RectData, startOffset + 4);
        //    r.Height = BitConverterWithLimitCheck.ToInt16(RectData, startOffset + 6);

        //    return r;
        //}

        //public emfRECTF GetRectF(int index) {
        //    emfRECTF r = new emfRECTF();
        //    if(index < 0 || index >= Count)
        //        return r;

        //    int startOffset = index * 16;
        //    r.X = BitConverterWithLimitCheck.ToSingle(RectData, startOffset + 0);
        //    r.Y = BitConverterWithLimitCheck.ToSingle(RectData, startOffset + 4);
        //    r.Width = BitConverterWithLimitCheck.ToSingle(RectData, startOffset + 8);
        //    r.Height = BitConverterWithLimitCheck.ToSingle(RectData, startOffset + 12);

        //    return r;
        //}
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emfPlusFillRects {
        public ushort Type;

        public ushort Flags;

        public Boolean ObjectIsRgb;

        public Boolean ObjectIsCompressed;

        public uint RecordSize;

        public uint DataSize;

        public uint BrushIDOrColor;

        public uint Count;

        public Byte[] RectData;

        //public emfRECTS GetRectS(int index) {
        //    emfRECTS r = new emfRECTS();
        //    if(index < 0 || index >= Count)
        //        return r;

        //    int startOffset = index * 8;
        //    r.X = BitConverterWithLimitCheck.ToInt16(RectData, startOffset);
        //    r.Y = BitConverterWithLimitCheck.ToInt16(RectData, startOffset + 2);
        //    r.Width = BitConverterWithLimitCheck.ToInt16(RectData, startOffset + 4);
        //    r.Height = BitConverterWithLimitCheck.ToInt16(RectData, startOffset + 6);

        //    return r;
        //}

        //public emfRECTF GetRectF(int index) {
        //    emfRECTF r = new emfRECTF();
        //    if(index < 0 || index >= Count)
        //        return r;

        //    int startOffset = index * 16;
        //    r.X = BitConverterWithLimitCheck.ToSingle(RectData, startOffset + 0);
        //    r.Y = BitConverterWithLimitCheck.ToSingle(RectData, startOffset + 4);
        //    r.Width = BitConverterWithLimitCheck.ToSingle(RectData, startOffset + 8);
        //    r.Height = BitConverterWithLimitCheck.ToSingle(RectData, startOffset + 12);

        //    return r;
        //}
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emfPlusDrawEllipse {
        public ushort Type;

        public ushort Flags;

        public Boolean ObjectReserved0;

        public Boolean ObjectIsCompressed;

        public byte ObjectID;

        public uint RecordSize;

        public uint DataSize;

        public Byte[] RectData;

        //public emfRECTS GetRectS() {
        //    emfRECTS r = new emfRECTS();

        //    r.X = BitConverterWithLimitCheck.ToInt16(RectData, 0);
        //    r.Y = BitConverterWithLimitCheck.ToInt16(RectData, 2);
        //    r.Width = BitConverterWithLimitCheck.ToInt16(RectData, 4);
        //    r.Height = BitConverterWithLimitCheck.ToInt16(RectData, 6);

        //    return r;
        //}

        //public emfRECTF GetRectF() {
        //    emfRECTF r = new emfRECTF();

        //    r.X = BitConverterWithLimitCheck.ToSingle(RectData, 0);
        //    r.Y = BitConverterWithLimitCheck.ToSingle(RectData, 4);
        //    r.Width = BitConverterWithLimitCheck.ToSingle(RectData, 8);
        //    r.Height = BitConverterWithLimitCheck.ToSingle(RectData, 12);

        //    return r;
        //}
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emfPlusFillEllipse {
        public ushort Type;

        public ushort Flags;

        public Boolean ObjectIsRgb;

        public Boolean ObjectIsCompressed;

        public Boolean Reserved3;

        public Boolean Reserved4;

        public byte Reserved5;

        public uint RecordSize;

        public uint DataSize;

        public uint BrushIDOrColor;

        public Byte[] RectData;

        //public emfRECTS GetRectS() {
        //    emfRECTS r = new emfRECTS();

        //    r.X = BitConverterWithLimitCheck.ToInt16(RectData, 0);
        //    r.Y = BitConverterWithLimitCheck.ToInt16(RectData, 2);
        //    r.Width = BitConverterWithLimitCheck.ToInt16(RectData, 4);
        //    r.Height = BitConverterWithLimitCheck.ToInt16(RectData, 6);

        //    return r;
        //}

        //public emfRECTF GetRectF() {
        //    emfRECTF r = new emfRECTF();

        //    r.X = BitConverterWithLimitCheck.ToSingle(RectData, 0);
        //    r.Y = BitConverterWithLimitCheck.ToSingle(RectData, 4);
        //    r.Width = BitConverterWithLimitCheck.ToSingle(RectData, 8);
        //    r.Height = BitConverterWithLimitCheck.ToSingle(RectData, 12);

        //    return r;
        //}
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct emfPlusEndOfFile {
        public ushort Type;

        public ushort Flags;

        public uint RecordSize;

        public uint DataSize;
    }

    #endregion Emf structures
}