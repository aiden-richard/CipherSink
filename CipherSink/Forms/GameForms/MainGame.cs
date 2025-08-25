using CipherSink.Models.GameLogic;

namespace CipherSink;

public partial class MainGame : Form
{
    public Game Game;

    public MainGame(Game game)
    {
        InitializeComponent();
        Game = game;
        Game.UpdateUI = UpdateUI;
    }

    public void UpdateUI()
    {
        Game.LocalPlayer.Gameboard.FillTableLayoutPanel(LayoutPanelLocal);
        Game.RemotePlayer.Gameboard.FillTableLayoutPanel(LayoutPanelOpponent);

        switch (Game.State)
        {
            case GameState.WaitingOnOpponentReady:
                LabelWaitingForOpponentReady.Visible = true;
                break;

            case GameState.LocalTurn:
                LabelWaitingForOpponentReady.Visible = false;

                // show grids for both players
                LayoutPanelOpponent.Visible = true;
                LayoutPanelLocal.Visible = true;
                break;

            case GameState.RemoteTurn:
                break;

            case GameState.Aborted:
                MessageBox.Show("Game aborted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                break;
        }
    }
}
