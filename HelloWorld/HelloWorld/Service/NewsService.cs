using HelloWorld.Model.WebModel;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
namespace HelloWorld.Service
{
    public class NewsService
    {
        const string apiKey = "5ed5428a61e44111813ff327706741bf";
        // https://newsapi.org/v1/articles?source=the-next-web&sortBy=latest&apiKey=5ed5428a61e44111813ff327706741bf
        readonly HttpClient client = new HttpClient();
        public async Task<Article[]> GetArticles(string serachText = "")
        {
            var url = $"https://newsapi.org/v1/articles?source=the-next-web&sortBy=latest&apiKey={apiKey}";
            var response = await client.GetAsync(url);
            var data = await response.Content?.ReadAsStringAsync();
            var Data = JsonConvert.DeserializeObject<ArticleWrapper>(data);
            return Data?.articles;
        }
    }
}
