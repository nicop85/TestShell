namespace TestShell;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private void OnLoginClicked(object sender, EventArgs e)
	{
        MessagingCenter.Send<object>(this, HomePage.EVENT_LOGGED_IN);
	}
}