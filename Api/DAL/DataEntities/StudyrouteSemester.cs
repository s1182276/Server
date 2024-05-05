using System.ComponentModel.DataAnnotations;

namespace KeuzeWijzerApi.DAL.DataEntities
{
    public class StudyrouteSemester
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Semester { get; set; }

        [Required]
        public int StudyrouteId { get; set; }
        public Studyroute? Studyroute { get; set; }

        [Required]
        public int ModuleId { get; set; }
        public SchoolModule? Module { get; set; }
        
        public int SchoolYearId { get; set; }
        public SchoolYear? SchoolYear { get; set; }
    }
}