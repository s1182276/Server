using System.ComponentModel.DataAnnotations;

namespace KeuzeWijzerApi.Models
{
    public class SemesterModule
    {
        [Key]
        public int Id { get; set; }
        public int? ModuleId { get; set; }
        public Module? Module { get; set; }
        public int? SemesterId { get; set; }
        public Semester? Semester { get; set; }
    }

}
