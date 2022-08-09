namespace Core.States
{
    public class StatesContainer
    {
        public static StartGameState StartGameState { get; private set; }
        public static StartTurnState StartTurnState { get; private set; }
        public static SmallUseDiceState SmallUseDiceState { get; private set; }
        public static LargeUseDiceState LargeUseDiceState { get; private set; }
        public static PassTurnState PassTurnState { get; private set; }
        public static MovePlayerState MovePlayerState { get; private set; }
        public static SelectDirectionState SelectDirectionState { get; private set; }

        public StatesContainer(
            StartGameState startGameState,
            PassTurnState passTurnState,
            StartTurnState startTurnState,
            SmallUseDiceState smallUseDiceState,
            LargeUseDiceState largeUseDiceState,
            MovePlayerState movePlayerState,
            SelectDirectionState selectDirectionState)
        {
            StartGameState = startGameState;
            PassTurnState = passTurnState;
            StartTurnState = startTurnState;
            SmallUseDiceState = smallUseDiceState;
            LargeUseDiceState = largeUseDiceState;
            MovePlayerState = movePlayerState;
            SelectDirectionState = selectDirectionState;
        }
    }
}