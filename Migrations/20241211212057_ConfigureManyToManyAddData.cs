using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HilaryHairCareAPI.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureManyToManyAddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameTable(
                name: "AppointmentServices",
                newName: "AppointmentService");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentServices_ServicesId",
                table: "AppointmentService",
                newName: "IX_AppointmentService_ServicesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentService",
                table: "AppointmentService",
                columns: new[] { "AppointmentsId", "ServicesId" });

            migrationBuilder.InsertData(
                table: "AppointmentService",
                columns: new[] { "AppointmentsId", "ServicesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentService_Appointments_AppointmentsId",
                table: "AppointmentService",
                column: "AppointmentsId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentService_Services_ServicesId",
                table: "AppointmentService",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentService_Appointments_AppointmentsId",
                table: "AppointmentService");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentService_Services_ServicesId",
                table: "AppointmentService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentService",
                table: "AppointmentService");

            migrationBuilder.DeleteData(
                table: "AppointmentService",
                keyColumns: new[] { "AppointmentsId", "ServicesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AppointmentService",
                keyColumns: new[] { "AppointmentsId", "ServicesId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "AppointmentService",
                keyColumns: new[] { "AppointmentsId", "ServicesId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.RenameTable(
                name: "AppointmentService",
                newName: "AppointmentServices");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentService_ServicesId",
                table: "AppointmentServices",
                newName: "IX_AppointmentServices_ServicesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentServices",
                table: "AppointmentServices",
                columns: new[] { "AppointmentsId", "ServicesId" });

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
    }
}
