using KeuzeWijzerApi.Controllers;
using KeuzeWijzerApi.Models;

namespace KeuzeWijzerApi.Services.Interfaces
{
    public interface ILeerrouteService
    {
        public void SaveLeerroute(LeerrouteDto leerroute);
        public LeerrouteDto GetLeerroute(int Id);
        public LeerrouteDto DeleteLeerroute(int Id);
        public List<LeerrouteDto> GetAllLeerroute();

    }
}