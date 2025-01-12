using Input;
using UIMediation.Mediators;

namespace Core.States
{
    public class LargeUseDiceState : UseDiceState
    {
        public LargeUseDiceState(UseDiceMediator useDiceMediator, IInputProvider inputProvider, PlayerMovesHolder playerMovesHolder) 
            : base(useDiceMediator, inputProvider, playerMovesHolder) { }

        protected override int Min => 5;
        protected override int Max => 10;
    }
}