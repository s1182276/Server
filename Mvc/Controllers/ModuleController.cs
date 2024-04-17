using KeuzeWijzerApi.Models;
using KeuzeWijzerMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace KeuzeWijzerMvc.Controllers
{
    public class ModuleController : Controller
    {
        private readonly IService<Module> _moduleSvc;

        public ModuleController(IService<Module> moduleService)
        {
            _moduleSvc = moduleService;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _moduleSvc.GetAsync("/Module/GetAllModules"));
        }

        public async Task<ActionResult> Details(int id)
        {
            var album = await _moduleSvc.GetAsync(id, "/Module");
            if (album == null) return NotFound();
            return View(album);
        }
    }
}
