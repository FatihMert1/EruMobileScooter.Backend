using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EruMobileScooter.Data.Migrations
{
    public partial class InitialDatabase : Migration
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
                    EnergyCapacity = table.Column<int>(nullable: false),
                    CurrentEnergy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyStations", x => x.Id);
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
                    Type = table.Column<int>(nullable: false),
                    isBanned = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnergyCreators",
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
                    table.PrimaryKey("PK_EnergyCreators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnergyCreators_EnergyStations_EnergyStationId",
                        column: x => x.EnergyStationId,
                        principalTable: "EnergyStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    CurrentRange = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    ScooterStationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scooters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scooters_ScooterStations_ScooterStationId",
                        column: x => x.ScooterStationId,
                        principalTable: "ScooterStations",
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
                name: "ScooterHistories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    ScooterId = table.Column<string>(nullable: true),
                    ScooterStationId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScooterHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScooterHistories_Scooters_ScooterId",
                        column: x => x.ScooterId,
                        principalTable: "Scooters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScooterHistories_ScooterStations_ScooterStationId",
                        column: x => x.ScooterStationId,
                        principalTable: "ScooterStations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScooterHistories_Users_UserId",
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
                name: "IX_EnergyCreators_EnergyStationId",
                table: "EnergyCreators",
                column: "EnergyStationId");

            migrationBuilder.CreateIndex(
                name: "IX_ScooterHistories_ScooterId",
                table: "ScooterHistories",
                column: "ScooterId");

            migrationBuilder.CreateIndex(
                name: "IX_ScooterHistories_ScooterStationId",
                table: "ScooterHistories",
                column: "ScooterStationId");

            migrationBuilder.CreateIndex(
                name: "IX_ScooterHistories_UserId",
                table: "ScooterHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Scooters_ScooterStationId",
                table: "Scooters",
                column: "ScooterStationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveScooters");

            migrationBuilder.DropTable(
                name: "EnergyCreators");

            migrationBuilder.DropTable(
                name: "ScooterHistories");

            migrationBuilder.DropTable(
                name: "EnergyStations");

            migrationBuilder.DropTable(
                name: "Scooters");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ScooterStations");
        }
    }
}
