using Input;
using UIMediation.Mediators;

namespace Core.States
{
    public class SmallUseDiceState : UseDiceState
    {
        public SmallUseDiceState(UseDiceMediator useDiceMediator, IInputProvider inputProvider) 
            : base(useDiceMediator, inputProvider) { }

        protected override int Min => 1;
        protected override int Max => 6;
    }
}