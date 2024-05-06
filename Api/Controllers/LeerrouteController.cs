using KeuzeWijzerCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using KeuzeWijzerApi.DAL.DataEntities;
using KeuzeWijzerApi.Repositories.Interfaces;
using System.Reflection;
using KeuzeWijzerApi.Repositories;

namespace KeuzeWijzerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeerrouteController : Controller
    {
        private readonly ILeerrouteRepo _leerrouteRepo;
        private readonly IMapper _mapper;

        public LeerrouteController(ILeerrouteRepo leerrouteRepo, IMapper mapper)
        {
            _leerrouteRepo = leerrouteRepo;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<LearningRouteDto>>> GetLeerroutes()
        {
            var learningRoutes = await _leerrouteRepo.GetAll();
            return Ok(_mapper.Map<IEnumerable<LearningRouteDto>>(learningRoutes));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LearningRouteDto>> GetLeerroute(int id)
        {
            var learningRoute = await _leerrouteRepo.GetById(id);

            if (learningRoute == null) { return NotFound(); }

            return Ok(learningRoute);
        }

        [HttpPost]
        public ActionResult<LearningRouteDto> PostLeerroute(LearningRouteDto learningRoute)
        {
            var learningRouteEntity = _mapper.Map<LearningRoute>(learningRoute);
            _leerrouteRepo.Add(learningRouteEntity);

            return CreatedAtAction("GetLeerroute", new { id = learningRoute.Id }, learningRoute);
        }
    }
}

