namespace CipherSink
{
    partial class AccountAndStats
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
            PlayerStatsGbx = new GroupBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            TotalSunkTbx = new TextBox();
            MissesTbx = new TextBox();
            HitsTbx = new TextBox();
            LossesTbx = new TextBox();
            WinsTbx = new TextBox();
            BtnCreatePlayer = new Button();
            BtnEditPlayer = new Button();
            BtnDeletePlayer = new Button();
            comboBoxSelectedPlayer = new ComboBox();
            LabelSelectPlayer = new Label();
            PlayerStatsGbx.SuspendLayout();
            SuspendLayout();
            // 
            // PlayerStatsGbx
            // 
            PlayerStatsGbx.BackColor = Color.Transparent;
            PlayerStatsGbx.Controls.Add(label8);
            PlayerStatsGbx.Controls.Add(label7);
            PlayerStatsGbx.Controls.Add(label6);
            PlayerStatsGbx.Controls.Add(label5);
            PlayerStatsGbx.Controls.Add(label4);
            PlayerStatsGbx.Controls.Add(TotalSunkTbx);
            PlayerStatsGbx.Controls.Add(MissesTbx);
            PlayerStatsGbx.Controls.Add(HitsTbx);
            PlayerStatsGbx.Controls.Add(LossesTbx);
            PlayerStatsGbx.Controls.Add(WinsTbx);
            PlayerStatsGbx.ForeColor = Color.FromArgb(128, 255, 255);
            PlayerStatsGbx.Location = new Point(12, 40);
            PlayerStatsGbx.Name = "PlayerStatsGbx";
            PlayerStatsGbx.Size = new Size(256, 191);
            PlayerStatsGbx.TabIndex = 7;
            PlayerStatsGbx.TabStop = false;
            PlayerStatsGbx.Text = "Player stats:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(93, 134);
            label8.Name = "label8";
            label8.Size = new Size(65, 15);
            label8.TabIndex = 9;
            label8.Text = "Total Sunk:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(167, 80);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 8;
            label7.Text = "Misses";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(32, 80);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 7;
            label6.Text = "Hits:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(167, 28);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 6;
            label5.Text = "Losses:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 28);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 5;
            label4.Text = "Wins:";
            // 
            // TotalSunkTbx
            // 
            TotalSunkTbx.Location = new Point(76, 152);
            TotalSunkTbx.Name = "TotalSunkTbx";
            TotalSunkTbx.ReadOnly = true;
            TotalSunkTbx.Size = new Size(100, 23);
            TotalSunkTbx.TabIndex = 4;
            TotalSunkTbx.TabStop = false;
            // 
            // MissesTbx
            // 
            MissesTbx.Location = new Point(167, 98);
            MissesTbx.Name = "MissesTbx";
            MissesTbx.ReadOnly = true;
            MissesTbx.Size = new Size(52, 23);
            MissesTbx.TabIndex = 3;
            MissesTbx.TabStop = false;
            // 
            // HitsTbx
            // 
            HitsTbx.Location = new Point(32, 98);
            HitsTbx.Name = "HitsTbx";
            HitsTbx.ReadOnly = true;
            HitsTbx.Size = new Size(52, 23);
            HitsTbx.TabIndex = 2;
            HitsTbx.TabStop = false;
            // 
            // LossesTbx
            // 
            LossesTbx.Location = new Point(167, 46);
            LossesTbx.Name = "LossesTbx";
            LossesTbx.ReadOnly = true;
            LossesTbx.Size = new Size(52, 23);
            LossesTbx.TabIndex = 1;
            LossesTbx.TabStop = false;
            // 
            // WinsTbx
            // 
            WinsTbx.Location = new Point(32, 46);
            WinsTbx.Name = "WinsTbx";
            WinsTbx.ReadOnly = true;
            WinsTbx.Size = new Size(52, 23);
            WinsTbx.TabIndex = 0;
            WinsTbx.TabStop = false;
            // 
            // BtnCreatePlayer
            // 
            BtnCreatePlayer.Location = new Point(12, 240);
            BtnCreatePlayer.Name = "BtnCreatePlayer";
            BtnCreatePlayer.Size = new Size(89, 46);
            BtnCreatePlayer.TabIndex = 8;
            BtnCreatePlayer.Text = "Create Player";
            BtnCreatePlayer.UseVisualStyleBackColor = true;
            BtnCreatePlayer.Click += CreateDbBtn_Click;
            // 
            // BtnEditPlayer
            // 
            BtnEditPlayer.Location = new Point(107, 240);
            BtnEditPlayer.Name = "BtnEditPlayer";
            BtnEditPlayer.Size = new Size(72, 47);
            BtnEditPlayer.TabIndex = 9;
            BtnEditPlayer.Text = "Edit Player";
            BtnEditPlayer.UseVisualStyleBackColor = true;
            BtnEditPlayer.Click += UpdateDbBtn_Click;
            // 
            // BtnDeletePlayer
            // 
            BtnDeletePlayer.Location = new Point(185, 240);
            BtnDeletePlayer.Name = "BtnDeletePlayer";
            BtnDeletePlayer.Size = new Size(83, 47);
            BtnDeletePlayer.TabIndex = 20;
            BtnDeletePlayer.Text = "Delete Player";
            BtnDeletePlayer.UseVisualStyleBackColor = true;
            BtnDeletePlayer.Click += DeleteDbBtn_Click;
            // 
            // comboBoxSelectedPlayer
            // 
            comboBoxSelectedPlayer.FormattingEnabled = true;
            comboBoxSelectedPlayer.Location = new Point(102, 11);
            comboBoxSelectedPlayer.Name = "comboBoxSelectedPlayer";
            comboBoxSelectedPlayer.Size = new Size(166, 23);
            comboBoxSelectedPlayer.TabIndex = 21;
            // 
            // LabelSelectPlayer
            // 
            LabelSelectPlayer.AutoSize = true;
            LabelSelectPlayer.ForeColor = Color.White;
            LabelSelectPlayer.Location = new Point(20, 14);
            LabelSelectPlayer.Name = "LabelSelectPlayer";
            LabelSelectPlayer.Size = new Size(76, 15);
            LabelSelectPlayer.TabIndex = 22;
            LabelSelectPlayer.Text = "Select Player:";
            // 
            // AccountAndStats
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(280, 299);
            Controls.Add(LabelSelectPlayer);
            Controls.Add(comboBoxSelectedPlayer);
            Controls.Add(BtnDeletePlayer);
            Controls.Add(BtnEditPlayer);
            Controls.Add(BtnCreatePlayer);
            Controls.Add(PlayerStatsGbx);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AccountAndStats";
            Text = "Account Stats";
            PlayerStatsGbx.ResumeLayout(false);
            PlayerStatsGbx.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox PlayerStatsGbx;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox TotalSunkTbx;
        private TextBox MissesTbx;
        private TextBox HitsTbx;
        private TextBox LossesTbx;
        private TextBox WinsTbx;
        private Button BtnCreatePlayer;
        private Button BtnEditPlayer;
        private Button BtnDeletePlayer;
        private ComboBox comboBoxSelectedPlayer;
        private Label LabelSelectPlayer;
    }
}