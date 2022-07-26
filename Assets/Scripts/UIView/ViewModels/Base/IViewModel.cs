using System.ComponentModel;

namespace UIView.ViewModels.Base
{
    public interface IViewModel : INotifyPropertyChanged
    {
        void OnPropertyChanged(string propertyName = null);
    }
}