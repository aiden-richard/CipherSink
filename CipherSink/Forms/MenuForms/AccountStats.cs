using CipherSink.Models.Database;
using System.Security.Cryptography;
using CipherSink.Models.Database.Entities;


namespace CipherSink;

public partial class AccountStats : Form
{
    public AccountStats()
    {
        InitializeComponent();
    }

    // Adds to the LocalUser table in the database

    private void CreateDbBtn_Click(object sender, EventArgs e)
    {
        RSA rsa = RSA.Create();
        using var db = new CipherSinkContext();
        var user = new LocalPlayer
        {
            Username = UsernameTestTbx.Text,
            EncryptedPrivateKeyBytes = rsa.ExportRSAPrivateKey(),
            PublicKeyBytes = rsa.ExportRSAPublicKey()
        };
        db.LocalPlayers.Add(user);
        db.SaveChanges();
        LoadLocalUserStats();
    }

    private void UpdateDbBtn_Click(object sender, EventArgs e)
    {
        using var db = new CipherSinkContext();
        var user = db.LocalPlayers.FirstOrDefault();
        if (user != null)
        {
            user.Username = UsernameTestTbx.Text;
            user.IncrementWins();
            user.IncrementLosses();
            user.AddHits(int.TryParse(HitsTestTbx.Text, out var hits) ? hits : 0);
            user.AddMisses(int.TryParse(MissesTestTbx.Text, out var misses) ? misses : 0);
            user.AddSunkShips(int.TryParse(SunkShipsTestTbx.Text, out var sunkShips) ? sunkShips : 0);
            db.SaveChanges();
        }
        LoadLocalUserStats();
    }

    private void DeleteDbBtn_Click(object sender, EventArgs e)
    {
        using var db = new CipherSinkContext();
        var user = db.LocalPlayers.FirstOrDefault();
        if (user != null)
        {
            db.LocalPlayers.Remove(user);
            db.SaveChanges();
        }
        LoadLocalUserStats();
    }

    private void LoadDbBtn_Click(object sender, EventArgs e)
    {
        LoadLocalUserStats();
    }

    private void LoadLocalUserStats()
    {
        using var db = new CipherSinkContext();
        var user = db.LocalPlayers.FirstOrDefault(); // For demo, just load the first user
        if (user != null)
        {
            WinsTbx.Text = user.Wins.ToString();
            LossesTbx.Text = user.Losses.ToString();
            HitsTbx.Text = user.Hits.ToString();
            MissesTbx.Text = user.Misses.ToString();
            TotalSunkTbx.Text = user.SunkShips.ToString();
        }
        else
        {
            WinsTbx.Text = LossesTbx.Text = HitsTbx.Text = MissesTbx.Text = TotalSunkTbx.Text = string.Empty;
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        LoadLocalUserStats();
    }
}
