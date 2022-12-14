using MasterChef.Domain.Models;
using MasterChef.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MasterChef.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApiConfiguration _apiConfig;
        private readonly HttpClient _client;
        public CategoriaController(IOptions<ApiConfiguration> settings)
        {
            _apiConfig = settings.Value;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_apiConfig.UrlApi);
        }
        public async Task<IActionResult> Index()
        {

            IEnumerable<Categoria> categoria = null;

            //HTTP GET
            var response = _client.GetAsync(_apiConfig.EndPointCategory).Result;

            if (response.IsSuccessStatusCode)
            {
                categoria = response.Content.ReadFromJsonAsync<IList<Categoria>>().Result;
            }


            return View(categoria);
        }

        public async Task<IActionResult> ListRecipes(int id)
        {
            Categoria categoria = new Categoria();

            var response = _client.GetAsync(_apiConfig.EndPointCategory + "/listrecipes/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                categoria = response.Content.ReadFromJsonAsync<Categoria>().Result;
            }

            return View(categoria);
        }
    }
}
