using KeuzeWijzerCore.Models;

namespace KeuzeWijzerApi.Services.Interfaces
{
    public interface IModuleService
    {
        void AddModule(ModuleDto module);
        Task<IEnumerable<ModuleDto>> GetAllModules();
        Task<ModuleDto> GetModule(string moduleId);
        void UpdateModule(string moduleId, ModuleDto module);
        void DeleteModule(string moduleId);
        bool ModuleExist(int id);
    }
}
