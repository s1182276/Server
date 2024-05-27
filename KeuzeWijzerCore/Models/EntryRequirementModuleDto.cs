namespace KeuzeWijzerCore.Models
{
    public class EntryRequirementModuleDto
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int MustModuleId { get; set; }
        public bool MustPassed { get; set; }
    }
}
