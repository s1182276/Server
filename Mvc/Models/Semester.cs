namespace KeuzeWijzerApi.Models
{
    public class Semester
    {
        public int Id { get; set; }
        public List<SemesterModule>? SemesterModules { get; set; }
    }
}
