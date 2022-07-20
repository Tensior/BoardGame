using UIView.ViewModels.Base;

namespace UIMediation.Mediators
{
    public abstract class ShowableMediator
    {
        private readonly ShowableViewModel _showableViewModel;

        protected ShowableMediator(ShowableViewModel showableViewModel)
        {
            _showableViewModel = showableViewModel;
        }

        protected virtual void Show()
        {
            _showableViewModel.IsShown = true;
        }

        protected virtual void Hide()
        {
            _showableViewModel.IsShown = false;
        }
    }
}