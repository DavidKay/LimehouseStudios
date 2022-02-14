using Microsoft.AspNetCore.Mvc;

namespace LimehouseStudios.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
