using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KeuzeWijzerApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SchoolYears",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Schooljaar1" },
                    { 2, "Schooljaar2" }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Active", "Description", "EC", "Level", "MinimalEC", "Name", "PRequired", "SchoolYearId", "Semester" },
                values: new object[,]
                {
                    { 1, true, "Omschrijving1", 10, 1, 0, "Module1", false, 1, 1 },
                    { 2, true, "Omschrijving2", 10, 1, 0, "Module2", false, 1, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SchoolYears",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SchoolYears",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
