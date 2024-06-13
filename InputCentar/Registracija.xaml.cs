using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Firebase.Auth;
using InputCentar.ViewModels;

namespace InputCentar
{
    public partial class Registracija : ContentPage
    {
        private readonly UserViewModel _userViewModel;
        private readonly FirebaseAuthProvider _firebaseAuthProvider;

        public Registracija()
        {
            InitializeComponent();
            _userViewModel = new UserViewModel(App.Database); // Assuming App.Database is an instance of DatabaseService

            // Initialize Firebase Authentication provider
            _firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyBxOUDFDWHXLX-CJZXq2AF3xHHZn-TJ2rA"));
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                FirstName = firstNameEntry.Text,
                LastName = lastNameEntry.Text,
                Username = usernameEntry.Text,
                Email = emailEntry.Text,
                Password = passwordEntry.Text // Note: Hash and salt the password in a real app
            };

            // Register user with Firebase Authentication
            try
            {
                var authResult = await _firebaseAuthProvider.CreateUserWithEmailAndPasswordAsync(user.Email, user.Password);
                // Firebase Authentication successful, now add user to your database
                user.FirebaseUserId = authResult.User.LocalId; // Save Firebase user ID
                user.Role = UserRoles.User; // Set role to User (0)
                await _userViewModel.AddUser(user);
                await DisplayAlert("Success", "User registered successfully", "OK");
                await Navigation.PopAsync(); // Navigate back to the login page or another page
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to register user: {ex.Message}", "OK");
            }
        }

        private void Prijava_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}
