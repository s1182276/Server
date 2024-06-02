using AutoMapper;
using KeuzeWijzerApi.DAL.DataEntities;
using KeuzeWijzerApi.DAL.Repositories.Interfaces;
using KeuzeWijzerApi.Services.Interfaces;
using KeuzeWijzerCore.AuthorizationPolicies;
using KeuzeWijzerCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace KeuzeWijzerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudyRouteController : ControllerBase
    {
        private readonly IStudyRouteRepo _studyRouteRepo;
        private readonly IMapper _mapper;
        private readonly IAppUserService _appUserService;

        public StudyRouteController(IStudyRouteRepo studyRouteRepo, IMapper mapper, IAppUserService appUserService)
        {
            _studyRouteRepo = studyRouteRepo;
            _mapper = mapper;
            _appUserService = appUserService;
        }

        [AuthorizeIsInStudentOrStudentSupervisorGroup]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<StudyrouteDto>>> GetStudyroutes()
        {
            var studyRoutes = await _studyRouteRepo.GetAll();
            var studentId = await _appUserService.GetAuthenticatedAppUserAsync();
            var result = studyRoutes.Where(s => s.StudentId == studentId.Id);
            return Ok(_mapper.Map<IEnumerable<StudyrouteDto>>(result));
        }

        [AuthorizeIsInStudentOrStudentSupervisorGroup]
        [HttpGet("{id}")]
        public async Task<ActionResult<StudyrouteDto>> GetStudyroute(int id)
        {
            var studyRoute = await _studyRouteRepo.GetById(id);
            var studentId = await _appUserService.GetAuthenticatedAppUserAsync();

            if (studyRoute?.StudentId != studentId.Id) { return Unauthorized(); }

            if (studyRoute == null) { return NotFound(); }

            return Ok(_mapper.Map<StudyrouteDto>(studyRoute));
        }

        [AuthorizeIsInStudentOrStudentSupervisorGroup]
        [HttpPost]
        public async Task<ActionResult<StudyrouteDto>> PostStudyroute(StudyrouteDto studyRouteDto)
        {
            var studyRouteEntity = _mapper.Map<Studyroute>(studyRouteDto);
            var userId = await _appUserService.GetAuthenticatedAppUserAsync();
            studyRouteEntity.StudentId = userId.Id;
            await _studyRouteRepo.Add(studyRouteEntity);

            var createdStudyrouteDto = _mapper.Map<StudyrouteDto>(studyRouteEntity);
            return CreatedAtAction("GetStudyroute", new { id = createdStudyrouteDto.Id }, createdStudyrouteDto);
        }

        [AuthorizeIsInStudentOrStudentSupervisorGroup]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudyroute(int id, StudyrouteDto studyRouteDto)
        {
            if (id != studyRouteDto.Id) return BadRequest();

            var studyRouteEntity = await _studyRouteRepo.GetById(id);
            var studentId = await _appUserService.GetAuthenticatedAppUserAsync();

            if (studyRouteEntity == null) return NotFound();
            if (studyRouteEntity.StudentId != studentId.Id) return Unauthorized();

            _mapper.Map(studyRouteDto, studyRouteEntity);

            await _studyRouteRepo.Update(studyRouteEntity);

            return NoContent();
        }

        [AuthorizeIsInStudentOrStudentSupervisorGroup]
        [RequiredScope("All")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudyroute(int id)
        {
            var studyRouteEntity = await _studyRouteRepo.GetById(id);
            var studentId = await _appUserService.GetAuthenticatedAppUserAsync();

            if (studyRouteEntity == null) return NotFound();
            if (studyRouteEntity.StudentId != studentId.Id) return Unauthorized();

            await _studyRouteRepo.Delete(studyRouteEntity);

            return NoContent();
        }
    }
}
