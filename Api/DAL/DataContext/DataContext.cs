using KeuzeWijzerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace KeuzeWijzerApi.DAL.DataContext
{
    public class KeuzeWijzerContext : DbContext
    {
        public KeuzeWijzerContext(DbContextOptions<KeuzeWijzerContext> options) : base(options)
        {
        }

        public DbSet<LearningRoute> Leerroutes { get; set; }
        public DbSet<LearningYear> LearningYears { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<SemesterModule> SemesterModules { get; set; }
    }
}

