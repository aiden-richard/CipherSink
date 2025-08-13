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

    public Action UpdateUI { get; set; }

    public Game(TcpPeer peer, LocalPlayer localPlayer)
    {
        Peer = peer;
        LocalPlayer = localPlayer;
        LocalPlayer.GameBoard = new Gameboard();
        RemotePlayer = new RemotePlayer();
        RemotePlayer.GameBoard = new Gameboard();
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
                        MessageBox.Show("Connection verified", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        State = GameState.PlaceShips;
                    }
                    else
                    {
                        State = GameState.Aborted;
                    }
                    
                    break;

                case GameState.PlaceShips:
                    return;
                    
                case GameState.WaitingOnOpponentReady:
                    // Logic for waiting on opponent
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
                    break;
            }
        }
    }
}
