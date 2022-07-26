namespace Core.States
{
    public class FiniteStateMachine
    {
        public IState CurrentState { get; private set; }
        
        public void EnterState(IState startingState)
        {
            CurrentState = startingState;
            startingState.Enter();
        }

        public void ChangeState(IState newState)
        {
            CurrentState.Exit();

            EnterState(newState);
        }
    }
}
