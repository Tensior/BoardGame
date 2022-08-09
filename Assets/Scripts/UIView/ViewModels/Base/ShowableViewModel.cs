using UnityWeld.Binding;

namespace UIView.ViewModels.Base
{
    [Binding]
    public class ShowableViewModel : MonoBehaviourViewModel
    {
        private bool _isShown;

        public bool IsShown
        {
            get => _isShown;
            set
            {
                if (value == _isShown)
                {
                    return;
                }

                _isShown = value;
                gameObject.SetActive(_isShown);
            }
        }
    }
}