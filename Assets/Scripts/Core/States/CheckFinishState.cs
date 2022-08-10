using Core.Map;
using Core.Players;
using Core.Turns;

namespace Core.States
{
    public class CheckFinishState : IState
    {
        private readonly ITurnsProvider _turnsProvider;
        private readonly IPlayerProvider _playerProvider;
        private readonly IMapProvider _mapProvider;
        private bool _isGameFinished; 

        public CheckFinishState(ITurnsProvider turnsProvider, IPlayerProvider playerProvider, IMapProvider mapProvider)
        {
            _turnsProvider = turnsProvider;
            _playerProvider = playerProvider;
            _mapProvider = mapProvider;
        }
        
        void IState.Enter()
        {
            var player = _playerProvider.GetPlayer(_turnsProvider.CurrentPlayerID);

            _isGameFinished = player.CurrentNode == _mapProvider.FinishNode;
        }

        IState IState.Update()
        {
            if (!_isGameFinished)
            {
                return StatesContainer.PassTurnState;
            }

            return StatesContainer.GameFinishState;
        }

        void IState.Exit() { }
    }
}