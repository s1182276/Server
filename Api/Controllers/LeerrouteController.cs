//using KeuzeWijzerApi.Services;
//using Microsoft.AspNetCore.Mvc;
//using KeuzeWijzerApi.DAL.DataEntities;
//using KeuzeWijzerApi.Repositories.Interfaces;
using KeuzeWijzerApi.Services.Interfaces;
using KeuzeWijzerApi.Services;
using Microsoft.AspNetCore.Mvc;
using KeuzeWijzerApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;

//namespace KeuzeWijzerApi.Controllers
//{
//    [Authorize]
//    [RequiredScope("All", "Leerroute")]
//    [ApiController]
//    [Route("[controller]")]
//    public class LeerrouteController : Controller
//    {
//        ILeerrouteRepo leerrouteRepo;

//        public LeerrouteController()
//        {
//            leerrouteRepo = new LeerrouteRepo();
//        }

//        [HttpGet("GetAllLeerroutes")]
//        public IActionResult GetAllLeerroutes()
//        {
//            return Ok(leerrouteRepo.GetAllLeerroute());
//        }

//        [HttpGet("GetLeerroute/{id}")]
//        public IActionResult GetLeerroute(int id)
//        {
//            return Ok(leerrouteRepo.GetLeerroute(id));
//        }

//        [HttpPost("SaveLeerroute")]
//        public IActionResult SaveLeerroute([FromBody] LearningRoute leerroute)
//        { 
//            leerrouteRepo.SaveLeerroute(leerroute);
//            return Ok();
//        }
//    }
//}
