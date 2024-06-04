using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Microsoft.Maui.Controls.PlatformConfiguration.macOSSpecific;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Android;
using Microsoft.Maui.Graphics.Win2D;
using Microsoft.Maui.Graphics.NativeText;
using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace InputCentar
{
    public class CustomDatePickerRenderer : DatePicker
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Customize the appearance of the date picker control
                Control.Background = new SolidColorBrush(Colors.White);
                Control.TextSize = 18;

                // Highlight already used dates in red
                Control.On<Android>().SetShowWeekNumbers(true);
                Control.On<Android>().SetDayOfWeekFormat(DayOfWeekFormat.Short);

                // Example: Highlight dates between 2022-01-01 and 2022-01-15
                Control.On<Android>().SetDateRestriction(new DateTime(2022, 1, 1), new DateTime(2022, 1, 15));
            }
        }
    }
}
