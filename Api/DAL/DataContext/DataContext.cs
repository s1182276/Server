using KeuzeWijzerApi.DAL.DataModels;
using Microsoft.EntityFrameworkCore;

namespace KeuzeWijzerApi.DAL.DataContext
{
    public class KeuzeWijzerContext : DbContext
    {
        public KeuzeWijzerContext(DbContextOptions<KeuzeWijzerContext> options) : base(options)
        {
        }

        public DbSet<Leerroute> Leerroutes { get; set; }
        public DbSet<Module> Modules { get; set; }
    }
}
