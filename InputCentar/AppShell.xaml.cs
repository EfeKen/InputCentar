using Microsoft.Maui.Controls;
using System;
using System.Windows.Input;

namespace InputCentar
{
    public partial class AppShell : Shell
    {
        public ICommand NavigateToMainPageCommand { get; }

        public AppShell()
        {
            InitializeComponent();

            // Initialize the command
            NavigateToMainPageCommand = new Command(NavigateToMainPage);
        }

        private async void NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}