using CipherSink.Models.GameLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace CipherSink.Forms.GameForms;

public partial class PlaceShips : Form
{
    private Game game;

    public PlaceShips(Game _game)
    {
        InitializeComponent();
        game = _game;
        game.UpdateUI = UpdateUI;
        game.Start();
    }

    public void UpdateUI()
    {
        switch (game.State)
        {
            case GameState.VerifyUser:
                
                break;

            case GameState.PlaceShips:
                // Logic for placing ships
                break;
            case GameState.WaitingOnOpponentReady:
                // Logic for waiting on opponent
                break;
            case GameState.LocalTurn:
                // Logic for local player's turn
                break;
            case GameState.RemoteTurn:
                // Logic for remote player's turn
                break;
            case GameState.Finished:
                // Logic for finishing the game
                break;
            case GameState.Aborted:
                MessageBox.Show("Game aborted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;
        }
    }
}
