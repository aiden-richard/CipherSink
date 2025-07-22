using System.ComponentModel;

namespace CipherSink.Models;

/// <summary>
/// CheckCellResult enumeration represents the result of checking a cell in the game board.
/// </summary>
internal enum CheckCellResult
{
    Hit,
    Miss,
    OutOfBounds
}

/// <summary>
/// Enumeration representing the occupation type of a cell in the grid.
/// For now it only has three values: Empty, Hit, and Miss. Once Ships are implemented,
/// we can add more values to this enum.
/// </summary>
internal enum OccupationType
{
    [Description("C")]
    Carrier,

    [Description("B")]
    Battleship,

    [Description("C")]
    Cruiser,

    [Description("S")]
    Submarine,

    [Description("D")]
    Destroyer,

    [Description("O")]
    Empty,

    [Description("X")]
    Hit,

    [Description("M")]
    Miss
}