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
                new SchoolModule { Id = 1, Name = "Web Development", Active = true, Description = "In deze periode besteden we aandacht aan verschillende aspecten van webtechnologie. Het doel van het semester is om te leren hoe je robuuste webapplicaties ontwerpt en realiseert. Het semester bestaat uit de modules Server Technology, Client Technology en Security for web applications.", EC = 30, Level = 2, MinimalEC = 50, PRequired = true, SchoolYearId = 1, Semester = 2 },
                new SchoolModule { Id = 2, Name = "Object-Oriënted Software Design & Development (OOSDD)", Active = true, Description = "Voordat je begint aan een praktijkopdracht ga je eerst een goede basis leggen. Je krijgt les in C# programmeren, databases benaderen vanuit C# en modeleren met behulp van de Unified Modelling Language (UML). Ook gebruik je Scrum om samen het project te realiseren. In een klein project, waarin je een eenvoudig spel gaat bouwen, ga je de kennis al direct toepassen. ", EC = 30, Level = 2, MinimalEC = 50, PRequired = true, SchoolYearId = 1, Semester = 1 }
            );
        }
    }
}
