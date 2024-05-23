using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InputCentar
{
    public partial class MainPage : ContentPage
    {

        NewsViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            GoToMainPageCommand = new Command(GoToMainPage);
            BindingContext = this;

            viewModel = (NewsViewModel)BindingContext;

            /*   Task.Run(async () =>
               {
                   while (true)
                   {

                       await Task.Delay(5000); 
                       currentIndex = (currentIndex + 1) % imageSources.Count;
                       await mainImage.FadeTo(0, 250); 
                       mainImage.Source = imageSources[currentIndex]; 
                       await mainImage.FadeTo(1, 250); 
                   }
               });*/
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.LoadNewsItemsAsync();
        }

        private async void GoToMainPage()
        {
            await Navigation.PushAsync(new MainPage());
        }
    }


}