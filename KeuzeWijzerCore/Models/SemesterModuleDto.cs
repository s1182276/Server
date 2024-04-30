namespace KeuzeWijzerCore.Models
{
    public class SemesterModuleDto
    {
        public int Id { get; set; }
        public int? ModuleId { get; set; }
        public ModuleDto? Module { get; set; }
        public int? SemesterId { get; set; }
        public SemesterDto? Semester { get; set; }
    }

}
