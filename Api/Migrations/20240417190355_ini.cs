using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeuzeWijzerApi.Migrations
{
    /// <inheritdoc />
    public partial class ini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leerroutes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leerroutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LearningYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    YearNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    LearningRouteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningYears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningYears_Leerroutes_LearningRouteId",
                        column: x => x.LearningRouteId,
                        principalTable: "Leerroutes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LearningYearId = table.Column<int>(type: "INTEGER", nullable: true),
                    LearningYearId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semesters_LearningYears_LearningYearId",
                        column: x => x.LearningYearId,
                        principalTable: "LearningYears",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Semesters_LearningYears_LearningYearId1",
                        column: x => x.LearningYearId1,
                        principalTable: "LearningYears",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SemesterModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModuleId = table.Column<int>(type: "INTEGER", nullable: true),
                    SemesterId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SemesterModules_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SemesterModules_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LearningYears_LearningRouteId",
                table: "LearningYears",
                column: "LearningRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterModules_ModuleId",
                table: "SemesterModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterModules_SemesterId",
                table: "SemesterModules",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_LearningYearId",
                table: "Semesters",
                column: "LearningYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_LearningYearId1",
                table: "Semesters",
                column: "LearningYearId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SemesterModules");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "LearningYears");

            migrationBuilder.DropTable(
                name: "Leerroutes");
        }
    }
}
