namespace CipherSink.Models.GameLogic;

internal enum GameState
{
    VerifyUser,
    PlaceShips,
    WaitingOnOpponentReady,
    LocalTurn,
    RemoteTurn,
    Finished,
    Aborted
}
