namespace InputCentar;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;


public partial class Kontakt : ContentPage
{
	public Kontakt()

    {
        InitializeComponent();
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        
        await Launcher.OpenAsync(new Uri("https://www.google.com/maps/place/Mokušnice+10,+Zenica+72000,+Bosna+i+Hercegovina/@44.195711,17.907922,14z/data=!4m6!3m5!1s0x475ee26ac104fce1:0x44ce56d2059fc280!8m2!3d44.1957114!4d17.9079221!16s%2Fg%2F11vjljrrn6?hl=hr-HR&entry=ttu"));
    }

    private async void ImageButton_ClickedI(object sender, EventArgs e)
    {

        await Launcher.OpenAsync(new Uri("https://mail.google.com"));
    }

    private async void OnCallButtonClicked(object sender, EventArgs e)
    {
        try
        {
            // Broj telefona koji želite da pozovete
            string phoneNumber = "062 116 343";

            // Kreirajte URI za poziv
            var uri = new Uri($"tel:{phoneNumber}");

            // Pokrenite dialer
            await Launcher.Default.OpenAsync(uri);
        }
        catch (Exception ex)
        {
            // Rukovanje izuzecima
            await DisplayAlert("Greška", $"Nije moguće pokrenuti dialer: {ex.Message}", "OK");
        }
    }
}