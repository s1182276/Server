﻿using KeuzeWijzerCore.Models;
using KeuzeWijzerMvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeuzeWijzerMvc.Controllers
{
    public class SchoolModuleController : Controller
    {
        private readonly IService<SchoolModuleDto> _moduleSvc;
        private readonly IService<SchoolYearDto> _schoolYearSvc;
        public SelectList selectList { get; set; }

        public SchoolModuleController(IService<SchoolModuleDto> moduleService,
                                      IService<SchoolYearDto> schoolYearSvc)
        {
            _moduleSvc = moduleService;
            _schoolYearSvc = schoolYearSvc;
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
        public async Task<ActionResult> Create()
        {
            await PopulateViewBag();
            return View();
        }

        // POST: [Controller]/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SchoolModuleDto module)
        {
            await PopulateViewBag();

            if (ModelState.IsValid)
            {
                if (await _moduleSvc.AddAsync(module, "/SchoolModule"))
                    return RedirectToAction(nameof(Index));
            }

            return View(module);
        }

        // GET: [Controller]/Copy/5
        public async Task<ActionResult> Copy(int id)
        {
            var module = await _moduleSvc.GetAsync(id, "/SchoolModule");
            if (module == null) return NotFound();

            await PopulateViewBag();
            module.Name = $"{module.Name} - Kopie";
            return View(module);
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
            if (await _moduleSvc.UpdateAsync(id, module, "/SchoolModule"))
                return RedirectToAction(nameof(Index));

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
            if (await _moduleSvc.DeleteAsync(id, "/SchoolModule"))
                return RedirectToAction(nameof(Index));
            return View();
        }

        public ActionResult Stop()
        {
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateViewBag()
        {
            List<SchoolYearDto> schoolYears = await _schoolYearSvc.GetAsync("/SchoolYears");
            ViewBag.SchoolYearId = new SelectList(schoolYears, "Id", "Name");

            List<SchoolModuleDto> schoolModules = await _moduleSvc.GetAsync("/SchoolModule");
            ViewBag.Modules = new SelectList(schoolModules, "Id", "Name");
        }
    }
}
