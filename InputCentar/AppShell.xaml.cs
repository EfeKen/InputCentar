using Microsoft.Maui.Controls;
using System;
using System.Windows.Input;
using Microsoft.Maui.Controls.Handlers;


namespace InputCentar
{
    public partial class AppShell : Shell
    {

        public AppShell()
        {
            InitializeComponent();

        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new LoginPage());
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//RegisterPage");
        }

    }

}