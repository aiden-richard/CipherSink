namespace CipherSink
{
    partial class Gameboard
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
            panel1 = new Panel();
            panel2 = new Panel();
            TurnTrackerTbx = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(81, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(302, 272);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Location = new Point(81, 404);
            panel2.Name = "panel2";
            panel2.Size = new Size(302, 270);
            panel2.TabIndex = 1;
            // 
            // TurnTrackerTbx
            // 
            TurnTrackerTbx.Location = new Point(447, 338);
            TurnTrackerTbx.Name = "TurnTrackerTbx";
            TurnTrackerTbx.ReadOnly = true;
            TurnTrackerTbx.Size = new Size(100, 23);
            TurnTrackerTbx.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(482, 320);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 3;
            label1.Text = "Turn:";
            // 
            // Gameboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 686);
            Controls.Add(label1);
            Controls.Add(TurnTrackerTbx);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Gameboard";
            Text = "Gameboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TextBox TurnTrackerTbx;
        private Label label1;
    }
}