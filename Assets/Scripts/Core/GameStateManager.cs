using Core.States;
using Zenject;

namespace Core
{
    public class GameStateManager : IInitializable, ITickable, ICurrentStateProvider
    {
        private FiniteStateMachine _fsm;

        IState ICurrentStateProvider.CurrentState => _fsm.CurrentState;

        void IInitializable.Initialize()
        {
            _fsm = new FiniteStateMachine();
            
            _fsm.EnterState(StatesContainer.StartGameState);
        }

        void ITickable.Tick()
        {
            var stateToSwitch = _fsm.CurrentState.Update();
            if (stateToSwitch != null)
            {
                _fsm.ChangeState(stateToSwitch);
            }
        }
    }
}