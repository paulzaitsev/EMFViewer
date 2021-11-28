using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EMFAssembly;

namespace EMFViewer {
    public partial class Form1 : Form {
        EMFProvider metafileProvider;
        string file;
        public Form1() {
            InitializeComponent();
            file = Path.GetTempFileName();
            metafileProvider = new EMFProvider(file);
            metafileProvider.DrawToMetafile(hdc => Draw(hdc));
            metafileProvider.FillMetadata();
            textEdit1.Text = metafileProvider.Log.ToString();
            pictureBox1.Image = metafileProvider.DrawToImage(Draw, 500, 500);
        }
        void Draw(IntPtr hdc) {
            using(Font font = new Font("Calibri", 14f)) {
                IntPtr hFont = font.ToHfont();
                using(Graphics graphics = Graphics.FromHdc(hdc)) {
                    var rect = new Rectangle(0, 0, 100, 100);
                    graphics.FillRectangle(Brushes.Yellow, rect);
                    graphics.DrawString("String", font, Brushes.Red, rect, StringFormat.GenericDefault);
                }
                GDI.DeleteObject(hFont);
            }
        }
        protected override void OnClosed(EventArgs e) {
            base.OnClosed(e);
            metafileProvider.Dispose();
            File.Delete(file);
        }
    }
}