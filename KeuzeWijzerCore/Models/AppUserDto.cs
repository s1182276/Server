using KeuzeWijzerCore.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeuzeWijzerCore.Models
{
    public class AppUserDto
    {
        public int Id { get; set; }
        public string? AzureAdId { get; set; }
        public string? DisplayName { get; set; }
        public int? StartingYear { get; set; }
        public int? EcPoints { get; set; }
        public bool HasPropedeuse { get; set; }
        public bool IsFirstSignIn { get; set; }
        public AppUserRole AppUserRole { get; set; }
    }
}
