using InputCentar.Models;
using SQLite;

namespace InputCentar
{
    public partial class App : Application
    {
        static SQLiteAsyncConnection database;

        public static SQLiteAsyncConnection Database
        {
            get
            {
                if (database == null)
                {
                    var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NewsItems.db3");
                    database = new SQLiteAsyncConnection(dbPath);
                    database.CreateTableAsync<NewsItem>().Wait();
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}