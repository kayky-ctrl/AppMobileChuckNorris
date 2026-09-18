using AppMobileChuckNorris.ViewModels;

namespace AppMobileChuckNorris
{
    public partial class MainPage : ContentPage
    {

        public MainPage(ChuckNorrisViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}
