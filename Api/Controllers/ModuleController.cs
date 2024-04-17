using KeuzeWijzerApi.DAL.DataContext;
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
        IModuleRepo moduleRepo;
        private readonly KeuzeWijzerContext _dbcontextD;

        public ModuleController(KeuzeWijzerContext dbcontext)
        {
            moduleRepo = new ModuleRepo();
            _dbcontextD = dbcontext;
        }

        [HttpGet("GetAllModules")]
        public IActionResult GetAllModules()
        {
            var allModules = _dbcontextD.Modules.ToList();
            return Ok(allModules);
        }

        [HttpPost("CreateModule")]
        public IActionResult SaveModule([FromBody] Models.Module module)
        {
            Module moduleDto = new Module();
            moduleDto.Name = module.Name;
            moduleDto.Description = module.Description;

            _dbcontextD.Modules.Add(moduleDto);
            _dbcontextD.SaveChanges();
            return Ok();
        }
    }
}
