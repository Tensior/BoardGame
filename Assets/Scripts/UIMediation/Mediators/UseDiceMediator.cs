using Input;
using UIMediation.Mediators.Base;
using UIView.ViewModels;

namespace UIMediation.Mediators
{
    public class UseDiceMediator : InputShowableMediator<UseDiceVM>
    {
        public UseDiceMediator(UseDiceVM viewModel, IInputController inputController) 
            : base(viewModel, inputController) { }

        public override void Show()
        {
            base.Show();

            ViewModel.OnStopDice += DiceStopped;
        }

        public override void Hide()
        {
            base.Hide();

            ViewModel.OnStopDice -= DiceStopped;
        }

        public void SetNumber(int number)
        {
            ViewModel.Number = number;
        }

        private void DiceStopped()
        {
            InputController.IsDiceStopped = true;
        }
    }
}