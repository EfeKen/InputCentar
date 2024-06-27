using Firebase.Auth;
using Google.Cloud.Firestore;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace InputCentar
{
    public partial class Kalendar : ContentPage
    {
        private DateTime startDate;
        private DateTime endDate;
        private FirestoreDb firestoreDb;
        private FirebaseAuth firebaseAuth;

        public Kalendar()
        {
            InitializeComponent();
            InitializeFirestore();

            // Initialize Firebase Authentication
            
        }

        private void InitializeFirestore()
        {
            // Set environment variable for Google Application Credentials
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "C:\\Users\\USER\\source\\repos\\InputCentar\\InputCentar\\Platforms\\Android\\google-services\\inputapp-870db-firebase-adminsdk-3axmc-fcd0e0d53f.json");

            // Initialize Firestore
            firestoreDb = FirestoreDb.Create("inputapp-870db");
        }

        private async Task<bool> IsUserLoggedInAsync()
        {
            // Example: Check if user is logged in (You should implement your own authentication logic)
            // For example, using Firebase Authentication or any other authentication mechanism

            bool isLoggedIn = true; // Replace with your authentication check logic
            return await Task.FromResult(isLoggedIn);
        }

        private async Task<string> GetCurrentLoggedInUserEmailAsync()
        {
            // Example: Get current user's email (You should implement your own authentication logic)
            // For example, using Firebase Authentication or any other authentication mechanism
            string userEmail = "example@example.com"; // Replace with your actual user email retrieval logic
            return await Task.FromResult(userEmail);
        }

        private async void MakeReservationClicked(object sender, EventArgs e)
        {
            // Check if user is logged in
            bool isLoggedIn = await IsUserLoggedInAsync();
            if (!isLoggedIn)
            {
                await DisplayAlert("Error", "Morate se ulogovati da biste izvršili rezervaciju.", "OK");
                return;
            }

            // Retrieve entered values
            string ime = imeEntry.Text;
            string prezime = prezimeEntry.Text;
            string brojMobitela = brojMobitelaEntry.Text;

            // Handle reservation logic
            if (startDate < endDate)
            {
                // Make reservation for the selected date range
                string userEmail = await GetCurrentLoggedInUserEmailAsync();

                // Save reservation data to Firestore
                await SaveReservationToFirestore(startDate, endDate, userEmail, ime, prezime, brojMobitela);

                // Show success message
                await DisplayAlert("Rezervacija", $"Uspješno ste rezervisali od {startDate.ToShortDateString()} do {endDate.ToShortDateString()}", "OK");

                // Optionally navigate back or perform other actions after successful reservation
                // Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Datum završetka mora biti poslije datuma početka.", "OK");
            }
        }

        private async Task SaveReservationToFirestore(DateTime startDate, DateTime endDate, string userEmail, string ime, string prezime, string brojMobitela)
        {
            // Reference to the Narudzbe collection in Firestore
            CollectionReference narudzbeRef = firestoreDb.Collection("Narudzbe");

            // Convert DateTime to UTC and then to Google.Cloud.Firestore.Timestamp
            Google.Cloud.Firestore.Timestamp startTimestamp = Google.Cloud.Firestore.Timestamp.FromDateTime(startDate.ToUniversalTime());
            Google.Cloud.Firestore.Timestamp endTimestamp = Google.Cloud.Firestore.Timestamp.FromDateTime(endDate.ToUniversalTime());

            // Create a new document with reservation data
            var reservationData = new
            {
                Datumpocetka = startTimestamp,
                Datumzavrsetka = endTimestamp,
                Email = userEmail,
                ImePrezime = $"{ime} {prezime}",
                BrojTelefona = brojMobitela
            };

            // Add the reservation document to Firestore
            await narudzbeRef.AddAsync(reservationData);
        }

        private void StartDateSelected(object sender, DateChangedEventArgs e)
        {
            startDate = e.NewDate;
        }

        private void EndDateSelected(object sender, DateChangedEventArgs e)
        {
            endDate = e.NewDate;
        }
    }
}
