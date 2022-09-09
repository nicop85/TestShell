namespace TestShell;

public partial class HomePage : Shell
{
	public HomePage()
	{
        FlyoutItem item = new FlyoutItem()
        {
            Title = "Home",
            Route = "MainPage",
            Items =
            {
                new ShellContent()
                {
                    ContentTemplate = new DataTemplate(typeof(DetailPage))
                }
            }
        };

        Items.Add(item);

        InitializeComponent();
	}
}
