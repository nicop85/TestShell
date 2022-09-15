namespace TestShell;

public partial class DetailPage2 : ContentPage
{
	int count = 0;

	public DetailPage2()
	{
		InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
	{
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}

