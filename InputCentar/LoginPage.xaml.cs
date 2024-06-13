using System;
using Microsoft.Maui.Controls;
using Firebase.Auth; // Import Firebase Authentication namespace
using InputCentar.Models;

namespace InputCentar
{
    public partial class LoginPage : ContentPage
    {
        private readonly FirebaseAuthProvider _firebaseAuthProvider;

        public LoginPage()
        {
            InitializeComponent();

            // Initialize Firebase Authentication provider
            _firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyBxOUDFDWHXLX-CJZXq2AF3xHHZn-TJ2rA"));
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            var username = usernameEntry.Text;
            var password = passwordEntry.Text;

            try
            {
                // Authenticate user with Firebase Authentication
                var authResult = await _firebaseAuthProvider.SignInWithEmailAndPasswordAsync(username, password);

                // Authentication successful, retrieve user data from your local database
                var user = await App.Database.GetUserByUsernameAndPasswordAsync(username,password);

                if (user != null)
                {
                    App.CurrentUser = user;
                    await DisplayAlert("Success", "Login successful", "OK");

                    // Navigate to the main page or another page
                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    await DisplayAlert("Error", "User not found", "OK");
                }
            }
            catch (FirebaseAuthException ex)
            {
                // Handle authentication errors
                await DisplayAlert("Error", $"Failed to login: {ex.Reason}", "OK");
            }
        }

        private void Registracija_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registracija());
        }
    }
}
