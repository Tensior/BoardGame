using UnityEngine;

namespace Core.States
{
    public class FiniteStateMachine
    {
        public IState CurrentState { get; private set; }
        
        public void EnterState(IState state)
        {
            Debug.Log($"Entering {state.GetType().Name}");
            CurrentState = state;
            state.Enter();
        }

        public void ChangeState(IState newState)
        {
            CurrentState.Exit();

            EnterState(newState);
        }
    }
}
