using CipherSink.Models;


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
        using var db = new CipherSinkContext();
        var user = new LocalUser
        {
            Username = UsernameTestTbx.Text,
            EncryptedPrivateKey = PrivateKeyTbx.Text,
            PublicKey = PublicKeyTbx.Text,
            Wins = int.TryParse(WinsTestTbx.Text, out var w) ? w : 0,
            Losses = int.TryParse(LossesTestTbx.Text, out var l) ? l : 0,
            Hits = int.TryParse(HitsTestTbx.Text, out var h) ? h : 0,
            Misses = int.TryParse(MissesTestTbx.Text, out var m) ? m : 0,
            SunkShips = int.TryParse(SunkShipsTestTbx.Text, out var s) ? s : 0
        };
        db.LocalUsers.Add(user);
        db.SaveChanges();
        LoadLocalUserStats();
    }

    private void UpdateDbBtn_Click(object sender, EventArgs e)
    {
        using var db = new CipherSinkContext();
        var user = db.LocalUsers.FirstOrDefault();
        if (user != null)
        {
            user.Username = UsernameTestTbx.Text;
            user.EncryptedPrivateKey = PrivateKeyTbx.Text;
            user.PublicKey = PublicKeyTbx.Text;
            user.Wins = int.TryParse(WinsTestTbx.Text, out var w) ? w : 0;
            user.Losses = int.TryParse(LossesTestTbx.Text, out var l) ? l : 0;
            user.Hits = int.TryParse(HitsTestTbx.Text, out var h) ? h : 0;
            user.Misses = int.TryParse(MissesTestTbx.Text, out var m) ? m : 0;
            user.SunkShips = int.TryParse(SunkShipsTestTbx.Text, out var s) ? s : 0;
            db.SaveChanges();
        }
        LoadLocalUserStats();
    }

    private void DeleteDbBtn_Click(object sender, EventArgs e)
    {
        using var db = new CipherSinkContext();
        var user = db.LocalUsers.FirstOrDefault();
        if (user != null)
        {
            db.LocalUsers.Remove(user);
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
        var user = db.LocalUsers.FirstOrDefault(); // For demo, just load the first user
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
