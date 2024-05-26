using AutoMapper;
using KeuzeWijzerApi.DAL.DataEntities;
using KeuzeWijzerApi.DAL.Repositories.Interfaces;
using KeuzeWijzerApi.Repositories.Interfaces;
using KeuzeWijzerCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace KeuzeWijzerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolModuleController : Controller
    {
        private readonly IModuleRepo _moduleRepo;
        private readonly IEntryRequirementModuleRepo _ermRepo;
        private readonly IMapper _mapper;

        public SchoolModuleController(IModuleRepo moduleRepo, IMapper mapper, IEntryRequirementModuleRepo ermRepo)
        {
            _moduleRepo = moduleRepo;
            _mapper = mapper;
            _ermRepo = ermRepo;
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

            if (module == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SchoolModuleDto>(module));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutModule(int id, SchoolModuleDto moduleDto)
        {
            if (id != moduleDto.Id)
            {
                return BadRequest();
            }

            var moduleEntity = _mapper.Map<SchoolModule>(moduleDto);

            if (_moduleRepo.DoesExist(id))
            {
                await _moduleRepo.Update(moduleEntity);
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<SchoolModuleDto>> PostModule(SchoolModuleDto moduleDto)
        {
            var moduleEntity = _mapper.Map<SchoolModule>(moduleDto);

            await _moduleRepo.Add(moduleEntity);

            var updatedModule = await _moduleRepo.GetById(moduleEntity.Id);

            var createdModuleDto = _mapper.Map<SchoolModuleDto>(updatedModule);
            return CreatedAtAction(nameof(GetModule), new { id = createdModuleDto.Id }, createdModuleDto);
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
