using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EruMobileScooter.Data.Migrations
{
    public partial class Initial_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnergyStations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    EnergyCapacity = table.Column<double>(nullable: false),
                    CurrentEnergy = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyStations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scooters",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    ChargeState = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    MaxRange = table.Column<int>(nullable: false),
                    Barcode = table.Column<string>(nullable: true),
                    CurrentRange = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scooters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScooterStations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    MaxCapacity = table.Column<int>(nullable: false),
                    CurrentCapacity = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScooterStations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Identity = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Faculty = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false),
                    isBanned = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnergyGenerators",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    EnergyCapacity = table.Column<int>(nullable: false),
                    CurrentEnergy = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    EnergyStationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyGenerators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnergyGenerators_EnergyStations_EnergyStationId",
                        column: x => x.EnergyStationId,
                        principalTable: "EnergyStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActiveScooters",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    ScooterId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveScooters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveScooters_Scooters_ScooterId",
                        column: x => x.ScooterId,
                        principalTable: "Scooters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActiveScooters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScooterTransportHistories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    ScooterId = table.Column<string>(nullable: true),
                    FromStationId = table.Column<string>(nullable: true),
                    ToStationId = table.Column<string>(nullable: true),
                    FromStationOutTime = table.Column<DateTime>(nullable: false),
                    ToStationInTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScooterTransportHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScooterTransportHistories_ScooterStations_FromStationId",
                        column: x => x.FromStationId,
                        principalTable: "ScooterStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScooterTransportHistories_Scooters_ScooterId",
                        column: x => x.ScooterId,
                        principalTable: "Scooters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScooterTransportHistories_ScooterStations_ToStationId",
                        column: x => x.ToStationId,
                        principalTable: "ScooterStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScooterTransportHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ScooterTransportHistoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_ScooterTransportHistories_ScooterTransportHistoryId",
                        column: x => x.ScooterTransportHistoryId,
                        principalTable: "ScooterTransportHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveScooters_ScooterId",
                table: "ActiveScooters",
                column: "ScooterId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveScooters_UserId",
                table: "ActiveScooters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyGenerators_EnergyStationId",
                table: "EnergyGenerators",
                column: "EnergyStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ScooterTransportHistoryId",
                table: "Payments",
                column: "ScooterTransportHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScooterTransportHistories_FromStationId",
                table: "ScooterTransportHistories",
                column: "FromStationId");

            migrationBuilder.CreateIndex(
                name: "IX_ScooterTransportHistories_ScooterId",
                table: "ScooterTransportHistories",
                column: "ScooterId");

            migrationBuilder.CreateIndex(
                name: "IX_ScooterTransportHistories_ToStationId",
                table: "ScooterTransportHistories",
                column: "ToStationId");

            migrationBuilder.CreateIndex(
                name: "IX_ScooterTransportHistories_UserId",
                table: "ScooterTransportHistories",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveScooters");

            migrationBuilder.DropTable(
                name: "EnergyGenerators");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "EnergyStations");

            migrationBuilder.DropTable(
                name: "ScooterTransportHistories");

            migrationBuilder.DropTable(
                name: "ScooterStations");

            migrationBuilder.DropTable(
                name: "Scooters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
