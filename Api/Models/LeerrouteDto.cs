namespace KeuzeWijzerApi.Models
{
    public class LeerrouteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ModuleDto> Modules { get; set; }
    }
}
