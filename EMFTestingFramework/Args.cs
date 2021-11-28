using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMFAssembly {
    public class EMRObjectArgsBase {
        public EMRObjectArgsBase(string elementName) {
            ElementName = elementName;
        }
        public string ElementName { get; }
    }

    public class EmrTextArgs : EMRObjectArgsBase {
        public EmrTextArgs(EMRElementContainer container, EmrRecordExtTextOutW textOut) : base(container.Name) {
            TextOut = textOut;
            Container = container;
        }
        public EmrRecordExtTextOutW TextOut { get; }
        public EMRElementContainer Container { get; }
    }

    public class EmrSelectObjectArgs : EMRObjectArgsBase {
        public EmrSelectObjectArgs(EMRElementContainer container, EmrRecordSelectObject @object) : base(container.Name) {
            Object = @object;
            Container = container;
        }
        public EmrRecordSelectObject Object { get; }
        public EMRElementContainer Container { get; }
    }

    public class EmrFontArgs : EMRObjectArgsBase {
        public EmrFontArgs(EMRElementContainer container, EmrRecordCreateFontIndirect font) : base(container.Name) {
            Font = font;
            Container = container;
        }
        public EmrRecordCreateFontIndirect Font { get; }
        public EMRElementContainer Container { get; }
    }

    public class EmrPolygonArgs : EMRObjectArgsBase {
        public EmrPolygonArgs(EMRElementContainer container, EmrRecordPolygon poly) : base(container.Name) {
            Polygon = poly;
            Container = container;
        }
        public EmrRecordPolygon Polygon { get; }
        public EMRElementContainer Container { get; }
    }

    public class SkinElementImageObjectArgs : EMRObjectArgsBase {
        public SkinElementImageObjectArgs(EMRElementContainer container, EmrRecordBitBlt bitblt) : base(container.Name) {
            BitBlt = bitblt;
            Container = container;
        }
        public EmrRecordBitBlt BitBlt { get; }
        public EMRElementContainer Container { get; }
    }
}