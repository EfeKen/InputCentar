namespace InputCentar;

public partial class PridruziSe : ContentPage
{
	public PridruziSe()
	{
		InitializeComponent();
	}
    private void OnImageButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Volontiraj());
    }

    private void OnImageButton2_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Praksa());
    }
    private void OnImageButton3_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Upit());
    }
    private void OnImageButto4_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Doniraj());
    }
}