using UIView.ViewModels.Base;
using UnityWeld.Binding;

namespace UIView.ViewModels
{
    [Binding]
    public class LivesVM : MonoBehaviourViewModel
    {
        private float _percentage;

        [Binding]
        public float Percentage
        {
            get => _percentage;
            set
            {
                _percentage = value;
                OnPropertyChanged(nameof(Percentage));
            }
        }
    }
}