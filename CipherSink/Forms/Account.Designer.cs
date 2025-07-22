namespace CipherSink
{
    partial class Account
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
            label1 = new Label();
            ActiveUserTbx = new TextBox();
            label2 = new Label();
            LogOutUserBtn = new Button();
            NewUserTbx = new TextBox();
            label3 = new Label();
            LogInUserBtn = new Button();
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
            UserStatsGbx.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 171);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 0;
            label1.Text = "Current User:";
            // 
            // ActiveUserTbx
            // 
            ActiveUserTbx.Location = new Point(100, 168);
            ActiveUserTbx.Name = "ActiveUserTbx";
            ActiveUserTbx.ReadOnly = true;
            ActiveUserTbx.Size = new Size(231, 23);
            ActiveUserTbx.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Impact", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(103, 19);
            label2.Name = "label2";
            label2.Size = new Size(131, 23);
            label2.TabIndex = 2;
            label2.Text = "Add a new user:";
            // 
            // LogOutUserBtn
            // 
            LogOutUserBtn.Location = new Point(237, 197);
            LogOutUserBtn.Name = "LogOutUserBtn";
            LogOutUserBtn.Size = new Size(94, 36);
            LogOutUserBtn.TabIndex = 3;
            LogOutUserBtn.Text = "Log out";
            LogOutUserBtn.UseVisualStyleBackColor = true;
            // 
            // NewUserTbx
            // 
            NewUserTbx.Location = new Point(92, 60);
            NewUserTbx.Name = "NewUserTbx";
            NewUserTbx.Size = new Size(239, 23);
            NewUserTbx.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(19, 63);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 5;
            label3.Text = "Username:";
            // 
            // LogInUserBtn
            // 
            LogInUserBtn.Location = new Point(237, 94);
            LogInUserBtn.Name = "LogInUserBtn";
            LogInUserBtn.Size = new Size(94, 33);
            LogInUserBtn.TabIndex = 6;
            LogInUserBtn.Text = "Sign in";
            LogInUserBtn.UseVisualStyleBackColor = true;
            // 
            // UserStatsGbx
            // 
            UserStatsGbx.BackColor = Color.Transparent;
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
            UserStatsGbx.Location = new Point(68, 253);
            UserStatsGbx.Name = "UserStatsGbx";
            UserStatsGbx.Size = new Size(195, 185);
            UserStatsGbx.TabIndex = 7;
            UserStatsGbx.TabStop = false;
            UserStatsGbx.Text = "Current user's stats:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(67, 138);
            label8.Name = "label8";
            label8.Size = new Size(65, 15);
            label8.TabIndex = 9;
            label8.Text = "Total Sunk:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(114, 80);
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
            label5.Location = new Point(114, 28);
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
            TotalSunkTbx.Location = new Point(50, 156);
            TotalSunkTbx.Name = "TotalSunkTbx";
            TotalSunkTbx.ReadOnly = true;
            TotalSunkTbx.Size = new Size(100, 23);
            TotalSunkTbx.TabIndex = 4;
            // 
            // MissesTbx
            // 
            MissesTbx.Location = new Point(114, 98);
            MissesTbx.Name = "MissesTbx";
            MissesTbx.ReadOnly = true;
            MissesTbx.Size = new Size(52, 23);
            MissesTbx.TabIndex = 3;
            // 
            // HitsTbx
            // 
            HitsTbx.Location = new Point(32, 98);
            HitsTbx.Name = "HitsTbx";
            HitsTbx.ReadOnly = true;
            HitsTbx.Size = new Size(52, 23);
            HitsTbx.TabIndex = 2;
            // 
            // LossesTbx
            // 
            LossesTbx.Location = new Point(114, 46);
            LossesTbx.Name = "LossesTbx";
            LossesTbx.ReadOnly = true;
            LossesTbx.Size = new Size(52, 23);
            LossesTbx.TabIndex = 1;
            // 
            // WinsTbx
            // 
            WinsTbx.Location = new Point(32, 46);
            WinsTbx.Name = "WinsTbx";
            WinsTbx.ReadOnly = true;
            WinsTbx.Size = new Size(52, 23);
            WinsTbx.TabIndex = 0;
            // 
            // Account
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 450);
            Controls.Add(UserStatsGbx);
            Controls.Add(LogInUserBtn);
            Controls.Add(label3);
            Controls.Add(NewUserTbx);
            Controls.Add(LogOutUserBtn);
            Controls.Add(label2);
            Controls.Add(ActiveUserTbx);
            Controls.Add(label1);
            Name = "Account";
            Text = "Account";
            UserStatsGbx.ResumeLayout(false);
            UserStatsGbx.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox ActiveUserTbx;
        private Label label2;
        private Button LogOutUserBtn;
        private TextBox NewUserTbx;
        private Label label3;
        private Button LogInUserBtn;
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
    }
}