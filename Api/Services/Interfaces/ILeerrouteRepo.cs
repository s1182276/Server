using KeuzeWijzerApi.Controllers;
using KeuzeWijzerApi.DAL.DataModels;

namespace KeuzeWijzerApi.Services.Interfaces
{
    public interface ILeerrouteRepo
    {
        public void SaveLeerroute(Leerroute leerroute);
        public Leerroute GetLeerroute(int Id);
        public Leerroute DeleteLeerroute(int Id);
        public List<Leerroute> GetAllLeerroute();

    }
}