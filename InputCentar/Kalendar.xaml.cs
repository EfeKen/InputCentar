using Microsoft.Maui.Controls;
using System;

namespace InputCentar
{
    public partial class Kalendar : ContentPage
    {
        private DateTime startDate;
        private DateTime endDate;

        public Kalendar()
        {
            InitializeComponent();
        }

        private void StartDateSelected(object sender, DateChangedEventArgs e)
        {
            startDate = e.NewDate;
        }

        private void EndDateSelected(object sender, DateChangedEventArgs e)
        {
            endDate = e.NewDate;
        }

        private void MakeReservationClicked(object sender, EventArgs e)
        {
            // Handle reservation logic here
            if (startDate < endDate)
            {
                // Make reservation for the selected date range
                DisplayAlert("Rezervacija", $"Uspješno ste rezervisali od {startDate.ToShortDateString()} do {endDate.ToShortDateString()}", "OK");
            }
            else
            {
                DisplayAlert("Error", "Datum završetka mora biti poslije datuma poèetka", "OK");
            }
        }
    }
}
