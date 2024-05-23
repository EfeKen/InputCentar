using System;
using System.Globalization;



namespace InputCentar
{
    public partial class Kalendar : ContentPage
    {
        private DateTime currentMonth;
        private DateTime selectedStartDate;
        private DateTime selectedEndDate;

        public Kalendar()
        {
            InitializeComponent();

            // Initialize the calendar
            currentMonth = DateTime.Today;
            selectedStartDate = DateTime.MinValue;
            selectedEndDate = DateTime.MinValue;
            DisplayCalendar(currentMonth);
        }

        private void DisplayCalendar(DateTime month)
        {
            calendarGrid.Children.Clear();
            calendarGrid.RowDefinitions.Clear();
            calendarGrid.ColumnDefinitions.Clear();

            // Add year label
            Label yearLabel = new Label
            {
                Text = month.ToString("MMMM yyyy"),
                HorizontalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold
            };

            // Specify column span for the year label
            Grid.SetColumnSpan(yearLabel, 7);

            calendarGrid.Children.Add(yearLabel);

            // Add weekday labels
            for (int i = 0; i < 7; i++)
            {
                calendarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                Label label = new Label
                {
                    Text = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames[i],
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                };

                // Specify column and row positions for weekday labels
                Grid.SetColumn(label, i);
                Grid.SetRow(label, 1);

                calendarGrid.Children.Add(label);
            }

            // Get the first day of the month and number of days in the month
            DateTime firstDayOfMonth = new DateTime(month.Year, month.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(month.Year, month.Month);

            // Calculate the starting column for the first day of the month
            int startColumn = (int)firstDayOfMonth.DayOfWeek;

            // Add rows for each week
            int numRows = (int)Math.Ceiling((startColumn + daysInMonth) / 7.0) + 2; // Add 2 rows for the last week
            for (int i = 0; i < numRows; i++)
            {
                calendarGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }

            // Add days of the month
            int row = 2; // Start from row 2
            int col = startColumn; // Start from the calculated start column
            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime date = new DateTime(month.Year, month.Month, day);

                Label label = new Label
                {
                    Text = day.ToString(),
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    BackgroundColor = (date >= selectedStartDate && date <= selectedEndDate) ? Color.FromRgb(255, 0, 0) : Color.FromRgb(255, 255, 255) // Red for selected range, white otherwise
                };

                // Specify column and row positions for day labels
                Grid.SetColumn(label, col);
                Grid.SetRow(label, row);

                calendarGrid.Children.Add(label);
                col = (col + 1) % 7;

                // Move to the next row if necessary
                if (col == 0)
                {
                    row++;
                }
            }
        }


        private void CalendarDayTapped(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var day = int.Parse(label.Text);

            DateTime date = new DateTime(currentMonth.Year, currentMonth.Month, day);

            if (selectedStartDate == DateTime.MinValue)
            {
                selectedStartDate = date;
                label.BackgroundColor = Color.FromRgb(255, 0, 0); // Red
            }
            else if (selectedEndDate == DateTime.MinValue)
            {
                if (date > selectedStartDate)
                {
                    selectedEndDate = date;
                    label.BackgroundColor = Color.FromRgb(255, 0, 0); // Red
                }
                else
                {
                    // If user selects a date before the start date, reset selection
                    selectedStartDate = date;
                    selectedEndDate = DateTime.MinValue;
                    DisplayCalendar(currentMonth); // Refresh calendar display
                }
            }
            else
            {
                // If both start and end dates are selected, reset selection
                selectedStartDate = date;
                selectedEndDate = DateTime.MinValue;
                DisplayCalendar(currentMonth); // Refresh calendar display
            }
        }

        private void RezervirajButton_Clicked(object sender, EventArgs e)
        {
            // Handle reservation confirmation
            if (selectedStartDate != DateTime.MinValue && selectedEndDate != DateTime.MinValue)
            {
                // Reservation confirmed for selectedStartDate to selectedEndDate
                // Perform any necessary actions here
                // For example, display confirmation message or process reservation
                // Reset selected dates after confirmation
                selectedStartDate = DateTime.MinValue;
                selectedEndDate = DateTime.MinValue;
                DisplayCalendar(currentMonth); // Refresh calendar display
            }
            else
            {
                // Show error message or prompt user to select both start and end dates
            }
        }

        
        private void NextMonth_Clicked(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(1);
            DisplayCalendar(currentMonth);
        }
    }
}
