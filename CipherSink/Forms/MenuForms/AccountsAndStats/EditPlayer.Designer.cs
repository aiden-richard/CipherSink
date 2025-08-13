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
            comboBoxSelectPlayer = new ComboBox();
            TxtBxPublicKey = new TextBox();
            LabelSelectPlayer = new Label();
            BtnUpdatePlayer = new Button();
            BtnIncrementWins = new Button();
            BtnIncrementLosses = new Button();
            LabelWins = new Label();
            LabelLosses = new Label();
            SuspendLayout();
            // 
            // LabelUsername
            // 
            LabelUsername.AutoSize = true;
            LabelUsername.ForeColor = Color.White;
            LabelUsername.Location = new Point(35, 76);
            LabelUsername.Name = "LabelUsername";
            LabelUsername.Size = new Size(63, 15);
            LabelUsername.TabIndex = 0;
            LabelUsername.Text = "Username:";
            // 
            // TxtBxUsername
            // 
            TxtBxUsername.Location = new Point(104, 73);
            TxtBxUsername.Name = "TxtBxUsername";
            TxtBxUsername.Size = new Size(253, 23);
            TxtBxUsername.TabIndex = 1;
            // 
            // LabelPublicKey
            // 
            LabelPublicKey.AutoSize = true;
            LabelPublicKey.ForeColor = Color.White;
            LabelPublicKey.Location = new Point(33, 119);
            LabelPublicKey.Name = "LabelPublicKey";
            LabelPublicKey.Size = new Size(65, 15);
            LabelPublicKey.TabIndex = 2;
            LabelPublicKey.Text = "Public Key:";
            // 
            // comboBoxSelectPlayer
            // 
            comboBoxSelectPlayer.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSelectPlayer.FormattingEnabled = true;
            comboBoxSelectPlayer.Location = new Point(104, 25);
            comboBoxSelectPlayer.Name = "comboBoxSelectPlayer";
            comboBoxSelectPlayer.Size = new Size(253, 23);
            comboBoxSelectPlayer.TabIndex = 3;
            comboBoxSelectPlayer.TabStop = false;
            comboBoxSelectPlayer.SelectedIndexChanged += comboBoxSelectPlayer_SelectedIndexChanged;
            // 
            // TxtBxPublicKey
            // 
            TxtBxPublicKey.Location = new Point(104, 116);
            TxtBxPublicKey.Multiline = true;
            TxtBxPublicKey.Name = "TxtBxPublicKey";
            TxtBxPublicKey.ReadOnly = true;
            TxtBxPublicKey.Size = new Size(471, 114);
            TxtBxPublicKey.TabIndex = 4;
            TxtBxPublicKey.TabStop = false;
            // 
            // LabelSelectPlayer
            // 
            LabelSelectPlayer.AutoSize = true;
            LabelSelectPlayer.ForeColor = Color.White;
            LabelSelectPlayer.Location = new Point(22, 28);
            LabelSelectPlayer.Name = "LabelSelectPlayer";
            LabelSelectPlayer.Size = new Size(76, 15);
            LabelSelectPlayer.TabIndex = 5;
            LabelSelectPlayer.Text = "Select Player:";
            // 
            // BtnUpdatePlayer
            // 
            BtnUpdatePlayer.Location = new Point(460, 332);
            BtnUpdatePlayer.Name = "BtnUpdatePlayer";
            BtnUpdatePlayer.Size = new Size(115, 47);
            BtnUpdatePlayer.TabIndex = 6;
            BtnUpdatePlayer.Text = "Update Player Info";
            BtnUpdatePlayer.UseVisualStyleBackColor = true;
            BtnUpdatePlayer.Click += BtnUpdatePlayer_Click;
            // 
            // BtnIncrementWins
            // 
            BtnIncrementWins.Location = new Point(104, 273);
            BtnIncrementWins.Name = "BtnIncrementWins";
            BtnIncrementWins.Size = new Size(107, 34);
            BtnIncrementWins.TabIndex = 7;
            BtnIncrementWins.Text = "Increment Wins";
            BtnIncrementWins.UseVisualStyleBackColor = true;
            BtnIncrementWins.Click += BtnIncrementWins_Click;
            // 
            // BtnIncrementLosses
            // 
            BtnIncrementLosses.Location = new Point(215, 273);
            BtnIncrementLosses.Name = "BtnIncrementLosses";
            BtnIncrementLosses.Size = new Size(107, 34);
            BtnIncrementLosses.TabIndex = 8;
            BtnIncrementLosses.Text = "Increment Losses";
            BtnIncrementLosses.UseVisualStyleBackColor = true;
            BtnIncrementLosses.Click += BtnIncrementLosses_Click;
            // 
            // LabelWins
            // 
            LabelWins.AutoSize = true;
            LabelWins.ForeColor = Color.White;
            LabelWins.Location = new Point(104, 243);
            LabelWins.Name = "LabelWins";
            LabelWins.Size = new Size(36, 15);
            LabelWins.TabIndex = 9;
            LabelWins.Text = "Wins:";
            // 
            // LabelLosses
            // 
            LabelLosses.AutoSize = true;
            LabelLosses.ForeColor = Color.White;
            LabelLosses.Location = new Point(173, 243);
            LabelLosses.Name = "LabelLosses";
            LabelLosses.Size = new Size(44, 15);
            LabelLosses.TabIndex = 10;
            LabelLosses.Text = "Losses:";
            // 
            // EditPlayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(587, 391);
            Controls.Add(LabelLosses);
            Controls.Add(LabelWins);
            Controls.Add(BtnIncrementLosses);
            Controls.Add(BtnIncrementWins);
            Controls.Add(BtnUpdatePlayer);
            Controls.Add(LabelSelectPlayer);
            Controls.Add(TxtBxPublicKey);
            Controls.Add(comboBoxSelectPlayer);
            Controls.Add(LabelPublicKey);
            Controls.Add(TxtBxUsername);
            Controls.Add(LabelUsername);
            FormBorderStyle = FormBorderStyle.FixedDialog;
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
        private ComboBox comboBoxSelectPlayer;
        private TextBox TxtBxPublicKey;
        private Label LabelSelectPlayer;
        private Button BtnUpdatePlayer;
        private Button BtnIncrementWins;
        private Button BtnIncrementLosses;
        private Label LabelWins;
        private Label LabelLosses;
    }
}