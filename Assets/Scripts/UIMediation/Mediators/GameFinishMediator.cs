using UIMediation.Mediators.Base;
using UIView.ViewModels;
using UnityEngine;

namespace UIMediation.Mediators
{
    public sealed class GameFinishMediator : ShowableMediator<GameFinishVM>
    {
        public GameFinishMediator(GameFinishVM viewModel) : base(viewModel)
        {
            Hide();
        }

        public void SetWin()
        {
            ViewModel.FinishText = "YOU WON! CONGRATULATIONS!";
            ViewModel.Color = Color.green;
        }

        public void SetLoose()
        {
            ViewModel.FinishText = "YOU LOST! GOOD LUCK NEXT TIME!";
            ViewModel.Color = Color.green;
        }
    }
}