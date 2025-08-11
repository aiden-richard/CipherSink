namespace CipherSink.Models.GameLogic;

public enum GameState
{
    VerifyUser,
    PlaceShips,
    WaitingOnOpponentReady,
    LocalTurn,
    RemoteTurn,
    Finished,
    Aborted
}
