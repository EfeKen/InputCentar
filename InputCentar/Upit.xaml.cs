namespace InputCentar;

public partial class Upit : ContentPage
{
	public Upit()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync(new Uri("https://docs.google.com/forms/d/e/1FAIpQLSfyd90CTw-Z9Wlrt0wjcSn4Fc6WGrujCyE1SGwSR4wMQh7ufQ/viewform?usp=sf_link"));
    }
}