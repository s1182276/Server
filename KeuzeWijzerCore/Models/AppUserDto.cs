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
    }
}
