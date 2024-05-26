using KeuzeWijzerCore.Models;

namespace KeuzeWijzerMvc.ViewModels
{
    public class SchoolModuleViewModel
    {
        private List<SchoolModuleDto> _schoolModules;

        public SchoolModuleDto SchoolModule { get; set; }
        public List<SchoolModuleDto> EntryRequirementSchoolModules { get; private set; } = new List<SchoolModuleDto>();

        public SchoolModuleViewModel() { }

        public SchoolModuleViewModel(SchoolModuleDto schoolModule, List<SchoolModuleDto> schoolModules)
        {
            SchoolModule = schoolModule;
            _schoolModules = schoolModules;

            PopulateEntryRequirementModules();
        }

        /// <summary>
        /// Cross checks the schoolmodules that have a required module and populates the list with the actual modules instead of a linking table
        /// It's used in the SchoolModule copy view
        /// </summary>
        private void PopulateEntryRequirementModules()
        {
            var ids = SchoolModule.EntryRequirementModules
                            .Where(m => m.ModuleId == SchoolModule.Id)
                            .Select(m => m.Id).ToList();

            EntryRequirementSchoolModules = _schoolModules.Where(sm => ids.Contains(sm.Id)).ToList();
        }
    }
}
