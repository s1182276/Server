using KeuzeWijzerApi.Services.Interfaces;
using KeuzeWijzerApi.Services;
using Microsoft.AspNetCore.Mvc;
using KeuzeWijzerApi.Models;

namespace KeuzeWijzerApi.Controllers
{
    public class LeerrouteController : Controller
    {
        ILeerrouteRepo leerrouteRepo;

        public LeerrouteController()
        {
            leerrouteRepo = new LeerrouteRepo();
        }

        [HttpGet("GetAllLeerroutes")]
        public IActionResult GetAllLeerroutes()
        {
            return Ok(leerrouteRepo.GetAllLeerroute());
        }

        [HttpGet("GetLeerroute/{id}")]
        public IActionResult GetLeerroute(int id)
        {
            return Ok(leerrouteRepo.GetLeerroute(id));
        }

        [HttpPost("SaveLeerroute")]
        public IActionResult SaveLeerroute([FromBody] LearningRoute leerroute)
        { 
            leerrouteRepo.SaveLeerroute(leerroute);
            return Ok();
        }
    }
}
