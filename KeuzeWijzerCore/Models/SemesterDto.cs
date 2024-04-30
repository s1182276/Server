namespace KeuzeWijzerCore.Models
{
    public class SemesterDto
    {
        public int Id { get; set; }
        public List<SemesterModuleDto>? SemesterModules { get; set; }
    }
}
