using InputCentar.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;


namespace InputCentar.ViewModels
{
    public class NewsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<NewsItem> NewsItems { get; set; }

        // Properties for the new news item
        public string NewTitle { get; set; }
        public string NewDescription { get; set; }
        public string NewImageUrl { get; set; }

        public NewsViewModel()
        {
            NewsItems = new ObservableCollection<NewsItem>();

            // Load news items initially
            Task.Run(async () => await LoadNewsItems());
        }

        private async Task LoadNewsItems()
        {
            var newsItemsFromDb = await App.Database.GetNewsItemsAsync();
            NewsItems.Clear();
            foreach (var item in newsItemsFromDb)
            {
                NewsItems.Add(item);
            }
        }

        public async Task AddNewsItem()
        {
            var newItem = new NewsItem
            {
                Title = NewTitle,
                Description = NewDescription,
                ImageUrl = NewImageUrl,
                Date = DateTime.Now.ToString(),
                DetailText = "New Detail Text"
            };
            await App.Database.SaveNewsItemAsync(newItem);
            NewsItems.Insert(0, newItem); // Insert at the beginning of the list

            // Clear the fields after adding the news item
            NewTitle = string.Empty;
            NewDescription = string.Empty;
            NewImageUrl = string.Empty;
        }

        public async Task DeleteNewsItem(NewsItem newsItem)
        {
            if (newsItem != null)
            {
                await App.Database.DeleteNewsItemAsync(newsItem);
                NewsItems.Remove(newsItem);
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
