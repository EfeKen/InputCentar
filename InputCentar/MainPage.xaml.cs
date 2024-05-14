using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InputCentar
{
    public partial class MainPage : ContentPage
    {
        private List<string> imageSources = new List<string> { "image1.jpg", "image2.jpg", "image3.jpg" };
        private int currentIndex = 0;

        public MainPage()
        {
            InitializeComponent();

            
            Task.Run(async () =>
            {
                while (true)
                {
                   
                    await Task.Delay(5000); 
                    currentIndex = (currentIndex + 1) % imageSources.Count;
                    await mainImage.FadeTo(0, 250); 
                    mainImage.Source = imageSources[currentIndex]; 
                    await mainImage.FadeTo(1, 250); 
                }
            });
        }
    }
}