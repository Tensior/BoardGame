using Core.Turns;
using UIMediation.Mediators;

namespace Core.States
{
    public class PassTurnState : IState
    {
        private readonly ITurnsController _turnsController;
        private readonly ITurnsProvider _turnsProvider;
        private readonly GameHUDMediator _gameHUDMediator;

        public PassTurnState(ITurnsController turnsController, ITurnsProvider turnsProvider, GameHUDMediator gameHUDMediator)
        {
            _turnsController = turnsController;
            _turnsProvider = turnsProvider;
            _gameHUDMediator = gameHUDMediator;
        }

        void IState.Enter()
        {
            _turnsController.NextTurn();
        }

        IState IState.Update()
        {
            return StatesContainer.StartTurnState;
        }

        void IState.Exit()
        {
            _gameHUDMediator.CurrentPlayer = _turnsProvider.CurrentPlayerID.ToString();
            _gameHUDMediator.CurrentTurn = _turnsProvider.TurnNumber;
        }
    }
}