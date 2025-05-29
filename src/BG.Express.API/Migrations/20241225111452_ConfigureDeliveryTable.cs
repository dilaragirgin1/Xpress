using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BG.Express.API.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureDeliveryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_AddressId",
                table: "Deliveries",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Addresses_AddressId",
                table: "Deliveries",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Addresses_AddressId",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_AddressId",
                table: "Deliveries");
        }
    }
}
