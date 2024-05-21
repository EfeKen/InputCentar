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
}