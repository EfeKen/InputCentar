namespace InputCentar;

public partial class PridruziSe : ContentPage
{
	public PridruziSe()
	{
		InitializeComponent();
	}
    private void Page1Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Volontiraj());
    }

    private void Page2Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Praksa());
    }

    private void Page3Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Upit());
    }

    private void Page4Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Doniraj());
    }
}