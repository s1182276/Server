using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeuzeWijzerApi.DAL.DataEntities
{
    public class SchoolModule
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int EC { get; set; }
        public int Level { get; set; }
        public bool Active { get; set; }

        [ForeignKey("SchoolYear")]
        public int SchoolYearId { get; set; }
        public SchoolYear? SchoolYear { get; set; }

        public string? Description { get; set; }
        public bool PRequired { get; set; }
        public int MinimalEC { get; set; }
        public int Semester { get; set; }

        public ICollection<EntryRequirementModule> EntryRequirementModules { get; set; } = new List<EntryRequirementModule>();
    }
}
