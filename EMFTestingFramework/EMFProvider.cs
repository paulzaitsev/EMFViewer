using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EMFAssembly {
    public class EMFProvider : IDisposable {
        string filePath;
        public EMFProvider(string filePath) {
            this.filePath = filePath;
        }
        static Dictionary<uint, EMRRecord> gdiHandles;
        public static Dictionary<uint, EMRRecord> GdiHandles {
            get {
                if(gdiHandles == null) gdiHandles = new Dictionary<uint, EMRRecord>();
                return gdiHandles;
            }
        }
        public static void ClearHandlesCache() {
            if(gdiHandles != null) {
                gdiHandles.Clear();
                gdiHandles = null;
            }
        }
        public void DrawToMetafile(Action<IntPtr> draw) {
            IntPtr cdc = GDI.CreateCompatibleDC(IntPtr.Zero);
            IntPtr hdcMf = GDI.CreateEnhMetaFile(cdc, filePath, IntPtr.Zero, null);
            if(hdcMf != IntPtr.Zero) {
                draw(hdcMf);
                IntPtr hEnh = GDI.CloseEnhMetaFile(hdcMf);
                if(hEnh == IntPtr.Zero)
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                GDI.DeleteEnhMetaFile(hEnh);
                GDI.DeleteDC(cdc);
            }
        }
        public Bitmap DrawToImage(Action<IntPtr> draw, int width, int height) {
            Bitmap bm = new Bitmap(width, height);
            using(Bitmap bm1 = new Bitmap(width, height)) {
                using(Graphics g1 = Graphics.FromImage(bm1)) {
                    IntPtr hdc1 = g1.GetHdc();
                    draw(hdc1);
                    using(Graphics g2 = Graphics.FromImage(bm)) {
                        IntPtr hdc2 = g2.GetHdc();
                        GDI.BitBlt(hdc2, 0, 0, width, height, hdc1, 0, 0, 13369376);
                        g2.ReleaseHdcInternal(hdc2);
                    }
                    g1.ReleaseHdc(hdc1);
                }
            }
            return bm;
        }
        Metadata metadata;
        public Metadata FillMetadata() {
            metadata = new Metadata();
            log = null;
            EnumerateMetafile();
            return metadata;
        }
        public Metadata Metadata => metadata;
        StringBuilder log;
        public StringBuilder Log {
            get {
                if(log == null) log = new StringBuilder();
                return log;
            }
        }
        public Dictionary<int, Type> Types {
            get {
                if(primitiveTypes == null) {
                    primitiveTypes = new Dictionary<int, Type>();
                    primitiveTypes.Add(RecordType.EMR_HEADER, typeof(EmrRecordHeader));
                    primitiveTypes.Add(RecordType.EMR_EXTCREATEFONTINDIRECTW, typeof(EmrRecordCreateFontIndirect));
                    primitiveTypes.Add(RecordType.EMR_EXTTEXTOUTW, typeof(EmrRecordExtTextOutW));
                    primitiveTypes.Add(RecordType.EMR_SETBKMODE, typeof(EmrRecordBKMode));
                    primitiveTypes.Add(RecordType.EMR_SETTEXTALIGN, typeof(EmrRecordEmrAlignment));
                    primitiveTypes.Add(RecordType.EMR_SETTEXTCOLOR, typeof(EmrRecordSetTextColor));
                    primitiveTypes.Add(RecordType.EMR_CREATEBRUSHINDIRECT, typeof(EmrRecordCreateBrushIndirect));
                    primitiveTypes.Add(RecordType.EMR_CREATEPEN, typeof(EmrRecordCreatePen));
                    primitiveTypes.Add(RecordType.EMR_MODIFYWORLDTRANSFORM, typeof(EmrRecordModifyWorldTransform));
                    primitiveTypes.Add(RecordType.EMR_SELECTOBJECT, typeof(EmrRecordSelectObject));
                    primitiveTypes.Add(RecordType.EMR_DELETEOBJECT, typeof(EmrRecordDeleteObject));
                    primitiveTypes.Add(RecordType.EMR_POLYGON16, typeof(EmrRecordPolygon));
                    primitiveTypes.Add(RecordType.EMR_BITBLT, typeof(EmrRecordBitBlt));
                }
                return primitiveTypes;
            }
        }
        Dictionary<int, Type> primitiveTypes;
        public void EnumerateMetafile() {
            IntPtr hEnh = GDI.GetEnhMetaFileA(filePath);
            Stack<EMRElementContainer> elements = new Stack<EMRElementContainer>();
            GDI.EnumEnhMetaFile(IntPtr.Zero, hEnh, delegate(IntPtr ptr, IntPtr[] lpht, IntPtr lpmr, int handles, int data) {
                int iType = Marshal.ReadInt32(lpmr);
                if(iType == RecordType.EMR_GDICOMMENT) {
                    object emrRecord = Marshal.PtrToStructure(lpmr, typeof(EMRGDICOMMENT));
                    EMRGDICOMMENT record = (EMRGDICOMMENT) emrRecord;
                    byte[] commentData = new byte[record.cbData];
                    for(int i = 0; i < commentData.Length; i++)
                        commentData[i] = record.Data[i];
                    string comment = Encoding.ASCII.GetString(commentData);
                    Log.Append("GDICOMMENT:" + comment + Environment.NewLine);
                    if(comment.Contains("BeginDraw")) {
                        var container = new EMRElementContainer(GetCommentDescription(comment));
                        if(elements.Count > 0) {
                            container.Parent = elements.Peek();
                            elements.Peek().Children.Add(container);
                            elements.Push(container);
                        }
                        else elements.Push(container);
                    }
                    else if(comment.Contains("EndDraw")) {
                        var container = elements.Pop();
                        if(elements.Count == 0) {
                            metadata.Elements.Add(container);
                        }
                    }
                }
                Type gdiPrimitiveWrapperType;
                if(Types.TryGetValue(iType, out gdiPrimitiveWrapperType)) {
                    object instance = Activator.CreateInstance(gdiPrimitiveWrapperType, lpmr);
                    AddPrimitive(elements, (EMRRecord)instance);
                }
                return 1;
            }, IntPtr.Zero, IntPtr.Zero);
            GDI.DeleteEnhMetaFile(hEnh);
        }
        void AddPrimitive(Stack<EMRElementContainer> elements, EMRRecord record) {
            Log.Append(record.GetInfo());
            var element = elements.Count > 0 ? elements.Peek() : null;
            element?.Records.Add(record);
        }
        string GetCommentDescription(string comment) {
            return comment.Replace("BeginDraw ", string.Empty);
        }
        public void Dispose() {
            ClearHandlesCache();
        }
    }
}
