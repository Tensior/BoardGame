using System.Collections.Generic;
using System.Linq;
using Configs;
using Utils;

namespace Core.Turns
{
    public class TurnsManager : ITurnsProvider, ITurnsController
    {
        private readonly TurnsConfigSO _turnsConfig;
        
        private readonly IEnumerator<PlayerID> _turnsCycle;
        private PlayerID _currentPlayer;

        PlayerID ITurnsProvider.CurrentPlayerID => _currentPlayer;

        TurnData ITurnsProvider.CurrentTurnData =>
            _turnsConfig.PlayerTurnData.Find(t => t._playerID == _currentPlayer).TurnData;

        public TurnsManager(TurnsConfigSO turnsConfig)
        {
            _turnsConfig = turnsConfig;
            _turnsCycle = turnsConfig.PlayerTurnData.Select(t => t._playerID).CyclicCopy().GetEnumerator();
            _currentPlayer = _turnsCycle.Current;
        }

        void ITurnsController.NextTurn()
        {
            if (_turnsCycle.MoveNext())
            {
                _currentPlayer = _turnsCycle.Current;
            }
        }
    }
}