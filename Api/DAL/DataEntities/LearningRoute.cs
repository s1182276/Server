using System.ComponentModel.DataAnnotations;

namespace KeuzeWijzerApi.DAL.DataEntities
{
    public class LearningRoute
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<LearningYear>? LearningYears { get; set; }
    }
}
