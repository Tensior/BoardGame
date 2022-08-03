using Core.States;
using UnityEngine;
using Zenject;

namespace Core
{
    public class GameStateManager : MonoBehaviour
    {
        private FiniteStateMachine _fsm;
        private PassTurnState _passTurnState;
        
        public IState CurrentState => _fsm.CurrentState;

        [Inject]
        private void Inject(PassTurnState passTurnState)
        {
            _passTurnState = passTurnState;
        }
        
        private void Awake()
        {
            _fsm = new FiniteStateMachine();
            
            _fsm.EnterState(_passTurnState);
        }

        private void Update()
        {
            var stateToSwitch = _fsm.CurrentState.Update();
            if (stateToSwitch != null)
            {
                _fsm.ChangeState(stateToSwitch);
            }
        }
    }
}