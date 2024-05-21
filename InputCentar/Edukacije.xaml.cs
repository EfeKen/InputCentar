namespace InputCentar;

public partial class Edukacije : ContentPage
{
	public Edukacije()
	{
		InitializeComponent();
	}
    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        // Otvori URL u web pregledniku
        await Launcher.OpenAsync(new Uri("https://docs.google.com/forms/d/e/1FAIpQLSfyd90CTw-Z9Wlrt0wjcSn4Fc6WGrujCyE1SGwSR4wMQh7ufQ/viewform?usp=sf_link"));
    }
    private async void Label_Tapped(object sender, EventArgs e)
    {
        // Otvori URL u web pregledniku
        await Launcher.OpenAsync(new Uri("https://docs.google.com/forms/d/e/1FAIpQLSfyd90CTw-Z9Wlrt0wjcSn4Fc6WGrujCyE1SGwSR4wMQh7ufQ/viewform?usp=sf_link"));
    }
    private async void FacebookButton_Clicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync(new Uri("https://www.facebook.com/CentarINPUT"));
    }

    private async void InstagramButton_Clicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync(new Uri("https://www.instagram.com/centar_za_mlade_input/"));
    }

    private async void LinkedInButton_Clicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync(new Uri("https://ba.linkedin.com/in/centar-za-mlade-input-304976137"));
    }
}