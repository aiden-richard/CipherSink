namespace CipherSink.Models.GameBoard;

/// <summary>
/// CheckCellResult enumeration represents the result of checking a cell in the game board.
/// </summary>
public enum CheckCellResult
{
    Hit,
    Miss,
    OutOfBounds
}

/// <summary>
/// Enumeration representing the occupation type of a cell in the grid.
/// </summary>
public enum OccupationType
{
    Carrier,

    Battleship,

    Cruiser,

    Submarine,

    Destroyer,

    Empty,

    Hit,

    Miss
}