using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BG.Express.API.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlateNumber = table.Column<string>(type: "text", nullable: false),
                    StartLocationCode = table.Column<string>(type: "text", nullable: false),
                    EndLocationCode = table.Column<string>(type: "text", nullable: false),
                    CrossDockCode = table.Column<string>(type: "text", nullable: false),
                    VolumeCapacity = table.Column<int>(type: "integer", nullable: false),
                    BoxCapacity = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreateUserCode = table.Column<string>(type: "text", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateUserCode = table.Column<string>(type: "text", nullable: false),
                    DriverCode = table.Column<string>(type: "text", nullable: false),
                    FixedUsageCost = table.Column<decimal>(type: "numeric", nullable: false),
                    CostPerKm = table.Column<decimal>(type: "numeric", nullable: false),
                    EarliestAvailableTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LatestAvailableTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    VehicleType = table.Column<string>(type: "text", nullable: false),
                    SpeedMultiplier = table.Column<decimal>(type: "numeric", nullable: false),
                    ServiceTimeMultiplier = table.Column<decimal>(type: "numeric", nullable: false),
                    IsHostes = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
