namespace CipherSink
{
    partial class AccountStats
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
            UserStatsGbx = new GroupBox();
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
            CreateDbBtn = new Button();
            UpdateDbBtn = new Button();
            UsernameTestTbx = new TextBox();
            PrivateKeyTbx = new TextBox();
            PublicKeyTbx = new TextBox();
            WinsTestTbx = new TextBox();
            LossesTestTbx = new TextBox();
            HitsTestTbx = new TextBox();
            MissesTestTbx = new TextBox();
            label1 = new Label();
            SunkShipsTestTbx = new TextBox();
            DeleteDbBtn = new Button();
            LoadDbBtn = new Button();
            UserStatsGbx.SuspendLayout();
            SuspendLayout();
            // 
            // UserStatsGbx
            // 
            UserStatsGbx.BackColor = Color.Transparent;
            UserStatsGbx.Controls.Add(LoadDbBtn);
            UserStatsGbx.Controls.Add(label8);
            UserStatsGbx.Controls.Add(label7);
            UserStatsGbx.Controls.Add(label6);
            UserStatsGbx.Controls.Add(label5);
            UserStatsGbx.Controls.Add(label4);
            UserStatsGbx.Controls.Add(TotalSunkTbx);
            UserStatsGbx.Controls.Add(MissesTbx);
            UserStatsGbx.Controls.Add(HitsTbx);
            UserStatsGbx.Controls.Add(LossesTbx);
            UserStatsGbx.Controls.Add(WinsTbx);
            UserStatsGbx.ForeColor = Color.FromArgb(128, 255, 255);
            UserStatsGbx.Location = new Point(12, 283);
            UserStatsGbx.Name = "UserStatsGbx";
            UserStatsGbx.Size = new Size(256, 208);
            UserStatsGbx.TabIndex = 7;
            UserStatsGbx.TabStop = false;
            UserStatsGbx.Text = "Current user's stats:";
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
            // CreateDbBtn
            // 
            CreateDbBtn.Location = new Point(12, 254);
            CreateDbBtn.Name = "CreateDbBtn";
            CreateDbBtn.Size = new Size(75, 23);
            CreateDbBtn.TabIndex = 8;
            CreateDbBtn.Text = "Create";
            CreateDbBtn.UseVisualStyleBackColor = true;
            CreateDbBtn.Click += CreateDbBtn_Click;
            // 
            // UpdateDbBtn
            // 
            UpdateDbBtn.Location = new Point(105, 254);
            UpdateDbBtn.Name = "UpdateDbBtn";
            UpdateDbBtn.Size = new Size(75, 23);
            UpdateDbBtn.TabIndex = 9;
            UpdateDbBtn.Text = "Update";
            UpdateDbBtn.UseVisualStyleBackColor = true;
            UpdateDbBtn.Click += UpdateDbBtn_Click;
            // 
            // UsernameTestTbx
            // 
            UsernameTestTbx.Location = new Point(12, 44);
            UsernameTestTbx.Name = "UsernameTestTbx";
            UsernameTestTbx.Size = new Size(256, 23);
            UsernameTestTbx.TabIndex = 10;
            // 
            // PrivateKeyTbx
            // 
            PrivateKeyTbx.Location = new Point(12, 87);
            PrivateKeyTbx.Name = "PrivateKeyTbx";
            PrivateKeyTbx.Size = new Size(100, 23);
            PrivateKeyTbx.TabIndex = 11;
            // 
            // PublicKeyTbx
            // 
            PublicKeyTbx.Location = new Point(168, 87);
            PublicKeyTbx.Name = "PublicKeyTbx";
            PublicKeyTbx.Size = new Size(100, 23);
            PublicKeyTbx.TabIndex = 12;
            // 
            // WinsTestTbx
            // 
            WinsTestTbx.Location = new Point(12, 128);
            WinsTestTbx.Name = "WinsTestTbx";
            WinsTestTbx.Size = new Size(100, 23);
            WinsTestTbx.TabIndex = 13;
            // 
            // LossesTestTbx
            // 
            LossesTestTbx.Location = new Point(168, 128);
            LossesTestTbx.Name = "LossesTestTbx";
            LossesTestTbx.Size = new Size(100, 23);
            LossesTestTbx.TabIndex = 14;
            // 
            // HitsTestTbx
            // 
            HitsTestTbx.Location = new Point(12, 170);
            HitsTestTbx.Name = "HitsTestTbx";
            HitsTestTbx.Size = new Size(100, 23);
            HitsTestTbx.TabIndex = 15;
            // 
            // MissesTestTbx
            // 
            MissesTestTbx.Location = new Point(168, 170);
            MissesTestTbx.Name = "MissesTestTbx";
            MissesTestTbx.Size = new Size(100, 23);
            MissesTestTbx.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.DarkBlue;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(128, 255, 255);
            label1.Location = new Point(22, 8);
            label1.Name = "label1";
            label1.Size = new Size(236, 21);
            label1.TabIndex = 18;
            label1.Text = "Placeholder Textboxes for testing";
            // 
            // SunkShipsTestTbx
            // 
            SunkShipsTestTbx.Location = new Point(88, 210);
            SunkShipsTestTbx.Name = "SunkShipsTestTbx";
            SunkShipsTestTbx.Size = new Size(100, 23);
            SunkShipsTestTbx.TabIndex = 19;
            // 
            // DeleteDbBtn
            // 
            DeleteDbBtn.Location = new Point(193, 254);
            DeleteDbBtn.Name = "DeleteDbBtn";
            DeleteDbBtn.Size = new Size(75, 23);
            DeleteDbBtn.TabIndex = 20;
            DeleteDbBtn.Text = "Delete";
            DeleteDbBtn.UseVisualStyleBackColor = true;
            DeleteDbBtn.Click += DeleteDbBtn_Click;
            // 
            // LoadDbBtn
            // 
            LoadDbBtn.ForeColor = Color.Black;
            LoadDbBtn.Location = new Point(191, 179);
            LoadDbBtn.Name = "LoadDbBtn";
            LoadDbBtn.Size = new Size(59, 23);
            LoadDbBtn.TabIndex = 10;
            LoadDbBtn.Text = "Refresh";
            LoadDbBtn.UseVisualStyleBackColor = true;
            LoadDbBtn.Click += LoadDbBtn_Click;
            // 
            // AccountStats
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(280, 503);
            Controls.Add(DeleteDbBtn);
            Controls.Add(SunkShipsTestTbx);
            Controls.Add(label1);
            Controls.Add(MissesTestTbx);
            Controls.Add(HitsTestTbx);
            Controls.Add(LossesTestTbx);
            Controls.Add(WinsTestTbx);
            Controls.Add(PublicKeyTbx);
            Controls.Add(PrivateKeyTbx);
            Controls.Add(UsernameTestTbx);
            Controls.Add(UpdateDbBtn);
            Controls.Add(CreateDbBtn);
            Controls.Add(UserStatsGbx);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AccountStats";
            Text = "Account Stats";
            UserStatsGbx.ResumeLayout(false);
            UserStatsGbx.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox UserStatsGbx;
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
        private Button CreateDbBtn;
        private Button UpdateDbBtn;
        private TextBox UsernameTestTbx;
        private TextBox PrivateKeyTbx;
        private TextBox PublicKeyTbx;
        private TextBox WinsTestTbx;
        private TextBox LossesTestTbx;
        private TextBox HitsTestTbx;
        private TextBox MissesTestTbx;
        private Label label1;
        private TextBox SunkShipsTestTbx;
        private Button DeleteDbBtn;
        private Button LoadDbBtn;
    }
}