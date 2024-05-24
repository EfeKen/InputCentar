using InputCentar.Data;
using System;
using System.IO;


namespace InputCentar
{
    public partial class App : Application
    {
        static NewsItemDatabase database;

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell(); // Ensure your AppShell.xaml is set up correctly
        }

        public static NewsItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NewsItems.db3");
                    database = new NewsItemDatabase(dbPath);
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
