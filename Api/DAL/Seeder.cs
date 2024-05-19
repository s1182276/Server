﻿using KeuzeWijzerApi.DAL.DataEntities;
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
            _modelBuilder.Entity<SchoolYear>().HasData(
                new SchoolYear { Id = 1, Name = "Schooljaar1" },
                new SchoolYear { Id = 2, Name = "Schooljaar2" }
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