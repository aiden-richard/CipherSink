namespace CipherSink.Forms.Game
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
            LabelSelectUser = new Label();
            comboBoxSelectUser = new ComboBox();
            BtnCreateGame = new Button();
            comboBoxGameType = new ComboBox();
            LabelGameType = new Label();
            SuspendLayout();
            // 
            // LabelGamePassword
            // 
            LabelGamePassword.AutoSize = true;
            LabelGamePassword.ForeColor = Color.White;
            LabelGamePassword.Location = new Point(20, 55);
            LabelGamePassword.Name = "LabelGamePassword";
            LabelGamePassword.Size = new Size(162, 15);
            LabelGamePassword.TabIndex = 0;
            LabelGamePassword.Text = "Optional Game Pin (A-z, 0-9):";
            // 
            // TxtBxGamePin
            // 
            TxtBxGamePin.Location = new Point(188, 52);
            TxtBxGamePin.Name = "TxtBxGamePin";
            TxtBxGamePin.Size = new Size(160, 23);
            TxtBxGamePin.TabIndex = 1;
            // 
            // LabelSelectUser
            // 
            LabelSelectUser.AutoSize = true;
            LabelSelectUser.ForeColor = Color.White;
            LabelSelectUser.Location = new Point(53, 20);
            LabelSelectUser.Name = "LabelSelectUser";
            LabelSelectUser.Size = new Size(129, 15);
            LabelSelectUser.TabIndex = 3;
            LabelSelectUser.Text = "Select a User to Play as:";
            // 
            // comboBoxSelectUser
            // 
            comboBoxSelectUser.FormattingEnabled = true;
            comboBoxSelectUser.Location = new Point(188, 12);
            comboBoxSelectUser.Name = "comboBoxSelectUser";
            comboBoxSelectUser.Size = new Size(160, 23);
            comboBoxSelectUser.TabIndex = 4;
            // 
            // BtnCreateGame
            // 
            BtnCreateGame.Location = new Point(132, 137);
            BtnCreateGame.Name = "BtnCreateGame";
            BtnCreateGame.Size = new Size(114, 37);
            BtnCreateGame.TabIndex = 5;
            BtnCreateGame.Text = "Create Game";
            BtnCreateGame.UseVisualStyleBackColor = true;
            // 
            // comboBoxGameType
            // 
            comboBoxGameType.FormattingEnabled = true;
            comboBoxGameType.Location = new Point(188, 91);
            comboBoxGameType.Name = "comboBoxGameType";
            comboBoxGameType.Size = new Size(160, 23);
            comboBoxGameType.TabIndex = 7;
            // 
            // LabelGameType
            // 
            LabelGameType.AutoSize = true;
            LabelGameType.ForeColor = Color.White;
            LabelGameType.Location = new Point(113, 94);
            LabelGameType.Name = "LabelGameType";
            LabelGameType.Size = new Size(69, 15);
            LabelGameType.TabIndex = 6;
            LabelGameType.Text = "Game Type:";
            // 
            // CreateGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(388, 186);
            Controls.Add(comboBoxGameType);
            Controls.Add(LabelGameType);
            Controls.Add(BtnCreateGame);
            Controls.Add(comboBoxSelectUser);
            Controls.Add(LabelSelectUser);
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
        private Label LabelSelectUser;
        private ComboBox comboBoxSelectUser;
        private Button BtnCreateGame;
        private ComboBox comboBoxGameType;
        private Label LabelGameType;
    }
}