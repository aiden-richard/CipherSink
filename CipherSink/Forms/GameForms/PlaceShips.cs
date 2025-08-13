using CipherSink.Models.GameLogic;

namespace CipherSink.Forms.GameForms;

public partial class PlaceShips : Form
{
    private Game Game;

    public PlaceShips(Game game)
    {
        InitializeComponent();
        Game = game;
        Game.UpdateUI = UpdateUI;
        Game.Start();
    }

    public void UpdateUI()
    {
        switch (Game.State)
        {
            case GameState.VerifyUser:
                this.BackColor = Color.LightBlue;
                break;

            case GameState.PlaceShips:
                BackColor = Color.DarkBlue;
                // Display place ships UI
                break;

            case GameState.WaitingOnOpponentReady:
                // once ships are placed, state will change to WaitingOnOpponentReady
                // we will send User to main game board form here
                break;

            case GameState.Aborted:
                MessageBox.Show("Game aborted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;
        }
    }
}
