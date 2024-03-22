using KeuzeWijzerApi.Models;
using KeuzeWijzerApi.Services.Interfaces;

namespace KeuzeWijzerApi.Services
{
    public class ModuleService : IModuleService
    {


        public List<ModuleDto> GetAllModules()
        {
            return new List<ModuleDto>()
            {
                new ModuleDto {
                    id = 1,
                    name = "Module 1" ,
                    description = "beschrijving1"
                },
                new ModuleDto
                {
                    id = 2,
                    name = "Module 2",
                    description = "beschrijving2"
                }
            };
        }
    }
}
