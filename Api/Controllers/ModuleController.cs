using KeuzeWijzerApi.DataContext;
using KeuzeWijzerApi.Models;
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
        private readonly KeuzeWijzerContext _dbcontextD;

        public ModuleController(KeuzeWijzerContext dbcontext)
        {
            moduleService = new ModuleService();
            _dbcontextD = dbcontext;
        }

        [HttpGet("GetAllModules")]
        public IActionResult GetAllModules()
        {
            //var allModules = moduleService.GetAllModules();
            var allModules = _dbcontextD.Modules.ToList();
            return Ok(allModules);
        }

        [HttpPost("CreateModule")]
        public IActionResult SaveModule([FromBody] Module module)
        {
            ModuleDto moduleDto = new ModuleDto();
            moduleDto.name = module.name;
            moduleDto.description = module.description;

            _dbcontextD.Modules.Add(moduleDto);
            _dbcontextD.SaveChanges();
            return Ok();

        }
    }
}
