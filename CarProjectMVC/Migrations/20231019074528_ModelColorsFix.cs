using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarProjectMVC.Migrations
{
    /// <inheritdoc />
    public partial class ModelColorsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "cdae0033-f28d-4d58-b09b-82b8318eb2bf");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "51e5a417-9bf8-4f8d-869e-61e37e245a46");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "9e48f7c6-5fdc-4093-8001-9271eedd7623");

            migrationBuilder.CreateIndex(
                name: "IX_CarModelCarColor_ColorId",
                table: "CarModelCarColor",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModelCarColor_ModelId",
                table: "CarModelCarColor",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModelCarColor_Colors_ColorId",
                table: "CarModelCarColor",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModelCarColor_Models_ModelId",
                table: "CarModelCarColor",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModelCarColor_Colors_ColorId",
                table: "CarModelCarColor");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModelCarColor_Models_ModelId",
                table: "CarModelCarColor");

            migrationBuilder.DropIndex(
                name: "IX_CarModelCarColor_ColorId",
                table: "CarModelCarColor");

            migrationBuilder.DropIndex(
                name: "IX_CarModelCarColor_ModelId",
                table: "CarModelCarColor");

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
        }
    }
}
