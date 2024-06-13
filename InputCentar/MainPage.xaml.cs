using System;
using System.ComponentModel;
using InputCentar.ViewModels;
using InputCentar.Models;
using Microsoft.Maui.Controls;

namespace InputCentar
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
            // Set the BindingContext for NewsViewModel
            this.BindingContext = new NewsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Load news items when the page appears
            LoadNewsItems();
        }

        public async void LoadNewsItems()
        {
            // Ensure the BindingContext is set to NewsViewModel
            if (BindingContext is NewsViewModel viewModel)
            {
                // Load news items asynchronously
                await viewModel.LoadNewsItems();
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
