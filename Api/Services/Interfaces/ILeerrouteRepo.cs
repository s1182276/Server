using KeuzeWijzerApi.Controllers;
using KeuzeWijzerApi.Models;

namespace KeuzeWijzerApi.Services.Interfaces
{
    public interface ILeerrouteRepo
    {
        public void SaveLeerroute(LearningRoute leerroute);
        public LearningRoute GetLeerroute(int Id);
        public LearningRoute DeleteLeerroute(int Id);
        public List<LearningRoute> GetAllLeerroute();

    }
}