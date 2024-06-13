using System;
using System.ComponentModel;
using InputCentar.ViewModels;
using InputCentar.Models;
using Microsoft.Maui.Controls;

namespace InputCentar
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private bool isAdmin;
        public bool IsAdmin
        {
            get => isAdmin;
            set
            {
                if (isAdmin != value)
                {
                    isAdmin = value;
                    OnPropertyChanged(nameof(IsAdmin));
                }
            }
        }

        public MainPage()
        {
            InitializeComponent();
            // Set the BindingContext for NewsViewModel
            this.BindingContext = new NewsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Update IsAdmin based on the current user role
            IsAdmin = App.CurrentUser?.Role == UserRoles.Admin;
            // Notify UI of property change
            OnPropertyChanged(nameof(IsAdmin));
        }

        private void AddNewsClicked(object sender, EventArgs e)
        {
            if (IsAdmin)
            {
                var viewModel = (NewsViewModel)this.BindingContext;
                viewModel.NewTitle = string.Empty;
                viewModel.NewDescription = string.Empty;
                viewModel.NewImageUrl = string.Empty;
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

            var viewModel = (NewsViewModel)this.BindingContext;
            await viewModel.AddNewsItem();
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
            {
                var viewModel = (NewsViewModel)this.BindingContext;
                await viewModel.DeleteNewsItem(newsItem);
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged;
        protected override void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            base.OnPropertyChanged(propertyName);
        }
    }
}
