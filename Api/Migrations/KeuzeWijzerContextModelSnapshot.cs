﻿// <auto-generated />
using KeuzeWijzerApi.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KeuzeWijzerApi.Migrations
{
    [DbContext(typeof(KeuzeWijzerContext))]
    partial class KeuzeWijzerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("KeuzeWijzerApi.DAL.DataEntities.EntryRequirementModule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModuleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MustModuleId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("MustPassed")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.HasIndex("MustModuleId");

                    b.ToTable("EntryRequirementModules");
                });

            modelBuilder.Entity("KeuzeWijzerApi.DAL.DataEntities.Module", b =>
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

                    b.Property<int>("SchoolYearId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Semester")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SchoolYearId");

                    b.ToTable("Modules");
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
                });

            modelBuilder.Entity("KeuzeWijzerApi.DAL.DataEntities.EntryRequirementModule", b =>
                {
                    b.HasOne("KeuzeWijzerApi.DAL.DataEntities.Module", "Module")
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KeuzeWijzerApi.DAL.DataEntities.Module", "MustModule")
                        .WithMany()
                        .HasForeignKey("MustModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");

                    b.Navigation("MustModule");
                });

            modelBuilder.Entity("KeuzeWijzerApi.DAL.DataEntities.Module", b =>
                {
                    b.HasOne("KeuzeWijzerApi.DAL.DataEntities.SchoolYear", "SchoolYear")
                        .WithMany("Modules")
                        .HasForeignKey("SchoolYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SchoolYear");
                });

            modelBuilder.Entity("KeuzeWijzerApi.DAL.DataEntities.StudyrouteSemester", b =>
                {
                    b.HasOne("KeuzeWijzerApi.DAL.DataEntities.Module", "Module")
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

            modelBuilder.Entity("KeuzeWijzerApi.DAL.DataEntities.SchoolYear", b =>
                {
                    b.Navigation("Modules");
                });

            modelBuilder.Entity("KeuzeWijzerApi.DAL.DataEntities.Studyroute", b =>
                {
                    b.Navigation("StudyrouteSemesters");
                });
#pragma warning restore 612, 618
        }
    }
}
