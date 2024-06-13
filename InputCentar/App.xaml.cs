using InputCentar.Data;
using InputCentar.ViewModels;
using System;
using System.IO;

namespace InputCentar
{
    public partial class App : Application
    {
        static DatabaseService database;
        public AppShellViewModel AppShellViewModel { get; private set; }

        public static User CurrentUser { get; set; }

        public App()
        {
            InitializeComponent();
            AppShellViewModel = new AppShellViewModel();
            var appShell = new AppShell();
            appShell.BindingContext = AppShellViewModel;
            MainPage = new AppShell(); // Ensure your AppShell.xaml is set up correctly
        }

        public static DatabaseService Database
        {
            get
            {
                if (database == null)
                {
                    var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "InputCentar.db3");
                    database = new DatabaseService();
                }
                return database;
            }
        }

     

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
