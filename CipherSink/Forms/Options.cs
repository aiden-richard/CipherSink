using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CipherSink
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Draw a vertical gradient from yellow (top) to blue (bottom)
            using (var brush = new LinearGradientBrush(this.ClientRectangle, Color.LightGoldenrodYellow, Color.RoyalBlue, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
