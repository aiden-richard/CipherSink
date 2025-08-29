using CipherSink.Models.Database;
using CipherSink.Models.Database.Entities;
using CipherSink.Models.Validation;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace CipherSink.Forms.MenuForms.AccountsAndStats;
public partial class EditPlayer : Form
{
    private CipherSinkContext dbContext;

    private LocalPlayer SelectedPlayer { get; set; }

    public EditPlayer(LocalPlayer player)
    {
        InitializeComponent();

        SelectedPlayer = player;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        string? password = PromptForPassword(this, $"Enter password for {SelectedPlayer.Username}:");
        if (!Validator.IsValidPassword(password) || !SelectedPlayer.LoadPrivatekey(password))
        {
            MessageBox.Show("Invalid password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }

        this.dbContext = new CipherSinkContext();

        this.dbContext.Database.EnsureCreated();

        SelectedPlayer = dbContext.LocalPlayers.Find(SelectedPlayer.Id);
        if (SelectedPlayer == null)
        {
            MessageBox.Show("Player not found in database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
            return;
        }

        LoadPlayerData();
    }

    private void LoadPlayerData()
    {
        TxtBxUsername.Text = SelectedPlayer.Username;

        string pemKey = SelectedPlayer.RsaObject.ExportRSAPublicKeyPem();
        TxtBxPublicKey.Text = pemKey;
    }


    private void BtnImportKey_Click(object sender, EventArgs e)
    {
        if (SelectedPlayer is null)
        {
            MessageBox.Show("Select a player first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        using var openFileDialog = new OpenFileDialog
        {
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            Filter = "PEM / Key Files (*.pem;*.key;*.txt)|*.pem;*.key;*.txt|All files (*.*)|*.*",
            FilterIndex = 1,
            RestoreDirectory = true
        };

        if (openFileDialog.ShowDialog() != DialogResult.OK)
            return;

        string filePath = openFileDialog.FileName;
        string pem;
        try
        {
            pem = File.ReadAllText(filePath, Encoding.UTF8);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to read file.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            if (!TryImportKeyMaterial(pem, out RSA? importedRsa))
            {
                MessageBox.Show("File did not contain a recognizable RSA key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (importedRsa.KeySize < 2048)
            {
                MessageBox.Show("RSA key is too small. Minimum 2048 bits required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                importedRsa.Dispose();
                return;
            }

            // Update player RSA object
            SelectedPlayer.RsaObject?.Dispose();
            SelectedPlayer.RsaObject = importedRsa;

            // Update public key bytes
            SelectedPlayer.PublicKeyBytes = importedRsa.ExportRSAPublicKey();

            string? password = PromptForPassword(this, $"Enter password to encrypt key\n(this will become user's new password):");
            // Encrypt and store private key
            SelectedPlayer.EncryptedPrivateKeyBytes = SelectedPlayer.RsaObject.ExportEncryptedPkcs8PrivateKey(
                password.ToCharArray(),
                new PbeParameters(
                    PbeEncryptionAlgorithm.Aes256Cbc,
                    HashAlgorithmName.SHA256, 600000)
            );

            LoadPlayerData();

            MessageBox.Show($"Key pair imported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (CryptographicException cex)
        {
            MessageBox.Show("Cryptographic error importing key.\n\n" + cex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Unexpected error importing key.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static bool TryImportKeyMaterial(string pem, out RSA? rsa)
    {
        rsa = null;

        // Normalize line endings
        pem = pem.Replace("\r\n", "\n").Trim();

        // Decide path based on markers
        bool containsEncryptedPrivate = pem.Contains("BEGIN ENCRYPTED PRIVATE KEY", StringComparison.OrdinalIgnoreCase);
        bool containsPrivate = pem.Contains("BEGIN RSA PRIVATE KEY", StringComparison.OrdinalIgnoreCase) ||
                               pem.Contains("BEGIN PRIVATE KEY", StringComparison.OrdinalIgnoreCase) ||
                               containsEncryptedPrivate;
        bool containsPublic = pem.Contains("BEGIN RSA PUBLIC KEY", StringComparison.OrdinalIgnoreCase);

        // Must contain at least a public key and one private key type
        if (!containsPrivate || !containsPublic)
            return false;

        rsa = RSA.Create();

        if (containsEncryptedPrivate)
        {
            string? password = PromptForPassword(null, "This file contains an ENCRYPTED PRIVATE KEY.\nEnter passphrase (leave blank to cancel):");
            if (string.IsNullOrEmpty(password))
            {
                rsa.Dispose();
                rsa = null;
                return false;
            }
            rsa.ImportFromEncryptedPem(pem, password);
        }
        else
        {
            rsa.ImportFromPem(pem);
        }

        // Validation
        _ = rsa.ExportRSAPublicKey(); // Throws if invalid.
        _ = rsa.ExportPkcs8PrivateKey(); // Throws if invalid.

        return true;
    }

    private void BtnExportKeys_Click(object sender, EventArgs e)
    {
        if (SelectedPlayer is null)
        {
            MessageBox.Show("Select a player first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        try
        {
            // Build PEM sections
            string publicPem = SelectedPlayer.RsaObject?.ExportRSAPublicKeyPem() ?? BuildPublicKeyPem(SelectedPlayer.PublicKeyBytes);
            byte[] encryptedPrivate = SelectedPlayer.EncryptedPrivateKeyBytes;
            if (encryptedPrivate is null || encryptedPrivate.Length == 0)
            {
                MessageBox.Show("Player has no encrypted private key to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string encryptedPrivatePem = BuildEncryptedPrivateKeyPem(encryptedPrivate);

            string combined = publicPem.TrimEnd() + Environment.NewLine + Environment.NewLine + encryptedPrivatePem + Environment.NewLine;

            using var saveDialog = new SaveFileDialog
            {
                Title = "Export Key Pair",
                FileName = $"{SelectedPlayer.Username}_keys.pem",
                Filter = "PEM Files (*.pem)|*.pem|All Files (*.*)|*.*",
                FilterIndex = 1,
                OverwritePrompt = true
            };

            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;

            File.WriteAllText(saveDialog.FileName, combined, Encoding.UTF8);
            MessageBox.Show("Keys exported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Failed to export keys.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static string BuildPublicKeyPem(byte[] publicKeyBytes)
        {
            string b64 = Convert.ToBase64String(publicKeyBytes, Base64FormattingOptions.InsertLineBreaks);
            return $"-----BEGIN PUBLIC KEY-----{Environment.NewLine}{b64}{Environment.NewLine}-----END PUBLIC KEY-----";
        }

        static string BuildEncryptedPrivateKeyPem(byte[] encryptedBytes)
        {
            string b64 = Convert.ToBase64String(encryptedBytes, Base64FormattingOptions.InsertLineBreaks);
            return $"-----BEGIN ENCRYPTED PRIVATE KEY-----{Environment.NewLine}{b64}{Environment.NewLine}-----END ENCRYPTED PRIVATE KEY-----";
        }
    }

    // Simple password prompt (modal). Returns null if user cancels or leaves blank.
    private static string? PromptForPassword(IWin32Window? owner, string prompt)
    {
        using var form = new Form
        {
            Width = 420,
            Height = 210,
            Text = "Password",
            FormBorderStyle = FormBorderStyle.FixedDialog,
            StartPosition = FormStartPosition.CenterParent,
            MinimizeBox = false,
            MaximizeBox = false
        };

        var lbl = new Label { Left = 12, Top = 12, Width = 380, Height = 50, Text = prompt };
        var txt = new TextBox { Left = 15, Top = 80, Width = 370, UseSystemPasswordChar = true };
        var ok = new Button { Text = "OK", Left = 220, Width = 75, Top = 115, Height = 35, DialogResult = DialogResult.OK };
        var cancel = new Button { Text = "Cancel", Left = 310, Width = 75, Top = 115, Height = 35, DialogResult = DialogResult.Cancel };

        form.Controls.AddRange(new Control[] { lbl, txt, ok, cancel });
        form.AcceptButton = ok;
        form.CancelButton = cancel;

        var dr = owner is null ? form.ShowDialog() : form.ShowDialog(owner);
        if (dr == DialogResult.OK && !string.IsNullOrWhiteSpace(txt.Text))
            return txt.Text;
        return null;
    }

    private void BtnUpdatePlayer_Click(object sender, EventArgs e)
    {

        if (ValidInputs())
        {
            if (SelectedPlayer.Username != TxtBxUsername.Text)
            {
                SelectedPlayer.Username = TxtBxUsername.Text;
            }

            dbContext.SaveChanges();

            MessageBox.Show("Player info updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
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

        return true;
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        base.OnClosing(e);

        this.dbContext?.Dispose();
        this.dbContext = null;
    }
}
