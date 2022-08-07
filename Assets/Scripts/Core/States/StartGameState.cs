using Core.Map;
using Core.Players;

namespace Core.States
{
    public class StartGameState : IState
    {
        private readonly IPlayersProvider _playersProvider;
        private readonly IMapManager _mapManager;

        public StartGameState(IPlayersProvider playersProvider, IMapManager mapManager)
        {
            _playersProvider = playersProvider;
            _mapManager = mapManager;
        }
        
        void IState.Enter()
        {
            foreach (var player in _playersProvider.Players)
            {
                player.SetCurrentNode(_mapManager.StartNode);
            }
        }

        IState IState.Update()
        {
            return StatesContainer.PassTurnState;
        }

        void IState.Exit() { }
    }
}