using AutoMapper;
using KeuzeWijzerApi.DAL.DataEntities;
using KeuzeWijzerApi.Repositories.Interfaces;
using KeuzeWijzerCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace KeuzeWijzerApi.Controllers
{
    [Authorize]
    [RequiredScope("All", "Module")]
    [ApiController]
    [Route("[controller]")]
    public class SchoolModuleController : Controller
    {
        private readonly IModuleRepo _moduleRepo;
        private readonly IMapper _mapper;
        
        public SchoolModuleController(IModuleRepo moduleRepo, IMapper mapper)
        {
            _moduleRepo = moduleRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolModuleDto>>> GetModules()
        {
            var modules = await _moduleRepo.GetAll();
            return Ok(_mapper.Map<IEnumerable<SchoolModuleDto>>(modules));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolModuleDto>> GetModule(int id)
        {
            var module = await _moduleRepo.GetById(id);

            if (module == null) { return NotFound(); }

            return Ok(module);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutModule(int id, SchoolModuleDto module)
        {
            var moduleEntity = _mapper.Map<SchoolModule>(module);

            if (_moduleRepo.DoesExist(id))
            {
                await _moduleRepo.Update(moduleEntity);
                return Ok();
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<SchoolModuleDto>> PostModule(SchoolModuleDto module)
        {
            var moduleEntity = _mapper.Map<SchoolModule>(module);
            await _moduleRepo.Add(moduleEntity);

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

            await _moduleRepo.Delete(module);

            return NoContent();
        }
    }
}
