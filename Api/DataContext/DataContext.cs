using KeuzeWijzerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace KeuzeWijzerApi.DataContext
{
    public class KeuzeWijzerContext : DbContext
    {
        public KeuzeWijzerContext(DbContextOptions<KeuzeWijzerContext> options) : base(options)
        { 
        }

        public DbSet<LeerrouteDto> Leerroutes { get; set; }
        public DbSet<ModuleDto> Modules { get; set; }
    }
}
