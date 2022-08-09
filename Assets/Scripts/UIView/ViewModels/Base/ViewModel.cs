using System.ComponentModel;
using JetBrains.Annotations;

namespace UIView.ViewModels.Base
{
    public abstract class ViewModel : IViewModel 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}