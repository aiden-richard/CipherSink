namespace CipherSink.Models.GameBoard;

/// <summary>
/// This class represents a pair of coordinates (X, Y).
/// </summary>
public class Coordinates
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

    /// <summary>
    /// Determines whether the specified object is equal to the current Coordinates instance
    /// by checking first that the object is of type Coordinates, then comparing the X and Y values.
    /// </summary>
    /// <param name="obj">Other Object to compare to</param>
    /// <returns>true if objects are equal</returns>
    public override bool Equals(object? obj)
    {
        if (obj is Coordinates other)
        {
            return X == other.X && Y == other.Y;
        }
        return false;
    }

    /// <summary>
    /// Returns a hash code for this instance. Necessary to ensure that objects considered equal
    /// by Equals have the same hash code, which is required for correct behavior in hash-based collections.
    /// 
    /// For example, if we keep a hashset called hits to track which cells of a ship have been hit, we need
    /// to ensure that Coordinates objects with the same X and Y values have the same hash code.
    /// </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}
