using Core.Map;
using Core.Players;

namespace Core.States
{
    public class StartGameState : IState
    {
        private readonly IPlayerProvider _playerProvider;
        private readonly IMapProvider _mapProvider;

        public StartGameState(IPlayerProvider playerProvider, IMapProvider mapProvider)
        {
            _playerProvider = playerProvider;
            _mapProvider = mapProvider;
        }
        
        void IState.Enter()
        {
            foreach (var player in _playerProvider.Players)
            {
                player.CurrentNode = _mapProvider.StartNode;
            }
        }

        IState IState.Update()
        {
            return StatesContainer.PassTurnState;
        }

        void IState.Exit() { }
    }
}