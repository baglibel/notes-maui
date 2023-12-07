using Notes.Services;
namespace Notes.Views;

public partial class LoginView : ContentPage
{
	public LoginView()
	{
		InitializeComponent();

	}
	private int attempt;
    protected override void OnAppearing()
    {
        base.OnAppearing();
        lblError.Text = string.Empty;
		btnLogin.IsEnabled = true;
        bool logged_in = Preferences.Get("logged_in", false);
        if (logged_in)
            App.Current.MainPage = new NavigationPage(new MainView());
    }
    private void OnLoginClicked(object sender, EventArgs e)
    {
		string user = entryUsername.Text;
		string pass = entryPassword.Text;
		if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
		{
            ShowError("All fields must be filled!");
			return;
        }
		if (attempt >= 3)
		{
            btnLogin.IsEnabled = false;
            ShowError("Too much failed login attempts!");
			return;
        }
		if (!LoginService.isCorrect(user, pass))
		{
            ++attempt;
            ShowError("Invalid username or password!");
            return;
        }
		Preferences.Set("logged_in", true);
        App.Current.MainPage = new NavigationPage(new MainView());
		entryUsername.Text = string.Empty;
		entryPassword.Text = string.Empty;					
    }
    private async void ShowError(string error)
    {
        lblError.Text = error;
        await Task.Delay(3000);
        lblError.Text = "";
    }
}