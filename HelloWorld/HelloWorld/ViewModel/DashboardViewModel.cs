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
        MovieService service;
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


        private ObservableCollection<Movie> movies;

        public ObservableCollection<Movie> Movies
        {
            get { return movies; }
            set
            {
                movies = value;
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
            service = new MovieService();
            OnSearchCommand = new Command(async () => await OnSearch(), () => !IsBusy);
        }
        async Task OnSearch()
        {
            IsBusy = true;
            var obj = await service.GetMovies(searchText?.Trim());
            if (obj.data.movie_count == 0)
            {
                OnShowDialog($"Search result for {SearchText}", $"0 result found.");
                IsBusy = false;
                return;
            }
            OnShowDialog($"Search result for {SearchText}", $"{obj.data.movie_count} result found.");
            Movies = new ObservableCollection<Movie>(obj.data?.movies);
            IsBusy = false;
        }
    }
}
