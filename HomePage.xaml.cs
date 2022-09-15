namespace TestShell;

public partial class HomePage : Shell
{
    public static string EVENT_LOGGED_IN = "EVENT_LOGGED_IN";
    public static string EVENT_UNLOCK_SUCCESS = "EVENT_UNLOCK_SUCCESS";

    public bool UserLoggedIn { get; set; } = false;
    public bool ShouldCheckBiometrics { get; set; } = true;

    public HomePage()
	{
        InitializeComponent();

        MessagingCenter.Subscribe<object>(this, EVENT_LOGGED_IN, OnLoggedIn);
        MessagingCenter.Subscribe<object>(this, EVENT_UNLOCK_SUCCESS, OnUnlockSuccess);

        Routing.RegisterRoute(nameof(DetailPage2), typeof(DetailPage2));

        InitializeShell();

        BindingContext = this;
    }

    private void InitializeShell()
    {
        if (!UserLoggedIn)
        {
            GoToLoginPage();
        }
        else
        {
            GoToHomePage();
            
            if (ShouldCheckBiometrics)
            {
                ShowUnlockPage();
            }
        }
    }

    #region Event handlers
    private void OnLoggedIn(object sender)
    {
        UserLoggedIn = true;

        InitializeShell();
    }

    private async void OnUnlockSuccess(object sender)
    {
        await Navigation.PopModalAsync();

        //await Navigation.PopAsync();
    }

    public void OnResume()
    {
        if (ShouldCheckBiometrics)
        {
            ShowUnlockPage();
        }
    }
    #endregion

    #region Redirect logic
    private void GoToLoginPage()
    {
        ShellContent item = new()
        {
            ContentTemplate = new DataTemplate(typeof(LoginPage))
        };

        Items.Clear();
        Items.Add(item);
    }

    private void GoToHomePage()
    {
        FlyoutItem item = new FlyoutItem()
        {
            Title = "Details",
            Route = nameof(DetailPage),
            Items =
            {
                new ShellContent()
                {
                    ContentTemplate = new DataTemplate(typeof(DetailPage))
                }
            }
        };

        Items.Clear();
        Items.Add(item);
    }

    private async void ShowUnlockPage()
    {
        await Navigation.PushModalAsync(new UnlockPage());

        // Changing the above line for the following one, doesn't triggers the exception.
        // You will have to change the line in the OnUnlockSuccess method.
        //await Navigation.PushAsync(new UnlockPage());
    }
    #endregion
}
