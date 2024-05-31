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
                DisplayAlert("Reservation", $"Reservation made from {startDate.ToShortDateString()} to {endDate.ToShortDateString()}", "OK");
            }
            else
            {
                DisplayAlert("Error", "End date must be after start date", "OK");
            }
        }
    }
}
