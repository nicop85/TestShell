namespace TestShell;

public partial class DetailPage : ContentPage
{
	public DetailPage()
	{
		InitializeComponent();
    }

	private void OnGoToNextPage(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync(nameof(DetailPage2));
	}
}

