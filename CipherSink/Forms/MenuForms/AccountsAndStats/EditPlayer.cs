using CipherSink.Models.Database;
using CipherSink.Models.Database.Entities;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace CipherSink.Forms.MenuForms.AccountsAndStats;
public partial class EditPlayer : Form
{
    private CipherSinkContext dbContext;

    private LocalPlayer SelectedPlayer
    {
        get => (LocalPlayer)comboBoxSelectPlayer.SelectedItem;
        set => comboBoxSelectPlayer.SelectedItem = value;
    }

    public EditPlayer()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        this.dbContext = new CipherSinkContext();

        this.dbContext.Database.EnsureCreated();

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

        LoadPlayerData();
    }

    private void LoadPlayerData()
    {
        TxtBxUsername.Text = SelectedPlayer.Username;

        string pemKey = SelectedPlayer.RsaObject.ExportRSAPublicKeyPem();
        TxtBxPublicKey.Text = pemKey;

        LabelWins.Text = $"Wins: {SelectedPlayer.TotalWins.ToString()}";
        LabelLosses.Text = $"Losses: {SelectedPlayer.TotalLosses.ToString()}";
    }

    private void comboBoxSelectPlayer_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadPlayerData();
    }

    private void BtnUpdatePlayer_Click(object sender, EventArgs e)
    {
        if (ValidInputs())
        {
            if (SelectedPlayer == null)
            {
                MessageBox.Show("No player selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // No player selected
            }

            SelectedPlayer.Username = TxtBxUsername.Text;
            dbContext.SaveChanges();

            MessageBox.Show("Player info updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Close the form after creating the user
        }
    }

    private bool ValidInputs()
    {
        if (!Regex.IsMatch(TxtBxUsername.Text, @"^[A-Za-z0-9]+$"))
        {
            MessageBox.Show("Username must be alphanumeric", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false; // No user selected
        }
        else if (TxtBxUsername.Text.Length < 1 || TxtBxUsername.Text.Length > 32)
        {
            MessageBox.Show("Username must be between 1 and 32 characters.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
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

    private void BtnIncrementWins_Click(object sender, EventArgs e)
    {
        SelectedPlayer?.IncrementWins();
        LabelWins.Text = $"Wins: {SelectedPlayer.TotalWins.ToString()}";
    }

    private void BtnIncrementLosses_Click(object sender, EventArgs e)
    {
        SelectedPlayer?.IncrementLosses();
        LabelLosses.Text = $"Losses: {SelectedPlayer.TotalLosses.ToString()}";
    }
}