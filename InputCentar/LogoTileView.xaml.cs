namespace InputCentar;

public partial class LogoTileView : ContentView
{
	public LogoTileView()
	{
		InitializeComponent();
	}
    private async void OnLogoTapped(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PopToRootAsync();
        await Shell.Current.GoToAsync("//MainPage");
    }
}