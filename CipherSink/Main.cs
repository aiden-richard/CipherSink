using CipherSink.Forms.GameForms;

namespace CipherSink;

public partial class Main : Form
{
    public Main()
    {
        InitializeComponent();
    }

    private void CreateGameBtn_Click(object sender, EventArgs e)
    {
        // For now will just open the gameboard form, later on should open a message box to create a game
        var createGameForm = new CreateGame();
        createGameForm.ShowDialog();
    }

    private void JoinGameBtn_Click(object sender, EventArgs e)
    {
        var joinGameForm = new JoinGame();
        joinGameForm.ShowDialog();
    }

    private void PlayerAccountBtn_Click(object sender, EventArgs e)
    {
        var accountForm = new AccountAndStats();
        accountForm.ShowDialog();
    }

    private void OptionsBtn_Click(object sender, EventArgs e)
    {
        var optionsForm = new Options();
        optionsForm.ShowDialog();
    }

    private void RecentGamesBtn_Click(object sender, EventArgs e)
    {
        var friendsForm = new RecentGames();
        friendsForm.ShowDialog();
    }

    private void ExitBtn_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}
