namespace CipherSink.Forms.MenuForms.AccountsAndStats
{
    partial class EditPlayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LabelUsername = new Label();
            TxtBxUsername = new TextBox();
            LabelPublicKey = new Label();
            TxtBxPublicKey = new TextBox();
            BtnUpdatePlayer = new Button();
            BtnImportKey = new Button();
            BtnExportKeys = new Button();
            SuspendLayout();
            // 
            // LabelUsername
            // 
            LabelUsername.AutoSize = true;
            LabelUsername.ForeColor = Color.White;
            LabelUsername.Location = new Point(50, 40);
            LabelUsername.Margin = new Padding(4, 0, 4, 0);
            LabelUsername.Name = "LabelUsername";
            LabelUsername.Size = new Size(95, 25);
            LabelUsername.TabIndex = 0;
            LabelUsername.Text = "Username:";
            // 
            // TxtBxUsername
            // 
            TxtBxUsername.Location = new Point(149, 35);
            TxtBxUsername.Margin = new Padding(4, 5, 4, 5);
            TxtBxUsername.Name = "TxtBxUsername";
            TxtBxUsername.Size = new Size(360, 31);
            TxtBxUsername.TabIndex = 1;
            // 
            // LabelPublicKey
            // 
            LabelPublicKey.AutoSize = true;
            LabelPublicKey.ForeColor = Color.White;
            LabelPublicKey.Location = new Point(47, 104);
            LabelPublicKey.Margin = new Padding(4, 0, 4, 0);
            LabelPublicKey.Name = "LabelPublicKey";
            LabelPublicKey.Size = new Size(96, 25);
            LabelPublicKey.TabIndex = 2;
            LabelPublicKey.Text = "Public Key:";
            // 
            // TxtBxPublicKey
            // 
            TxtBxPublicKey.Location = new Point(149, 99);
            TxtBxPublicKey.Margin = new Padding(4, 5, 4, 5);
            TxtBxPublicKey.Multiline = true;
            TxtBxPublicKey.Name = "TxtBxPublicKey";
            TxtBxPublicKey.ReadOnly = true;
            TxtBxPublicKey.Size = new Size(671, 187);
            TxtBxPublicKey.TabIndex = 4;
            TxtBxPublicKey.TabStop = false;
            // 
            // BtnUpdatePlayer
            // 
            BtnUpdatePlayer.Location = new Point(656, 380);
            BtnUpdatePlayer.Margin = new Padding(4, 5, 4, 5);
            BtnUpdatePlayer.Name = "BtnUpdatePlayer";
            BtnUpdatePlayer.Size = new Size(164, 78);
            BtnUpdatePlayer.TabIndex = 6;
            BtnUpdatePlayer.Text = "Update Player Info";
            BtnUpdatePlayer.UseVisualStyleBackColor = true;
            BtnUpdatePlayer.Click += BtnUpdatePlayer_Click;
            // 
            // BtnImportKey
            // 
            BtnImportKey.Location = new Point(149, 294);
            BtnImportKey.Name = "BtnImportKey";
            BtnImportKey.Size = new Size(166, 60);
            BtnImportKey.TabIndex = 11;
            BtnImportKey.Text = "Import New Keys";
            BtnImportKey.UseVisualStyleBackColor = true;
            BtnImportKey.Click += BtnImportKey_Click;
            // 
            // BtnExportKeys
            // 
            BtnExportKeys.Location = new Point(321, 294);
            BtnExportKeys.Name = "BtnExportKeys";
            BtnExportKeys.Size = new Size(166, 60);
            BtnExportKeys.TabIndex = 12;
            BtnExportKeys.Text = "Export Keys";
            BtnExportKeys.UseVisualStyleBackColor = true;
            BtnExportKeys.Click += BtnExportKeys_Click;
            // 
            // EditPlayer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(839, 471);
            Controls.Add(BtnExportKeys);
            Controls.Add(BtnImportKey);
            Controls.Add(BtnUpdatePlayer);
            Controls.Add(TxtBxPublicKey);
            Controls.Add(LabelPublicKey);
            Controls.Add(TxtBxUsername);
            Controls.Add(LabelUsername);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "EditPlayer";
            Text = "Edit Player";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelUsername;
        private TextBox TxtBxUsername;
        private Label LabelPublicKey;
        private TextBox textBox1;
        private Label Label;
        private TextBox TxtBxPublicKey;
        private Button BtnUpdatePlayer;
        private Button BtnImportKey;
        private Button BtnExportKeys;
    }
}