using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarProjectMVC.Migrations
{
    /// <inheritdoc />
    public partial class DropCarColorCarModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "11324145-5bd9-4f04-a385-5f78199d9664");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "685f8e70-3636-438c-a718-968bba455296");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "96247cd7-e9c4-4ad7-aa3d-1063ee4e3d40");

            migrationBuilder.DropTable(
                name: "CarColorCarModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d94fb583-cb36-4b08-a456-319b24a955bb");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "8ca49c47-f255-4f87-91c9-ebce4bec3062");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "83b8a4df-2b18-453a-aa78-37c430f896e0");

            migrationBuilder.CreateTable(
                name: "CarColorCarModel",
                columns: table => new
                {
                    ColorsId = table.Column<int>(type: "integer", nullable: false),
                    ModelsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarColorCarModel", x => new { x.ColorsId, x.ModelsId });
                    table.ForeignKey(
                        name: "FK_CarColorCarModel_Colors_ColorsId",
                        column: x => x.ColorsId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarColorCarModel_Models_ModelsId",
                        column: x => x.ModelsId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
    });
        }
    }
}
