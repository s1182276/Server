using KeuzeWijzerCore.Models;
using KeuzeWijzerMvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KeuzeWijzerMvc.Controllers
{
    public class SchoolModuleController : Controller
    {
        private readonly IService<SchoolModuleDto> _moduleSvc;
        //public SelectList selectList { get; set; }

        public SchoolModuleController(IService<SchoolModuleDto> moduleService)
        {
            _moduleSvc = moduleService;
        }

        public async Task<ActionResult> Index()
        {
            var view = await _moduleSvc.GetAsync("/SchoolModule");
            return View(view);
        }


        public async Task<ActionResult> Details(int id)
        {
            var module = await _moduleSvc.GetAsync(id, "/SchoolModule");
            if (module == null) return NotFound();
            return View(module);
        }

        // GET: [Controller]/Create
        public ActionResult Create() => View();

        // POST: [Controller]/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SchoolModuleDto module)
        {
            if (await _moduleSvc.AddAsync(module, "/SchoolModule")) return RedirectToAction(nameof(Index));
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            return View(await _moduleSvc.GetAsync(id, "/SchoolModule"));
        }

        // POST: [Controller]/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SchoolModuleDto module)
        {
            if (await _moduleSvc.UpdateAsync(id, module, "/SchoolModule")) return RedirectToAction(nameof(Index));
            return View();
        }


        public async Task<ActionResult> Delete(int id)
        {
            var module = await _moduleSvc.GetAsync(id, "/SchoolModule");
            if (module == null) return NotFound();
            return View(module);
        }

        // POST: [Controller]/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (await _moduleSvc.DeleteAsync(id, "/SchoolModule")) return RedirectToAction(nameof(Index));
            return View();
        }

        public ActionResult Stop()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
