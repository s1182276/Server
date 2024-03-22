using KeuzeWijzerApi.Services.Interfaces;
using KeuzeWijzerApi.Services;
using Microsoft.AspNetCore.Mvc;
using KeuzeWijzerApi.Models;

namespace KeuzeWijzerApi.Controllers
{
    public class LeerrouteController : Controller
    {
        ILeerrouteService leerrouteService;

        public LeerrouteController()
        {
            leerrouteService = new LeerrouteService();
        }

        [HttpGet("GetAllLeerroutes")]
        public IActionResult GetAllLeerroutes()
        {
            return Ok(leerrouteService.GetAllLeerroute());
        }

        [HttpGet("GetLeerroute/{id}")]
        public IActionResult GetLeerroute(int id)
        {
            return Ok(leerrouteService.GetLeerroute(id));
        }

        [HttpPost("SaveLeerroute")]
        public IActionResult SaveLeerroute([FromBody] LeerrouteDto leerroute)
        { 
            leerrouteService.SaveLeerroute(leerroute);
            return Ok();
        }
    }
}
