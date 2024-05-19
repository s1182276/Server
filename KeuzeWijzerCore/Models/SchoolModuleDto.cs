using System.ComponentModel.DataAnnotations;

namespace KeuzeWijzerCore.Models
{
    public class SchoolModuleDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Naam is verplicht")]
        [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "De modulenaam mag alleen letters, cijfers en spaties bevatten.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Aantal EC's is verplicht")]
        public int? EC { get; set; }
        public int Level { get; set; }
        public bool Active { get; set; }
        [Required(ErrorMessage = "Gekoppelde Cohort is verplicht")]
        public int SchoolYearId { get; set; }
        public SchoolYearDto? SchoolYear { get; set; }
        [Required(ErrorMessage = "Omschrijving is verplicht")]
        public string? Description { get; set; }
        public bool PRequired { get; set; }
        [Required(ErrorMessage = "Verplicht veld. Voer 0 in als er geen punten verplicht zijn")]
        [Range(0, int.MaxValue, ErrorMessage = "Benodigde studiepunten mag niet negatief zijn.")]
        public int MinimalEC { get; set; } = 0;
        public int Semester { get; set; }
        public ICollection<EntryRequirementModuleDto> EntryRequirementModules { get; set; } = new List<EntryRequirementModuleDto>();
    }
}
