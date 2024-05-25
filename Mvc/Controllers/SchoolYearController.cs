using KeuzeWijzerCore.Models;
using KeuzeWijzerMvc.Services.Interfaces;
using KeuzeWijzerMvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KeuzeWijzerMvc.Controllers
{
    public class SchoolYearController : Controller
    {
        private readonly IService<SchoolYearDto> _schoolYearSvc;
        private readonly IService<SchoolModuleDto> _moduleSvc;
        //public SelectList selectList { get; set; }

        public SchoolYearController(IService<SchoolYearDto> schoolYearService,
                                    IService<SchoolModuleDto> moduleSvc)
        {
            _schoolYearSvc = schoolYearService;
            _moduleSvc = moduleSvc;
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


        // GET: [Controller]/Copy/5
        public async Task<ActionResult> Copy(int id)
        {
            var schoolYear = await _schoolYearSvc.GetAsync(id, "/SchoolYears");
            // Need to add a warning or notice here
            if (schoolYear == null)
            {
                return NotFound();
            }

            schoolYear.Name = $"{schoolYear.Name} - Kopie";

            var syvm = new SchoolYearViewModel(schoolYear);

            return View(syvm);
        }


        // POST: [Controller]/Copy/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CopySchoolYear(SchoolYearViewModel syvm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            var modules = syvm.GetSchoolModules();

            if (modules != null)
            {
                foreach (var module in modules)
                {
                    module.Id = 0;
                }
            }

            var schoolYearDto = new SchoolYearDto()
            {
                Id = syvm.Id,
                Name = syvm.Name,
                SchoolModules = modules != null ? modules : null
            };

            if (await _schoolYearSvc.AddAsync(schoolYearDto, "/SchoolYears")) return RedirectToAction(nameof(Index));
            return View();
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
