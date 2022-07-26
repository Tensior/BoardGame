using Input;

namespace Core.States
{
    public class StartTurnState : IState
    {
        private readonly IInputProvider _inputProvider;
        private readonly UseDiceState _useDiceState;
        private IState _stateToSwitch;

        public StartTurnState(IInputProvider inputProvider, UseDiceState useDiceState)
        {
            _inputProvider = inputProvider;
            _useDiceState = useDiceState;
        }

        void IState.Enter()
        {
            _stateToSwitch = null;

            //TODO: show turn interface or make it interactable
        }

        IState IState.Update()
        {
            if (_inputProvider.IsSmallDiceChosen)
            {
                _stateToSwitch = _useDiceState;
            }
            else if (_inputProvider.IsLargeDiceChosen)
            {
                _stateToSwitch = _useDiceState;
            }
            
            return _stateToSwitch;
        }

        void IState.Exit()
        {
            //TODO: Hide turn interface or make it non-interactable
        }
    }
}