using CipherSink.Models.Cryptography;
using CipherSink.Models.Cryptography.MerkleTree;
using CipherSink.Models.Database.Entities;
using CipherSink.Models.GameBoard;
using CipherSink.Models.Networking;
using System.IO; // added for MemoryStream
using System.Text; // added for Encoding

namespace CipherSink.Models.GameLogic;

public class Game
{
    public int Id { get; set; }
    private TcpPeer Peer { get; set; }
    public LocalPlayer LocalPlayer { get; set; }
    public RemotePlayer RemotePlayer { get; set; }

    public GameState State { get; private set; } = GameState.VerifyUser;

    // Optional async UI update delegate
    public Func<Task>? UpdateUIAsync { get; set; }

    // TCS for waiting on user ship placement confirmation
    private TaskCompletionSource<bool>? _placementReadyTcs;

    // TCS for waiting on user attack confirmation
    private TaskCompletionSource<Coordinates>? _attackEnemyTcs;

    public string StatusMessage;

    public Game(TcpPeer peer, LocalPlayer localPlayer)
    {
        Peer = peer;
        LocalPlayer = localPlayer;
        RemotePlayer = new RemotePlayer();
    }

    /// <summary>
    /// Called by UI when player finishes placing ships.
    /// </summary>
    public void AcceptShipPlacements() => _placementReadyTcs?.TrySetResult(true);

    /// <summary>
    /// Called by UI when player finishes placing ships.
    /// </summary>
    public void AcceptAttackOnEnemyCell(Coordinates coords) => _attackEnemyTcs?.TrySetResult(coords);

    /// <summary>
    /// Main game loop. Runs until Finished or Aborted.
    /// </summary>
    public async Task Start()
    {
        if (UpdateUIAsync == null)
            throw new InvalidOperationException("UpdateUIAsync must be set before starting the game.");

        while (State is not GameState.Finished and not GameState.Aborted)
        {
            await UpdateUIAsync();

            switch (State)
            {
                case GameState.VerifyUser:
                    await RunVerifyUserAsync();
                    break;
                case GameState.PlaceShips:
                    await RunPlaceShipsAsync();
                    break;
                case GameState.WaitingOnOpponentReady:
                    await RunWaitingOnOpponentReadyAsync();
                    break;
                case GameState.LocalTurn:
                    await RunLocalTurnAsync();
                    break;
                case GameState.RemoteTurn:
                    await RunRemoteTurnAsync();
                    break;
            }
        }

        // One last UI update for terminal state
        await UpdateUIAsync();
    }

    private async Task RunVerifyUserAsync()
    {
        try
        {
            bool connected = Peer.IsHost
                ? await Peer.TryAcceptConnection()
                : await Peer.TryConnect();

            if (!connected)
            {
                State = GameState.Aborted;
                return;
            }

            await Peer.ExchangeKeys();
            bool validated = await Peer.ValidateConnection();
            if (!validated || !Peer.ConnectionVerified)
            {
                State = GameState.Aborted;
                return;
            }

            RemotePlayer.PublicKeyBytes = Peer.PeerPublicKeyBytes!;
            State = GameState.PlaceShips;
        }
        catch
        {
            State = GameState.Aborted;
        }
    }

    private async Task RunPlaceShipsAsync()
    {
        // Set / reset TCS if needed (AI added this but I see no reason to delete)
        if (_placementReadyTcs is null || _placementReadyTcs.Task.IsCompleted)
            _placementReadyTcs = new(TaskCreationOptions.RunContinuationsAsynchronously);

        try
        {
            await _placementReadyTcs.Task; // wait for AcceptShipPlacements
            LocalPlayer.Gameboard.LockShips();
            State = GameState.WaitingOnOpponentReady;
        }
        catch
        {
            State = GameState.Aborted;
        }
    }

    private async Task RunWaitingOnOpponentReadyAsync()
    {
        try
        {
            await Peer.SendMessage(LocalPlayer.Gameboard.MerkleTree.RootHash);
            byte[] rootHash = await Peer.ReceiveMessage();
            RemotePlayer.MerkleValidator = new MerkleValidator(rootHash);
            State = Peer.IsHost ? GameState.LocalTurn : GameState.RemoteTurn;
            StatusMessage = Peer.IsHost ? "Your Turn..." : "Opponent's Turn...";
        }
        catch
        {
            State = GameState.Aborted;
        }
    }

