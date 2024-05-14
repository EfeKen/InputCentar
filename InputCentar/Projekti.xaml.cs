using System;
using Microsoft.Maui.Controls;

namespace InputCentar
{
    public partial class Projekti : ContentPage
    {
        public Projekti()
        {
            InitializeComponent();

            // Mock data for projects
            var projects = new[]
            {
                new { Name = "Project 1" },
                new { Name = "Project 2" },
                new { Name = "Project 3" },
                // Add more projects as needed
            };

            // Set the items source of the ListView to the list of projects
            ProjektiListView.ItemsSource = projects;
        }

        private void AktivniProjekti_Clicked(object sender, EventArgs e)
        {
            // Handle button click here
            // You can add code to navigate to another page or perform any action you want
            // For example:
            // Navigation.PushAsync(new AktivniProjektiPage());
        }
    }
}
