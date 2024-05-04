using System.ComponentModel.DataAnnotations;

namespace KeuzeWijzerApi.DAL.DataEntities
{
    public class Studyroute
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool HistoricalRoute { get; set; }

        // Add Later maybe > public User Student { get; set; }
        public required ICollection<StudyrouteSemester> StudyrouteSemesters { get; set; }
    }
}
