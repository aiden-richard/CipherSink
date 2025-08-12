using CipherSink.Models;

namespace CipherSink;

public partial class RecentPlayers : Form
{
    public RecentPlayers()
    {
        InitializeComponent();
    }

    // Adds to the RemotePlayers table in the database

    private void CreateDbBtn_Click(object sender, EventArgs e)
    {
        using var db = new CipherSinkContext();
        var player = new RemotePlayer
        {
            Username = RUsernameTestTbx.Text,
            PublicKey = RPublicKeyTestTbx.Text,
            IsFriend = bool.TryParse(IsFriendTestTbx.Text, out var isFriend) ? isFriend : false
        };
        db.RemotePlayers.Add(player);
        db.SaveChanges();
        LoadRemotePlayers();
    }

    private void UpdateDbBtn_Click(object sender, EventArgs e)
    {
        using var db1 = new CipherSinkContext();
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
        using var db2 = new CipherSinkContext();
        var player = db2.RemotePlayers.Find(playerId);
        if (player != null)
        {
            player.Username = RUsernameTestTbx.Text;
            player.PublicKey = RPublicKeyTestTbx.Text;
            player.IsFriend = bool.TryParse(IsFriendTestTbx.Text, out var isFriend) ? isFriend : false;
            db2.SaveChanges();
        }
        LoadRemotePlayers();
    }

    private void DeleteDbBtn_Click(object sender, EventArgs e)
    {
        using var db3 = new CipherSinkContext();
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
        using var db4 = new CipherSinkContext();
        var player = db4.RemotePlayers.FirstOrDefault(p => p.Id == playerId);
        if (player != null)
        {
            db4.RemotePlayers.Remove(player);
            db4.SaveChanges();
        }
        LoadRemotePlayers();
    }

    private void LoadDbBtn_Click(object sender, EventArgs e)
    {
        LoadRemotePlayers();
    }

    private void LoadRemotePlayers()
    {
        RecentPlayersLV.Items.Clear();
        using var db = new CipherSinkContext();
        var players = db.RemotePlayers.ToList();
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
                player.PublicKey,
                player.IsFriend.ToString()
            });
            RecentPlayersLV.Items.Add(item);
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        LoadRemotePlayers();
    }
}
