namespace CipherSink.Forms.GameForms
{
    partial class JoinGame
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
            BtnJoinGame = new Button();
            TxtBxHostIp = new TextBox();
            LabelHostIp = new Label();
            comboBoxSelectPlayer = new ComboBox();
            LabelSelectPlayer = new Label();
            TxtBxPlayerPassword = new TextBox();
            LabelPlayerPassword = new Label();
            TxtBxGamePin = new TextBox();
            LabelGamePassword = new Label();
            SuspendLayout();
            // 
            // BtnJoinGame
            // 
            BtnJoinGame.Location = new Point(170, 165);
            BtnJoinGame.Name = "BtnJoinGame";
            BtnJoinGame.Size = new Size(94, 40);
            BtnJoinGame.TabIndex = 0;
            BtnJoinGame.Text = "Join Game";
            BtnJoinGame.UseVisualStyleBackColor = true;
            BtnJoinGame.Click += BtnJoinGame_Click;
            // 
            // TxtBxHostIp
            // 
            TxtBxHostIp.Location = new Point(213, 81);
            TxtBxHostIp.Name = "TxtBxHostIp";
            TxtBxHostIp.Size = new Size(160, 23);
            TxtBxHostIp.TabIndex = 3;
            // 
            // LabelHostIp
            // 
            LabelHostIp.AutoSize = true;
            LabelHostIp.ForeColor = Color.White;
            LabelHostIp.Location = new Point(159, 84);
            LabelHostIp.Name = "LabelHostIp";
            LabelHostIp.Size = new Size(48, 15);
            LabelHostIp.TabIndex = 2;
            LabelHostIp.Text = "Host Ip:";
            // 
            // comboBoxSelectPlayer
            // 
            comboBoxSelectPlayer.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSelectPlayer.FormattingEnabled = true;
            comboBoxSelectPlayer.Location = new Point(213, 12);
            comboBoxSelectPlayer.Name = "comboBoxSelectPlayer";
            comboBoxSelectPlayer.Size = new Size(160, 23);
            comboBoxSelectPlayer.TabIndex = 1;
            comboBoxSelectPlayer.TabStop = false;
            // 
            // LabelSelectPlayer
            // 
            LabelSelectPlayer.AutoSize = true;
            LabelSelectPlayer.ForeColor = Color.White;
            LabelSelectPlayer.Location = new Point(69, 15);
            LabelSelectPlayer.Name = "LabelSelectPlayer";
            LabelSelectPlayer.Size = new Size(138, 15);
            LabelSelectPlayer.TabIndex = 5;
            LabelSelectPlayer.Text = "Select a Player to Play as:";
            // 
            // TxtBxPlayerPassword
            // 
            TxtBxPlayerPassword.Location = new Point(213, 47);
            TxtBxPlayerPassword.Name = "TxtBxPlayerPassword";
            TxtBxPlayerPassword.PasswordChar = '*';
            TxtBxPlayerPassword.Size = new Size(160, 23);
            TxtBxPlayerPassword.TabIndex = 2;
            // 
            // LabelPlayerPassword
            // 
            LabelPlayerPassword.AutoSize = true;
            LabelPlayerPassword.ForeColor = Color.White;
            LabelPlayerPassword.Location = new Point(112, 50);
            LabelPlayerPassword.Name = "LabelPlayerPassword";
            LabelPlayerPassword.Size = new Size(95, 15);
            LabelPlayerPassword.TabIndex = 10;
            LabelPlayerPassword.Text = "Player Password:";
            // 
            // TxtBxGamePin
            // 
            TxtBxGamePin.Location = new Point(213, 117);
            TxtBxGamePin.Name = "TxtBxGamePin";
            TxtBxGamePin.Size = new Size(160, 23);
            TxtBxGamePin.TabIndex = 4;
            // 
            // LabelGamePassword
            // 
            LabelGamePassword.AutoSize = true;
            LabelGamePassword.ForeColor = Color.White;
            LabelGamePassword.Location = new Point(45, 120);
            LabelGamePassword.Name = "LabelGamePassword";
            LabelGamePassword.Size = new Size(162, 15);
            LabelGamePassword.TabIndex = 12;
            LabelGamePassword.Text = "Optional Game Pin (A-z, 0-9):";
            // 
            // JoinGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(449, 217);
            Controls.Add(TxtBxGamePin);
            Controls.Add(LabelGamePassword);
            Controls.Add(TxtBxPlayerPassword);
            Controls.Add(LabelPlayerPassword);
            Controls.Add(comboBoxSelectPlayer);
            Controls.Add(LabelSelectPlayer);
            Controls.Add(LabelHostIp);
            Controls.Add(TxtBxHostIp);
            Controls.Add(BtnJoinGame);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "JoinGame";
            Text = "Join Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnJoinGame;
        private TextBox TxtBxHostIp;
        private Label LabelHostIp;
        private ComboBox comboBoxSelectPlayer;
        private Label LabelSelectPlayer;
        private TextBox TxtBxPlayerPassword;
        private Label LabelPlayerPassword;
        private TextBox TxtBxGamePin;
        private Label LabelGamePassword;
    }
}