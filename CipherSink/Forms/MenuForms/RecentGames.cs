using CipherSink.Models;
using CipherSink.Models.Database;
using CipherSink.Models.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Security.Cryptography;

namespace CipherSink;

public partial class RecentGames : Form
{
    private CipherSinkContext dbContext;

    public RecentGames()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        this.dbContext = new CipherSinkContext();

        // comment the line below to not start fresh with a new database.
        this.dbContext.Database.EnsureDeleted();
        this.dbContext.Database.EnsureCreated();

        LoadRemotePlayers();
    }

    private void LoadRemotePlayers()
    {
        RecentPlayersLV.Items.Clear();
        var players = dbContext.RemotePlayers.ToList();
        RecentPlayersLV.View = View.Details;
        if (RecentPlayersLV.Columns.Count == 0)
        {
            RecentPlayersLV.Columns.Add("Id", 40);
            RecentPlayersLV.Columns.Add("Username", 100);
            RecentPlayersLV.Columns.Add("Public Key", 150);
            RecentPlayersLV.Columns.Add("Is Friend", 60);
        }
        foreach (var player in players)
        {
            var item = new ListViewItem(new[]
            {
                player.Id.ToString(),
                player.Username,
                Convert.ToBase64String(player.PublicKeyBytes),
                player.IsFriend.ToString()
            });
            RecentPlayersLV.Items.Add(item);
        }
    }

    // Adds to the RemotePlayers table in the database
    private void CreateDbBtn_Click(object sender, EventArgs e)
    {
        RSA rsa = RSA.Create();
        var player = new RemotePlayer
        {
            Username = RUsernameTestTbx.Text,
            PublicKeyBytes = rsa.ExportRSAPublicKey(),
            IsFriend = bool.TryParse(IsFriendTestTbx.Text, out var isFriend) ? isFriend : false
        };
        dbContext.RemotePlayers.Add(player);
        dbContext.SaveChanges();
        LoadRemotePlayers();
    }

    private void UpdateDbBtn_Click(object sender, EventArgs e)
    {
        if (RecentPlayersLV.SelectedItems.Count == 0)
        {
            MessageBox.Show("Please select a player to update.");
            return;
        }
        var selectedItem = RecentPlayersLV.SelectedItems[0];
        if (!int.TryParse(selectedItem.SubItems[0].Text, out int playerId))
        {
            MessageBox.Show("Invalid player ID.");
            return;
        }
        var player = dbContext.RemotePlayers.Find(playerId);
        if (player != null)
        {
            player.Username = RUsernameTestTbx.Text;
            player.IsFriend = bool.TryParse(IsFriendTestTbx.Text, out var isFriend) ? isFriend : false;
            dbContext.SaveChanges();
        }
        LoadRemotePlayers();
    }

    private void DeleteDbBtn_Click(object sender, EventArgs e)
    {
        if (RecentPlayersLV.SelectedItems.Count == 0)
        {
            MessageBox.Show("Please select a player to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        var selectedItem = RecentPlayersLV.SelectedItems[0];
        if (!int.TryParse(selectedItem.SubItems[0].Text, out int playerId))
        {
            MessageBox.Show("Invalid player ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        var player = dbContext.RemotePlayers.FirstOrDefault(p => p.Id == playerId);
        if (player != null)
        {
            dbContext.RemotePlayers.Remove(player);
            dbContext.SaveChanges();
        }
        LoadRemotePlayers();
    }

    private void LoadDbBtn_Click(object sender, EventArgs e)
    {
        LoadRemotePlayers();
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        base.OnClosing(e);

        this.dbContext?.Dispose();
        this.dbContext = null;
    }
}
