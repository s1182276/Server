using KeuzeWijzerCore.Models;
using KeuzeWijzerMvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KeuzeWijzerMvc.Controllers
{
    public class SchoolYearController : Controller
    {
        private readonly IService<SchoolYearDto> _schoolYearSvc;
        //public SelectList selectList { get; set; }

        public SchoolYearController(IService<SchoolYearDto> schoolYearService)
        {
            _schoolYearSvc = schoolYearService;
        }

        public async Task<ActionResult> Index()
        {
            var view = await _schoolYearSvc.GetAsync("/SchoolYears");
            return View(view);
        }

        public async Task<ActionResult> Details(int id)
        {
            var schoolYear = await _schoolYearSvc.GetAsync(id, "/SchoolYears");
            if (schoolYear == null) return NotFound();
            return View(schoolYear);
        }

        // GET: [Controller]/Create
        public ActionResult Create() => View();

        // POST: [Controller]/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SchoolYearDto schoolYear)
        {
            if (await _schoolYearSvc.AddAsync(schoolYear, "/SchoolYears")) return RedirectToAction(nameof(Index));
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            return View(await _schoolYearSvc.GetAsync(id, "/SchoolYears"));
        }

        // POST: [Controller]/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SchoolYearDto schoolYear)
        {
            if (await _schoolYearSvc.UpdateAsync(id, schoolYear, "/SchoolYears")) return RedirectToAction(nameof(Index));
            return View();
        }

        public async Task<ActionResult> Delete(int id)
        {
            var schoolYear = await _schoolYearSvc.GetAsync(id, "/SchoolYears");
            if (schoolYear == null) return NotFound();
            return View(schoolYear);
        }

        // POST: [Controller]/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (await _schoolYearSvc.DeleteAsync(id, "/SchoolYears")) return RedirectToAction(nameof(Index));
            return View();
        }

        public ActionResult Stop()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
