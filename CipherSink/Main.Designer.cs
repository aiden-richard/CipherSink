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
            CreateGameBtn = new Button();
            PlayerAccountBtn = new Button();
            OptionsBtn = new Button();
            RecentGamesBtn = new Button();
            ExitBtn = new Button();
            TitleLbl = new Label();
            QuoteLbl = new Label();
            JoinGameBtn = new Button();
            SuspendLayout();
            // 
            // CreateGameBtn
            // 
            CreateGameBtn.Location = new Point(138, 160);
            CreateGameBtn.Name = "CreateGameBtn";
            CreateGameBtn.Size = new Size(195, 33);
            CreateGameBtn.TabIndex = 0;
            CreateGameBtn.Text = "Create Game";
            CreateGameBtn.UseVisualStyleBackColor = true;
            CreateGameBtn.Click += CreateGameBtn_Click;
            // 
            // PlayerAccountBtn
            // 
            PlayerAccountBtn.Location = new Point(138, 262);
            PlayerAccountBtn.Name = "PlayerAccountBtn";
            PlayerAccountBtn.Size = new Size(195, 33);
            PlayerAccountBtn.TabIndex = 1;
            PlayerAccountBtn.Text = "Account Stats";
            PlayerAccountBtn.UseVisualStyleBackColor = true;
            PlayerAccountBtn.Click += PlayerAccountBtn_Click;
            // 
            // OptionsBtn
            // 
            OptionsBtn.Location = new Point(138, 340);
            OptionsBtn.Name = "OptionsBtn";
            OptionsBtn.Size = new Size(195, 33);
            OptionsBtn.TabIndex = 2;
            OptionsBtn.Text = "Options";
            OptionsBtn.UseVisualStyleBackColor = true;
            OptionsBtn.Click += OptionsBtn_Click;
            // 
            // RecentGamesBtn
            // 
            RecentGamesBtn.Location = new Point(138, 301);
            RecentGamesBtn.Name = "RecentGamesBtn";
            RecentGamesBtn.Size = new Size(195, 33);
            RecentGamesBtn.TabIndex = 3;
            RecentGamesBtn.Text = "Recent Games";
            RecentGamesBtn.UseVisualStyleBackColor = true;
            RecentGamesBtn.Click += RecentGamesBtn_Click;
            // 
            // ExitBtn
            // 
            ExitBtn.Location = new Point(138, 405);
            ExitBtn.Name = "ExitBtn";
            ExitBtn.Size = new Size(195, 33);
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
            TitleLbl.Location = new Point(112, 43);
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
            QuoteLbl.Location = new Point(121, 112);
            QuoteLbl.Name = "QuoteLbl";
            QuoteLbl.Size = new Size(224, 29);
            QuoteLbl.TabIndex = 7;
            QuoteLbl.Text = "You cracked my code!";
            // 
            // JoinGameBtn
            // 
            JoinGameBtn.Location = new Point(138, 199);
            JoinGameBtn.Name = "JoinGameBtn";
            JoinGameBtn.Size = new Size(195, 33);
            JoinGameBtn.TabIndex = 8;
            JoinGameBtn.Text = "Join Game";
            JoinGameBtn.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 450);
            Controls.Add(JoinGameBtn);
            Controls.Add(QuoteLbl);
            Controls.Add(TitleLbl);
            Controls.Add(ExitBtn);
            Controls.Add(RecentGamesBtn);
            Controls.Add(OptionsBtn);
            Controls.Add(PlayerAccountBtn);
            Controls.Add(CreateGameBtn);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Main";
            Text = "CipherSink";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CreateGameBtn;
        private Button PlayerAccountBtn;
        private Button OptionsBtn;
        private Button RecentGamesBtn;
        private Button ExitBtn;
        private Label TitleLbl;
        private Label QuoteLbl;
        private Button JoinGameBtn;
    }
}
