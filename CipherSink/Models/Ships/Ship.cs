namespace CipherSink.Models.Ships;

/// <summary>
/// This class represents a ship on the game board.
/// </summary>
internal abstract class Ship
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Ship"/> class with the specified name, size, and occupation type.
    /// </summary>
    /// <param name="name">The name of the ship. Cannot be null or empty.</param>
    /// <param name="size">The size of the ship as an int, representing the number of cells it occupies.</param>
    /// <param name="occupation">The occupation type of the ship</param>
    protected Ship(string name, int size, OccupationType occupation)
    {
        Name = name;
        Size = size;
        Occupation = occupation;
    }

    /// <summary>
    /// The name of the ship, stored as a string
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// The size of the ship, which is the number of cells it occupies on the game board.
    /// </summary>
    public required int Size { get; init; }

    /// <summary>
    /// The occupation type of the ship, represented by the OccupationType enum.
    /// </summary>
    public OccupationType Occupation { get; init; }

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
    public void SetPositions(List<Coordinates> positions)
    {
        if (Positions.Count > 0)
        {
            throw new InvalidOperationException($"Positions have already been set for ship: {Name}");
        }

        if (positions.Count != Size)
        {
            throw new ArgumentException($"The number of positions must be equal to the size of the ship ({Size}).");
        }

        Positions = positions;
    }
}
