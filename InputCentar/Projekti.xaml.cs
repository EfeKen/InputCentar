using System;
using Microsoft.Maui.Controls;

namespace InputCentar
{
    public partial class Projekti : ContentPage
    {
        public Projekti()
        {
            InitializeComponent();
            
           

           

          
            
            var projects = new[]
            {
                new { Name = "Project 1" },
                new { Name = "Project 2" },
                new { Name = "Project 3" },
                new { Name = "Project 1" },
                new { Name = "Project 2" },
                new { Name = "Project 3" },
                new { Name = "Project 2" },
                new { Name = "Project 1" },
                new { Name = "Project 2" },
                new { Name = "Project 3" },
                new { Name = "Project 1" },
                new { Name = "Project 2" },
                new { Name = "Project 1" },
                new { Name = "Project 2" },
                new { Name = "Project 1" },
                new { Name = "Project 2" },
                new { Name = "Project 3" },
                new { Name = "Project 1" },
                new { Name = "Project 2" },
                new { Name = "Project 1" },
                new { Name = "Project 2" },
                new { Name = "Project 3" },
                new { Name = "Project 3" },
                new { Name = "Project 3" },
                new { Name = "Project 3" },
                new { Name = "Project 3" },

            };

            
            ProjektiListView.ItemsSource = projects;
        }

        private async void AktivniProjekti_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AktivniProjekti());
        }
        private async void BackButtonClicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new MainPage());
        }
    }
}

