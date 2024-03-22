using KeuzeWijzerApi.Services;
using KeuzeWijzerApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KeuzeWijzerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModuleController : Controller
    {
        IModuleService moduleService;

        public ModuleController()
        {
            moduleService = new ModuleService();
        }

        [HttpGet("GetAllModules")]
        public IActionResult GetAllModules()
        {
            var allModules = moduleService.GetAllModules();
            return Ok(allModules);
        }
    }
}
