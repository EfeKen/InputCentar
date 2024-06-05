using System;
using Microsoft.Maui.Controls;

namespace InputCentar
{
    public partial class Registracija : ContentPage
    {
        public Registracija()
        {
            InitializeComponent();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                FirstName = firstNameEntry.Text,
                LastName = lastNameEntry.Text,
                Username = usernameEntry.Text,
                Email = emailEntry.Text,
                Password = passwordEntry.Text, // Note: Hash and salt the password in a real app
                Role = UserRoles.User
            };

            await App.Database.SaveUserAsync(user);
            await DisplayAlert("Success", "User registered successfully", "OK");
        }

        private void Prijava_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}
