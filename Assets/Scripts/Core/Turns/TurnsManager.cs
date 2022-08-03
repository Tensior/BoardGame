using System.Collections.Generic;
using System.Linq;
using Configs;

namespace Core.Turns
{
    public class TurnsManager : ITurnsProvider, ITurnsController
    {
        private readonly TurnsConfigSO _turnsConfig;
        
        private readonly IEnumerator<PlayerID> _turns;
        private bool _isSmallDiceAvailable;
        private bool _isLargeDiceAvailable;

        public PlayerID CurrentPlayerID => _turns.Current;

        public TurnData CurrentTurnData =>
            _turnsConfig.PlayerTurnData.Find(t => t._playerID == _turns.Current).TurnData;

        public int TurnNumber { get; private set; }

        public bool IsSmallDiceAvailable => TurnNumber % CurrentTurnData.SmallDiceUseRate == 0;

        public bool IsLargeDiceAvailable => TurnNumber % CurrentTurnData.LargeDiceUseRate == 0;

        public TurnsManager(TurnsConfigSO turnsConfig)
        {
            _turnsConfig = turnsConfig;
            _turns = turnsConfig.PlayerTurnData.Select(t => t._playerID).ToList().GetEnumerator();
            TurnNumber = 1;
        }

        public void NextTurn()
        {
            if (_turns.MoveNext())
            {
                return;
            }
            
            _turns.Reset();
            _turns.MoveNext();
            ++TurnNumber;
        }
    }
}