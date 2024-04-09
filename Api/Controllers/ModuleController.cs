using KeuzeWijzerApi.DAL.DataContext;
using KeuzeWijzerApi.DAL.DataModels;
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
            //var allModules = moduleService.GetAllModules();
            var allModules = _dbcontextD.Modules.ToList();
            return Ok(allModules);
        }

        [HttpPost("CreateModule")]
        public IActionResult SaveModule([FromBody] Models.Module module)
        {
            DAL.DataModels.Module moduleDto = new DAL.DataModels.Module();
            moduleDto.name = module.name;
            moduleDto.description = module.description;

            _dbcontextD.Modules.Add(moduleDto);
            _dbcontextD.SaveChanges();
            return Ok();

        }
    }
}
