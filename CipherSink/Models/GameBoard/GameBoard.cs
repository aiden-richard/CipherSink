using CipherSink.Models.Cryptography.MerkleTree;

namespace CipherSink.Models.GameBoard;

/// <summary>
/// This class represents the game board for the Battleship game
/// It has a grid of cells and a list of ships.
/// It provides methods to initialize the grid, place ships, and to check cells
/// </summary>
public class Gameboard
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
    /// Gets the Merkle tree associated with the current instance.
    /// The Tree gets created after all ships are locked.
    /// This is null if the gameboard belongs to the RemotePlayer class
    /// </summary>
    public MerkleTree? MerkleTree { get; set; }

    /// <summary>
    /// Read-only list of ships
    /// </summary>
    public IReadOnlyList<Ship> Ships { get; init; }

    /// <summary>
    /// Constructor to initialize the ships and the grid of cells.
    /// </summary>
    public Gameboard()
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

        foreach (var cell in ship.Positions)
        {
            Grid[cell.X, cell.Y].OccupationType = OccupationType.Empty; // Clear previous positions
        }

        // end coordinates based on orientation
        int endX = vertical ? x : x + ship.Size - 1;
        int endY = vertical ? y + ship.Size - 1 : y;

        // check start coordinates are within bounds of board
        if (x < 0 || x >= BoardSize || y < 0 || y >= BoardSize)
        {
            throw new ArgumentOutOfRangeException("Coordinates are out of bounds.");
        }

        // check end coordinates are within not less than 0
        // throw exception if they are because it should not be possible to place a ship in this direction
        if (endX < 0 || endY < 0)
        {
            throw new ArgumentOutOfRangeException("Ship extends beyond the bounds of the board.");
        }

        // check if end coordinates are within the positive bounds of board
        // return false rather than throw exception because it is possible to place a ship in this direction
        // a user might try to click the bottom or right edge of the board and this should not throw an exception
        if (endX >= BoardSize || endY >= BoardSize)
        {
            return false; // Ship extends beyond the bounds of the board
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
    public void RandomizeShipPositions()
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
    /// If any ship fails to lock, it returns false.
    /// If a fail occurs, any ships that were successfully locked will remain locked.
    /// </summary>
    /// <returns><see langword="true"/> if all ships are locked; <see langword="false"/> otherwise</returns>
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

        MerkleTree = new MerkleTree(Grid);
        return true; // All ships successfully locked
    }

    /// <summary>
    /// Checks a cell for a ship at the given coordinates.
    /// </summary>
    /// <param name="coordinates">The coordinates to check.</param>
    /// <returns>A CheckCellResult indicating Hit, Miss, or OutOfBounds.</returns>
    public CheckCellResult CheckCell(Coordinates coordinates)
    {
        if (coordinates is null)
        {
            throw new ArgumentNullException(nameof(coordinates));
        }

        int x = coordinates.X;
        int y = coordinates.Y;

        if (x < 0 || x >= BoardSize || y < 0 || y >= BoardSize)
        {
            return CheckCellResult.OutOfBounds;
        }

        if (!Grid[x, y].IsOccupied)
        {
            Grid[x, y].OccupationType = OccupationType.Miss;
            return CheckCellResult.Miss;
        }

        foreach (var ship in Ships)
        {
            if (ship.Positions.Any(pos => pos.Equals(coordinates)))
            {
                ship.RegisterHit(coordinates);
                Grid[x, y].OccupationType = OccupationType.Hit;
                return CheckCellResult.Hit;
            }
        }

        return CheckCellResult.Miss;
    }

    public void FillTableLayoutPanel(TableLayoutPanel TLP)
    {
        for (int row = 0; row < TLP.RowCount; row++)
        {
            for (int col = 0; col < TLP.ColumnCount; col++)
            {
                // Get panel at the current position
                var cellPanel = TLP.GetControlFromPosition(col, row);

                if (cellPanel == null)
                {
                    cellPanel = new Panel();
                    TLP.Controls.Add(cellPanel, col, row);
                }


                if (Grid[col, row].OccupationType == OccupationType.Hit)
                {
                    cellPanel.BackColor = Color.Red; // Hit
                }
                else if (Grid[col, row].IsOccupied)
                {
                    cellPanel.BackColor = Color.Gray;
                }
                else
                {
                    cellPanel.BackColor = Color.Transparent; // Empty cell
                }
            }
        }
    }
}
