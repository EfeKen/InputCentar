using InputCentar.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using InputCentar.ViewModels;

namespace InputCentar.Data
{
    public class DatabaseService
    {
        readonly SQLiteAsyncConnection _database;

        public Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            return _database.Table<User>()
                            .Where(u => u.Username == username && u.Password == password)
                            .FirstOrDefaultAsync();
        }

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            InitializeDatabase();
        }

        private async void InitializeDatabase()
        {
            await _database.CreateTableAsync<NewsItem>();
            await _database.CreateTableAsync<User>();

            await InsertAdminUserIfNotExists();
        }

        private async Task InsertAdminUserIfNotExists()
        {
            var adminUser = await _database.Table<User>().Where(u => u.Role == UserRoles.Admin).FirstOrDefaultAsync();
            if (adminUser == null)
            {
                adminUser = new User
                {
                    FirstName = "Admin",
                    LastName = "User",
                    Username = "admin",
                    Email = "admin@example.com",
                    Password = "admin", // Note: In a real app, hash and salt the password
                    Role = UserRoles.Admin
                };
                await SaveUserAsync(adminUser);
            }
        }

        // NewsItem methods
        public Task<List<NewsItem>> GetNewsItemsAsync()
        {
            return _database.Table<NewsItem>().ToListAsync();
        }

        public Task<NewsItem> GetNewsItemAsync(int id)
        {
            return _database.Table<NewsItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveNewsItemAsync(NewsItem item)
        {
            if (item.Id != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        public Task<int> DeleteNewsItemAsync(NewsItem item)
        {
            return _database.DeleteAsync(item);
        }

        // User methods
        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<User> GetUserAsync(int id)
        {
            return _database.Table<User>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (user.Id != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }
    }
}
