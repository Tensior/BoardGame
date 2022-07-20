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

        public virtual void Show()
        {
            _showableViewModel.IsShown = true;
        }

        public virtual void Hide()
        {
            _showableViewModel.IsShown = false;
        }
    }
}