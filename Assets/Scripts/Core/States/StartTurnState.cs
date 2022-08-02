using Input;
using UIMediation.Mediators;

namespace Core.States
{
    public class StartTurnState : IState
    {
        private readonly IInputProvider _inputProvider;
        private readonly GameTurnMediator _gameTurnMediator;
        private IState _stateToSwitch;

        public StartTurnState(IInputProvider inputProvider, GameTurnMediator gameTurnMediator)
        {
            _inputProvider = inputProvider;
            _gameTurnMediator = gameTurnMediator;
        }

        void IState.Enter()
        {
            _stateToSwitch = null;

            _gameTurnMediator.Show();
            _gameTurnMediator.SetDicesAvailability(true, true);
        }

        IState IState.Update()
        {
            if (_inputProvider.IsSmallDiceChosen)
            {
                _stateToSwitch = StatesContainer.SmallUseDiceState;
            }
            else if (_inputProvider.IsLargeDiceChosen)
            {
                _stateToSwitch = StatesContainer.LargeUseDiceState;
            }
            
            return _stateToSwitch;
        }

        void IState.Exit()
        {
            //TODO: Hide turn interface or make it non-interactable
        }
    }
}