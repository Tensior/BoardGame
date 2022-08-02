using System.Collections.Generic;
using System.Linq;
using Configs;

namespace Core.Turns
{
    public class TurnsManager : ITurnsProvider, ITurnsController
    {
        private readonly TurnsConfigSO _turnsConfig;
        
        private readonly IEnumerator<PlayerID> _turns;
        private int _turnNumber;

        PlayerID ITurnsProvider.CurrentPlayerID => _turns.Current;

        TurnData ITurnsProvider.CurrentTurnData =>
            _turnsConfig.PlayerTurnData.Find(t => t._playerID == _turns.Current).TurnData;

        int ITurnsProvider.TurnNumber => _turnNumber;

        public TurnsManager(TurnsConfigSO turnsConfig)
        {
            _turnsConfig = turnsConfig;
            _turns = turnsConfig.PlayerTurnData.Select(t => t._playerID).ToList().GetEnumerator();
            _turnNumber = 1;
        }

        void ITurnsController.NextTurn()
        {
            if (_turns.MoveNext())
            {
                return;
            }
            
            _turns.Reset();
            _turns.MoveNext();
            ++_turnNumber;
        }
    }
}