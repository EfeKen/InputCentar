namespace InputCentar;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
    }

    private void Registracija_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Registracija());
    }

}