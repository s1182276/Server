namespace KeuzeWijzerCore.Models
{
    public class LearningRouteDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<LearningYearDto>? LearningYears { get; set; }
    }
}
