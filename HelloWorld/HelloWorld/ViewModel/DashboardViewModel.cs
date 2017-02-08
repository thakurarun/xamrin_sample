using Android.App;
using HelloWorld.Model.WebModel;
using HelloWorld.Service;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloWorld.ViewModel
{
    public class DashboardViewModel : BaseViewModel
    {
        NewsService service;
        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnProperyChange();
            }
        }

        private ObservableCollection<Article> articles;

        public ObservableCollection<Article> Articles
        {
            get { return articles; }
            set
            {
                articles = value;
                OnProperyChange();
            }
        }

        public Command OnSearchCommand { get; }

        public delegate void ShowDialog(string title, string message);
        public event ShowDialog DialogEventHandler;
        protected void OnShowDialog(string title, string message)
        {
            DialogEventHandler?.Invoke(title, message);
        }

        public DashboardViewModel()
        {
            service = new NewsService();
            OnSearchCommand = new Command(async () => await OnSearch(), () => !IsBusy);
        }
        async Task OnSearch()
        {
            IsBusy = true;
            Articles = new ObservableCollection<Article>(await service?.GetArticles());
            if (Articles?.Count == 0)
                OnShowDialog("Search Performed", "API NOT WORKING.");
            IsBusy = false;
        }
    }
}
