using CipherSink.Models.GameLogic;

namespace CipherSink.Forms.GameForms;

public partial class PlaceShips : Form
{
    public Game Game;

    public PlaceShips(Game game)
    {
        InitializeComponent();
        Game = game;
        Game.UpdateUI = UpdateUI;
        Game.Start();

        BtnRandomizePositions.PerformClick(); // Randomize ship positions on start
        Game.LocalPlayer.Gameboard.FillTableLayoutPanel(LayoutPanelPlaceShips);
    }

    public void UpdateUI()
    {
        switch (Game.State)
        {
            case GameState.VerifyUser:
                // Show waiting label and change background color
                this.BackColor = Color.LightSkyBlue;
                LabelWaitingForConnection.Visible = true;
                break;

            case GameState.PlaceShips:
                // Hide the waiting label and change background color
                LabelWaitingForConnection.Visible = false;
                BackColor = Color.DarkBlue;

                // show controls for placing ships
                LayoutPanelPlaceShips.Visible = true;
                BtnRandomizePositions.Visible = true;
                BtnReady.Visible = true;
                break;

            case GameState.WaitingOnOpponentReady:
                var mainGameForm = new MainGame(Game);
                break;

            case GameState.Aborted:
                MessageBox.Show("Game aborted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                break;
        }
    }

    private void BtnRandomizePositions_Click(object sender, EventArgs e)
    {
        Game.LocalPlayer.Gameboard.RandomizeShipPositions();
        Game.LocalPlayer.Gameboard.FillTableLayoutPanel(LayoutPanelPlaceShips);
    }

    private void BtnReady_Click(object sender, EventArgs e)
    {
        Game.AcceptShipPlacements();
    }
}
