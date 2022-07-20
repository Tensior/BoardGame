namespace Input.Interfaces
{
    public interface IInputProvider
    {
        bool IsPause { get; }
        void SetGameplayActive(bool isActive);
    }
}