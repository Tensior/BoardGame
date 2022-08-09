namespace Input
{
    public interface IInputController
    {
        bool IsSmallDiceChosen { set; }
        bool IsLargeDiceChosen { set; }
        bool IsDiceStopped { set; }
        int? SelectedDirection { set; }
    }
}