namespace KeuzeWijzerCore.Models
{
    public class LearningYearDto
    {
        public int Id { get; set; }
        public int YearNumber { get; set; }
        public List<SemesterDto>? FirstSemester { get; set; }
        public List<SemesterDto>? SecondSemester { get; set; }
    }
}
