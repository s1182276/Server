using System.ComponentModel.DataAnnotations;

namespace KeuzeWijzerApi.DAL.DataEntities
{
    public class LearningYear
    {
        public int Id { get; set; }
        public int YearNumber { get; set; }
        public List<Semester>? FirstSemester { get; set; }
        public List<Semester>? SecondSemester { get; set; }
    }
}
