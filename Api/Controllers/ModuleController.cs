using KeuzeWijzerApi.DAL.DataContext;
using KeuzeWijzerApi.Models;
using KeuzeWijzerApi.Services;
using KeuzeWijzerApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;

namespace KeuzeWijzerApi.Controllers
{
    [Authorize]
    [RequiredScope("All", "Module")]
    [ApiController]
    [Route("[controller]")]
    public class ModuleController : Controller
    {
        private readonly IModuleRepo moduleRepo;
        private readonly KeuzeWijzerContext _dbcontextD;

        public ModuleController(KeuzeWijzerContext dbcontext)
        {
            moduleRepo = new ModuleRepo();
            _dbcontextD = dbcontext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Module>>> GetModules()
        {
            if (_dbcontextD == null) return NotFound();
            if (_dbcontextD.Modules == null) return NotFound();
            return await _dbcontextD.Modules.ToListAsync(); ;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Module>> GetModule(int id)
        {
            var module = await _dbcontextD.Modules.FindAsync(id);

            if (module == null)
            {
                return NotFound();
            }

            return module;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutModule(int id, Module module)
        {
            if (id != module.Id)
            {
                return BadRequest();
            }

            _dbcontextD.Entry(module).State = EntityState.Modified;

            try
            {
                await _dbcontextD.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Module>> PostModule(Module module)
        {
            _dbcontextD.Modules.Add(module);
            await _dbcontextD.SaveChangesAsync();

            return CreatedAtAction("GetModule", new { id = module.Id }, module);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            var module = await _dbcontextD.Modules.FindAsync(id);
            if (module == null)
            {
                return NotFound();
            }

            _dbcontextD.Modules.Remove(module);
            await _dbcontextD.SaveChangesAsync();

            return NoContent();
        }

        //public IActionResult SaveModule([FromBody] Models.Module module)
        //{
        //    Module moduleDto = new Module();
        //    moduleDto.Name = module.Name;
        //    moduleDto.Description = module.Description;

        //    _dbcontextD.Modules.Add(moduleDto);
        //    _dbcontextD.SaveChanges();
        //    return Ok();
        //}

        private bool ModuleExists(int id)
        {
            return _dbcontextD.Modules.Any(e => e.Id == id);
        }
    }
}
