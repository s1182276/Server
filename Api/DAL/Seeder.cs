using KeuzeWijzerApi.DAL.DataEntities;
using Microsoft.EntityFrameworkCore;

namespace KeuzeWijzerApi.DAL
{
    public class Seeder
    {
        private readonly ModelBuilder _modelBuilder;

        public Seeder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            var envKey = Environment.GetEnvironmentVariable("ENV_KEY");

            switch (envKey)
            {
                case "dev":
                    SeedDefault();
                    break;
                case "tst":
                    SeedTest();
                    break;
                case "acc":
                    SeedAcc();
                    break;
                default:
                    SeedDefault();
                    break;
            }
        }

        private void SeedDefault()
        {
            _modelBuilder.Entity<SchoolYear>().HasData(
                new SchoolYear { Id = 1, Name = "Schooljaar1" },
                new SchoolYear { Id = 2, Name = "Schooljaar2" }
            );

            _modelBuilder.Entity<SchoolModule>().HasData(
                new SchoolModule { Id = 1, Name = "Module1", Active = true, Description = "Omschrijving1", EC = 10, Level = 1, MinimalEC = 0, PRequired = false, SchoolYearId = 1, Semester = 1 },
                new SchoolModule { Id = 2, Name = "Module2", Active = true, Description = "Omschrijving2", EC = 10, Level = 1, MinimalEC = 0, PRequired = false, SchoolYearId = 1, Semester = 1 }
            );

            _modelBuilder.Entity<Studyroute>().HasData(
                new Studyroute { Id = 1, Name = "Studieroute1", HistoricalRoute = false, StudentId = 1234 },
                new Studyroute { Id = 2, Name = "Studieroute2", HistoricalRoute = true, StudentId = 1234 }
            );

            _modelBuilder.Entity<StudyrouteSemester>().HasData(
                new StudyrouteSemester { Id = 1, Semester = 1, StudyrouteId = 1, ModuleId = 1, SchoolYearId = 1 },
                new StudyrouteSemester { Id = 2, Semester = 1, StudyrouteId = 1, ModuleId = 2, SchoolYearId = 1 }
            );
        }

        private void SeedTest()
        {
            _modelBuilder.Entity<SchoolYear>().HasData(
                new SchoolYear { Id = 1, Name = "Schooljaar1Test" },
                new SchoolYear { Id = 2, Name = "Schooljaar2Test" }
            );

            _modelBuilder.Entity<SchoolModule>().HasData(
                new SchoolModule { Id = 1, Name = "Module1Test", Active = true, Description = "Omschrijving1Test", EC = 10, Level = 1, MinimalEC = 0, PRequired = false, SchoolYearId = 1, Semester = 1 },
                new SchoolModule { Id = 2, Name = "Module2Test", Active = true, Description = "Omschrijving2Test", EC = 10, Level = 1, MinimalEC = 0, PRequired = false, SchoolYearId = 1, Semester = 1 }
            );
        }

        private void SeedAcc()
        {
            _modelBuilder.Entity<SchoolYear>().HasData(
                new SchoolYear { Id = 1, Name = "2024" },
                new SchoolYear { Id = 2, Name = "2025" }
            );

            _modelBuilder.Entity<SchoolModule>().HasData(
                new SchoolModule { Id = 1, Name = "Module1", Active = true, Description = "Omschrijving1", EC = 10, Level = 1, MinimalEC = 0, PRequired = false, SchoolYearId = 1, Semester = 1 },
                new SchoolModule { Id = 2, Name = "Module2", Active = true, Description = "Omschrijving2", EC = 10, Level = 1, MinimalEC = 0, PRequired = false, SchoolYearId = 1, Semester = 1 }
            );

            _modelBuilder.Entity<EntryRequirementModule>().HasData(
                new EntryRequirementModule { Id = 1, ModuleId = 1, MustModuleId = 2, MustPassed = true }
            );
        }
    }
}