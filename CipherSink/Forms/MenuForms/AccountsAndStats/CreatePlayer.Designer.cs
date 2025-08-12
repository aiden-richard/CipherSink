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
            BtnCreateUser = new Button();
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
            // BtnCreateUser
            // 
            BtnCreateUser.Location = new Point(98, 74);
            BtnCreateUser.Name = "BtnCreateUser";
            BtnCreateUser.Size = new Size(101, 37);
            BtnCreateUser.TabIndex = 2;
            BtnCreateUser.Text = "Create User";
            BtnCreateUser.UseVisualStyleBackColor = true;
            BtnCreateUser.Click += this.BtnCreateUser_Click;
            // 
            // CreateUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(295, 123);
            Controls.Add(BtnCreateUser);
            Controls.Add(LabelUsername);
            Controls.Add(TxtBxUsername);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "CreateUser";
            Text = "Create";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtBxUsername;
        private Label LabelUsername;
        private Button BtnCreateUser;
    }
}