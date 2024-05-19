using KeuzeWijzerApi.DAL.DataEntities;
using Microsoft.EntityFrameworkCore;

namespace KeuzeWijzerApi.DAL.DataContext
{
    public class KeuzeWijzerContext : DbContext
    {
        public KeuzeWijzerContext(DbContextOptions<KeuzeWijzerContext> options) : base(options)
        {
        }

        public DbSet<SchoolModule> SchoolModules { get; set; }
        public DbSet<EntryRequirementModule> EntryRequirementModules { get; set; }
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<Studyroute> Studyroutes { get; set; }
        public DbSet<StudyrouteSemester> StudyrouteSemesters { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SchoolModule>()
                .HasOne(sm => sm.SchoolYear)
                .WithMany(sy => sy.SchoolModules)
                .HasForeignKey(sm => sm.SchoolYearId);

            modelBuilder.Entity<EntryRequirementModule>()
                .HasOne(erm => erm.MustModule)
                .WithMany()
                .HasForeignKey(erm => erm.MustModuleId);

            new Seeder(modelBuilder).Seed();
        }
    }
}