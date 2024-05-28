using InputCentar.Data;
using System;
using System.IO;


namespace InputCentar
{
    public partial class App : Application
    {
        static DatabaseService database;

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell(); // Ensure your AppShell.xaml is set up correctly
        }

        public static DatabaseService Database
        {
            get
            {
                if (database == null)
                {
                    var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "InputCentar.db3");
                    database = new DatabaseService(dbPath);
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
