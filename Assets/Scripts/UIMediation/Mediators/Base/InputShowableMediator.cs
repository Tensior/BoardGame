using Input;
using UIView.ViewModels.Base;

namespace UIMediation.Mediators.Base
{
    public abstract class InputShowableMediator<T> : ShowableMediator<T> where T : ShowableViewModel
    {
        protected readonly IInputController InputController;

        protected InputShowableMediator(T viewModel, IInputController inputController) : base(viewModel)
        {
            InputController = inputController;
        }
    }
}