using Core.Turns;

namespace Core.States
{
    public class PassTurnState : IState
    {
        private readonly ITurnsController _turnsController;

        public PassTurnState(ITurnsController turnsController)
        {
            _turnsController = turnsController;
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
            //throw new System.NotImplementedException();
        }
    }
}