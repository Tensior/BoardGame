using System;
using UIView.ViewModels.Base;
using UnityWeld.Binding;

namespace UIView.ViewModels
{
    [Binding]
    public class MainMenuVM : ShowableViewModel
    {
        public event Action OnStartGameClicked;
        public event Action OnExitGameClicked;

        [Binding]
        public void StartGame()
        {
            OnStartGameClicked?.Invoke();
        }
        
        [Binding]
        public void ExitGame()
        {
            OnExitGameClicked?.Invoke();
        }
    }
}