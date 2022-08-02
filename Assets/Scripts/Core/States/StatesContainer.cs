namespace Core.States
{
    public class StatesContainer
    {
        public static StartTurnState StartTurnState { get; private set; }
        public static SmallUseDiceState SmallUseDiceState { get; private set; }
        public static LargeUseDiceState LargeUseDiceState { get; private set; }
        public static PassTurnState PassTurnState { get; private set; }

        public StatesContainer(
            StartTurnState startTurnState,
            SmallUseDiceState smallUseDiceState,
            LargeUseDiceState largeUseDiceState,
            PassTurnState passTurnState)
        {
            StartTurnState = startTurnState;
            SmallUseDiceState = smallUseDiceState;
            LargeUseDiceState = largeUseDiceState;
            PassTurnState = passTurnState;
        }
    }
}