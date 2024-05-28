﻿using KeuzeWijzerCore.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using KeuzeWijzerApi.DAL.Repositories;
using KeuzeWijzerApi.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using KeuzeWijzerApi.DAL.DataEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;

namespace KeuzeWijzerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudyRouteController : ControllerBase
    {
        private readonly IStudyRouteRepo _studyRouteRepo;
        private readonly IMapper _mapper;

        public StudyRouteController(IStudyRouteRepo studyRouteRepo, IMapper mapper)
        {
            _studyRouteRepo = studyRouteRepo;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<StudyrouteDto>>> GetStudyroutes()
        {
            var studyRoutes = await _studyRouteRepo.GetAll();
            return Ok(_mapper.Map<IEnumerable<StudyrouteDto>>(studyRoutes));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudyrouteDto>> GetStudyroute(int id)
        {
            var studyRoute = await _studyRouteRepo.GetById(id);

            if (studyRoute == null) { return NotFound(); }

            return Ok(_mapper.Map<StudyrouteDto>(studyRoute));
        }

        [Authorize]
        [RequiredScope("All")]
        [HttpPost]
        public async Task<ActionResult<StudyrouteDto>> PostStudyroute(StudyrouteDto studyRouteDto)
        {
            var studyRouteEntity = _mapper.Map<Studyroute>(studyRouteDto);
            await _studyRouteRepo.Add(studyRouteEntity);

            var createdStudyrouteDto = _mapper.Map<StudyrouteDto>(studyRouteEntity);
            return CreatedAtAction("GetStudyroute", new { id = createdStudyrouteDto.Id }, createdStudyrouteDto);
        }

        [Authorize]
        [RequiredScope("All")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudyroute(int id, StudyrouteDto studyRouteDto)
        {
            if (id != studyRouteDto.Id) return BadRequest();

            var studyRouteEntity = await _studyRouteRepo.GetById(id);
            if (studyRouteEntity == null) return NotFound();

            _mapper.Map(studyRouteDto, studyRouteEntity);

            await _studyRouteRepo.Update(studyRouteEntity);

            return NoContent();
        }

        [Authorize]
        [RequiredScope("All")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudyroute(int id)
        {
            var studyRouteEntity = await _studyRouteRepo.GetById(id);
            if (studyRouteEntity == null) return NotFound();

            await _studyRouteRepo.Delete(studyRouteEntity);

            return NoContent();
        }
    }
}
