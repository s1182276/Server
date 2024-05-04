using KeuzeWijzerApi.DAL.DataContext;
using KeuzeWijzerApi.Models;
using KeuzeWijzerApi.Services;
using KeuzeWijzerApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using KeuzeWijzerApi.DAL.DataEntities;
using KeuzeWijzerApi.Repositories.Interfaces;
using KeuzeWijzerCore.Models;
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
        private readonly IModuleRepo _moduleRepo;
        private readonly IMapper _mapper;
        
        public ModuleController(IModuleRepo moduleRepo, IMapper mapper)
        {
            _moduleRepo = moduleRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModuleDto>>> GetModules()
        {
            var modules = await _moduleRepo.GetAll();
            return Ok(_mapper.Map<IEnumerable<ModuleDto>>(modules));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleDto>> GetModule(int id)
        {
            var module = await _moduleRepo.GetById(id);

            if (module == null) { return NotFound(); }

            return Ok(module);
        }

        [HttpPut("{id}")]
        public IActionResult PutModule(int id, ModuleDto module)
        {
            var moduleEntity = _mapper.Map<Module>(module);

            if(_moduleRepo.DoesExist(id))
            {
                _moduleRepo.Update(moduleEntity);
                return Ok();
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<ModuleDto> PostModule(ModuleDto module)
        {
            var moduleEntity = _mapper.Map<Module>(module);
            _moduleRepo.Add(moduleEntity);

            return CreatedAtAction("GetModule", new { id = module.Id }, module);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            var module = await _moduleRepo.GetById(id);

            if (module == null)
            {
                return NotFound();
            }

            _moduleRepo.Delete(module);

            return NoContent();
        }
    }
}
