using KeuzeWijzerApi.DAL.DataModels;

namespace KeuzeWijzerApi.Services.Interfaces
{
    public interface IModuleRepo
    {
        List<Module> GetAllModules();
    }
}