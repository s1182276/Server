using KeuzeWijzerApi.Models;

namespace KeuzeWijzerApi.Services.Interfaces
{
    public interface IModuleService
    {
        List<ModuleDto> GetAllModules();
    }
}