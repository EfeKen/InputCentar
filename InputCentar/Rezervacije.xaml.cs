using Google.Cloud.Firestore;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace InputCentar
{
    public partial class Rezervacije : ContentPage
    {
        private FirestoreDb firestoreDb;
        public ObservableCollection<Rezervacija> RezervacijeList { get; set; }

        public Rezervacije()
        {
            InitializeComponent();
            InitializeFirestore();
            RezervacijeList = new ObservableCollection<Rezervacija>();
            RezervacijeListView.ItemsSource = RezervacijeList;
        }

        private void InitializeFirestore()
        {
            // Set environment variable for Google Application Credentials
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "C:\\Users\\STEM8\\source\\repos\\InputCentar\\InputCentar\\Platforms\\Android\\google-services\\inputapp-870db-firebase-adminsdk-3axmc-fcd0e0d53f.json");

            // Initialize Firestore
            firestoreDb = FirestoreDb.Create("inputapp-870db");
        }

        private async Task LoadRezervacijeFromFirestore()
        {
            CollectionReference rezervacijeRef = firestoreDb.Collection("Rezervacije");
            QuerySnapshot querySnapshot = await rezervacijeRef.GetSnapshotAsync();

            RezervacijeList.Clear(); // Clear existing items before adding new ones

            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                Dictionary<string, object> data = documentSnapshot.ToDictionary();

                // Extract data from document
                string naziv = data.ContainsKey("Naziv") ? data["Naziv"]?.ToString() : string.Empty;
                string slika = data.ContainsKey("Slika") ? data["Slika"]?.ToString() : string.Empty;
                string grupa = data.ContainsKey("Grupa") ? data["Grupa"]?.ToString() : string.Empty;

                // Add extracted data to ObservableCollection
                RezervacijeList.Add(new Rezervacija { Naziv = naziv, Slika = slika, Grupa = grupa });
            }
        }

        // Call this method to load Rezervacije from Firestore
        private async void LoadRezervacijeButton_Clicked(object sender, EventArgs e)
        {
            await LoadRezervacijeFromFirestore();
        }
    }

    public class Rezervacija
    {
        public string Naziv { get; set; }
        public string Slika { get; set; }
        public string Grupa { get; set; }
    }
}
