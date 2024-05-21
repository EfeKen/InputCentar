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
        await Launcher.OpenAsync(new Uri("https://www.facebook.com/CentarINPUT/"));
    }
    private async void Label_Tapped(object sender, EventArgs e)
    {
        // Otvori URL u web pregledniku
        await Launcher.OpenAsync(new Uri("https://www.facebook.com/CentarINPUT"));
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