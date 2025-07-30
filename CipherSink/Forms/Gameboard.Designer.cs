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
            TurnTrackerTbx = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // TurnTrackerTbx
            // 
            TurnTrackerTbx.Location = new Point(447, 338);
            TurnTrackerTbx.Name = "TurnTrackerTbx";
            TurnTrackerTbx.ReadOnly = true;
            TurnTrackerTbx.Size = new Size(100, 23);
            TurnTrackerTbx.TabIndex = 2;
            TurnTrackerTbx.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(128, 255, 255);
            label1.Location = new Point(478, 314);
            label1.Name = "label1";
            label1.Size = new Size(45, 21);
            label1.TabIndex = 3;
            label1.Text = "Turn:";
            // 
            // Gameboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(599, 686);
            Controls.Add(label1);
            Controls.Add(TurnTrackerTbx);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Gameboard";
            Text = "Gameboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox TurnTrackerTbx;
        private Label label1;
    }
}