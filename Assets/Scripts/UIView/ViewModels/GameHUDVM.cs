using System;
using UIView.ViewModels.Base;
using UnityWeld.Binding;

namespace UIView.ViewModels
{
    [Binding]
    public class GameHUDVM : ShowableViewModel
    {
        public event Action OnExitToMainMenuClicked;

        private string _currentPlayer;
        private int _currentTurn;

        [Binding]
        public void ExitToMainMenu()
        {
            OnExitToMainMenuClicked?.Invoke();
        }
        
        [Binding]
        public string CurrentPlayer
        {
            get => _currentPlayer;
            set
            {
                if (value == _currentPlayer)
                {
                    return;
                }

                _currentPlayer = value;
                OnPropertyChanged(nameof(CurrentPlayer));
            }
        }
        
        [Binding]
        public int CurrentTurn
        {
            get => _currentTurn;
            set
            {
                if (value == _currentTurn)
                {
                    return;
                }

                _currentTurn = value;
                OnPropertyChanged(nameof(CurrentTurn));
            }
        }
    }
}