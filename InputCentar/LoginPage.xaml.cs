using InputCentar.Data;
using InputCentar.ViewModels;
using InputCentar.Models;

namespace InputCentar;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        var databaseService = App.Database;
        var userViewModel = new UserViewModel(databaseService);
        BindingContext = userViewModel;
    }
    private void Login_Clicked(object sender, EventArgs e)
    {
     
    }

    private void Registracija_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Registracija());
    }

}