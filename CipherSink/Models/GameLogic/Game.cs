using CipherSink.Models.Cryptography;
using CipherSink.Models.Database.Entities;
using CipherSink.Models.Networking;

namespace CipherSink.Models.GameLogic;

public class Game
{
    public int Id { get; set; }

    private TcpPeer Peer { get; set; }

    public LocalPlayer LocalPlayer { get; set; }

    public RemotePlayer RemotePlayer { get; set; }

    public GameState State { get; set; } = GameState.VerifyUser;

    public Action? UpdateUI { get; set; }

    public Game(TcpPeer peer, LocalPlayer localPlayer)
    {
        Peer = peer;
        LocalPlayer = localPlayer;
        RemotePlayer = new RemotePlayer();
    }

    // TCS used to await user confirmation of ship placements
    // initialized to null, set in the PlaceShips state
    private TaskCompletionSource<bool>? _placementReadyTcs;

    /// <summary>
    /// This method is called by the UI to indicate that the user has finished placing ships
    /// It sets the TaskCompletionSource to allow the game loop to continue.
    /// </summary>
    public void AcceptShipPlacements()
    {
        _placementReadyTcs?.TrySetResult(true);
    }

    public async Task Start()
    {
        if (UpdateUI == null)
        {
            throw new Exception("UpdateUI action must be set before starting the game.");
        }

        while (State != GameState.Finished)
        {
            UpdateUI.Invoke();

            switch (State)
            {
                case GameState.VerifyUser:
                    if (Peer.IsHost)
                    {
                        await Peer.TryAcceptConnection();
                        await Peer.ExchangeKeys();
                        await Peer.ValidateConnection();
                    }
                    else
                    {
                        await Peer.TryConnect();
                        await Peer.ExchangeKeys();
                        await Peer.ValidateConnection();
                    }

                    if (Peer.ConnectionVerified)
                    {
                        RemotePlayer.PublicKeyBytes = Peer.PeerPublicKeyBytes;
                        State = GameState.PlaceShips;
                    }
                    else
                    {
                        State = GameState.Aborted;
                    }

                    break;

                case GameState.PlaceShips:
                    // Show placement UI via UpdateUI; then await the user's acceptance.
                    if (_placementReadyTcs is null || _placementReadyTcs.Task.IsCompleted)
                    {
                        _placementReadyTcs = new(TaskCreationOptions.RunContinuationsAsynchronously);
                    }

                    try
                    {
                        await _placementReadyTcs.Task; // Wait until AcceptShipPlacements() is called by the UI
                        LocalPlayer.Gameboard.LockShips();
                        State = GameState.WaitingOnOpponentReady; // Proceed to waiting for opponent readiness
                    }
                    catch (TaskCanceledException)
                    {
                        State = GameState.Aborted;
                    }
                    catch (Exception)
                    {
                        State = GameState.Aborted;
                    }

                    break;

                case GameState.WaitingOnOpponentReady:
                    if (Peer.IsHost)
                    {
                        await Peer.SendMerkleRoot(LocalPlayer.Gameboard.MerkleTree.RootHash);
                        RemotePlayer.MerkleValidator = await Peer.ReceiveMerkleRoot();
                    }
                    else
                    {
                        RemotePlayer.MerkleValidator = await Peer.ReceiveMerkleRoot();
                        await Peer.SendMerkleRoot(LocalPlayer.Gameboard.MerkleTree.RootHash);
                    }
                    break;

                case GameState.LocalTurn:
                    // Logic for local player's turn
                    break;
                case GameState.RemoteTurn:
                    // Logic for remote player's turn
                    break;
                case GameState.Finished:
                    // Logic for finishing the game
                    break;
                case GameState.Aborted:
                    MessageBox.Show("Game aborted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
        }
    }
}
