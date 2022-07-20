using UIView.ViewModels.Base;
using UnityWeld.Binding;

namespace UIView.ViewModels
{
    [Binding]
    public class ScoreVM : MonoBehaviourViewModel
    {
        private int _score;

        [Binding]
        public int Score
        {
            get => _score;
            set
            {
                if (_score == value)
                {
                    return;
                }
                
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }
    }
}