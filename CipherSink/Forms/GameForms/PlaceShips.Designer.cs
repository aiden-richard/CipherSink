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
            LayoutPanelPlaceShips = new TableLayoutPanel();
            BtnRandomizePositions = new Button();
            BtnReady = new Button();
            LabelWaitingForConnection = new Label();
            SuspendLayout();
            // 
            // LayoutPanelPlaceShips
            // 
            LayoutPanelPlaceShips.AutoSize = true;
            LayoutPanelPlaceShips.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            LayoutPanelPlaceShips.ColumnCount = 10;
            LayoutPanelPlaceShips.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.Location = new Point(44, 9);
            LayoutPanelPlaceShips.Margin = new Padding(0);
            LayoutPanelPlaceShips.Name = "LayoutPanelPlaceShips";
            LayoutPanelPlaceShips.RowCount = 10;
            LayoutPanelPlaceShips.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            LayoutPanelPlaceShips.Size = new Size(522, 522);
            LayoutPanelPlaceShips.TabIndex = 5;
            LayoutPanelPlaceShips.Visible = false;
            // 
            // BtnRandomizePositions
            // 
            BtnRandomizePositions.Location = new Point(149, 546);
            BtnRandomizePositions.Name = "BtnRandomizePositions";
            BtnRandomizePositions.Size = new Size(139, 53);
            BtnRandomizePositions.TabIndex = 6;
            BtnRandomizePositions.Text = "Randomize Placements";
            BtnRandomizePositions.UseVisualStyleBackColor = true;
            BtnRandomizePositions.Visible = false;
            BtnRandomizePositions.Click += BtnRandomizePositions_Click;
            // 
            // BtnReady
            // 
            BtnReady.Location = new Point(311, 546);
            BtnReady.Name = "BtnReady";
            BtnReady.Size = new Size(139, 53);
            BtnReady.TabIndex = 7;
            BtnReady.Text = "Ready!";
            BtnReady.UseVisualStyleBackColor = true;
            BtnReady.Visible = false;
            BtnReady.Click += BtnReady_Click;
            // 
            // LabelWaitingForConnection
            // 
            LabelWaitingForConnection.AutoSize = true;
            LabelWaitingForConnection.Font = new Font("Segoe UI Semibold", 32F, FontStyle.Bold);
            LabelWaitingForConnection.ForeColor = Color.White;
            LabelWaitingForConnection.Location = new Point(55, 157);
            LabelWaitingForConnection.Name = "LabelWaitingForConnection";
            LabelWaitingForConnection.Size = new Size(511, 59);
            LabelWaitingForConnection.TabIndex = 8;
            LabelWaitingForConnection.Text = "Waiting for Connection...";
            // 
            // PlaceShips
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkBlue;
            ClientSize = new Size(610, 617);
            Controls.Add(LabelWaitingForConnection);
            Controls.Add(BtnReady);
            Controls.Add(BtnRandomizePositions);
            Controls.Add(LayoutPanelPlaceShips);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "PlaceShips";
            Text = "PlaceShips";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel LayoutPanelPlaceShips;
        private Button BtnRandomizePositions;
        private Button BtnReady;
        private Label LabelWaitingForConnection;
    }
}