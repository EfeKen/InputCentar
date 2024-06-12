using System;
using InputCentar.ViewModels;
using InputCentar.Models;
using Microsoft.Maui.Controls;

namespace InputCentar
{
    public partial class MainPage : ContentPage
    {
        public bool IsAdmin { get; set; }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new NewsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Update IsAdmin based on the current user role
            IsAdmin = App.CurrentUser?.Role == UserRoles.Admin;
            OnPropertyChanged(nameof(IsAdmin));
        }

        private void AddNewsClicked(object sender, EventArgs e)
        {
            if (IsAdmin)
            {
                ((NewsViewModel)BindingContext).NewTitle = string.Empty;
                ((NewsViewModel)BindingContext).NewDescription = string.Empty;
                ((NewsViewModel)BindingContext).NewImageUrl = string.Empty;
                addNewsForm.IsVisible = !addNewsForm.IsVisible;
            }
            else
            {
                DisplayAlert("Error", "You must be an admin to add news", "OK");
            }
        }

        private async void AddClicked(object sender, EventArgs e)
        {
            if (!IsAdmin)
            {
                await DisplayAlert("Error", "You must be an admin to add news", "OK");
                return;
            }

            await ((NewsViewModel)BindingContext).AddNewsItem();
            addNewsForm.IsVisible = false;
        }

        private async void DeleteNewsClicked(object sender, EventArgs e)
        {
            if (!IsAdmin)
            {
                await DisplayAlert("Error", "You must be an admin to delete news", "OK");
                return;
            }

            var newsItem = ((Button)sender).BindingContext as NewsItem;
            if (newsItem != null)
                await ((NewsViewModel)BindingContext).DeleteNewsItem(newsItem);
        }
    }
}
