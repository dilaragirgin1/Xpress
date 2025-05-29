using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BG.Express.API.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Y",
                table: "Addresses",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "X",
                table: "Addresses",
                newName: "Latitude");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Addresses",
                newName: "Y");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Addresses",
                newName: "X");
        }
    }
}
