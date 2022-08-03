using Configs;

namespace Core.Turns
{
    public interface ITurnsProvider
    {
        PlayerID CurrentPlayerID { get; }
        TurnData CurrentTurnData { get; }
        int TurnNumber { get; }
        bool IsSmallDiceAvailable { get; }
        bool IsLargeDiceAvailable { get; }
    }
}