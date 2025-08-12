using CipherSink.Forms.MenuForms.AccountsAndStats;
using CipherSink.Models.Database;
using CipherSink.Models.Database.Entities;
using System.ComponentModel;
using System.Security.Cryptography;


namespace CipherSink;

public partial class AccountAndStats : Form
{
    private CipherSinkContext dbContext;

    public AccountAndStats()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        this.dbContext = new CipherSinkContext();

        // uncomment the line below to start fresh with a new database.
        // this.dbContext.Database.EnsureDeleted();
        this.dbContext.Database.EnsureCreated();

        LoadLocalPlayerStats();
    }

    private void LoadLocalPlayerStats()
    {
        // populate the Players ComboBox
        var players = dbContext.LocalPlayers.ToList();
        if (players.Count > 0)
        {
            comboBoxSelectedPlayer.DataSource = players;
            comboBoxSelectedPlayer.DisplayMember = "Username";
            comboBoxSelectedPlayer.ValueMember = "Id";
        }
        else
        {
            comboBoxSelectedPlayer.DataSource = null; // No players available
        }

        // populate the stats TextBoxes
        var player = (LocalPlayer)comboBoxSelectedPlayer.SelectedItem;
        if (player != null)
        {
            WinsTbx.Text = player.Wins.ToString();
            LossesTbx.Text = player.Losses.ToString();
            HitsTbx.Text = player.Hits.ToString();
            MissesTbx.Text = player.Misses.ToString();
            TotalSunkTbx.Text = player.SunkShips.ToString();
        }
        else
        {
            WinsTbx.Text = LossesTbx.Text = HitsTbx.Text = MissesTbx.Text = TotalSunkTbx.Text = string.Empty;
        }
    }

    // Adds to the LocalUser table in the database
    private void CreateDbBtn_Click(object sender, EventArgs e)
    {
        var createUserForm = new CreatePlayer();
        createUserForm.ShowDialog();
        LoadLocalPlayerStats(); // Refresh the player list after creating a new user
    }

    private void UpdateDbBtn_Click(object sender, EventArgs e)
    {
        return;
    }

    private void DeleteDbBtn_Click(object sender, EventArgs e)
    {
        return;
    }

    private void LoadDbBtn_Click(object sender, EventArgs e)
    {
        LoadLocalPlayerStats();
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        base.OnClosing(e);

        this.dbContext?.Dispose();
        this.dbContext = null;
    }
}
