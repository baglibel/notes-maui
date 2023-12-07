using Notes.Views;

namespace Notes;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new LoginView();
        Current.UserAppTheme = AppTheme.Dark;
    }
}
