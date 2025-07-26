namespace CipherSink
{
    partial class Options
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
            label1 = new Label();
            label2 = new Label();
            MasterAudioTbr = new TrackBar();
            MusicAudioTbr = new TrackBar();
            AudioGbx = new GroupBox();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)MasterAudioTbr).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MusicAudioTbr).BeginInit();
            AudioGbx.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 29);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "Master:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 102);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 1;
            label2.Text = "Music:";
            // 
            // MasterAudioTbr
            // 
            MasterAudioTbr.Location = new Point(26, 47);
            MasterAudioTbr.Name = "MasterAudioTbr";
            MasterAudioTbr.Size = new Size(260, 45);
            MasterAudioTbr.TabIndex = 2;
            // 
            // MusicAudioTbr
            // 
            MusicAudioTbr.Location = new Point(26, 120);
            MusicAudioTbr.Name = "MusicAudioTbr";
            MusicAudioTbr.Size = new Size(260, 45);
            MusicAudioTbr.TabIndex = 3;
            // 
            // AudioGbx
            // 
            AudioGbx.BackColor = Color.Transparent;
            AudioGbx.Controls.Add(label1);
            AudioGbx.Controls.Add(MusicAudioTbr);
            AudioGbx.Controls.Add(label2);
            AudioGbx.Controls.Add(MasterAudioTbr);
            AudioGbx.ForeColor = Color.FromArgb(128, 255, 255);
            AudioGbx.Location = new Point(12, 12);
            AudioGbx.Name = "AudioGbx";
            AudioGbx.Size = new Size(309, 177);
            AudioGbx.TabIndex = 4;
            AudioGbx.TabStop = false;
            AudioGbx.Text = "Audio:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = Color.FromArgb(128, 255, 255);
            label3.Location = new Point(18, 251);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 5;
            label3.Text = "Ship Designs:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Info;
            label4.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label4.Location = new Point(64, 329);
            label4.Name = "label4";
            label4.Size = new Size(234, 31);
            label4.TabIndex = 6;
            label4.Text = "Work in progress";
            // 
            // Options
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(333, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(AudioGbx);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Options";
            Text = "Options";
            ((System.ComponentModel.ISupportInitialize)MasterAudioTbr).EndInit();
            ((System.ComponentModel.ISupportInitialize)MusicAudioTbr).EndInit();
            AudioGbx.ResumeLayout(false);
            AudioGbx.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TrackBar MasterAudioTbr;
        private TrackBar MusicAudioTbr;
        private GroupBox AudioGbx;
        private Label label3;
        private Label label4;
    }
}