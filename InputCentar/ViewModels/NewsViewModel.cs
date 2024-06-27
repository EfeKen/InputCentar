using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using InputCentar.Models;

namespace InputCentar.ViewModels
{
    public class NewsViewModel : INotifyPropertyChanged
    {
        private readonly FirestoreDb _firestoreDb;

        private ObservableCollection<NewsItem> _newsItems;
        public ObservableCollection<NewsItem> NewsItems
        {
            get { return _newsItems; }
            set
            {
                _newsItems = value;
                OnPropertyChanged(nameof(NewsItems));
            }
        }

        public NewsViewModel()
        {
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "C:\\Users\\USER\\Source\\Repos\\InputCentar\\InputCentar\\Platforms\\Android\\google-services\\inputapp-870db-firebase-adminsdk-3axmc-fcd0e0d53f.json");

            _firestoreDb = FirestoreDb.Create("inputapp-870db");

            NewsItems = new ObservableCollection<NewsItem>();

            // Load news items initially
            Task.Run(async () => await LoadNewsItems());
        }

        public async Task LoadNewsItems()
        {
            CollectionReference vijestiRef = _firestoreDb.Collection("Vijesti");
            QuerySnapshot querySnapshot = await vijestiRef.GetSnapshotAsync();

            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                Dictionary<string, object> newsData = documentSnapshot.ToDictionary();
                string naslov = newsData["Naslov"].ToString();
                string slika = newsData["Slika"].ToString();

                // Add the retrieved news item to the NewsItems collection
               // NewsItems.Add(new NewsItem { Title = naslov, ImageUrl = slika });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
