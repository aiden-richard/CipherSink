namespace CipherSink.Forms.GameForms
{
    partial class PlaceShips
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
            EnemyPlayerTlp = new TableLayoutPanel();
            SuspendLayout();
            // 
            // EnemyPlayerTlp
            // 
            EnemyPlayerTlp.ColumnCount = 11;
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
            EnemyPlayerTlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.Location = new Point(49, 12);
            EnemyPlayerTlp.Name = "EnemyPlayerTlp";
            EnemyPlayerTlp.RowCount = 11;
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
            EnemyPlayerTlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            EnemyPlayerTlp.Size = new Size(512, 512);
            EnemyPlayerTlp.TabIndex = 5;
            // 
            // PlaceShips
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(610, 610);
            Controls.Add(EnemyPlayerTlp);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "PlaceShips";
            Text = "PlaceShips";
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel EnemyPlayerTlp;
    }
}