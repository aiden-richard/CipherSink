using CipherSink.Models.Database;
using CipherSink.Models.Database.Entities;
using CipherSink.Models.Validation;
using System.ComponentModel;

namespace CipherSink.Forms.MenuForms.AccountsAndStats;

public partial class CreatePlayer : Form
{
    private CipherSinkContext dbContext;

    public CreatePlayer()
    {
        InitializeComponent();
        this.AcceptButton = BtnCreatePlayer;
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
            LocalPlayer user = new(TxtBxUsername.Text, TxtBxPassword.Text);

            dbContext.LocalPlayers.Add(user);
            dbContext.SaveChanges();

            MessageBox.Show("User created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close(); // Close the form after creating the user
        }
    }

    private bool ValidInputs()
    {
        if (!Validator.IsValidUsername(TxtBxUsername.Text))
        {
            MessageBox.Show("Invalid username. It must be alphanumeric and between 1 and 32 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (!Validator.IsValidPassword(TxtBxPassword.Text))
        {
            MessageBox.Show("Invalid password. It must be alphanumeric and between 4 and 32 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
