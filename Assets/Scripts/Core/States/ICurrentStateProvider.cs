using Core.States;

namespace Core
{
    public interface ICurrentStateProvider
    {
        IState CurrentState { get; }
    }
}