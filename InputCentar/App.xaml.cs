using InputCentar.Data;
using System;
using System.IO;

namespace InputCentar
{
    public partial class App : Application
    {
        static DatabaseService database;

        public static User CurrentUser { get; set; } // Currently logged-in user
        public static UserRoles CurrentUserRole { get; set; } = UserRoles.Visitor; // Default to visitor

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
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

        public static void Logout()
        {
            CurrentUser = null;
            CurrentUserRole = UserRoles.Visitor; // Set role to visitor on logout
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
