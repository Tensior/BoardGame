using System;
using UIView.ViewModels.Base;
using UnityEngine;
using UnityWeld.Binding;

namespace UIView.ViewModels
{
    [Binding]
    public class ArrowVM : ViewModel
    {
        public event Action<int> OnArrowClicked;
        
        private readonly int _index;
        private Quaternion _rotation;
        
        [Binding]
        public Quaternion Rotation
        {
            get => _rotation;
            set
            {
                if (value == _rotation)
                {
                    return;
                }

                _rotation = value;
                OnPropertyChanged(nameof(Rotation));
            }
        }

        public ArrowVM(int index, Quaternion rotation)
        {
            _index = index;
            _rotation = rotation;
        }

        [Binding]
        public void ArrowClick()
        {
            OnArrowClicked?.Invoke(_index);
        }
    }
}