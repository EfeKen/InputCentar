using System;
using InputCentar.ViewModels;
using InputCentar.Models;

namespace InputCentar
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AddNewsClicked(object sender, EventArgs e)
        {
            ((NewsViewModel)BindingContext).NewTitle = string.Empty;
            ((NewsViewModel)BindingContext).NewDescription = string.Empty;
            ((NewsViewModel)BindingContext).NewImageUrl = string.Empty;
            addNewsForm.IsVisible = !addNewsForm.IsVisible;
        }

        private async void AddClicked(object sender, EventArgs e)
        {
            await ((NewsViewModel)BindingContext).AddNewsItem();
            addNewsForm.IsVisible = false;
        }
        private async void DeleteNewsClicked(object sender, System.EventArgs e)
        {
            // Retrieve the clicked news item from the binding context
            var newsItem = ((Button)sender).BindingContext as NewsItem;

            // Call the corresponding method in the view model to delete the news item
            if (newsItem != null)
                await ((NewsViewModel)BindingContext).DeleteNewsItem(newsItem);
        }
    }
}
