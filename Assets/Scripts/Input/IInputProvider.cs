namespace Input
{
    public interface IInputProvider
    {
        bool IsSmallDiceChosen { get; }
        bool IsLargeDiceChosen { get; }
        bool IsDiceStopped { get; }
        int? SelectedDirection { get; }
    }
}