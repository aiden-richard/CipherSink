using CipherSink.Models.Database;
using CipherSink.Models.Database.Entities;
using CipherSink.Models.GameLogic;
using CipherSink.Models.Networking;
using CipherSink.Models.Validation;
using System.ComponentModel;

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

            TcpPeer peer = new TcpPeer(SelectedPlayer.RsaObject, isPrivatGame, null);

            Game game = new(peer, SelectedPlayer);

            var placeShipsForm = new PlaceShips(game);
            placeShipsForm.ShowDialog();
            this.Close();
        }
    }

    private bool ValidInputs()
    {
        if (!Validator.IsValidPassword(TxtBxPlayerPassword.Text))
        {
            MessageBox.Show("Password must be alphanumeric and between 4 and 32 characters.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        
        if (!SelectedPlayer.LoadPrivatekey(TxtBxPlayerPassword.Text))
        {
            MessageBox.Show("Incorrect Password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (TxtBxGamePin.Text != String.Empty && !Validator.IsValidGamePin(TxtBxGamePin.Text))
        {
            MessageBox.Show("Game PIN must be alphanumeric and between 4 and 32 characters.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        base.OnClosing(e);

        this.dbContext?.Dispose();
        this.dbContext = null;
    }
}
