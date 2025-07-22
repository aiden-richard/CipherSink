namespace CipherSink
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StartGameBtn = new Button();
            PlayerAccountBtn = new Button();
            OptionsBtn = new Button();
            FriendsBtn = new Button();
            ExitBtn = new Button();
            TitleLbl = new Label();
            QuoteLbl = new Label();
            RecentGamesLV = new ListView();
            label1 = new Label();
            SuspendLayout();
            // 
            // StartGameBtn
            // 
            StartGameBtn.Location = new Point(169, 160);
            StartGameBtn.Name = "StartGameBtn";
            StartGameBtn.Size = new Size(121, 49);
            StartGameBtn.TabIndex = 0;
            StartGameBtn.Text = "Start Game";
            StartGameBtn.UseVisualStyleBackColor = true;
            StartGameBtn.Click += StartGameBtn_Click;
            // 
            // PlayerAccountBtn
            // 
            PlayerAccountBtn.Location = new Point(27, 231);
            PlayerAccountBtn.Name = "PlayerAccountBtn";
            PlayerAccountBtn.Size = new Size(121, 49);
            PlayerAccountBtn.TabIndex = 1;
            PlayerAccountBtn.Text = "Account";
            PlayerAccountBtn.UseVisualStyleBackColor = true;
            PlayerAccountBtn.Click += PlayerAccountBtn_Click;
            // 
            // OptionsBtn
            // 
            OptionsBtn.Location = new Point(169, 231);
            OptionsBtn.Name = "OptionsBtn";
            OptionsBtn.Size = new Size(121, 49);
            OptionsBtn.TabIndex = 2;
            OptionsBtn.Text = "Options";
            OptionsBtn.UseVisualStyleBackColor = true;
            OptionsBtn.Click += OptionsBtn_Click;
            // 
            // FriendsBtn
            // 
            FriendsBtn.Location = new Point(306, 231);
            FriendsBtn.Name = "FriendsBtn";
            FriendsBtn.Size = new Size(121, 49);
            FriendsBtn.TabIndex = 3;
            FriendsBtn.Text = "Friends";
            FriendsBtn.UseVisualStyleBackColor = true;
            FriendsBtn.Click += FriendsBtn_Click;
            // 
            // ExitBtn
            // 
            ExitBtn.Location = new Point(27, 389);
            ExitBtn.Name = "ExitBtn";
            ExitBtn.Size = new Size(121, 49);
            ExitBtn.TabIndex = 4;
            ExitBtn.Text = "Exit";
            ExitBtn.UseVisualStyleBackColor = true;
            ExitBtn.Click += ExitBtn_Click;
            // 
            // TitleLbl
            // 
            TitleLbl.AutoSize = true;
            TitleLbl.BackColor = Color.Transparent;
            TitleLbl.Font = new Font("Impact", 36F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            TitleLbl.Location = new Point(98, 42);
            TitleLbl.Name = "TitleLbl";
            TitleLbl.Size = new Size(253, 60);
            TitleLbl.TabIndex = 6;
            TitleLbl.Text = "CipherSink";
            // 
            // QuoteLbl
            // 
            QuoteLbl.AutoSize = true;
            QuoteLbl.BackColor = Color.Transparent;
            QuoteLbl.Font = new Font("Impact", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            QuoteLbl.Location = new Point(118, 111);
            QuoteLbl.Name = "QuoteLbl";
            QuoteLbl.Size = new Size(224, 29);
            QuoteLbl.TabIndex = 7;
            QuoteLbl.Text = "You cracked my code!";
            // 
            // RecentGamesLV
            // 
            RecentGamesLV.Location = new Point(235, 341);
            RecentGamesLV.Name = "RecentGamesLV";
            RecentGamesLV.Size = new Size(228, 97);
            RecentGamesLV.TabIndex = 8;
            RecentGamesLV.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Lora", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(235, 313);
            label1.Name = "label1";
            label1.Size = new Size(160, 25);
            label1.TabIndex = 9;
            label1.Text = "Most Recent Games:";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 450);
            Controls.Add(label1);
            Controls.Add(RecentGamesLV);
            Controls.Add(QuoteLbl);
            Controls.Add(TitleLbl);
            Controls.Add(ExitBtn);
            Controls.Add(FriendsBtn);
            Controls.Add(OptionsBtn);
            Controls.Add(PlayerAccountBtn);
            Controls.Add(StartGameBtn);
            Name = "Main";
            Text = "CipherSink";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button StartGameBtn;
        private Button PlayerAccountBtn;
        private Button OptionsBtn;
        private Button FriendsBtn;
        private Button ExitBtn;
        private Label TitleLbl;
        private Label QuoteLbl;
        private ListView RecentGamesLV;
        private Label label1;
    }
}
