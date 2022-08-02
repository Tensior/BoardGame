using Input;
using UIMediation.Mediators.Base;
using UIView.ViewModels;

namespace UIMediation.Mediators
{
    public class UseDiceMediator : InputShowableMediator<UseDiceVM>
    {
        public int Number
        {
            get => ViewModel.Number;
            set => ViewModel.Number = value;
        }

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

        private void DiceStopped()
        {
            InputController.IsDiceStopped = true;
        }
    }
}