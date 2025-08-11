using CipherSink.Models.GameLogic;
using CipherSink.Models.Networking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CipherSink.Forms.GameForms;

public partial class CreateGame : Form
{
    public enum GameType
    {
        SinglePlayer,
        Multiplayer
    }

    public CreateGame()
    {
        InitializeComponent();
        // Initialize the form components
        // Need db context before working on this

        // Make a fake player list for now
        Player player1 = new Player("Alice");
        Player player2 = new Player("Bob");

        // Add players to ComboBox
        List<Player> players = new List<Player> { player1, player2 };
        comboBoxSelectUser.DataSource = players;
        comboBoxSelectUser.DisplayMember = "Name";
        comboBoxSelectUser.ValueMember = "Name";
    }

    private void BtnCreateGame_Click(object sender, EventArgs e)
    {
        if (ValidInputs())
        {
            Player selectedPlayer = (Player)comboBoxSelectUser.SelectedItem;
            TcpPeer peer = new TcpPeer(selectedPlayer.Rsa);

            Game game = new(peer, selectedPlayer, true);

            var placeShipsForm = new PlaceShips(game);
            placeShipsForm.ShowDialog();
        }
    }

    private bool ValidInputs()
    {
        if (comboBoxSelectUser.SelectedIndex < 0) 
        {
            MessageBox.Show("Please select a user.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false; // No user selected
        }
        else if (!Regex.IsMatch(TxtBxGamePin.Text, @"^[A-Za-z0-9]+$"))
        {
            MessageBox.Show("Game PIN must be alphanumeric.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false; // Game PIN must be alphanumeric
        }
        else if (TxtBxGamePin.Text.Length < 4 || TxtBxGamePin.Text.Length > 32)
        {
            MessageBox.Show("Game PIN must be between 4 and 32 characters.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false; // Game PIN must be between 4 and 32 characters
        }
        else
        {
            return true; // All inputs are valid
        }
    }
}
