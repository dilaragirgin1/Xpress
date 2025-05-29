using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BG.Express.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "GeocodeScore",
                table: "Addresses",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "WarningMessage",
                table: "Addresses",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeocodeScore",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "WarningMessage",
                table: "Addresses");
        }
    }
}
