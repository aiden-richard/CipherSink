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
            SuspendLayout();
            // 
            // RecentPlayersLV
            // 
            RecentPlayersLV.Location = new Point(12, 37);
            RecentPlayersLV.Name = "RecentPlayersLV";
            RecentPlayersLV.Size = new Size(282, 390);
            RecentPlayersLV.TabIndex = 2;
            RecentPlayersLV.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(145, 25);
            label2.TabIndex = 3;
            label2.Text = "Recent Players:";
            // 
            // RecentPlayers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 450);
            Controls.Add(label2);
            Controls.Add(RecentPlayersLV);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "RecentPlayers";
            Text = "Recent Players";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListView RecentPlayersLV;
        private Label label2;
    }
}