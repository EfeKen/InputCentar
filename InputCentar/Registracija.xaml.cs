using System;
using Microsoft.Maui.Controls;
using InputCentar.ViewModels;

namespace InputCentar
{
    public partial class Registracija : ContentPage
    {
        private readonly UserViewModel _userViewModel;

        public Registracija()
        {
            InitializeComponent();
            _userViewModel = new UserViewModel(App.Database); // Assuming App.Database is an instance of DatabaseService
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
                Role = UserRoles.User // Set role to User (0)
            };

            await _userViewModel.AddUser(user);
            await DisplayAlert("Success", "User registered successfully", "OK");
            await Navigation.PopAsync(); // Navigate back to the login page or another page
        }

        private void Prijava_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}
