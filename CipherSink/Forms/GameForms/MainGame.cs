using CipherSink.Models.GameBoard;
using CipherSink.Models.GameLogic;

namespace CipherSink;

public partial class MainGame : Form
{
    public Game Game;

    public MainGame(Game game)
    {
        InitializeComponent();
        Game = game;
        Game.UpdateUIAsync = UpdateUIAsync;

        // Set up TableLayoutPanels
        for (int row = 0; row < LayoutPanelOpponent.RowCount; row++)
        {
            for (int col = 0; col < LayoutPanelOpponent.ColumnCount; col++)
            {
                // Get panel at the current position
                var cellPanel = LayoutPanelOpponent.GetControlFromPosition(col, row);

                if (cellPanel == null)
                {
                    cellPanel = new Panel();
                    LayoutPanelOpponent.Controls.Add(cellPanel, col, row);
                }

                // Capture loop variables for closure
                int x = col;
                int y = row;
                cellPanel.Click += (_, _) => Game.AcceptAttackOnEnemyCell(new Coordinates(x, y));
            }
        }

        // Initial UI sync
        _ = UpdateUIAsync();
    }

    private Task UpdateUIAsync()
    {
        Game.LocalPlayer.Gameboard.FillTableLayoutPanel(LayoutPanelLocal);
        Game.RemotePlayer.Gameboard.FillTableLayoutPanel(LayoutPanelOpponent);

        switch (Game.State)
        {
            case GameState.WaitingOnOpponentReady:
                LabelWaitingForOpponentReady.Visible = true;
                LabelStatusMessage.Text = String.Empty;
                break;

            case GameState.LocalTurn:
                LabelWaitingForOpponentReady.Visible = false;
                LayoutPanelOpponent.Visible = true;
                LayoutPanelLocal.Visible = true;
                LabelStatusMessage.Text = Game.StatusMessage;
                break;

            case GameState.RemoteTurn:
                LabelWaitingForOpponentReady.Visible = false;
                LayoutPanelOpponent.Visible = true;
                LayoutPanelLocal.Visible = true;
                LabelStatusMessage.Text = Game.StatusMessage;
                break;
            
            case GameState.Finished:
                LayoutPanelOpponent.Visible = false;
                LayoutPanelLocal.Visible = false;
                LabelStatusMessage.Text = String.Empty;
                LabelWaitingForOpponentReady.Text = Game.StatusMessage; // use waiting for opponent ready label for bigger text
                LabelWaitingForOpponentReady.Visible = false;

                break;

            case GameState.Aborted:
                Close();
                break;
        }
        return Task.CompletedTask;
    }
}
