using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KeuzeWijzerApi.DAL.DataModels
{
    public class Leerroute
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Modules { get; set; }
    }
}
