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

            // Configure the one-to-many relationship between SchoolYear and SchoolModule
            modelBuilder.Entity<SchoolModule>()
                .HasOne(sm => sm.SchoolYear)  // Defines the inverse navigation
                .WithMany(sy => sy.SchoolModules)   // Connects to the collection of modules in SchoolYear
                .HasForeignKey(sm => sm.SchoolYearId);  // Sets the foreign key on SchoolModule

            // Call the Seeder to populate initial data
            new Seeder(modelBuilder).Seed();
        }
    }
}