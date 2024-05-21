using Microsoft.Maui.Controls;
using InputCentar.Models;
using System;

namespace InputCentar
{
    [QueryProperty(nameof(NewsItem), "NewsItem")]
    public partial class NewsPage : ContentPage
    {
        private NewsItem newsItem;
        public NewsItem NewsItem
        {
            get => newsItem;
            set
            {
                newsItem = value;
                OnPropertyChanged();
                UpdateNewsDetails();
            }
        }

        public NewsPage()
        {
            InitializeComponent();
        }

        private void UpdateNewsDetails()
        {
            if (NewsItem != null)
            {
                NewsImage.Source = NewsItem.ImageUrl;
                NewsTitle.Text = NewsItem.Title;
                newsDescription.Text = NewsItem.Description;
                newsDate.Text = NewsItem.Date;
                newsDetailText.Text = NewsItem.DetailText; 
            }
        }
    }
}