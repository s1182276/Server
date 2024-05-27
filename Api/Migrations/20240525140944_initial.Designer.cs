﻿// <auto-generated />
using System;
using KeuzeWijzerApi.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KeuzeWijzerApi.Migrations
{
    [DbContext(typeof(KeuzeWijzerContext))]
    [Migration("20240525140944_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("KeuzeWijzerApi.DAL.DataEntities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AzureAdId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("KeuzeWijzerApi.DAL.DataEntities.EntryRequirementModule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModuleId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MustModuleId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("MustPassed")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.HasIndex("MustModuleId");

                    b.ToTable("EntryRequirementModules");
                });

            modelBuilder.Entity("KeuzeWijzerApi.DAL.DataEntities.SchoolModule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("EC")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinimalEC")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PRequired")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SchoolYearId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Semester")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SchoolYearId");

                    b.ToTable("SchoolModules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Description = "Omschrijving1",
                            EC = 10,
                            Level = 1,
                            MinimalEC = 0,
                            Name = "Module1",
                            PRequired = false,
                            SchoolYearId = 1,
                            Semester = 1
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            Description = "Omschrijving2",
                            EC = 10,
                            Level = 1,
                            MinimalEC = 0,
                            Name = "Module2",
                            PRequired = false,
                            SchoolYearId = 1,
                            Semester = 1
                        });
                });

            modelBuilder.Entity("KeuzeWijzerApi.DAL.DataEntities.SchoolYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SchoolYears");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Schooljaar1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Schooljaar2"
                        });
                });

            modelBuilder.Entity("KeuzeWijzerApi.DAL.DataEntities.Studyroute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HistoricalRoute")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Studyroutes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HistoricalRoute = false,
                            Name = "Studieroute1",
                            StudentId = 1234
                        },
                        new
                        {
                            Id = 2,
                            HistoricalRoute = true,
                            Name = "Studieroute2",
                            StudentId = 1234
                        });
                });

            modelBuilder.Entity("KeuzeWijzerApi.DAL.DataEntities.StudyrouteSemester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModuleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SchoolYearId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Semester")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudyrouteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.HasIndex("SchoolYearId");

                    b.HasIndex("StudyrouteId");

                    b.ToTable("StudyrouteSemesters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ModuleId = 1,
                            SchoolYearId = 1,
                            Semester = 1,
                            StudyrouteId = 1
                        },
                        new
                        {
                            Id = 2,
                            ModuleId = 2,
                            SchoolYearId = 1,
                            Semester = 1,
                            StudyrouteId = 1
                        });
                });

            modelBuilder.Entity("KeuzeWijzerApi.DAL.DataEntities.EntryRequirementModule", b =>
                {
                    b.HasOne("KeuzeWijzerApi.DAL.DataEntities.SchoolModule", "Module")
                        .WithMany("EntryRequirementModules")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KeuzeWijzerApi.DAL.DataEntities.SchoolModule", "MustModule")
                        .WithMany()
                        .HasForeignKey("MustModuleId");

                    b.Navigation("Module");

                    b.Navigation("MustModule");
                });

            modelBuilder.Entity("KeuzeWijzerApi.DAL.DataEntities.SchoolModule", b =>
                {
                    b.HasOne("KeuzeWijzerApi.DAL.DataEntities.SchoolYear", "SchoolYear")
                        .WithMany("SchoolModules")
                        .HasForeignKey("SchoolYearId");

                    b.Navigation("SchoolYear");
                });

            modelBuilder.Entity("KeuzeWijzerApi.DAL.DataEntities.StudyrouteSemester", b =>
                {
                    b.HasOne("KeuzeWijzerApi.DAL.DataEntities.SchoolModule", "Module")
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KeuzeWijzerApi.DAL.DataEntities.SchoolYear", "SchoolYear")
                        .WithMany()
                        .HasForeignKey("SchoolYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KeuzeWijzerApi.DAL.DataEntities.Studyroute", "Studyroute")
                        .WithMany("StudyrouteSemesters")
                        .HasForeignKey("StudyrouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");

                    b.Navigation("SchoolYear");

                    b.Navigation("Studyroute");
                });

            modelBuilder.Entity("KeuzeWijzerApi.DAL.DataEntities.SchoolModule", b =>
                {
                    b.Navigation("EntryRequirementModules");
                });

            modelBuilder.Entity("KeuzeWijzerApi.DAL.DataEntities.SchoolYear", b =>
                {
                    b.Navigation("SchoolModules");
                });

            modelBuilder.Entity("KeuzeWijzerApi.DAL.DataEntities.Studyroute", b =>
                {
                    b.Navigation("StudyrouteSemesters");
                });
#pragma warning restore 612, 618
        }
    }
}
