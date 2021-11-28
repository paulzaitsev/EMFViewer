using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace EMFAssembly {
    public abstract class EMRRecord {
        int rType;
        public EMRRecord(int rType) {
            this.rType = rType;

        }
        public int Identifier => rType;
        public abstract string GetInfo();
    }

    public class EMRElementContainer {
        public EMRElementContainer(string name) {
            Name = name;
        }
        public string Name { get; }
        List<EMRElementContainer> children;
        public List<EMRElementContainer> Children {
            get {
                if(children == null) children = new List<EMRElementContainer>();
                return children;
            }
        }
        public EMRElementContainer Parent { get; set; }
        List<EMRRecord> primitives;
        public List<EMRRecord> Records {
            get {
                if(primitives == null) primitives = new List<EMRRecord>();
                return primitives;
            }
        }
    }

    public class EmrRecordSelectObject : EMRRecord {
        EMRSELECTOBJECT emrSelectObject;
        EMRRecord selected;
        public EmrRecordSelectObject(IntPtr ptr) : base(RecordType.EMR_SELECTOBJECT) {
            object selectObject = Marshal.PtrToStructure(ptr, typeof(EMRSELECTOBJECT));
            emrSelectObject = (EMRSELECTOBJECT) selectObject;
            EMFProvider.GdiHandles.TryGetValue(emrSelectObject.ihObject, out selected);
        }
        public EMRSELECTOBJECT Value => emrSelectObject;
        public uint ObjHandle => emrSelectObject.ihObject;
        public EMRRecord SelectedObject => selected;
        public StockObjects StockObject => (StockObjects) ObjHandle;
        public override string GetInfo() {
            if(selected != null)
                return "SELECTOBJECT: \r\n" + selected.GetInfo();
            if((uint) StockObjects.WHITE_BRUSH <= ObjHandle && ObjHandle <= (uint) StockObjects.DC_PEN)
                return "SELECTOBJECT StockObject: " + (StockObjects) ObjHandle + "\r\n";
            return $"SELECTOBJECT ObjectHandle = {ObjHandle} \r\n";
        }
    }

    public class EmrRecordDeleteObject : EMRRecord {
        EMRSELECTOBJECT emrDeleteObject;
        EMRRecord deleted;
        public EmrRecordDeleteObject(IntPtr ptr) : base(RecordType.EMR_DELETEOBJECT) {
            object selectObject = Marshal.PtrToStructure(ptr, typeof(EMRSELECTOBJECT));
            emrDeleteObject = (EMRSELECTOBJECT) selectObject;
            EMFProvider.GdiHandles.TryGetValue(emrDeleteObject.ihObject, out deleted);
        }
        public EMRSELECTOBJECT Value => emrDeleteObject;
        public uint ObjHandle => emrDeleteObject.ihObject;
        public EMRRecord DeletedObject => deleted;
        public StockObjects StockObject => (StockObjects)ObjHandle;
        public override string GetInfo() {
            if(deleted != null)
                return "DELETEOBJECT : \r\n" + deleted.GetInfo();
            if((uint)StockObjects.WHITE_BRUSH <= ObjHandle && ObjHandle <= (uint)StockObjects.DC_PEN)
                return "DELETEOBJECT StockObject: " + (StockObjects)ObjHandle + "\r\n";
            return $"DELETEOBJECT  ObjectHandle = {ObjHandle} \r\n";
        }
    }

    public class EmrRecordCreatePen : EMRRecord {
        EMRCREATEPEN emrPen;
        public EmrRecordCreatePen(IntPtr ptr) : base(RecordType.EMR_CREATEPEN) {
            object pen = Marshal.PtrToStructure(ptr, typeof(EMRCREATEPEN));
            emrPen = (EMRCREATEPEN) pen;
            if(!EMFProvider.GdiHandles.ContainsKey(emrPen.ihPen)) {
                EMFProvider.GdiHandles.Add(emrPen.ihPen, this);
            }
        }
        public EMRCREATEPEN Value => emrPen;
        public LOGPEN LogPen => emrPen.lopn;
        public override string GetInfo() {
            return string.Format("LOGPEN: style = {0} color = {1} width = {2} \r\n", PenStyleItoString((PenStyle) LogPen.lopnStyle), LogPen.lopnColor.ToColor(), LogPen.lopnWidth.x);
        }
        string PenStyleItoString(PenStyle ps) {
            StringBuilder str = new StringBuilder();
            if((ps & PenStyle.PS_GEOMETRIC) != 0)
                str.Append("COSMETIC");
            else
                str.Append("GEOMETRIC");
            if((ps & PenStyle.PS_ENDCAP_SQUARE) != 0)
                str.Append(GetSuffix(str) + "ENDCAP_SQUARE");
            else if((ps & PenStyle.PS_ENDCAP_FLAT) != 0)
                str.Append(GetSuffix(str) + "ENDCAP_FLAT");
            else
                str.Append(GetSuffix(str) + "ENDCAP_ROUND");
            if((ps & PenStyle.PS_JOIN_BEVEL) != 0)
                str.Append(GetSuffix(str) + "JOIN_BEVEL");
            else if((ps & PenStyle.PS_JOIN_MITER) != 0)
                str.Append(GetSuffix(str) + "JOIN_MITER");
            else
                str.Append(GetSuffix(str) + "JOIN_ROUND");
            if((ps & PenStyle.PS_DASH) != 0)
                str.Append(GetSuffix(str) + "DASH");
            else if((ps & PenStyle.PS_DOT) != 0)
                str.Append(GetSuffix(str) + "DOT");
            else if((ps & PenStyle.PS_DASHDOT) != 0)
                str.Append(GetSuffix(str) + "DASHDOT");
            else if((ps & PenStyle.PS_DASHDOTDOT) != 0)
                str.Append(GetSuffix(str) + "DASHDOTDOT");
            else if((ps & PenStyle.PS_NULL) != 0)
                str.Append(GetSuffix(str) + "NULL");
            else if((ps & PenStyle.PS_INSIDEFRAME) != 0)
                str.Append(GetSuffix(str) + "INSIDEFRAME");
            else if((ps & PenStyle.PS_USERSTYLE) != 0)
                str.Append(GetSuffix(str) + "USERSTYLE");
            else if((ps & PenStyle.PS_ALTERNATE) != 0)
                str.Append(GetSuffix(str) + "ALTERNATE");
            else
                str.Append(GetSuffix(str) + "SOLID");
            return str.ToString();
        }
        string GetSuffix(StringBuilder sb) {
            string str = sb.ToString();
            return string.IsNullOrWhiteSpace(str) ? "" : "__";
        }
    }

    public class EmrRecordCreateBrushIndirect : EMRRecord {
        EMRCREATEBRUSHINDIRECT emrBrush;
        public EmrRecordCreateBrushIndirect(IntPtr ptr) : base(RecordType.EMR_CREATEBRUSHINDIRECT) {
            object brush = Marshal.PtrToStructure(ptr, typeof(EMRCREATEBRUSHINDIRECT));
            emrBrush = (EMRCREATEBRUSHINDIRECT) brush;
            if(!EMFProvider.GdiHandles.ContainsKey(emrBrush.ihBrush))
                EMFProvider.GdiHandles.Add(emrBrush.ihBrush, this);
        }
        public EMRCREATEBRUSHINDIRECT Value => emrBrush;
        public LOGBRUSH LogBrush => emrBrush.lb;
        public override string GetInfo() {
            return $"LOGBRUSH: color = {LogBrush.lbColor.ToColor()}" + " hatchStyle = " + (HatchStyle) LogBrush.lbHatch + " brushStyle = " + (BrushStyle) LogBrush.lbStyle + "\r\n";
        }
    }

    public class EmrRecordSetTextColor : EMRRecord {
        EMRSETTEXTCOLOR setTextColor;
        public EmrRecordSetTextColor(IntPtr ptr) : base(RecordType.EMR_SETTEXTCOLOR) {
            object textColor = Marshal.PtrToStructure(ptr, typeof(EMRSETTEXTCOLOR));
            setTextColor = (EMRSETTEXTCOLOR) textColor;

        }
        public EMRSETTEXTCOLOR Value => setTextColor;
        public Color Color => setTextColor.crColor.ToColor();
        public override string GetInfo() {
            return $"SETTEXTCOLOR: color = {Color} \r\n";
        }
    }

    public class EmrRecordEmrAlignment : EMRRecord {
        EMRSELECTCLIPPATH textAlign;
        public EmrRecordEmrAlignment(IntPtr ptr) : base(RecordType.EMR_SETTEXTALIGN) {
            object bkMode = Marshal.PtrToStructure(ptr, typeof(EMRSELECTCLIPPATH));
            textAlign = (EMRSELECTCLIPPATH) bkMode;
        }
        public TextAlignment Alignment => (TextAlignment) textAlign.iMode;
        public override string GetInfo() {
            return $"SETTEXTALIGN: {Alignment} \r\n";
        }
    }

    public class EmrRecordBKMode : EMRRecord {
        EMRSELECTCLIPPATH emrBkMode;
        public EmrRecordBKMode(IntPtr ptr) : base(RecordType.EMR_SETBKMODE) {
            object bkMode = Marshal.PtrToStructure(ptr, typeof(EMRSELECTCLIPPATH));
            emrBkMode = (EMRSELECTCLIPPATH) bkMode;
        }
        public BackgroundMode Mode => (BackgroundMode) emrBkMode.iMode;
        public override string GetInfo() {
            return $"SETBKMODE: {Mode} \r\n";
        }
    }

    public class EmrRecordBitBlt : EMRRecord {
        EMRBITBLT bitblt;
        public EmrRecordBitBlt(IntPtr ptr) : base(RecordType.EMR_BITBLT) {
            object bblt = Marshal.PtrToStructure(ptr, typeof(EMRBITBLT));
            bitblt = (EMRBITBLT)bblt;
            //IntPtr ptrToBitmapInfo = ptr + (int) bitblt.offBmiSrc;
            //object bminfo = Marshal.PtrToStructure(ptrToBitmapInfo, typeof(BITMAPINFO));
            //var emrbmInfo = (BITMAPINFO)bminfo;
        }
        public EMRBITBLT Value => bitblt;
        public override string GetInfo() {
            return "BITBLT:\r\n" + "X src: " + bitblt.xSrc + "\r\n" + "Y src: " + bitblt.ySrc + "\r\n" + "X dst: " + bitblt.xDest + "\r\n" + "Y dst: " + bitblt.yDest + "\r\n" + "Bounds" + RectLtoString(bitblt.rclBounds) + "\r\n";
        }
        string RectLtoString(RECTL r) {
            return "Lft=" + r.left + ", " + "Top=" + r.top + ", " + "Rgt=" + r.right + ", " + "Btm=" + r.bottom;
        }
    }

    public class EmrRecordPolygon : EMRRecord {
        EMRPOLYLINE16 emrPolygon;
        POINTS[] points;
        public EmrRecordPolygon(IntPtr ptr) : base(RecordType.EMR_POLYGON16) {
            object polygon = Marshal.PtrToStructure(ptr, typeof(EMRPOLYLINE16));
            emrPolygon = (EMRPOLYLINE16) polygon;
            points = new POINTS[emrPolygon.cpts];
            IntPtr pointsStart = ptr + 28;
            for(int i = 0; i < emrPolygon.cpts; i++)
                points[i] = Marshal.PtrToStructure<POINTS>(pointsStart + i * 4);
        }
        public EMRPOLYLINE16 Value => emrPolygon;
        public POINTS[] Points => points;
        public override string GetInfo() {
            return "EMRPOLYGON:" + "Bounds = " + RectLtoString(Value.rclBounds) + "\r\n" + "Count = " + Value.cpts + "\r\n" + "Points: " + PointsToString(Points) + "\r\n";
        }
        string PointsToString(POINTS[] pts) {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < pts.Length; i++)
                sb.Append(PointToString(pts[i]));
            return sb.ToString();
        }

        string PointToString(POINTS p) {
            return "X=" + p.x + ", " + "Y=" + p.y;
        }
        string RectLtoString(RECTL r) {
            return "Lft=" + r.left + ", " + "Top=" + r.top + ", " + "Rgt=" + r.right + ", " + "Btm=" + r.bottom;
        }
    }

    public class EmrRecordModifyWorldTransform : EMRRecord {
        EMRMODIFYWORLDTRANSFORM transform;
        public EmrRecordModifyWorldTransform(IntPtr ptr) : base(RecordType.EMR_MODIFYWORLDTRANSFORM) {
            object cfio = Marshal.PtrToStructure(ptr, typeof(EMRMODIFYWORLDTRANSFORM));
            EMRMODIFYWORLDTRANSFORM cfi = (EMRMODIFYWORLDTRANSFORM) cfio;
            this.transform = cfi;
        }
        public EMRMODIFYWORLDTRANSFORM Value => transform;
        public override string GetInfo() {
            return "MODIFYWORLDTRANSFORM: " + XFormToString(Value.xform) + "\r\n";
        }
        string XFormToString(XFORM m) {
            return "M11=" + m.eM11 + ", " + "M12=" + m.eM12 + ", " + "M21=" + m.eM21 + ", " + "M22=" + m.eM22 + ", " + "Dx=" + m.eDx + ", " + "Dy=" + m.eDy;
        }
    }

    public class EmrRecordHeader : EMRRecord {
        ENHMETAHEADER metaHeader;
        public EmrRecordHeader(IntPtr ptr) : base(RecordType.EMR_HEADER) {
            object header = Marshal.PtrToStructure(ptr, typeof(ENHMETAHEADER));
            metaHeader = (ENHMETAHEADER) header;
        }
        public ENHMETAHEADER Value => metaHeader;
        public override string GetInfo() {
            return "HEADER:" + "\r\n" + "Bounds: " + RectLtoString(Value.rclBounds) + "\r\n" + "Frame: " + RectLtoString(Value.rclFrame) + "\r\n" + "Device: " + SizetLtoString(Value.szlDevice) + "\r\n" + "Millimeters " + SizetLtoString(Value.szlMillimeters) + "\r\n";
        }
        string RectLtoString(RECTL r) {
            return "Lft=" + r.left + ", " + "Top=" + r.top + ", " + "Rgt=" + r.right + ", " + "Btm=" + r.bottom;
        }
        string SizetLtoString(SIZEL s) {
            return "Wdt=" + s.cx + ", " + "Hgh=" + s.cy;
        }
    }

    public class EmrRecordCreateFontIndirect : EMRRecord {
        EMREXTCREATEFONTINDIRECT value;
        public EmrRecordCreateFontIndirect(IntPtr ptr) : base(RecordType.EMR_EXTCREATEFONTINDIRECTW) {
            object cfio = Marshal.PtrToStructure(ptr, typeof(EMREXTCREATEFONTINDIRECT));
            EMREXTCREATEFONTINDIRECT cfi = (EMREXTCREATEFONTINDIRECT) cfio;
            this.value = cfi;
            if(!EMFProvider.GdiHandles.ContainsKey(cfi.ihFont)) {
                EMFProvider.GdiHandles.Add(cfi.ihFont, this);
            }
        }
        public EMREXTCREATEFONTINDIRECT Value => value;
        public Font GetPlatformFont(IntPtr hdc) => Font.FromLogFont(value.elfw.elfLogFont, hdc);
        public LOGFONT LogFont => value.elfw.elfLogFont;
        public override string GetInfo() {
            return "CREATEFONTINDIRECT: LOGFONT " + LogFontItoString(LogFont, true) + "\r\n";
        }
        string LogFontItoString(LOGFONT lf, bool withLinebreaks) {
            string facename = new string(lf.lfFaceName.ToCharArray()).Trim(new char[] {' ', '\0'});
            return "Height=" + lf.lfHeight + ", " + "Width=" + lf.lfWidth + ", " + "Escapement=" + lf.lfEscapement + "," + (withLinebreaks ? "\r\n  " : " ") + "Orientation=" + lf.lfOrientation + ", " + "Weight=" + lf.lfWeight + ", " + "Italic=" + lf.lfItalic + "," + (withLinebreaks ? "\r\n  " : " ") + "Underline=" + lf.lfUnderline + ", " + "StrikeOut=" + lf.lfStrikeOut + "," + (withLinebreaks ? "\r\n  " : " ") + "CharSet=" + lf.lfCharSet + ", " + "OutPrecision=" + lf.lfOutPrecision + "," + (withLinebreaks ? "\r\n  " : " ") + "ClipPrecision=" + lf.lfClipPrecision + ", " + "Quality=" + lf.lfQuality + "," + (withLinebreaks ? "\r\n  " : " ") + "PitchAndFamily=" + lf.lfPitchAndFamily + ", " + "Face-Name=" + facename;
        }
    }

    public class EmrRecordExtTextOutW : EMRRecord {
        EMREXTTEXTOUTA value;
        string text;
        public EmrRecordExtTextOutW(IntPtr ptr) : base(RecordType.EMR_EXTTEXTOUTW) {
            object textOut = Marshal.PtrToStructure(ptr, typeof(EMREXTTEXTOUTA));
            EMREXTTEXTOUTA textOutStruct = (EMREXTTEXTOUTA) textOut;
            this.value = textOutStruct;
            IntPtr textPtr = ptr + (int) textOutStruct.emrtext.offString;
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < textOutStruct.emrtext.nChars; i++)
                sb.Append(Marshal.PtrToStringAnsi(textPtr + i * 2));
            text = sb.ToString();
        }
        public EMREXTTEXTOUTA Value => value;
        public string Text => text;
        public override string GetInfo() {
            return "EXTTEXTOUTW\r\n" + "Bounds" + RectLtoString(Value.rclBounds) + "\r\n" + "GraphicsMode: " + Value.iGraphicsMode + "\r\n" + "EYScale = " + Value.eyScale + ", " + "EXScale = " + Value.exScale + "\r\n" + "ClipBounds = " + RectLtoString(Value.emrtext.rcl) + "\r\n" + "Text= " + Text + "\r\n";
        }
        string RectLtoString(RECTL r) {
            return "Lft=" + r.left + ", " + "Top=" + r.top + ", " + "Rgt=" + r.right + ", " + "Btm=" + r.bottom;
        }
    }
}