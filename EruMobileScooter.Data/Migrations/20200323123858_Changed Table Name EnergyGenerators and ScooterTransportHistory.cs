using Microsoft.EntityFrameworkCore.Migrations;

namespace EruMobileScooter.Data.Migrations
{
    public partial class ChangedTableNameEnergyGeneratorsandScooterTransportHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_energy_creators_energy_stations_energy_station_id",
                table: "energy_creators");

            migrationBuilder.DropForeignKey(
                name: "fk_scooter_histories_scooter_stations_from_station_id",
                table: "scooter_histories");

            migrationBuilder.DropForeignKey(
                name: "fk_scooter_histories_scooters_scooter_id",
                table: "scooter_histories");

            migrationBuilder.DropForeignKey(
                name: "fk_scooter_histories_scooter_stations_to_station_id",
                table: "scooter_histories");

            migrationBuilder.DropForeignKey(
                name: "fk_scooter_histories_users_user_id",
                table: "scooter_histories");

            migrationBuilder.DropPrimaryKey(
                name: "pk_scooter_histories",
                table: "scooter_histories");

            migrationBuilder.DropPrimaryKey(
                name: "pk_energy_creators",
                table: "energy_creators");

            migrationBuilder.RenameTable(
                name: "scooter_histories",
                newName: "scooter_transport_histories");

            migrationBuilder.RenameTable(
                name: "energy_creators",
                newName: "energy_generators");

            migrationBuilder.RenameIndex(
                name: "ix_scooter_histories_user_id",
                table: "scooter_transport_histories",
                newName: "ix_scooter_transport_histories_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_scooter_histories_to_station_id",
                table: "scooter_transport_histories",
                newName: "ix_scooter_transport_histories_to_station_id");

            migrationBuilder.RenameIndex(
                name: "ix_scooter_histories_scooter_id",
                table: "scooter_transport_histories",
                newName: "ix_scooter_transport_histories_scooter_id");

            migrationBuilder.RenameIndex(
                name: "ix_scooter_histories_from_station_id",
                table: "scooter_transport_histories",
                newName: "ix_scooter_transport_histories_from_station_id");

            migrationBuilder.RenameIndex(
                name: "ix_energy_creators_energy_station_id",
                table: "energy_generators",
                newName: "ix_energy_generators_energy_station_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_scooter_transport_histories",
                table: "scooter_transport_histories",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_energy_generators",
                table: "energy_generators",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_energy_generators_energy_stations_energy_station_id",
                table: "energy_generators",
                column: "energy_station_id",
                principalTable: "energy_stations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_scooter_transport_histories_scooter_stations_from_station_id",
                table: "scooter_transport_histories",
                column: "from_station_id",
                principalTable: "scooter_stations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_scooter_transport_histories_scooters_scooter_id",
                table: "scooter_transport_histories",
                column: "scooter_id",
                principalTable: "scooters",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_scooter_transport_histories_scooter_stations_to_station_id",
                table: "scooter_transport_histories",
                column: "to_station_id",
                principalTable: "scooter_stations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_scooter_transport_histories_users_user_id",
                table: "scooter_transport_histories",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_energy_generators_energy_stations_energy_station_id",
                table: "energy_generators");

            migrationBuilder.DropForeignKey(
                name: "fk_scooter_transport_histories_scooter_stations_from_station_id",
                table: "scooter_transport_histories");

            migrationBuilder.DropForeignKey(
                name: "fk_scooter_transport_histories_scooters_scooter_id",
                table: "scooter_transport_histories");

            migrationBuilder.DropForeignKey(
                name: "fk_scooter_transport_histories_scooter_stations_to_station_id",
                table: "scooter_transport_histories");

            migrationBuilder.DropForeignKey(
                name: "fk_scooter_transport_histories_users_user_id",
                table: "scooter_transport_histories");

            migrationBuilder.DropPrimaryKey(
                name: "pk_scooter_transport_histories",
                table: "scooter_transport_histories");

            migrationBuilder.DropPrimaryKey(
                name: "pk_energy_generators",
                table: "energy_generators");

            migrationBuilder.RenameTable(
                name: "scooter_transport_histories",
                newName: "scooter_histories");

            migrationBuilder.RenameTable(
                name: "energy_generators",
                newName: "energy_creators");

            migrationBuilder.RenameIndex(
                name: "ix_scooter_transport_histories_user_id",
                table: "scooter_histories",
                newName: "ix_scooter_histories_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_scooter_transport_histories_to_station_id",
                table: "scooter_histories",
                newName: "ix_scooter_histories_to_station_id");

            migrationBuilder.RenameIndex(
                name: "ix_scooter_transport_histories_scooter_id",
                table: "scooter_histories",
                newName: "ix_scooter_histories_scooter_id");

            migrationBuilder.RenameIndex(
                name: "ix_scooter_transport_histories_from_station_id",
                table: "scooter_histories",
                newName: "ix_scooter_histories_from_station_id");

            migrationBuilder.RenameIndex(
                name: "ix_energy_generators_energy_station_id",
                table: "energy_creators",
                newName: "ix_energy_creators_energy_station_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_scooter_histories",
                table: "scooter_histories",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_energy_creators",
                table: "energy_creators",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_energy_creators_energy_stations_energy_station_id",
                table: "energy_creators",
                column: "energy_station_id",
                principalTable: "energy_stations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_scooter_histories_scooter_stations_from_station_id",
                table: "scooter_histories",
                column: "from_station_id",
                principalTable: "scooter_stations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_scooter_histories_scooters_scooter_id",
                table: "scooter_histories",
                column: "scooter_id",
                principalTable: "scooters",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_scooter_histories_scooter_stations_to_station_id",
                table: "scooter_histories",
                column: "to_station_id",
                principalTable: "scooter_stations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_scooter_histories_users_user_id",
                table: "scooter_histories",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
