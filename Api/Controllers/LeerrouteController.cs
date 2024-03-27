using KeuzeWijzerApi.Services.Interfaces;
using KeuzeWijzerApi.Services;
using Microsoft.AspNetCore.Mvc;
using KeuzeWijzerApi.Models;
using KeuzeWijzerApi.DataContext;
using Microsoft.AspNetCore.SignalR;

namespace KeuzeWijzerApi.Controllers
{
    public class LeerrouteController : Controller
    {
        ILeerrouteService leerrouteService;
        private readonly KeuzeWijzerContext _dbcontext;

        public LeerrouteController(KeuzeWijzerContext dbcontext)
        {
            leerrouteService = new LeerrouteService();
            _dbcontext = dbcontext;
        }

        [HttpGet("GetAllLeerroutes")]
        public IActionResult GetAllLeerroutes()
        {
            //return Ok(leerrouteService.GetAllLeerroute());
            List<Leerroute> allLeerroutes = new List<Leerroute>();
            var response = _dbcontext.Leerroutes.ToList();

            foreach (var huh in response)
            {
                Leerroute leerroute = new Leerroute()
                {
                    Id = huh.Id,
                    Name = huh.Name,
                    Modules = new List<Module>()
                };

                string[] module = huh.Modules.Split(',');
                for (int i = 0; i < module.Length; i++)
                {
                    var mdlrsp = _dbcontext.Modules.Find(Int32.Parse(module[i]));
                    Module mod = new Module()
                    {
                        id = mdlrsp.id,
                        name = mdlrsp.name,
                        description = mdlrsp.description
                    };
                    leerroute.Modules.Add(mod);
                }
                allLeerroutes.Add(leerroute);
            }    

            return Ok(allLeerroutes);
        }

        [HttpGet("GetLeerroute/{id}")]
        public IActionResult GetLeerroute(int id)
        {
            var leerroute = _dbcontext.Leerroutes.Find(id);
            if (leerroute == null)
            {
                return BadRequest("Not found");
            }

            Leerroute selectedLeerroute = new Leerroute()
            {
                Id = leerroute.Id,
                Name = leerroute.Name,
                Modules = new List<Module>()
            };

            string[] module = leerroute.Modules.Split(',');
            for (int i = 0; i < module.Length; i++)
            {
                var moduleResponse = _dbcontext.Modules.Find(Int32.Parse(module[i]));
                Module mod = new Module()
                {
                    id = moduleResponse.id,
                    name = moduleResponse.name,
                    description = moduleResponse.description
                };
                selectedLeerroute.Modules.Add(mod);
            }
            return Ok(selectedLeerroute);
            // return Ok(leerrouteService.GetLeerroute(id));
        }

        [HttpPost("SaveLeerroute")]
        public IActionResult SaveLeerroute([FromBody] LeerrouteDto leerroute)
        {
            LeerrouteDto leerRouteDto = new LeerrouteDto();
            leerRouteDto.Id = leerroute.Id;
            leerRouteDto.Name = leerroute.Name;
            leerRouteDto.Modules = leerroute.Modules;

            _dbcontext.Leerroutes.Add(leerRouteDto);
            _dbcontext.SaveChanges();
            
            //leerrouteService.SaveLeerroute(leerroute);
            return Ok();
        }
    }
}
