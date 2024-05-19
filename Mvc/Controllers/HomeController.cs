using Microsoft.AspNetCore.Mvc;

namespace KeuzeWijzerMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
