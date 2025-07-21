namespace CipherSink
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            listBox1 = new ListBox();
            TitleLbl = new Label();
            QuoteLbl = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(157, 119);
            button1.Name = "button1";
            button1.Size = new Size(160, 44);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(14, 196);
            button2.Name = "button2";
            button2.Size = new Size(146, 49);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(157, 377);
            button3.Name = "button3";
            button3.Size = new Size(160, 44);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(314, 196);
            button4.Name = "button4";
            button4.Size = new Size(132, 49);
            button4.TabIndex = 3;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(14, 280);
            button5.Name = "button5";
            button5.Size = new Size(146, 48);
            button5.TabIndex = 4;
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(326, 300);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(120, 94);
            listBox1.TabIndex = 5;
            // 
            // TitleLbl
            // 
            TitleLbl.AutoSize = true;
            TitleLbl.Font = new Font("Impact", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TitleLbl.Location = new Point(98, 42);
            TitleLbl.Name = "TitleLbl";
            TitleLbl.Size = new Size(265, 60);
            TitleLbl.TabIndex = 6;
            TitleLbl.Text = "CipherSunk";
            // 
            // QuoteLbl
            // 
            QuoteLbl.AutoSize = true;
            QuoteLbl.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            QuoteLbl.Location = new Point(12, 166);
            QuoteLbl.Name = "QuoteLbl";
            QuoteLbl.Size = new Size(224, 29);
            QuoteLbl.TabIndex = 7;
            QuoteLbl.Text = "You cracked my code!";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 450);
            Controls.Add(QuoteLbl);
            Controls.Add(TitleLbl);
            Controls.Add(listBox1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Main";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private ListBox listBox1;
        private Label TitleLbl;
        private Label QuoteLbl;
    }
}
