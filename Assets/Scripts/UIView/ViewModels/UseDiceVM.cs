using System;
using UIView.ViewModels.Base;
using UnityWeld.Binding;

namespace UIView.ViewModels
{
    [Binding]
    public class UseDiceVM : ShowableViewModel
    {
        public event Action OnStopDice;
        private int _number;

        [Binding]
        public int Number
        {
            get => _number;
            set
            {
                if (value == _number)
                {
                    return;
                }

                _number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        [Binding]
        public void StopDice()
        {
            OnStopDice?.Invoke();
        }
    }
}