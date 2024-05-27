using Microsoft.AspNetCore.Mvc;
using KeuzeWijzerApi.DAL.DataEntities;
using AutoMapper;
using KeuzeWijzerCore.Models;
using KeuzeWijzerApi.DAL.Repositories.Interfaces;

namespace KeuzeWijzerApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SchoolYearsController : ControllerBase
    {
        private readonly ISchoolYearRepo _schoolYearRepo;
        private readonly IMapper _mapper;

        public SchoolYearsController(ISchoolYearRepo schoolYearRepo, IMapper mapper)
        {
            _schoolYearRepo = schoolYearRepo;
            _mapper = mapper;
        }

        // GET: api/SchoolYears
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolYear>>> GetSchoolYears()
        {
            var schoolYears = await _schoolYearRepo.GetAll();
            return Ok(_mapper.Map<IEnumerable<SchoolYearDto>>(schoolYears));
        }

        // GET: api/SchoolYears/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolYear>> GetSchoolYear(int id)
        {
            var schoolYear = await _schoolYearRepo.GetById(id);

            if (schoolYear == null) { return NotFound(); }

            return Ok(schoolYear);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchoolYear(int id, SchoolYear schoolYear)
        {
            var schoolYearEntity = _mapper.Map<SchoolYear>(schoolYear);

            if (_schoolYearRepo.DoesExist(id))
            {
                await _schoolYearRepo.Update(schoolYearEntity);
                return Ok();
            }

            return NotFound();
        }

        // POST: api/SchoolYears
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SchoolYear>> PostSchoolYear(SchoolYear schoolYear)
        {
            var moduleEntity = _mapper.Map<SchoolYear>(schoolYear);
            await _schoolYearRepo.Add(moduleEntity);

            return CreatedAtAction("GetSchoolYear", new { id = schoolYear.Id }, schoolYear);
        }

        // DELETE: api/SchoolYears/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolYear(int id)
        {
            var module = await _schoolYearRepo.GetById(id);

            if (module == null)
            {
                return NotFound();
            }

            await _schoolYearRepo.Delete(module);

            return NoContent();
        }
    }
}
