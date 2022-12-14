using MasterChef.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MasterChef.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}