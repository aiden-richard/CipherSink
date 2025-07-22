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

    private void StartGameBtn_Click(object sender, EventArgs e)
    {
        var gameboardForm = new Gameboard();
        gameboardForm.ShowDialog();
    }

    private void PlayerAccountBtn_Click(object sender, EventArgs e)
    {
        var accountForm = new Account();
        accountForm.ShowDialog();
    }

    private void OptionsBtn_Click(object sender, EventArgs e)
    {
        var optionsForm = new Options();
        optionsForm.ShowDialog();
    }

    private void FriendsBtn_Click(object sender, EventArgs e)
    {
        var friendsForm = new FriendsList();
        friendsForm.ShowDialog();
    }

    private void ExitBtn_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}
