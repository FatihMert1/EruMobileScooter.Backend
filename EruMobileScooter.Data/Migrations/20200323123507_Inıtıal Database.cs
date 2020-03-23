using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EruMobileScooter.Data.Migrations
{
    public partial class InıtıalDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "energy_stations",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    energy_capacity = table.Column<double>(nullable: false),
                    current_energy = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_energy_stations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "scooter_stations",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    max_capacity = table.Column<int>(nullable: false),
                    current_capacity = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_scooter_stations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "scooters",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    charge_state = table.Column<int>(nullable: false),
                    number = table.Column<int>(nullable: false),
                    max_range = table.Column<int>(nullable: false),
                    barcode = table.Column<string>(nullable: true),
                    current_range = table.Column<int>(nullable: false),
                    location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_scooters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    surname = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    identity = table.Column<string>(nullable: true),
                    gender = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    faculty = table.Column<string>(nullable: true),
                    department = table.Column<string>(nullable: true),
                    role = table.Column<int>(nullable: false),
                    is_banned = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "energy_creators",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    energy_capacity = table.Column<int>(nullable: false),
                    current_energy = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false),
                    energy_station_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_energy_creators", x => x.id);
                    table.ForeignKey(
                        name: "fk_energy_creators_energy_stations_energy_station_id",
                        column: x => x.energy_station_id,
                        principalTable: "energy_stations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "active_scooters",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    scooter_id = table.Column<string>(nullable: true),
                    user_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_active_scooters", x => x.id);
                    table.ForeignKey(
                        name: "fk_active_scooters_scooters_scooter_id",
                        column: x => x.scooter_id,
                        principalTable: "scooters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_active_scooters_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "scooter_histories",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    scooter_id = table.Column<string>(nullable: true),
                    from_station_id = table.Column<string>(nullable: true),
                    to_station_id = table.Column<string>(nullable: true),
                    from_station_out_time = table.Column<DateTime>(nullable: false),
                    to_station_in_time = table.Column<DateTime>(nullable: false),
                    user_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_scooter_histories", x => x.id);
                    table.ForeignKey(
                        name: "fk_scooter_histories_scooter_stations_from_station_id",
                        column: x => x.from_station_id,
                        principalTable: "scooter_stations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_scooter_histories_scooters_scooter_id",
                        column: x => x.scooter_id,
                        principalTable: "scooters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_scooter_histories_scooter_stations_to_station_id",
                        column: x => x.to_station_id,
                        principalTable: "scooter_stations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_scooter_histories_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_active_scooters_scooter_id",
                table: "active_scooters",
                column: "scooter_id");

            migrationBuilder.CreateIndex(
                name: "ix_active_scooters_user_id",
                table: "active_scooters",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_energy_creators_energy_station_id",
                table: "energy_creators",
                column: "energy_station_id");

            migrationBuilder.CreateIndex(
                name: "ix_scooter_histories_from_station_id",
                table: "scooter_histories",
                column: "from_station_id");

            migrationBuilder.CreateIndex(
                name: "ix_scooter_histories_scooter_id",
                table: "scooter_histories",
                column: "scooter_id");

            migrationBuilder.CreateIndex(
                name: "ix_scooter_histories_to_station_id",
                table: "scooter_histories",
                column: "to_station_id");

            migrationBuilder.CreateIndex(
                name: "ix_scooter_histories_user_id",
                table: "scooter_histories",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "active_scooters");

            migrationBuilder.DropTable(
                name: "energy_creators");

            migrationBuilder.DropTable(
                name: "scooter_histories");

            migrationBuilder.DropTable(
                name: "energy_stations");

            migrationBuilder.DropTable(
                name: "scooter_stations");

            migrationBuilder.DropTable(
                name: "scooters");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
