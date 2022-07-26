using System;

namespace Configs
{
    [Serializable]
    public struct TurnData
    {
        public int MaxDurationMs;
        public int SmallDiceUseRate;
        public int LargeDiceUseRate;
    }
    
    [Serializable]
    public struct PlayerTurnData
    {
        public PlayerID _playerID;
        public TurnData TurnData;
    }
}