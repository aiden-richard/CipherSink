using CipherSink.Forms.MenuForms.AccountsAndStats;
using CipherSink.Models.Database;
using CipherSink.Models.Database.Entities;
using System.ComponentModel;


namespace CipherSink;

public partial class AccountStats : Form
{
    private CipherSinkContext dbContext;

    private LocalPlayer SelectedPlayer
    {
        get => (LocalPlayer)comboBoxSelectPlayer.SelectedItem;
        set => comboBoxSelectPlayer.SelectedItem = value;
    }

    public AccountStats()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        this.dbContext = new CipherSinkContext();

        this.dbContext.Database.EnsureCreated();

        LoadComboBoxData();
        LoadStats();
    }

    private void LoadComboBoxData()
    {
        // Clear the change tracker to ensure we get fresh data from the database
        dbContext.ChangeTracker.Clear();

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
    }

    private void LoadStats()
    {
        // populate the stats TextBoxes
        if (SelectedPlayer != null)
        {
            WinsTbx.Text = SelectedPlayer.TotalWins.ToString();
            LossesTbx.Text = SelectedPlayer.TotalLosses.ToString();
            HitsTbx.Text = SelectedPlayer.TotalHits.ToString();
            MissesTbx.Text = SelectedPlayer.TotalMisses.ToString();
            TotalSunkTbx.Text = SelectedPlayer.TotalSunkShips.ToString();
        }
        else
        {
            WinsTbx.Text = LossesTbx.Text = HitsTbx.Text = MissesTbx.Text = TotalSunkTbx.Text = string.Empty;
        }
    }

    // Adds to the LocalPlayer table in the database
    private void BtnCreatePlayer_Click(object sender, EventArgs e)
    {
        var createPlayerForm = new CreatePlayer();
        createPlayerForm.ShowDialog();
        LoadComboBoxData(); // Refresh the player list after creating a new user
        LoadStats(); // Refresh the player stats
    }

    private void BtnEditPlayer_Click(object sender, EventArgs e)
    {
        if (SelectedPlayer == null)
        {
            MessageBox.Show("No players to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var editPlayerForm = new EditPlayer(SelectedPlayer);
        editPlayerForm.ShowDialog();
        LoadComboBoxData(); // Refresh the player list after editing a user
        LoadStats();
    }

    private void DeleteDbBtn_Click(object sender, EventArgs e)
    {
        if (SelectedPlayer == null)
        {
            MessageBox.Show("No player selected for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var result =  MessageBox.Show($"Are you sure you want to delete {SelectedPlayer.Username}?\nThis action cannot be undone.", $"Delete User: {SelectedPlayer.Username}", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (result == DialogResult.Yes)
        {
            dbContext.LocalPlayers.Remove(SelectedPlayer); // Remove the selected player from the database
            dbContext.SaveChanges(); // Save changes to the database
        }

        LoadComboBoxData(); // Refresh the player list after deletion
        LoadStats(); // Refresh the stats after deletion
    }

    private void comboBoxSelectPlayer_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadStats();
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        base.OnClosing(e);

        this.dbContext?.Dispose();
        this.dbContext = null;
    }
}
