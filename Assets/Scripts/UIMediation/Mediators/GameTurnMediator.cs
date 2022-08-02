using Input;
using UIMediation.Mediators.Base;
using UIView.ViewModels;

namespace UIMediation.Mediators
{
    public class GameTurnMediator : InputShowableMediator<GameTurnVM>
    {
        public GameTurnMediator(GameTurnVM gameTurnVM, IInputController inputController) 
            : base(gameTurnVM, inputController) { }

        public override void Show()
        {
            base.Show();

            ViewModel.OnSmallDiceUsed += SmallDiceUsed;
            ViewModel.OnLargeDiceUsed += LargeDiceUsed;
        }

        public override void Hide()
        {
            base.Hide();

            ViewModel.OnSmallDiceUsed -= SmallDiceUsed;
            ViewModel.OnLargeDiceUsed -= LargeDiceUsed;
        }

        private void SmallDiceUsed()
        {
            InputController.IsSmallDiceChosen = true;
        }

        private void LargeDiceUsed()
        {
            InputController.IsLargeDiceChosen = true;
        }

        public void SetDicesAvailability(bool canUseSmall, bool canUseLarge)
        {
            ViewModel.CanUseSmallDice = canUseSmall;
            ViewModel.CanUseLargeDice = canUseLarge;
        }
    }
}