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
            EnemyPlayerTlp = new TableLayoutPanel();
            ActivePlayerTlp = new TableLayoutPanel();
            SuspendLayout();
            // 
            // TurnTrackerTbx
            // 
            TurnTrackerTbx.Location = new Point(578, 501);
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
            label1.Location = new Point(609, 477);
            label1.Name = "label1";
            label1.Size = new Size(45, 21);
            label1.TabIndex = 3;
            label1.Text = "Turn:";
            // 
            // EnemyPlayerTlp
            // 
            EnemyPlayerTlp.ColumnCount = 10;
            EnemyPlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.Location = new Point(12, 12);
            EnemyPlayerTlp.Name = "EnemyPlayerTlp";
            EnemyPlayerTlp.RowCount = 10;
            EnemyPlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.Size = new Size(450, 452);
            EnemyPlayerTlp.TabIndex = 4;
            // 
            // ActivePlayerTlp
            // 
            ActivePlayerTlp.ColumnCount = 10;
            ActivePlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.Location = new Point(12, 535);
            ActivePlayerTlp.Name = "ActivePlayerTlp";
            ActivePlayerTlp.RowCount = 10;
            ActivePlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            ActivePlayerTlp.Size = new Size(450, 452);
            ActivePlayerTlp.TabIndex = 5;
            // 
            // Gameboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(774, 1018);
            Controls.Add(ActivePlayerTlp);
            Controls.Add(EnemyPlayerTlp);
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
        private TableLayoutPanel EnemyPlayerTlp;
        private TableLayoutPanel ActivePlayerTlp;
    }
}