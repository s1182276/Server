using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KeuzeWijzerApi.Migrations
{
    /// <inheritdoc />
    public partial class FreshIni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studyroutes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    HistoricalRoute = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studyroutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    EC = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    SchoolYearId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    PRequired = table.Column<bool>(type: "INTEGER", nullable: false),
                    MinimalEC = table.Column<int>(type: "INTEGER", nullable: false),
                    Semester = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolModules_SchoolYears_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "SchoolYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntryRequirementModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModuleId = table.Column<int>(type: "INTEGER", nullable: false),
                    MustModuleId = table.Column<int>(type: "INTEGER", nullable: false),
                    MustPassed = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryRequirementModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryRequirementModules_SchoolModules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "SchoolModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryRequirementModules_SchoolModules_MustModuleId",
                        column: x => x.MustModuleId,
                        principalTable: "SchoolModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyrouteSemesters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Semester = table.Column<int>(type: "INTEGER", nullable: false),
                    StudyrouteId = table.Column<int>(type: "INTEGER", nullable: false),
                    ModuleId = table.Column<int>(type: "INTEGER", nullable: false),
                    SchoolYearId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyrouteSemesters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyrouteSemesters_SchoolModules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "SchoolModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyrouteSemesters_SchoolYears_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "SchoolYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyrouteSemesters_Studyroutes_StudyrouteId",
                        column: x => x.StudyrouteId,
                        principalTable: "Studyroutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SchoolYears",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Schooljaar1" },
                    { 2, "Schooljaar2" }
                });

            migrationBuilder.InsertData(
                table: "SchoolModules",
                columns: new[] { "Id", "Active", "Description", "EC", "Level", "MinimalEC", "Name", "PRequired", "SchoolYearId", "Semester" },
                values: new object[,]
                {
                    { 1, true, "Omschrijving1", 10, 1, 0, "Module1", false, 1, 1 },
                    { 2, true, "Omschrijving2", 10, 1, 0, "Module2", false, 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntryRequirementModules_ModuleId",
                table: "EntryRequirementModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryRequirementModules_MustModuleId",
                table: "EntryRequirementModules",
                column: "MustModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolModules_SchoolYearId",
                table: "SchoolModules",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyrouteSemesters_ModuleId",
                table: "StudyrouteSemesters",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyrouteSemesters_SchoolYearId",
                table: "StudyrouteSemesters",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyrouteSemesters_StudyrouteId",
                table: "StudyrouteSemesters",
                column: "StudyrouteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryRequirementModules");

            migrationBuilder.DropTable(
                name: "StudyrouteSemesters");

            migrationBuilder.DropTable(
                name: "SchoolModules");

            migrationBuilder.DropTable(
                name: "Studyroutes");

            migrationBuilder.DropTable(
                name: "SchoolYears");
        }
    }
}
