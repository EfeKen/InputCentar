using System.Collections.ObjectModel;
using System.Threading.Tasks;
using InputCentar.Models;
using InputCentar.Data;
using InputCentar.ViewModels;


namespace InputCentar.ViewModels
{
    public class ProfilViewModel : User
    {
        private ObservableCollection<User> _users;

        public ObservableCollection<User> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        private void SetProperty(ref ObservableCollection<User> users, ObservableCollection<User> value)
        {
            throw new NotImplementedException();
        }

        public ProfilViewModel()
        {
            LoadUsers();
        }

        private async void LoadUsers()
        {
            var users = await App.Database.GetUsersAsync();
            Users = new ObservableCollection<User>(users);
        }
    }
}
