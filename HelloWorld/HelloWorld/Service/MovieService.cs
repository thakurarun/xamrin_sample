using HelloWorld.Model.WebModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace HelloWorld.Service
{
    public class MovieService
    {
        readonly HttpClient client = new HttpClient();
        public async Task<RootObject> GetMovies(string serachText = "")
        {
            var url = $"https://yts.ag/api/v2/list_movies.json?limit=50&sort_by=rating&query_term={serachText}";
            var response = await client.GetAsync(url);
            var data = await response.Content?.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RootObject>(data);
        }
    }
}
