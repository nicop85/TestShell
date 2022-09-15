namespace TestShell;

public partial class UnlockPage : ContentPage
{
	public UnlockPage()
	{
		InitializeComponent();
	}

	private void OnUnlockClicked(object sender, EventArgs e)
	{
        MessagingCenter.Send<object>(this, HomePage.EVENT_UNLOCK_SUCCESS);
	}
}