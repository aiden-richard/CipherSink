namespace CipherSink.Models.GameBoard;

/// <summary>
/// This class represents a cell in the grid.
/// It contains the coordinates of the cell and its occupation type.
/// Coordinates are represented by the Coordinates class.
/// OccupationType is represented by the OccupationType enum.
/// </summary>
internal class Cell
{
    /// <summary>
    /// Coordinates of the cell in the grid.
    /// Stored as an instance of the Coordinates class.
    /// </summary>
    public Coordinates Coordinates { get; init; }

    /// <summary>
    /// Occupation type of the cell.
    /// Stored as an instance of the OccupationType enum.
    /// </summary>
    public OccupationType OccupationType { get; set; }

    /// <summary>
    /// Constructor to initialize the cell with given coordinates.
    /// Occupation type is set to Empty by default.
    /// </summary>
    /// <param name="x">The x coordinate of the cell</param>
    /// <param name="y">The y coordinate of the cell</param>
    public Cell(int x, int y)
    {
        Coordinates = new Coordinates(x, y);
        OccupationType = OccupationType.Empty;
    }

    /// <summary>
    /// Determines whether the cell is occupied
    /// Returns true if the occupation type is not Empty or Miss.
    /// </summary>
    public bool IsOccupied
    {
        get {
            return OccupationType != OccupationType.Empty
                && OccupationType != OccupationType.Miss;
        }
    }
}
