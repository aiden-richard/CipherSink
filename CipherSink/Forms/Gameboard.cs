using System.Drawing.Drawing2D;


namespace CipherSink;

public partial class Gameboard : Form
{
    public Gameboard()
    {
        InitializeComponent();
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        // Draw a vertical gradient from yellow (top) to blue (bottom)
        using (var brush = new LinearGradientBrush(this.ClientRectangle, Color.LightBlue, Color.RoyalBlue, LinearGradientMode.Vertical))
        {
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }
    }
}
