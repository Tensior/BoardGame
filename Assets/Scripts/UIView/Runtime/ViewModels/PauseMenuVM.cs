using System;
using UIView.ViewModels.Base;
using UnityWeld.Binding;

namespace UIView.ViewModels
{
    [Binding]
    public class PauseMenuVM : ShowableViewModel
    {
        public event Action OnExitToMainMenuClicked;

        [Binding]
        public void ExitToMainMenu()
        {
            OnExitToMainMenuClicked?.Invoke();
        }
    }
}