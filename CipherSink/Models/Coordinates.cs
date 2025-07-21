namespace CipherSink.Models;

/// <summary>
/// This class represents a pair of coordinates (X, Y).
/// </summary>
internal class Coordinates
{
    /// <summary>
    /// The X coordinate.
    /// </summary>
    public int X { get; init; }

    /// <summary>
    /// The Y coordinate.
    /// </summary>
    public int Y { get; init; }

    /// <summary>
    /// Constructor to initialize the coordinates with given values.
    /// </summary>
    /// <param name="x">The x value to be set</param>
    /// <param name="y">The y value to be set</param>
    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Provides a string representation of the coordinates in the format "(X, Y)".
    /// </summary>
    /// <returns>A string representation of the coordinates in the the format (X, Y)</returns>
    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}
