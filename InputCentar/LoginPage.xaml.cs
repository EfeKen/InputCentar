using System;
using Microsoft.Maui.Controls;

namespace InputCentar
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            var username = usernameEntry.Text;
            var password = passwordEntry.Text;

            var user = await App.Database.GetUserByUsernameAndPasswordAsync(username, password);

            if (user != null)
            {
                await DisplayAlert("Success", "Login successful", "OK");
                // Navigate to the main page or another page
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                await DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }

        private void Registracija_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registracija());
        }
    }
}
