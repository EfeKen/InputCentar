using System;
using Microsoft.Maui.Controls;

namespace InputCentar
{
    public partial class Kalendar : ContentPage
    {
        private DateTime? startDate;
        private DateTime? endDate;

        public bool IsRentalDateSelected => startDate.HasValue && endDate.HasValue;

        public Kalendar()
        {
            InitializeComponent();

            // Populate the calendar grid with dates
            PopulateCalendarGrid();
        }

        private void PopulateCalendarGrid()
        {
            // Define the number of rows and columns for the calendar grid
            const int numRows = 6; // 6 weeks for a typical month
            const int numCols = 7; // 7 days in a week

            // Iterate over each row and column to create calendar cells
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    // Calculate the date for the current cell based on the row and column
                    DateTime date = DateTime.Today.AddDays((row * numCols) + col);

                    // Create a label to display the date
                    Label label = new Label
                    {
                        Text = date.Day.ToString(),
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    };

                    // Determine the background color for the date cell
                    Color backgroundColor = GetDateBackgroundColor(date);

                    // Set the background color of the label
                    label.BackgroundColor = backgroundColor;

                    // Add the label to the calendar grid at the current row and column
                    Grid.SetRow(label, row);
                    Grid.SetColumn(label, col);
                    calendarGrid.Children.Add(label);

                    // Add tap gesture recognizer to handle date selection
                    TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (sender, e) => SelectDate(date);
                    label.GestureRecognizers.Add(tapGestureRecognizer);
                }
            }
        }

        private Color GetDateBackgroundColor(DateTime date)
        {
            // Implement logic to determine the background color based on the date
            // For example, use red for occupied dates and green outlined for available dates
            if (IsDateOccupied(date))
            {
                // Red color (RGB: 255, 0, 0)
                return Color.FromRgb(255, 0, 0);
            }
            else if (IsDateAvailable(date))
            {
                // Transparent color (RGB: 0, 0, 0, 0)
                return Color.FromRgba(0, 0, 0, 0);
            }
            else
            {
                // Light gray color (RGB: 211, 211, 211)
                return Color.FromRgb(211, 211, 211);
            }
        }

        private bool IsDateOccupied(DateTime date)
        {
            // Implement logic to check if the date is occupied (already rented)
            // This is a placeholder method, replace it with your actual implementation
            // For example, check if the date falls within an existing rental period
            return false;
        }

        private bool IsDateAvailable(DateTime date)
        {
            // Implement logic to check if the date is available (not rented)
            // This is a placeholder method, replace it with your actual implementation
            // For example, check if the date does not fall within any existing rental periods
            return true;
        }

        private void SelectDate(DateTime date)
        {
            // Handle date selection
            if (!startDate.HasValue)
            {
                startDate = date;
            }
            else if (!endDate.HasValue)
            {
                endDate = date;
            }
            else
            {
                startDate = date;
                endDate = null;
            }

            // Update the calendar grid to reflect the selected dates
            PopulateCalendarGrid();
        }

        private async void ConfirmRental_Clicked(object sender, EventArgs e)
        {
            // Handle confirm rental button click
            if (startDate.HasValue && endDate.HasValue)
            {
                // Implement logic to confirm the rental and store the rental details
                // This is a placeholder method, replace it with your actual implementation
                await DisplayAlert("Rental Confirmed", $"Start Date: {startDate}\nEnd Date: {endDate}", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Please select start and end dates for the rental.", "OK");
            }
        }
    }
}
