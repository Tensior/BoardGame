using UIView.ViewModels.Base;
using UnityEngine;
using UnityWeld.Binding;

namespace UIView.ViewModels
{
    [Binding]
    public class GameFinishVM : ShowableViewModel
    {
        private string _finishText;
        private Color _color;
        
        [Binding]
        public string FinishText
        {
            get => _finishText;
            set
            {
                if (value == _finishText)
                {
                    return;
                }

                _finishText = value;
                OnPropertyChanged(nameof(FinishText));
            }
        }
        
        [Binding]
        public Color Color
        {
            get => _color;
            set
            {
                if (value == _color)
                {
                    return;
                }

                _color = value;
                OnPropertyChanged(nameof(Color));
            }
        }
    }
}