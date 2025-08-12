namespace CipherSink.Forms.MenuForms.AccountsAndStats
{
    partial class EditPlayer
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
            LabelUsername = new Label();
            TxtBxUsername = new TextBox();
            LabelPublicKey = new Label();
            SuspendLayout();
            // 
            // LabelUsername
            // 
            LabelUsername.AutoSize = true;
            LabelUsername.ForeColor = Color.White;
            LabelUsername.Location = new Point(37, 30);
            LabelUsername.Name = "LabelUsername";
            LabelUsername.Size = new Size(63, 15);
            LabelUsername.TabIndex = 0;
            LabelUsername.Text = "Username:";
            // 
            // TxtBxUsername
            // 
            TxtBxUsername.Location = new Point(106, 27);
            TxtBxUsername.Name = "TxtBxUsername";
            TxtBxUsername.Size = new Size(146, 23);
            TxtBxUsername.TabIndex = 1;
            // 
            // LabelPublicKey
            // 
            LabelPublicKey.AutoSize = true;
            LabelPublicKey.ForeColor = Color.White;
            LabelPublicKey.Location = new Point(35, 73);
            LabelPublicKey.Name = "LabelPublicKey";
            LabelPublicKey.Size = new Size(65, 15);
            LabelPublicKey.TabIndex = 2;
            LabelPublicKey.Text = "Public Key:";
            // 
            // EditPlayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(642, 391);
            Controls.Add(LabelPublicKey);
            Controls.Add(TxtBxUsername);
            Controls.Add(LabelUsername);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "EditPlayer";
            Text = "Edit Player";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelUsername;
        private TextBox TxtBxUsername;
        private Label LabelPublicKey;
        private TextBox textBox1;
        private Label Label;
    }
}