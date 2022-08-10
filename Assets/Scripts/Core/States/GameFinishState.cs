using Configs;
using Core.Turns;
using UIMediation.Mediators;

namespace Core.States
{
    public class GameFinishState : IState
    {
        private readonly ITurnsProvider _turnsProvider;
        private readonly GameFinishMediator _gameFinishMediator;

        public GameFinishState(ITurnsProvider turnsProvider, GameFinishMediator gameFinishMediator)
        {
            _turnsProvider = turnsProvider;
            _gameFinishMediator = gameFinishMediator;
        }
        
        void IState.Enter()
        {
            _gameFinishMediator.Show();
            
            if (_turnsProvider.CurrentPlayerID == PlayerID.Player)
            {
                _gameFinishMediator.SetWin();
            }
            else
            {
                _gameFinishMediator.SetLoose();
            }
        }

        IState IState.Update()
        {
            return null;
        }

        void IState.Exit()
        {
            
        }
    }
}