using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarProjectMVC.Migrations
{
    /// <inheritdoc />
    public partial class ModelColorsNameFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModelCarColor_Colors_ColorId",
                table: "CarModelCarColor");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModelCarColor_Models_ModelId",
                table: "CarModelCarColor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarModelCarColor",
                table: "CarModelCarColor");

            migrationBuilder.DropIndex(
                name: "IX_CarModelCarColor_ColorId",
                table: "CarModelCarColor");

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "CarModelCarColor",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 27);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CarModelCarColor");

            migrationBuilder.RenameColumn(
                name: "ModelId",
                table: "CarModelCarColor",
                newName: "ModelsId");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "CarModelCarColor",
                newName: "ColorsId");

            migrationBuilder.RenameIndex(
                name: "IX_CarModelCarColor_ModelId",
                table: "CarModelCarColor",
                newName: "IX_CarModelCarColor_ModelsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarModelCarColor",
                table: "CarModelCarColor",
                columns: new[] { "ColorsId", "ModelsId" });

            migrationBuilder.CreateTable(
                name: "ModelColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModelId = table.Column<int>(type: "integer", nullable: false),
                    ColorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelColors_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelColors_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ModelColors",
                columns: new[] { "Id", "ColorId", "ModelId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 2, 2 },
                    { 5, 3, 2 },
                    { 6, 4, 2 },
                    { 7, 3, 3 },
                    { 8, 4, 3 },
                    { 9, 5, 3 },
                    { 10, 1, 4 },
                    { 11, 7, 4 },
                    { 12, 3, 4 },
                    { 13, 4, 5 },
                    { 14, 5, 5 },
                    { 15, 7, 5 },
                    { 16, 5, 6 },
                    { 17, 7, 6 },
                    { 18, 8, 6 },
                    { 19, 6, 7 },
                    { 20, 1, 7 },
                    { 21, 4, 7 },
                    { 22, 2, 8 },
                    { 23, 4, 8 },
                    { 24, 6, 8 },
                    { 25, 5, 9 },
                    { 26, 6, 9 },
                    { 27, 7, 9 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "01b20a0c-6f88-4bce-870a-1b79b9594f20");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "921a8520-e836-4ce1-80e2-552d95eed2b1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "c7622fc9-5dfc-4881-9aa8-4b24d4945309");

            migrationBuilder.CreateIndex(
                name: "IX_ModelColors_ColorId",
                table: "ModelColors",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelColors_ModelId",
                table: "ModelColors",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModelCarColor_Colors_ColorsId",
                table: "CarModelCarColor",
                column: "ColorsId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModelCarColor_Models_ModelsId",
                table: "CarModelCarColor",
                column: "ModelsId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModelCarColor_Colors_ColorsId",
                table: "CarModelCarColor");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModelCarColor_Models_ModelsId",
                table: "CarModelCarColor");

            migrationBuilder.DropTable(
                name: "ModelColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarModelCarColor",
                table: "CarModelCarColor");

            migrationBuilder.RenameColumn(
                name: "ModelsId",
                table: "CarModelCarColor",
                newName: "ModelId");

            migrationBuilder.RenameColumn(
                name: "ColorsId",
                table: "CarModelCarColor",
                newName: "ColorId");

            migrationBuilder.RenameIndex(
                name: "IX_CarModelCarColor_ModelsId",
                table: "CarModelCarColor",
                newName: "IX_CarModelCarColor_ModelId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CarModelCarColor",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarModelCarColor",
                table: "CarModelCarColor",
                column: "Id");

            migrationBuilder.InsertData(
                table: "CarModelCarColor",
                columns: new[] { "Id", "ColorId", "ModelId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 2, 2 },
                    { 5, 3, 2 },
                    { 6, 4, 2 },
                    { 7, 3, 3 },
                    { 8, 4, 3 },
                    { 9, 5, 3 },
                    { 10, 1, 4 },
                    { 11, 7, 4 },
                    { 12, 3, 4 },
                    { 13, 4, 5 },
                    { 14, 5, 5 },
                    { 15, 7, 5 },
                    { 16, 5, 6 },
                    { 17, 7, 6 },
                    { 18, 8, 6 },
                    { 19, 6, 7 },
                    { 20, 1, 7 },
                    { 21, 4, 7 },
                    { 22, 2, 8 },
                    { 23, 4, 8 },
                    { 24, 6, 8 },
                    { 25, 5, 9 },
                    { 26, 6, 9 },
                    { 27, 7, 9 }
                });

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
    }
}
