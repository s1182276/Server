using KeuzeWijzerApi.DAL.DataEntities;
using Microsoft.EntityFrameworkCore;

namespace KeuzeWijzerApi.DAL.DataContext
{
    public class KeuzeWijzerContext : DbContext
    {
        public KeuzeWijzerContext(DbContextOptions<KeuzeWijzerContext> options) : base(options)
        {
        }

        public DbSet<Module> Modules { get; set; }
        public DbSet<EntryRequirementModule> EntryRequirementModules { get; set; }
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<Studyroute> Studyroutes { get; set; }
        public DbSet<StudyrouteSemester> StudyrouteSemesters { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new Seeder(modelBuilder).Seed();
        }
    }
}

