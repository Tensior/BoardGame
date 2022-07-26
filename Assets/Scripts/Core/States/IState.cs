namespace Core.States
{
    public interface IState
    {
        void Enter();
        IState Update();
        void Exit();
    }
}