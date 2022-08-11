using Core.Map;
using Core.Players;
using Core.Turns;
using UIMediation.Mediators;

namespace Core.States
{
    public class CheckFinishState : IState
    {
        private readonly ITurnsProvider _turnsProvider;
        private readonly IPlayerProvider _playerProvider;
        private readonly IMapProvider _mapProvider;
        private readonly UseDiceMediator _useDiceMediator;
        private bool _isGameFinished; 

        public CheckFinishState(
            ITurnsProvider turnsProvider, 
            IPlayerProvider playerProvider, 
            IMapProvider mapProvider,
            UseDiceMediator useDiceMediator)
        {
            _turnsProvider = turnsProvider;
            _playerProvider = playerProvider;
            _mapProvider = mapProvider;
            _useDiceMediator = useDiceMediator;
        }
        
        void IState.Enter()
        {
            _useDiceMediator.Hide();
            
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