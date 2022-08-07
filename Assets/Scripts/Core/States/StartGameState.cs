using Core.Map;
using Core.Players;

namespace Core.States
{
    public class StartGameState : IState
    {
        private readonly IPlayerProvider _playerProvider;
        private readonly IMapManager _mapManager;

        public StartGameState(IPlayerProvider playerProvider, IMapManager mapManager)
        {
            _playerProvider = playerProvider;
            _mapManager = mapManager;
        }
        
        void IState.Enter()
        {
            foreach (var player in _playerProvider.Players)
            {
                player.CurrentNode = _mapManager.StartNode;
            }
        }

        IState IState.Update()
        {
            return StatesContainer.PassTurnState;
        }

        void IState.Exit() { }
    }
}