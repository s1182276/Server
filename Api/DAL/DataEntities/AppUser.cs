using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KeuzeWijzerApi.DAL.DataEntities
{
    public class AppUser
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? AzureAdId { get; set; }

        [NotMapped]
        public string? DisplayName { get; set; }
    }
}
