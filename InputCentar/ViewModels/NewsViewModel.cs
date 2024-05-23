using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using InputCentar.Models;
using Microsoft.Maui.Controls;

namespace InputCentar.ViewModels
{
    public class NewsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<NewsItem> NewsItems { get; set; }
        public ICommand NewsTappedCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public NewsItem SelectedNewsItem { get; set; }

        public NewsViewModel()
        {
            NewsItems = new ObservableCollection<NewsItem>();
            NewsTappedCommand = new Command<NewsItem>(OnNewsTapped);
            SaveCommand = new Command(async () => await SaveNewsItemAsync(SelectedNewsItem));
            LoadNewsItemsAsync().Wait();
        }

        private async void OnNewsTapped(NewsItem newsItem)
        {
            if (newsItem != null)
            {
                var navigationParameter = new Dictionary<string, object>
                {
                    { "newsItem", newsItem }
                };
                await Shell.Current.GoToAsync(nameof(NewsPage), navigationParameter);
            }
        }

        public async Task LoadNewsItemsAsync()
        {
            var newsItems = await App.Database.Table<NewsItem>().ToListAsync();
            NewsItems.Clear();
            foreach (var newsItem in newsItems)
            {
                NewsItems.Add(newsItem);
            }
        }

        public async Task SaveNewsItemAsync(NewsItem newsItem)
        {
            if (newsItem == null)
                return;

            if (newsItem.Id != 0)
            {
                await App.Database.UpdateAsync(newsItem);
            }
            else
            {
                await App.Database.InsertAsync(newsItem);
            }
            await LoadNewsItemsAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
