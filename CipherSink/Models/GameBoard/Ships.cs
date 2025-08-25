namespace CipherSink.Models.GameBoard;

/// <summary>
/// This class represents a ship on the game board.
/// </summary>
public abstract class Ship
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Ship"/> class with the specified name, size, and occupation type.
    /// </summary>
    /// <param name="name">The name of the ship. Cannot be null or empty.</param>
    /// <param name="size">The size of the ship as an int, representing the number of cells it occupies.</param>
    /// <param name="occupation">The occupation type of the ship</param>
    protected Ship(string name, int size, OccupationType occupationType)
    {
        Name = name;
        Size = size;
        OccupationType = occupationType;
    }

    /// <summary>
    /// The name of the ship, stored as a string
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// The size of the ship, which is the number of cells it occupies on the game board.
    /// </summary>
    public int Size { get; init; }

    /// <summary>
    /// The occupation type of the ship, represented by the OccupationType enum.
    /// </summary>
    public OccupationType OccupationType { get; init; }

    /// <summary>
    /// A list of coordinates representing the positions occupied by the ship on the game board.
    /// </summary>
    public IReadOnlyList<Coordinates> Positions { get; protected set; } = new List<Coordinates>();

    /// <summary>
    /// A HashSet of coordinates representing the cells of the ship that have been hit
    /// </summary>
    private readonly HashSet<Coordinates> Hits = new();

    /// <summary>
    /// public property to access the hit positions of the ship.
    /// </summary>
    public IReadOnlyCollection<Coordinates> HitPositions => Hits;

    /// <summary>
    /// boolean indicating whether the ship is sunk or not.
    /// if the number of hits equals the size of the ship, it is considered sunk.
    /// </summary>
    public bool IsSunk => Hits.Count == Size;

    public bool IsLocked { get; protected set; } = false;

    /// <summary>
    /// Adds a coordinate to Hits if it is a valid position of the ship.
    /// </summary>
    /// <param name="coordinates"></param>
    public void RegisterHit(Coordinates coordinates)
    {
        if (Positions.Contains(coordinates))
        {
            Hits.Add(coordinates);
        }
    }

    /// <summary>
    /// Sets the positions of the ship on the game board.
    /// </summary>
    /// <param name="positions">The list of coordinates the ship is placed at</param>
    public bool SetPositions(List<Coordinates> positions)
    {
        if (positions == null)
        {
            throw new ArgumentNullException(nameof(positions), "Positions cannot be null.");
        }

        if (positions.Count != Size)
        {
            throw new ArgumentException($"The number of positions must be equal to the size of the ship ({Size}).");
        }

        if (IsLocked)
        {
            return false;
        }

        Positions = new List<Coordinates>(positions).AsReadOnly();
        return true;
    }

    /// <summary>
    /// Locks the current positions by setting the IsLocked property to true.
    /// The SetPositions method uses this property to determine if the ship's positions can be changed.
    /// If there are no positions to lock, it returns false.
    /// </summary>
    /// <returns><see langword="true"/> if the positions were successfully locked; otherwise, <see langword="false"/> if there
    /// are no positions to lock.</returns>
    public bool LockPositions()
    {
        if (Positions.Count == 0)
        {
            return false;
        }

        IsLocked = true;
        return true;
    }

    /// <summary>
    /// Locks the ship's positions by first setting the positions using SetPositions.
    /// </summary>
    /// <param name="positions">The list of positions that the method tries to set and lock</param>
    /// <returns><see langword="true"/> if the positions were successfully set and locked; otherwise, <see langword="false"/> if the positions could not be set or locked.</returns>
    public bool LockPositions(List<Coordinates> positions)
    {
        if (SetPositions(positions))
        {
            return LockPositions();
        }

        return false;
    }
}


internal class Carrier : Ship
{
    public Carrier() : base("Carrier", 5, OccupationType.Carrier) { }
}

internal class Battleship : Ship
{
    public Battleship() : base("Battleship", 4, OccupationType.Battleship) { }
}

internal class Cruiser : Ship
{
    public Cruiser() : base("Cruiser", 3, OccupationType.Cruiser) { }
}

internal class Submarine : Ship
{
    public Submarine() : base("Submarine", 3, OccupationType.Submarine) { }
}

internal class Destroyer : Ship
{
    public Destroyer() : base("Destroyer", 2, OccupationType.Destroyer) { }
}