using System.Collections.Generic;

namespace EMFAssembly {
    public class Metadata {
        //public GDIPrimitive_EMRHEADER Header { get; set; }
        List<EMRElementContainer> elements;
        public List<EMRElementContainer> Elements {
            get {
                if(elements == null) elements = new List<EMRElementContainer>();
                return elements;
            }
        }
    }
}