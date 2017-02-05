using Android.App;
using HelloWorld.ViewModel;
using Xamarin.Forms;
namespace HelloWorld.Main
{
    public partial class Dashboard : ContentPage
    {
        DashboardViewModel viewModel;
        public Dashboard()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            viewModel = new DashboardViewModel();
            viewModel.DialogEventHandler += ShowMessage;
            BindingContext = viewModel;
        }

        void ShowMessage(string title, string message)
        {
            DisplayAlert(title, message, "Dicard");
        }
    }
}
