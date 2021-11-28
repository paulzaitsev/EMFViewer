using System;
using System.IO;
using NUnit.Framework;

namespace EMFTestingFramework {
    [TestFixture]
    public class EMFDrawingBaseFixture {
        protected EMFProvider metafileProvider;
        string file;
        [SetUp]
        public virtual void Setup() {
            file = Path.GetTempFileName();
            metafileProvider = new EMFProvider(file);
        }
        protected virtual void DrawToMetafile(Action<IntPtr> draw) { 
            metafileProvider.DrawToMetafile(draw);
            metafileProvider.FillMetadata();
        }
        [TearDown]
        public virtual void TearDown() {
            metafileProvider.Dispose();
            File.Delete(file);
        }
    }
}