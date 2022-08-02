using Core.States;
using UnityEngine;
using Zenject;

namespace Core
{
    public class GameStateManager : MonoBehaviour
    {
        private FiniteStateMachine _fsm;
        private StartTurnState _startTurnState;

        [Inject]
        private void Inject(StartTurnState startTurnState)
        {
            _startTurnState = startTurnState;
        }
        
        private void Awake()
        {
            _fsm = new FiniteStateMachine();
            
            _fsm.EnterState(_startTurnState);
        }

        private void Update()
        {
            var stateToSwitch = _fsm.CurrentState.Update();
            if (stateToSwitch != null)
            {
                _fsm.ChangeState(stateToSwitch/*, _playersProvider.GetPlayer(_turnsProvider.CurrentPlayerID)*/);
            }
        }
    }
}