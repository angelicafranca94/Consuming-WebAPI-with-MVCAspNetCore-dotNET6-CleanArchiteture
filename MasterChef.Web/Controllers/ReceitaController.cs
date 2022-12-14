using MasterChef.Domain.Models;
using MasterChef.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace MasterChef.Web.Controllers
{
    public class ReceitaController : Controller
    {
        private readonly ApiConfiguration _apiConfig;
        private readonly HttpClient _client;
        public ReceitaController(IOptions<ApiConfiguration> settings)
        {
            _apiConfig = settings.Value;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_apiConfig.UrlApi);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Receita> receitas = null;

            //HTTP GET
            var response = _client.GetAsync(_apiConfig.EndPointRecipe).Result;

            if (response.IsSuccessStatusCode)
            {
                receitas = response.Content.ReadFromJsonAsync<IList<Receita>>().Result;
            }


            return View(receitas);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            Receita receitas = new Receita();

            var response = _client.GetAsync(_apiConfig.EndPointRecipe + "/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                receitas = response.Content.ReadFromJsonAsync<Receita>().Result;
            }

            return View(receitas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<Categoria> receitas = null;

            //HTTP GET
            var response = _client.GetAsync(_apiConfig.EndPointCategory).Result;

            if (response.IsSuccessStatusCode)
            {
                receitas = response.Content.ReadFromJsonAsync<IList<Categoria>>().Result;


                List<SelectListItem> Lista = new List<SelectListItem>();
                Lista.Add(new SelectListItem //adiciona uma opção que convida a escolher uma das possíveis opções
                {
                    Text = "Selecione uma Categoria",
                    Value = ""
                });

                foreach (var Linha in receitas)
                {
                    Lista.Add(new SelectListItem()
                    {
                        Value = Linha.Id.ToString(),
                        Text = Linha.Titulo
                    });
                }
                ViewBag.ListCategories = Lista;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Receita model)
        {
            string data = JsonSerializer.Serialize(model);
            StringContent content = new StringContent(data,
                Encoding.UTF8, "application/json");

            HttpResponseMessage response = _client.PostAsync(_apiConfig.EndPointRecipe, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Receita receitas = new Receita();

            var response = _client.GetAsync(_apiConfig.EndPointRecipe + "/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                receitas = response.Content.ReadFromJsonAsync<Receita>().Result;
            }


            IEnumerable<Categoria> categorias = null;

            //HTTP GET
            var responseCategory = _client.GetAsync(_apiConfig.EndPointCategory).Result;

            if (responseCategory.IsSuccessStatusCode)
            {
                categorias = responseCategory.Content.ReadFromJsonAsync<IList<Categoria>>().Result;


                List<SelectListItem> Lista = new List<SelectListItem>();
                Lista.Add(new SelectListItem //adiciona uma opção que convida a escolher uma das possíveis opções
                {
                    Text = "Selecione uma Categoria",
                    Value = ""
                });

                foreach (var Linha in categorias)
                {
                    Lista.Add(new SelectListItem()
                    {
                        Value = Linha.Id.ToString(),
                        Text = Linha.Titulo
                    });
                }
                ViewBag.ListCategories = Lista;
            }

            return View(receitas);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Receita model)
        {
            string data = JsonSerializer.Serialize(model);
            StringContent content = new StringContent(data,
                Encoding.UTF8, "application/json");

            HttpResponseMessage response = _client.PutAsync(_apiConfig.EndPointRecipe, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = _client.DeleteAsync(_apiConfig.EndPointRecipe + "/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(response.StatusCode);
        }
    }
}
