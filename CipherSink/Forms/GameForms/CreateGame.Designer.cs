namespace CipherSink.Forms.GameForms
{
    partial class CreateGame
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
            LabelGamePassword = new Label();
            TxtBxGamePin = new TextBox();
            LabelSelectPlayer = new Label();
            comboBoxSelectPlayer = new ComboBox();
            BtnCreateGame = new Button();
            comboBoxGameType = new ComboBox();
            LabelGameType = new Label();
            TxtBxPlayerPassword = new TextBox();
            LabelPlayerPassword = new Label();
            LabelPrivateMatches = new Label();
            SuspendLayout();
            // 
            // LabelGamePassword
            // 
            LabelGamePassword.AutoSize = true;
            LabelGamePassword.ForeColor = Color.White;
            LabelGamePassword.Location = new Point(20, 85);
            LabelGamePassword.Name = "LabelGamePassword";
            LabelGamePassword.Size = new Size(162, 15);
            LabelGamePassword.TabIndex = 0;
            LabelGamePassword.Text = "Optional Game Pin (A-z, 0-9):";
            // 
            // TxtBxGamePin
            // 
            TxtBxGamePin.Location = new Point(188, 82);
            TxtBxGamePin.Name = "TxtBxGamePin";
            TxtBxGamePin.Size = new Size(160, 23);
            TxtBxGamePin.TabIndex = 1;
            // 
            // LabelSelectPlayer
            // 
            LabelSelectPlayer.AutoSize = true;
            LabelSelectPlayer.ForeColor = Color.White;
            LabelSelectPlayer.Location = new Point(44, 15);
            LabelSelectPlayer.Name = "LabelSelectPlayer";
            LabelSelectPlayer.Size = new Size(138, 15);
            LabelSelectPlayer.TabIndex = 3;
            LabelSelectPlayer.Text = "Select a Player to Play as:";
            // 
            // comboBoxSelectPlayer
            // 
            comboBoxSelectPlayer.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSelectPlayer.FormattingEnabled = true;
            comboBoxSelectPlayer.Location = new Point(188, 12);
            comboBoxSelectPlayer.Name = "comboBoxSelectPlayer";
            comboBoxSelectPlayer.Size = new Size(160, 23);
            comboBoxSelectPlayer.TabIndex = 4;
            comboBoxSelectPlayer.TabStop = false;
            // 
            // BtnCreateGame
            // 
            BtnCreateGame.Location = new Point(137, 175);
            BtnCreateGame.Name = "BtnCreateGame";
            BtnCreateGame.Size = new Size(114, 37);
            BtnCreateGame.TabIndex = 5;
            BtnCreateGame.Text = "Create Game";
            BtnCreateGame.UseVisualStyleBackColor = true;
            BtnCreateGame.Click += BtnCreateGame_Click;
            // 
            // comboBoxGameType
            // 
            comboBoxGameType.FormattingEnabled = true;
            comboBoxGameType.Location = new Point(188, 117);
            comboBoxGameType.Name = "comboBoxGameType";
            comboBoxGameType.Size = new Size(160, 23);
            comboBoxGameType.TabIndex = 7;
            // 
            // LabelGameType
            // 
            LabelGameType.AutoSize = true;
            LabelGameType.ForeColor = Color.White;
            LabelGameType.Location = new Point(113, 120);
            LabelGameType.Name = "LabelGameType";
            LabelGameType.Size = new Size(69, 15);
            LabelGameType.TabIndex = 6;
            LabelGameType.Text = "Game Type:";
            // 
            // TxtBxPlayerPassword
            // 
            TxtBxPlayerPassword.Location = new Point(188, 47);
            TxtBxPlayerPassword.Name = "TxtBxPlayerPassword";
            TxtBxPlayerPassword.Size = new Size(160, 23);
            TxtBxPlayerPassword.TabIndex = 9;
            // 
            // LabelPlayerPassword
            // 
            LabelPlayerPassword.AutoSize = true;
            LabelPlayerPassword.ForeColor = Color.White;
            LabelPlayerPassword.Location = new Point(87, 50);
            LabelPlayerPassword.Name = "LabelPlayerPassword";
            LabelPlayerPassword.Size = new Size(95, 15);
            LabelPlayerPassword.TabIndex = 8;
            LabelPlayerPassword.Text = "Player Password:";
            // 
            // LabelPrivateMatches
            // 
            LabelPrivateMatches.AutoSize = true;
            LabelPrivateMatches.ForeColor = Color.White;
            LabelPrivateMatches.Location = new Point(44, 143);
            LabelPrivateMatches.Name = "LabelPrivateMatches";
            LabelPrivateMatches.Size = new Size(304, 15);
            LabelPrivateMatches.TabIndex = 10;
            LabelPrivateMatches.Text = "*Private matches will only allow connetions from friends";
            // 
            // CreateGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(388, 224);
            Controls.Add(LabelPrivateMatches);
            Controls.Add(TxtBxPlayerPassword);
            Controls.Add(LabelPlayerPassword);
            Controls.Add(comboBoxGameType);
            Controls.Add(LabelGameType);
            Controls.Add(BtnCreateGame);
            Controls.Add(comboBoxSelectPlayer);
            Controls.Add(LabelSelectPlayer);
            Controls.Add(TxtBxGamePin);
            Controls.Add(LabelGamePassword);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "CreateGame";
            Text = "Create Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelGamePassword;
        private TextBox TxtBxGamePin;
        private Label LabelSelectPlayer;
        private ComboBox comboBoxSelectPlayer;
        private Button BtnCreateGame;
        private ComboBox comboBoxGameType;
        private Label LabelGameType;
        private TextBox TxtBxPlayerPassword;
        private Label LabelPlayerPassword;
        private Label LabelPrivateMatches;
    }
}