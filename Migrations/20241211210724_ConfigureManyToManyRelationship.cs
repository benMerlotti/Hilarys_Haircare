using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HilaryHairCareAPI.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureManyToManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentServices",
                table: "AppointmentServices");

            migrationBuilder.DeleteData(
                table: "AppointmentServices",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppointmentServices",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AppointmentServices",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AppointmentServices");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "AppointmentServices",
                newName: "ServicesId");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "AppointmentServices",
                newName: "AppointmentsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentServices",
                table: "AppointmentServices",
                columns: new[] { "AppointmentsId", "ServicesId" });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentServices_ServicesId",
                table: "AppointmentServices",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentServices_Appointments_AppointmentsId",
                table: "AppointmentServices",
                column: "AppointmentsId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentServices_Services_ServicesId",
                table: "AppointmentServices",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentServices_Appointments_AppointmentsId",
                table: "AppointmentServices");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentServices_Services_ServicesId",
                table: "AppointmentServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentServices",
                table: "AppointmentServices");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentServices_ServicesId",
                table: "AppointmentServices");

            migrationBuilder.RenameColumn(
                name: "ServicesId",
                table: "AppointmentServices",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "AppointmentsId",
                table: "AppointmentServices",
                newName: "AppointmentId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AppointmentServices",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentServices",
                table: "AppointmentServices",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AppointmentServices",
                columns: new[] { "Id", "AppointmentId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 3 },
                    { 3, 2, 2 }
                });
        }
    }
}
