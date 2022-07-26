using UIView.ViewModels.Base;

namespace UIMediation.Mediators.Base
{
    public abstract class ShowableMediator<T> where T : ShowableViewModel
    {
        protected readonly T ViewModel;

        protected ShowableMediator(T viewModel)
        {
            ViewModel = viewModel;
        }

        public virtual void Show()
        {
            ViewModel.IsShown = true;
        }

        public virtual void Hide()
        {
            ViewModel.IsShown = false;
        }
    }
}