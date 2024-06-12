using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InputCentar.Models;
using InputCentar.Data;
using System.Collections.ObjectModel;

namespace InputCentar.ViewModels
{
    public class UserViewModel : User
    {
        private readonly DatabaseService _databaseService;
    
        public ObservableCollection<User> Users { get; set; }

        public UserViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
            Users = new ObservableCollection<User>();
            LoadUsers();
        }

        private async void LoadUsers()
        {
            var users = await _databaseService.GetUsersAsync();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        public async Task AddUser(User user)
        {
            user.Role = UserRoles.User; // Set role to User (0)
            await _databaseService.SaveUserAsync(user);
            Users.Add(user);
        }


        public async Task DeleteUser(User user)
        {
            await _databaseService.DeleteUserAsync(user);
            Users.Remove(user);
        }
    }
}
