namespace CipherSink.Models.GameLogic;

internal enum GameState
{
    VerifyUser,
    PlaceShips,
    WaitingOnOpponentReady,
    LocalTurn,
    RemoteTurn,
    AwaitShotResult,
    Finished,
    Aborted
}
