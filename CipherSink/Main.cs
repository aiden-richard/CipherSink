using System.Drawing.Drawing2D;

namespace CipherSink;

public partial class Main : Form
{
    public Main()
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

    private void CreateGameBtn_Click(object sender, EventArgs e)
    {
        // For now will just open the gameboard form, later on should open a message box to create a game
        var gameboardForm = new Gameboard();
        gameboardForm.ShowDialog();
    }

    private void PlayerAccountBtn_Click(object sender, EventArgs e)
    {
        var accountForm = new AccountStats();
        accountForm.ShowDialog();
    }

    private void OptionsBtn_Click(object sender, EventArgs e)
    {
        var optionsForm = new Options();
        optionsForm.ShowDialog();
    }

    private void RecentGamesBtn_Click(object sender, EventArgs e)
    {
        var friendsForm = new RecentPlayers();
        friendsForm.ShowDialog();
    }

    private void ExitBtn_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}
