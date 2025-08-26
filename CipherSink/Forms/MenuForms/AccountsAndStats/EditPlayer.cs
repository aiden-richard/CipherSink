using CipherSink.Models.Database;
using CipherSink.Models.Database.Entities;
using CipherSink.Models.Validation;
using System.ComponentModel;

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
            if (SelectedPlayer.Username != TxtBxUsername.Text)
            {
                SelectedPlayer.Username = TxtBxUsername.Text;

                dbContext.SaveChanges();

                MessageBox.Show("Player info updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Close the form after creating the user
            }
            else
            {
                MessageBox.Show("No Changes were made.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }

    private bool ValidInputs()
    {
        if (SelectedPlayer == null)
        {
            MessageBox.Show("No player selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false; // No player selected
        }

        if (!Validator.IsValidUsername(TxtBxUsername.Text))
        {
            MessageBox.Show("Invalid username. It must be alphanumeric and between 1 and 32 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // we will need to validate imported keys

        return true;
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
