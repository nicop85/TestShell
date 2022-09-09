namespace TestShell;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
	}

	private void OnLoginClicked(object sender, EventArgs e)
	{
        MessagingCenter.Send<object>(this, App.EVENT_LOGGED_IN);
	}
}