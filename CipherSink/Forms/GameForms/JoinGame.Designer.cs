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
            SuspendLayout();
            // 
            // BtnJoinGame
            // 
            BtnJoinGame.Location = new Point(139, 223);
            BtnJoinGame.Name = "BtnJoinGame";
            BtnJoinGame.Size = new Size(94, 40);
            BtnJoinGame.TabIndex = 0;
            BtnJoinGame.Text = "Join Game";
            BtnJoinGame.UseVisualStyleBackColor = true;
            BtnJoinGame.Click += BtnJoinGame_Click;
            // 
            // TxtBxHostIp
            // 
            TxtBxHostIp.Location = new Point(164, 54);
            TxtBxHostIp.Name = "TxtBxHostIp";
            TxtBxHostIp.Size = new Size(100, 23);
            TxtBxHostIp.TabIndex = 1;
            // 
            // LabelHostIp
            // 
            LabelHostIp.AutoSize = true;
            LabelHostIp.ForeColor = Color.White;
            LabelHostIp.Location = new Point(110, 57);
            LabelHostIp.Name = "LabelHostIp";
            LabelHostIp.Size = new Size(48, 15);
            LabelHostIp.TabIndex = 2;
            LabelHostIp.Text = "Host Ip:";
            // 
            // JoinGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(373, 275);
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
    }
}