    // For now these turn handlers just yield control; extend later with real logic
    private async Task RunLocalTurnAsync()
    {
        // Set / reset TCS if needed
        if (_attackEnemyTcs is null || _attackEnemyTcs.Task.IsCompleted)
            _attackEnemyTcs = new(TaskCreationOptions.RunContinuationsAsynchronously);

        Coordinates attackCell = await _attackEnemyTcs.Task;

        await Peer.SendMessage(new byte[] { (byte)attackCell.X, (byte)attackCell.Y });

        // Receive response with proof from opponent
        try
        {
            byte[] response = await Peer.ReceiveMessage();
            if (response.Length < 1)
            {
                State = GameState.Aborted;
                return;
            }

            int index = 0;
            int x = response[index++];
            int y = response[index++];
            var result = (CheckCellResult)response[index++];
            int saltLen = response[index++];
            if (index + saltLen > response.Length) { State = GameState.Aborted; return; }
            byte[] salt = response.Skip(index).Take(saltLen).ToArray();
            index += saltLen;
            int proofCount = response[index++];
            List<MerkleProofElement> proof = new();
            for (int i = 0; i < proofCount; i++)
            {
                if (index + 32 + 1 > response.Length) { State = GameState.Aborted; return; }
                byte[] hash = response.Skip(index).Take(32).ToArray();
                index += 32;
                bool isLeft = response[index++] == 1;
                proof.Add(new MerkleProofElement(hash, isLeft));
            }
            int cellDataLen = response[index++];
            if (index + cellDataLen > response.Length) { State = GameState.Aborted; return; }
            string cellDataString = Encoding.UTF8.GetString(response, index, cellDataLen);
            index += cellDataLen;

            // Validate proof
            bool valid = RemotePlayer.MerkleValidator?.Validate(cellDataString, salt, proof) ?? false;
            if (!valid)
            {
                State = GameState.Aborted; // invalid proof
                return;
            }

            // Update remote board knowledge (optional simple mark)
            // Parse occupancy from cellDataString pattern: "(x, y):X" or ":O"
            bool occupied = cellDataString.EndsWith(":X");
            if (x >= 0 && x < Gameboard.BoardSize && y >= 0 && y < Gameboard.BoardSize)
            {
                RemotePlayer.Gameboard.Grid[x, y].OccupationType = occupied ? OccupationType.Hit : OccupationType.Miss;
                if (occupied)
                    RemotePlayer.Gameboard.HitCounter++;
                StatusMessage = occupied ? "Hit! Waiting for Opponent's Turn..." : "Miss! Waiting for Opponents Turn...";
            }

            if (GameOver())
            {
                StatusMessage = "You Win!";
                State = GameState.Finished;
            }
            else
            {
                State = GameState.RemoteTurn;
            }
        }
        catch
        {
            State = GameState.Aborted;
        }
    }

    private async Task RunRemoteTurnAsync()
    {
        try
        {
            byte[] attackedCellCoordinates = await Peer.ReceiveMessage();
            if (attackedCellCoordinates.Length < 2)
            {
                State = GameState.Aborted; // malformed
                return;
            }

            int x = attackedCellCoordinates[0];
            int y = attackedCellCoordinates[1];
            var coords = new Coordinates(x, y);

            var attackResult = LocalPlayer.Gameboard.CheckCell(coords);
            if (attackResult == CheckCellResult.Hit)
            {
                LocalPlayer.Gameboard.Grid[x, y].OccupationType = OccupationType.Hit;
            }
            else if (attackResult == CheckCellResult.Miss)
            {
                LocalPlayer.Gameboard.Grid[x, y].OccupationType = OccupationType.Miss;
            }

            StatusMessage = attackResult == CheckCellResult.Hit ? "Opponent Hit! Your Turn..." : "Opponent Missed! Your Turn...";

            // Build cell data string exactly as original Merkle tree leaf construction
            // Original leaf format: $"{cell.Coordinates}:{(cell.IsOccupied ? "X" : "O")}" where IsOccupied tests ship presence (not Miss/Empty)
            var cell = LocalPlayer.Gameboard.Grid[x, y];
            string cellDataString = $"{cell.Coordinates}:{(cell.IsOccupied ? "X" : "O")}";

            var tree = LocalPlayer.Gameboard.MerkleTree ?? throw new InvalidOperationException("Merkle tree not built.");
            byte[] salt = tree.GetSalt(coords);
            List<MerkleProofElement> proofPath = tree.ConstructMerkleProof(coords);

            // Serialize response:
            // [x][y][attackResult][saltLen][salt bytes][proofCount][ each: 32 hash bytes + 1 isLeft ][cellDataLen][cellDataString bytes]
            // All length/count fields 1 byte (sufficient for current data sizes)
            byte[] cellDataBytes = Encoding.UTF8.GetBytes(cellDataString);
            if (cellDataBytes.Length > byte.MaxValue || salt.Length > byte.MaxValue || proofPath.Count > byte.MaxValue)
                throw new InvalidOperationException("Serialized component too large.");

            using MemoryStream ms = new();
            ms.WriteByte((byte)x);
            ms.WriteByte((byte)y);
            ms.WriteByte((byte)attackResult);
            ms.WriteByte((byte)salt.Length);
            ms.Write(salt, 0, salt.Length);
            ms.WriteByte((byte)proofPath.Count);
            foreach (var pe in proofPath)
            {
                // Hash assumed SHA-256 (32 bytes)
                if (pe.Hash.Length != 32)
                    throw new InvalidOperationException("Unexpected hash length in proof element.");
                ms.Write(pe.Hash, 0, pe.Hash.Length);
                ms.WriteByte(pe.IsLeft ? (byte)1 : (byte)0);
            }
            ms.WriteByte((byte)cellDataBytes.Length);
            ms.Write(cellDataBytes, 0, cellDataBytes.Length);

            await Peer.SendMessage(ms.ToArray());

            // After responding with proof, check win or switch turn
            if (GameOver())
            {
                StatusMessage = "You Lose!";
                State = GameState.Finished;
            }
            else
            {
                State = GameState.LocalTurn;
            }
        }
        catch
        {
            State = GameState.Aborted;
        }
    }

    public bool GameOver()
    {
        return LocalPlayer.Gameboard.Ships.All(s => s.IsSunk) || RemotePlayer.Gameboard.HitCounter >= 17;
    }
}
