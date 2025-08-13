namespace CipherSink.Forms.MenuForms.AccountsAndStats
{
    partial class CreatePlayer
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
            TxtBxUsername = new TextBox();
            LabelUsername = new Label();
            BtnCreatePlayer = new Button();
            LabelPassword = new Label();
            TxtBxPassword = new TextBox();
            SuspendLayout();
            // 
            // TxtBxUsername
            // 
            TxtBxUsername.Location = new Point(108, 29);
            TxtBxUsername.Name = "TxtBxUsername";
            TxtBxUsername.Size = new Size(147, 23);
            TxtBxUsername.TabIndex = 0;
            // 
            // LabelUsername
            // 
            LabelUsername.AutoSize = true;
            LabelUsername.ForeColor = Color.White;
            LabelUsername.Location = new Point(39, 32);
            LabelUsername.Name = "LabelUsername";
            LabelUsername.Size = new Size(63, 15);
            LabelUsername.TabIndex = 1;
            LabelUsername.Text = "Username:";
            // 
            // BtnCreatePlayer
            // 
            BtnCreatePlayer.Location = new Point(98, 101);
            BtnCreatePlayer.Name = "BtnCreatePlayer";
            BtnCreatePlayer.Size = new Size(101, 37);
            BtnCreatePlayer.TabIndex = 2;
            BtnCreatePlayer.Text = "Create User";
            BtnCreatePlayer.UseVisualStyleBackColor = true;
            BtnCreatePlayer.Click += BtnCreatePlayer_Click;
            // 
            // LabelPassword
            // 
            LabelPassword.AutoSize = true;
            LabelPassword.ForeColor = Color.White;
            LabelPassword.Location = new Point(42, 67);
            LabelPassword.Name = "LabelPassword";
            LabelPassword.Size = new Size(60, 15);
            LabelPassword.TabIndex = 4;
            LabelPassword.Text = "Password:";
            // 
            // TxtBxPassword
            // 
            TxtBxPassword.Location = new Point(108, 64);
            TxtBxPassword.Name = "TxtBxPassword";
            TxtBxPassword.Size = new Size(147, 23);
            TxtBxPassword.TabIndex = 3;
            // 
            // CreatePlayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(295, 150);
            Controls.Add(LabelPassword);
            Controls.Add(TxtBxPassword);
            Controls.Add(BtnCreatePlayer);
            Controls.Add(LabelUsername);
            Controls.Add(TxtBxUsername);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "CreatePlayer";
            Text = "Create";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtBxUsername;
        private Label LabelUsername;
        private Button BtnCreatePlayer;
        private Label LabelPassword;
        private TextBox TxtBxPassword;
    }
}