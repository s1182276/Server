using KeuzeWijzerCore.Models;
using KeuzeWijzerMvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KeuzeWijzerMvc.Controllers
{
    public class ModuleController : Controller
    {
        private readonly IService<ModuleDto> _moduleSvc;
        //public SelectList selectList { get; set; }

        public ModuleController(IService<ModuleDto> moduleService)
        {
            _moduleSvc = moduleService;
        }

        public async Task<ActionResult> Index()
        {
            var view = await _moduleSvc.GetAsync("/Module");
            return View(view);
        }

        public async Task<ActionResult> Details(int id)
        {
            var module = await _moduleSvc.GetAsync(id, "/Module");
            if (module == null) return NotFound();
            return View(module);
        }

        // GET: [Controller]/Create
        public ActionResult Create() => View();

        // POST: [Controller]/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ModuleDto module)
        {
            if (await _moduleSvc.AddAsync(module, "/Module")) return RedirectToAction(nameof(Index));
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            return View(await _moduleSvc.GetAsync(id, "/Module"));
        }

        // POST: [Controller]/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ModuleDto module)
        {
            if (await _moduleSvc.UpdateAsync(id, module, "/Module")) return RedirectToAction(nameof(Index));
            return View();
        }


        public async Task<ActionResult> Delete(int id)
        {
            var module = await _moduleSvc.GetAsync(id, "/Module");
            if (module == null) return NotFound();
            return View(module);
        }

        // POST: [Controller]/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (await _moduleSvc.DeleteAsync(id, "/Module")) return RedirectToAction(nameof(Index));
            return View();
        }

        public ActionResult Stop()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
