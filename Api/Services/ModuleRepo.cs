using KeuzeWijzerApi.DAL.DataModels;
using KeuzeWijzerApi.Services.Interfaces;

namespace KeuzeWijzerApi.Services
{
    public class ModuleRepo : IModuleRepo
    {


        public List<Module> GetAllModules()
        {
            return new List<Module>()
            {
                new Module {
                    id = 1,
                    name = "Module 1" ,
                    description = "beschrijving1"
                },
                new Module
                {
                    id = 2,
                    name = "Module 2",
                    description = "beschrijving2"
                }
            };
        }
    }
}
