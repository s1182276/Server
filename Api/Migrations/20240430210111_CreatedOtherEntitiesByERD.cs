using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeuzeWijzerApi.Migrations
{
    /// <inheritdoc />
    public partial class CreatedOtherEntitiesByERD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchoolYearId",
                table: "Modules",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
                        name: "FK_EntryRequirementModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryRequirementModules_Modules_MustModuleId",
                        column: x => x.MustModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_StudyrouteSemesters_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
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

            migrationBuilder.CreateIndex(
                name: "IX_Modules_SchoolYearId",
                table: "Modules",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryRequirementModules_ModuleId",
                table: "EntryRequirementModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryRequirementModules_MustModuleId",
                table: "EntryRequirementModules",
                column: "MustModuleId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_SchoolYears_SchoolYearId",
                table: "Modules",
                column: "SchoolYearId",
                principalTable: "SchoolYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_SchoolYears_SchoolYearId",
                table: "Modules");

            migrationBuilder.DropTable(
                name: "EntryRequirementModules");

            migrationBuilder.DropTable(
                name: "StudyrouteSemesters");

            migrationBuilder.DropTable(
                name: "SchoolYears");

            migrationBuilder.DropTable(
                name: "Studyroutes");

            migrationBuilder.DropIndex(
                name: "IX_Modules_SchoolYearId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "SchoolYearId",
                table: "Modules");
        }
    }
}
