using KeuzeWijzerCore.Models;
using Newtonsoft.Json;

namespace KeuzeWijzerMvc.ViewModels
{
    public class SchoolYearViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? SchoolModulesJson { get; set; } = string.Empty;

        public SchoolYearViewModel() { }

        public SchoolYearViewModel(SchoolYearDto schoolYearDto)
        {
            Id = schoolYearDto.Id;
            Name = schoolYearDto.Name;
            if(schoolYearDto.SchoolModules != null)
            {
                SchoolModulesJson = JsonConvert.SerializeObject(schoolYearDto.SchoolModules);
            }
        }

        /// <summary>
        /// Deserializes the modules that are stored as a JSON string in this object for use in the SchoolYearDto object
        /// </summary>
        public ICollection<SchoolModuleDto> GetSchoolModules()
        {
            if (!string.IsNullOrEmpty(SchoolModulesJson))
            {
                ICollection<SchoolModuleDto> modules = JsonConvert.DeserializeObject<List<SchoolModuleDto>>(SchoolModulesJson);
                return modules;
            }

            return null;
        }
    }
}
