using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace InputCentar.ViewModels
{
    public class AppShellViewModel : INotifyPropertyChanged
    {
        private bool isUserLoggedIn;

        public bool IsUserLoggedIn
        {
            get => isUserLoggedIn;
            set
            {
                if (isUserLoggedIn != value)
                {
                    isUserLoggedIn = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
