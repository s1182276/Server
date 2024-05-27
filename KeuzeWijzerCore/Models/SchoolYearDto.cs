namespace KeuzeWijzerCore.Models
{
    public class SchoolYearDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SchoolModuleDto>? SchoolModules { get; set; }
    }
}
