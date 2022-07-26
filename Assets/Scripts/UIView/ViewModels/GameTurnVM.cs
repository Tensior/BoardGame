using System;
using UIView.ViewModels.Base;
using UnityWeld.Binding;

namespace UIView.ViewModels
{
    [Binding]
    public class GameTurnVM : ShowableViewModel
    {
        public event Action OnSmallDiceUsed;
        public event Action OnLargeDiceUsed;

        private bool _canUseSmallDice;
        private bool _canUseLargeDice;
        
        [Binding]
        public bool CanUseSmallDice
        {
            get => _canUseSmallDice;
            set
            {
                if (value == _canUseSmallDice)
                {
                    return;
                }

                _canUseSmallDice = value;
                OnPropertyChanged(nameof(CanUseSmallDice));
            }
        }
        
        [Binding]
        public bool CanUseLargeDice
        {
            get => _canUseLargeDice;
            set
            {
                if (value == _canUseLargeDice)
                {
                    return;
                }

                _canUseLargeDice = value;
                OnPropertyChanged(nameof(CanUseLargeDice));
            }
        }
        
        [Binding]
        public void UseSmallDice()
        {
            OnSmallDiceUsed?.Invoke();
        }
        
        [Binding]
        public void UseLargeDice()
        {
            OnLargeDiceUsed?.Invoke();
        }
    }
}