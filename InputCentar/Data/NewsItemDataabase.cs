using InputCentar.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InputCentar.Data
{
    public class NewsItemDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public NewsItemDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<NewsItem>().Wait();
        }

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
    }
}
