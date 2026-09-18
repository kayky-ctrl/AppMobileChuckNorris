using AppMobileChuckNorris.ViewModels;

namespace AppMobileChuckNorris.Views;

public partial class PotterPage : ContentPage
{
	public PotterPage(PotterViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}