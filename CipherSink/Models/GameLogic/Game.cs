namespace CipherSink.Models.GameLogic;

internal class Game
{
    public int Id { get; set; }

    public Player LocalPlayer { get; set; }

    public Player? RemotePlayer { get; set; }

    public GameState State { get; set; }

    public required bool IsHost { get; set; }

    public required Action UpdateUI { get; set; }

    public Game(Player localPlayer, bool isHost, Action updateUI)
    {
        LocalPlayer = localPlayer;
        IsHost = isHost;
        UpdateUI = updateUI;
    }

    public void Start()
    {
        while (State != GameState.Finished)
        {
            switch (State)
            {
                case GameState.VerifyUser:
                    // Logic for verifying user
                    break;
                case GameState.PlaceShips:
                    // Logic for placing ships
                    break;
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
                    // Logic for aborting the game
                    break;
            }

            UpdateUI.Invoke();
        }
    }
}
