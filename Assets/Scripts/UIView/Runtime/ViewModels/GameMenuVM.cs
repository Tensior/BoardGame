using System;
using UIView.ViewModels.Base;
using UnityWeld.Binding;

namespace UIView.ViewModels
{
    [Binding]
    public class GameMenuVM : ShowableViewModel
    {
        public event Action OnExitToMainMenuClicked;

        [Binding]
        public void ExitToMainMenu()
        {
            OnExitToMainMenuClicked?.Invoke();
        }
    }
}