namespace CipherSink.Models.GameBoard;

/// <summary>
/// This class represents the game board for the Battleship game
/// It has a grid of cells and a list of ships.
/// It provides methods to initialize the grid, place ships, and to check cells
/// </summary>
internal class GameBoard
{
    /// <summary>
    /// The size of the game board, which is a square grid of cells.
    /// </summary>
    public const int BoardSize = 10;

    /// <summary>
    /// Gets the two-dimensional array representing the grid of cells.
    /// </summary>
    public Cell[,] Grid { get; init; }

    /// <summary>
    /// Read-only list of ships
    /// </summary>
    public IReadOnlyList<Ship> Ships { get; init; }

    /// <summary>
    /// Constructor to initialize the ships and the grid of cells.
    /// </summary>
    public GameBoard()
    {
        Grid = new Cell[BoardSize, BoardSize];
        InitializeGrid();
        Ships = new List<Ship>
        {
            new Carrier(),
            new Battleship(),
            new Cruiser(),
            new Submarine(),
            new Destroyer()
        }.AsReadOnly();
    }

    /// <summary>
    /// Loop through the grid and initialize each cell with its coordinates.
    /// </summary>
    private void InitializeGrid()
    {
        for (int y = 0; y < BoardSize; y++)
        {
            for (int x = 0; x < BoardSize; x++)
            {
                Grid[x, y] = new Cell(x, y);
            }
        }
    }

    /// <summary>
    /// Places a ship on the game board at the specified coordinates.
    /// Pre: The ship must not be null and the coordinates must be within bounds.
    /// </summary>
    /// <param name="ship">The ship we are trying to place on the board</param>
    /// <param name="x">the starting x coordinate of the ship</param>
    /// <param name="y">the starting y coordinate of the ship</param>
    /// <param name="vertical">boolean to track ship rotation</param>
    /// <returns>true if ship was placed; otherwise false</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public bool PlaceShip(Ship ship, int x, int y, bool vertical)
    {
        // check if ship is null
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship), "Ship cannot be null.");
        }

        // end coordinates based on orientation
        int endX = vertical ? x : x + ship.Size - 1;
        int endY = vertical ? y + ship.Size - 1 : y;

        // check start and end coordinates are within bounds
        if (x < 0 || endX >= BoardSize || y < 0 || endY >= BoardSize)
        {
            throw new ArgumentOutOfRangeException("Coordinates are out of bounds.");
        }

        // Check if the cells are already occupied
        for (int i = 0; i < ship.Size; i++)
        {
            int checkX = vertical ? x : x + i;
            int checkY = vertical ? y + i : y;
            if (Grid[checkX, checkY].IsOccupied)
            {
                return false; // Cannot place ship here
            }
        }

        // Place the ship on the grid and return true
        List<Coordinates> positions = new();
        for (int i = 0; i < ship.Size; i++)
        {
            int placeX = vertical ? x : x + i;
            int placeY = vertical ? y + i : y;
            Grid[placeX, placeY].OccupationType = ship.OccupationType;
            positions.Add(new Coordinates(placeX, placeY));
        }
        return ship.SetPositions(positions);
    }

    /// <summary>
    /// This method places ships randomly on the game board.
    /// If a ship cannot be placed after 1000 attempts, it throws an exception.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public void PlaceShipsRandomly()
    {
        var rand = new Random();
        foreach (var ship in Ships)
        {
            bool placed = false;
            int attempts = 0;
            while (!placed && attempts < 1000)
            {
                bool vertical = rand.Next(2) == 0;
                int x = vertical ? rand.Next(BoardSize) : rand.Next(BoardSize - ship.Size + 1);
                int y = vertical ? rand.Next(BoardSize - ship.Size + 1) : rand.Next(BoardSize);
                placed = PlaceShip(ship, x, y, vertical);
                attempts++;
            }
            if (!placed)
            {
                throw new InvalidOperationException($"Could not place ship: {ship.Name} after {attempts} attempts.");
            }
        }
    }
    /// <summary>
    /// This method locks all ships on the game board.
    /// It does this by calling the LockPositions method on each ship.
    /// if any ship fails to lock, it returns false.
    /// if a fail occurs, any ships that were successfully locked will remain locked.
    /// </summary>
    /// <returns>true if all ships are locked; false otherwise</returns>
    public bool LockShips() 
    {
        // Lock all ships to prevent further placement
        foreach (var ship in Ships)
        {
            if (!ship.IsLocked)
            {
                bool success = ship.LockPositions();
                if (!success)
                {
                    return false; // If any ship fails to lock, return false
                }
            }
        }

        return true; // All ships successfully locked
    }

    /// <summary>
    /// This method checks a cell for ship at the given coordinates.
    /// </summary>
    /// <param name="x">The x coordinate to check</param>
    /// <param name="y">The y coordinate to check</param>
    /// <returns>A CheckCellResult</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public CheckCellResult CheckCell(int x, int y)
    {
        // Check if coordinates are within bounds
        if (x < 0 || x >= BoardSize || y < 0 || y >= BoardSize)
        {
            return CheckCellResult.OutOfBounds;
        }

        if (!Grid[x, y].IsOccupied)
        {
            Grid[x, y].OccupationType = OccupationType.Miss; // Mark as Miss
            return CheckCellResult.Miss;
        }

        // Find the ship occupying this cell and register a hit
        Coordinates coord = new Coordinates(x, y);
        foreach (var ship in Ships)
        {
            if (ship.Positions.Any(pos => pos.Equals(coord)))
            {
                ship.RegisterHit(coord);
                Grid[x, y].OccupationType = OccupationType.Hit;
                return CheckCellResult.Hit; // Return Hit
            }
        }

        return CheckCellResult.Miss; // Should not reach here, but just in case
    }

    public override string ToString()
    {
        string PrettyGrid = "";

        for (int y = 0; y < BoardSize; y++)
        {
            for (int x = 0; x < BoardSize; x++)
            {
                PrettyGrid += Grid[x, y].ToString() + " ";
            }
            PrettyGrid += "\n";
        }

        return PrettyGrid;
    }
}
