namespace TestShell;

public partial class App : Application
{
    public App()
	{
		InitializeComponent();

        MainPage = new HomePage();
	}

	protected override void OnResume()
	{
		base.OnResume();

		(Shell.Current as HomePage).OnResume();
	}
}
