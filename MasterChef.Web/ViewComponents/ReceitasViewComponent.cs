using MasterChef.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MasterChef.Web.ViewComponents
{
    public class ReceitasViewComponent : ViewComponent
    {

        private IReceitaService _receitaService;

        public ReceitasViewComponent(IReceitaService receitaService)
        {
            _receitaService = receitaService;

        }

        public async Task<IViewComponentResult> InvokeAsync(int total, bool receitasDestaques)
        {
            var view = "receitas";

            if (receitasDestaques)
            {
                view = "receitasDestaques";
            }
            var noticias = _receitaService.Load(total);


            return View(view, noticias);

        }

    }
}
