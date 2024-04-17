using System.ComponentModel.DataAnnotations;

namespace KeuzeWijzerApi.Models
{
    public class Module
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
