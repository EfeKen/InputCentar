using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace InputCentar
{
    public partial class Kalendar: ContentPage
    {
        public Kalendar()
        {
            InitializeComponent();

            // Populate the pickers with date options
            PopulatePickers();
        }

        private void PopulatePickers()
        {
            // Generate a list of date options
            List<string> dateOptions = new List<string>();
            //DateTime currentDate = DateTime.Now.Date;
           DateTime currentDate = DateTime.MinValue; 
            List<string> dateOptionsmm = new List<string>();
            List<string> dateOptionsyy = new List<string>();
            DateTime currentDatemm = DateTime.MinValue;
            DateTime currentDateyy = DateTime.MinValue;
            for (int i = 0; i < 30; i++) // Populate options for the next 30 days
            {
                dateOptions.Add(currentDate.AddDays(i).ToString("dd"));
               
            }
            //za mjesece 
            for (int i = 0; i < 12; i++) 
            {
                dateOptionsmm.Add(currentDate.AddMonths(i).ToString("MM"));

            }



            //za godine
            for (int i = 0; i < 50; i++)
            {
                dateOptionsyy.Add(currentDate.AddMonths(i).ToString("YYYY"));

            }


            // Populate the StartPicker and EndPicker with date options
            foreach (string dateOption in dateOptions)
            {
                
                StartPicker.Items.Add(dateOption);
                EndPicker.Items.Add(dateOption);
            }
            foreach (string dateOptionmm in dateOptionsmm)
            {

                StartPickerMM.Items.Add(dateOptionmm);
                EndPickerMM.Items.Add(dateOptionmm);
            }
            foreach (string dateOptionyy in dateOptionsyy)
            {

                StartPickerYY.Items.Add(dateOptionyy);
                EndPickerYY.Items.Add(dateOptionyy);
            }
        }

        private async void RentButton_Clicked(object sender, EventArgs e)
        {
            string startDate = StartPicker.SelectedItem?.ToString();
            string endDate = EndPicker.SelectedItem?.ToString();
            string startDatemm = StartPickerMM.SelectedItem?.ToString();
            string endDatemm = EndPickerMM.SelectedItem?.ToString();
            string startDateyy = StartPickerYY.SelectedItem?.ToString();
            string endDateyy = EndPickerYY.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate)|| string.IsNullOrEmpty(startDatemm) || string.IsNullOrEmpty(endDatemm) || string.IsNullOrEmpty(startDateyy) || string.IsNullOrEmpty(endDateyy)  )
            {
                await DisplayAlert("Error", "Please select both start and end dates.", "OK");
                return;
            }

            // Your rental functionality here, e.g., saving to database, processing payment, etc.

            // Show success message
            await DisplayAlert("Success", "Reservation successful!", "OK");
        }
    }
}
