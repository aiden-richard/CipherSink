using CipherSink.Forms.GameForms;
using CipherSink.Models.Database;
using CipherSink.Models.Database.Entities;
using CipherSink.Models.GameLogic;
using CipherSink.Models.Networking;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace CipherSink.Forms.MenuForms.AccountsAndStats;

public partial class CreatePlayer : Form
{
    private CipherSinkContext dbContext;

    public CreatePlayer()
    {
        this.AcceptButton = BtnCreatePlayer;
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        this.dbContext = new CipherSinkContext();

        // uncomment the line below to start fresh with a new database.
        // this.dbContext.Database.EnsureDeleted();
        this.dbContext.Database.EnsureCreated();
    }

    private void BtnCreatePlayer_Click(object sender, EventArgs e)
    {
        if (ValidInputs())
        {
            var user = new LocalPlayer
            {
                Username = TxtBxUsername.Text
            };
            dbContext.LocalPlayers.Add(user);
            dbContext.SaveChanges();

            MessageBox.Show("User created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            MessageBox.Show("Username must be between 4 and 32 characters.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
}
