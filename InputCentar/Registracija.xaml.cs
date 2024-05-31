namespace InputCentar;

public partial class Registracija : ContentPage
{
	public Registracija()
	{
		InitializeComponent();
	}

    private void Prijava_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginPage());
    }

}