namespace TestShell;

public partial class App : Application
{
    public static string EVENT_LOGGED_IN = "APP_EVENT_LOGGED_IN";

    private static bool UserLoggedIn = false;

    public App()
	{
		InitializeComponent();

        MessagingCenter.Subscribe<object>(this, EVENT_LOGGED_IN, OnLoggedIn);

        RedirectUser();
	}

	protected override void OnResume()
	{
		base.OnResume();

        RedirectUser();
    }

    private void RedirectUser()
    {
        if (App.UserLoggedIn)
        {
            GoToHomePage();
        }
        else
        {
            MainPage = new LoginPage();
        }

        // Uncomment this block and comment the above one to see how everything works well
        // when using only the HomePage (Shell)
        //MainPage = new HomePage();
    }

    private void OnLoggedIn(object sender)
    {
        App.UserLoggedIn = true;

        GoToHomePage();
    }

    private void GoToHomePage()
    {
        MainPage = new HomePage();
    }
}
