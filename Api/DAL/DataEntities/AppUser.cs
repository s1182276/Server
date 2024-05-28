using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KeuzeWijzerCore.Enums;

namespace KeuzeWijzerApi.DAL.DataEntities
{
    public class AppUser
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? AzureAdId { get; set; }
        public int? StartingYear { get; set; }
        public int? EcPoints { get; set; }
        public bool HasPropedeuse { get; set; }

        /// <summary>
        /// Flags (ex. AppUser can be a StudentSupervisor and Administrator at the same time)
        /// </summary>
        public AppRole Role { get; set; }

        [NotMapped]
        public string? DisplayName { get; set; }
        [NotMapped]
        public bool IsFirstSignIn { get; set; }
    }
}
