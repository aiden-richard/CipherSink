using CipherSink.Models.GameLogic;

namespace CipherSink.Forms.GameForms;

public partial class PlaceShips : Form
{
    public Game Game;

    public PlaceShips(Game game)
    {
        InitializeComponent();
        Game = game;
        Game.UpdateUIAsync = UpdateUIAsync;
        _ = Game.Start();

        BtnRandomizePositions.PerformClick(); // Randomize ship positions on start
        Game.LocalPlayer.Gameboard.FillTableLayoutPanel(LayoutPanelPlaceShips, false);
    }

    private Task UpdateUIAsync()
    {
        switch (Game.State)
        {
            case GameState.VerifyUser:
                BackColor = Color.LightSkyBlue;
                LabelWaitingForConnection.Visible = true;
                break;

            case GameState.PlaceShips:
                LabelWaitingForConnection.Visible = false;
                BackColor = Color.DarkBlue;
                LayoutPanelPlaceShips.Visible = true;
                BtnRandomizePositions.Visible = true;
                BtnReady.Visible = true;
                break;

            case GameState.WaitingOnOpponentReady:
                var mainGameForm = new MainGame(Game);
                Hide();
                mainGameForm.Show();
                break;

            case GameState.Aborted:
                Close();
                break;
        }
        return Task.CompletedTask;
    }

    private void BtnRandomizePositions_Click(object sender, EventArgs e)
    {
        Game.LocalPlayer.Gameboard.RandomizeShipPositions();
        Game.LocalPlayer.Gameboard.FillTableLayoutPanel(LayoutPanelPlaceShips, false);
    }

    private void BtnReady_Click(object sender, EventArgs e)
    {
        BtnReady.Enabled = false;
        Game.AcceptShipPlacements();
    }
}
