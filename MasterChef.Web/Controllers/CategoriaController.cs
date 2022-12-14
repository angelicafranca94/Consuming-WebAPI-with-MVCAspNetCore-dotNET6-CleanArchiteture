using MasterChef.Domain.Models;
using MasterChef.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categoria model)
        {
            string data = JsonSerializer.Serialize(model);
            StringContent content = new StringContent(data,
                Encoding.UTF8, "application/json");

            HttpResponseMessage response = _client.PostAsync(_apiConfig.EndPointCategory, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Categoria categoria = new Categoria();

            var response = _client.GetAsync(_apiConfig.EndPointCategory + "/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                categoria = response.Content.ReadFromJsonAsync<Categoria>().Result;
            }

            return View(categoria);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Categoria model)
        {
            string data = JsonSerializer.Serialize(model);
            StringContent content = new StringContent(data,
                Encoding.UTF8, "application/json");

            HttpResponseMessage response = _client.PutAsync(_apiConfig.EndPointCategory, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = _client.DeleteAsync(_apiConfig.EndPointCategory + "/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(response.StatusCode);
        }
    }
}
