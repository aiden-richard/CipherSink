namespace CipherSink
{
    partial class RecentPlayers
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
            RecentPlayersLV = new ListView();
            label2 = new Label();
            CreateDbBtn = new Button();
            UpdateDbBtn = new Button();
            DeleteDbBtn = new Button();
            LoadDbBtn = new Button();
            RUsernameTestTbx = new TextBox();
            label1 = new Label();
            RPublicKeyTestTbx = new TextBox();
            IsFriendTestTbx = new TextBox();
            TimeTestTbx = new TextBox();
            TurnsTestTbx = new TextBox();
            SuspendLayout();
            // 
            // RecentPlayersLV
            // 
            RecentPlayersLV.Location = new Point(12, 305);
            RecentPlayersLV.Name = "RecentPlayersLV";
            RecentPlayersLV.Size = new Size(422, 390);
            RecentPlayersLV.TabIndex = 2;
            RecentPlayersLV.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(128, 255, 255);
            label2.Location = new Point(12, 277);
            label2.Name = "label2";
            label2.Size = new Size(145, 25);
            label2.TabIndex = 3;
            label2.Text = "Recent Players:";
            // 
            // CreateDbBtn
            // 
            CreateDbBtn.Location = new Point(64, 253);
            CreateDbBtn.Name = "CreateDbBtn";
            CreateDbBtn.Size = new Size(75, 23);
            CreateDbBtn.TabIndex = 4;
            CreateDbBtn.Text = "Create";
            CreateDbBtn.UseVisualStyleBackColor = true;
            // 
            // UpdateDbBtn
            // 
            UpdateDbBtn.Location = new Point(144, 253);
            UpdateDbBtn.Name = "UpdateDbBtn";
            UpdateDbBtn.Size = new Size(75, 23);
            UpdateDbBtn.TabIndex = 5;
            UpdateDbBtn.Text = "Update";
            UpdateDbBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteDbBtn
            // 
            DeleteDbBtn.Location = new Point(225, 253);
            DeleteDbBtn.Name = "DeleteDbBtn";
            DeleteDbBtn.Size = new Size(75, 23);
            DeleteDbBtn.TabIndex = 6;
            DeleteDbBtn.Text = "Remove";
            DeleteDbBtn.UseVisualStyleBackColor = true;
            // 
            // LoadDbBtn
            // 
            LoadDbBtn.Location = new Point(306, 253);
            LoadDbBtn.Name = "LoadDbBtn";
            LoadDbBtn.Size = new Size(75, 23);
            LoadDbBtn.TabIndex = 7;
            LoadDbBtn.Text = "Refresh";
            LoadDbBtn.UseVisualStyleBackColor = true;
            // 
            // RUsernameTestTbx
            // 
            RUsernameTestTbx.Location = new Point(12, 52);
            RUsernameTestTbx.Name = "RUsernameTestTbx";
            RUsernameTestTbx.Size = new Size(145, 23);
            RUsernameTestTbx.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(128, 255, 255);
            label1.Location = new Point(81, 9);
            label1.Name = "label1";
            label1.Size = new Size(290, 30);
            label1.TabIndex = 9;
            label1.Text = "Placeholder entries for testing";
            // 
            // RPublicKeyTestTbx
            // 
            RPublicKeyTestTbx.Location = new Point(12, 91);
            RPublicKeyTestTbx.Name = "RPublicKeyTestTbx";
            RPublicKeyTestTbx.Size = new Size(100, 23);
            RPublicKeyTestTbx.TabIndex = 10;
            // 
            // IsFriendTestTbx
            // 
            IsFriendTestTbx.Location = new Point(12, 120);
            IsFriendTestTbx.Name = "IsFriendTestTbx";
            IsFriendTestTbx.Size = new Size(100, 23);
            IsFriendTestTbx.TabIndex = 11;
            // 
            // TimeTestTbx
            // 
            TimeTestTbx.Location = new Point(200, 52);
            TimeTestTbx.Name = "TimeTestTbx";
            TimeTestTbx.Size = new Size(100, 23);
            TimeTestTbx.TabIndex = 12;
            // 
            // TurnsTestTbx
            // 
            TurnsTestTbx.Location = new Point(200, 91);
            TurnsTestTbx.Name = "TurnsTestTbx";
            TurnsTestTbx.Size = new Size(100, 23);
            TurnsTestTbx.TabIndex = 13;
            // 
            // RecentPlayers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(446, 707);
            Controls.Add(TurnsTestTbx);
            Controls.Add(TimeTestTbx);
            Controls.Add(IsFriendTestTbx);
            Controls.Add(RPublicKeyTestTbx);
            Controls.Add(label1);
            Controls.Add(RUsernameTestTbx);
            Controls.Add(LoadDbBtn);
            Controls.Add(DeleteDbBtn);
            Controls.Add(UpdateDbBtn);
            Controls.Add(CreateDbBtn);
            Controls.Add(label2);
            Controls.Add(RecentPlayersLV);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "RecentPlayers";
            Text = "Recent Games";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListView RecentPlayersLV;
        private Label label2;
        private Button CreateDbBtn;
        private Button UpdateDbBtn;
        private Button DeleteDbBtn;
        private Button LoadDbBtn;
        private TextBox RUsernameTestTbx;
        private Label label1;
        private TextBox RPublicKeyTestTbx;
        private TextBox IsFriendTestTbx;
        private TextBox TimeTestTbx;
        private TextBox TurnsTestTbx;
    }
}