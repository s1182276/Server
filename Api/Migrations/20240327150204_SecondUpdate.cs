using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeuzeWijzerApi.Migrations
{
    /// <inheritdoc />
    public partial class SecondUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Leerroutes_LeerrouteDtoId",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_LeerrouteDtoId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "LeerrouteDtoId",
                table: "Modules");

            migrationBuilder.AddColumn<string>(
                name: "Modules",
                table: "Leerroutes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modules",
                table: "Leerroutes");

            migrationBuilder.AddColumn<int>(
                name: "LeerrouteDtoId",
                table: "Modules",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modules_LeerrouteDtoId",
                table: "Modules",
                column: "LeerrouteDtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Leerroutes_LeerrouteDtoId",
                table: "Modules",
                column: "LeerrouteDtoId",
                principalTable: "Leerroutes",
                principalColumn: "Id");
        }
    }
}
