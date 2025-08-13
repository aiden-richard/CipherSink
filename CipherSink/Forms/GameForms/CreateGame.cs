using CipherSink.Models.Database;
using CipherSink.Models.Database.Entities;
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
    private CipherSinkContext dbContext;

    private LocalPlayer SelectedPlayer
    {
        get => (LocalPlayer)comboBoxSelectPlayer.SelectedItem;
        set => comboBoxSelectPlayer.SelectedItem = value;
    }

    public enum GameType
    {
        Private,
        Public
    }

    public CreateGame()
    {
        InitializeComponent();

        // Populate GameType ComboBox with enum values
        comboBoxGameType.DataSource = Enum.GetValues(typeof(GameType));
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        this.dbContext = new CipherSinkContext();

        // uncomment the line below to start fresh with a new database.
        // this.dbContext.Database.EnsureDeleted();
        this.dbContext.Database.EnsureCreated();

        LoadComboBoxData();
    }

    private void LoadComboBoxData()
    {
        // populate the Players ComboBox
        var players = dbContext.LocalPlayers.ToList();
        if (players.Count > 0)
        {
            comboBoxSelectPlayer.DataSource = players;
            comboBoxSelectPlayer.DisplayMember = "Username";
            comboBoxSelectPlayer.ValueMember = "Id";
        }
        else
        {
            comboBoxSelectPlayer.DataSource = null; // No players available
        }

        if (SelectedPlayer == null)
        {
            MessageBox.Show("No players available. Please create a player first.", "No Players", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close(); // Close the form if no players are available
        }
    }

    private void BtnCreateGame_Click(object sender, EventArgs e)
    {
        if (ValidInputs())
        {   
            bool isPrivatGame = comboBoxGameType.SelectedItem.ToString() == GameType.Private.ToString();
            TcpPeer peer = new TcpPeer(SelectedPlayer.RsaObject, isPrivatGame   );

            Game game = new(peer, SelectedPlayer, true);

            var placeShipsForm = new PlaceShips(game);
            placeShipsForm.ShowDialog();
        }
    }

    private bool ValidInputs()
    {
        if (!Regex.IsMatch(TxtBxPlayerPassword.Text, @"^[A-Za-z0-9]+$"))
        {
            MessageBox.Show("Player password must be alphanumeric.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false; // Player password must be alphanumeric
        }
        else if (!SelectedPlayer.LoadPrivatekey(TxtBxPlayerPassword.Text))
        {
            MessageBox.Show("Incorrect Password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false; // Failed to load player's private key with the provided password
        }
        else if (TxtBxGamePin.Text != String.Empty && !Regex.IsMatch(TxtBxGamePin.Text, @"^[A-Za-z0-9]+$"))
        {
            MessageBox.Show("Game PIN must be alphanumeric.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false; // Game PIN must be alphanumeric
        }
        else if (TxtBxGamePin.Text != String.Empty && (TxtBxGamePin.Text.Length < 4 || TxtBxGamePin.Text.Length > 32))
        {
            MessageBox.Show("Game PIN must be between 4 and 32 characters.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false; // Game PIN must be between 4 and 32 characters
        }
        else
        {
            return true; // All inputs are valid
        }
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        base.OnClosing(e);

        this.dbContext?.Dispose();
        this.dbContext = null;
    }
}
