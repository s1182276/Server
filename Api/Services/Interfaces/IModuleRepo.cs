using KeuzeWijzerApi.Models;

namespace KeuzeWijzerApi.Services.Interfaces
{
    public interface IModuleRepo
    {
        List<Module> GetAllModules();
    }
}