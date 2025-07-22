using System.Drawing.Drawing2D;


namespace CipherSink;

public partial class AccountStats : Form
{
    public AccountStats()
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
