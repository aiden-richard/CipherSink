namespace CipherSink;

public partial class Gameboard : Form
{
    public Gameboard()
    {
        InitializeComponent();
        InitializeGrids();
    }

    private void InitializeGrids()
    {
        int gridSize = 10; // Example size
        SetupGrid(EnemyPlayerTlp, gridSize);
        SetupGrid(ActivePlayerTlp, gridSize);
    }

    private void SetupGrid(TableLayoutPanel grid, int size)
    {
        grid.RowCount = size;
        grid.ColumnCount = size;
        grid.Controls.Clear();
        grid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

        for (int row = 0; row < size; row++)
        {
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / size));
            for (int col = 0; col < size; col++)
            {
                if (row == 0) grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / size));
                var cellPanel = new Panel
                {
                    BackColor = Color.Navy,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(1),
                    Tag = new Point(row, col) // Store position for event handler
                };
                cellPanel.Click += GridCell_Click;
                grid.Controls.Add(cellPanel, col, row);
            }
        }
    }

    private void GridCell_Click(object sender, EventArgs e)
    {
        var panel = sender as Panel;
        var pos = (Point)panel.Tag;
        // TODO: Interact with your Models/Gameboard classes here
        panel.BackColor = Color.Red; // Example: change color on click
    }

}
