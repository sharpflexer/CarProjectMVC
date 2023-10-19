using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarProjectMVC.Migrations
{
    /// <inheritdoc />
    public partial class BrandIdFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModelCarColor_Colors_ColorsId",
                table: "CarModelCarColor");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModelCarColor_Models_ModelsId",
                table: "CarModelCarColor");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models");

            migrationBuilder.DropTable(
                name: "ModelColors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarModelCarColor",
                table: "CarModelCarColor");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "CarModelCarColor",
                newName: "CarColorCarModel");

            migrationBuilder.RenameIndex(
                name: "IX_CarModelCarColor_ModelsId",
                table: "CarColorCarModel",
                newName: "IX_CarColorCarModel_ModelsId");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Models",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarColorCarModel",
                table: "CarColorCarModel",
                columns: new[] { "ColorsId", "ModelsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarColorCarModel_Colors_ColorsId",
                table: "CarColorCarModel",
                column: "ColorsId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarColorCarModel_Models_ModelsId",
                table: "CarColorCarModel",
                column: "ModelsId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarColorCarModel_Colors_ColorsId",
                table: "CarColorCarModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CarColorCarModel_Models_ModelsId",
                table: "CarColorCarModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarColorCarModel",
                table: "CarColorCarModel");

            migrationBuilder.RenameTable(
                name: "CarColorCarModel",
                newName: "CarModelCarColor");

            migrationBuilder.RenameIndex(
                name: "IX_CarColorCarModel_ModelsId",
                table: "CarModelCarColor",
                newName: "IX_CarModelCarColor_ModelsId");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Models",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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
                    ColorId = table.Column<int>(type: "integer", nullable: false),
                    ModelId = table.Column<int>(type: "integer", nullable: false)
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
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Audi" },
                    { 2, "BMW" },
                    { 3, "Mercedes-Benz" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Red" },
                    { 2, "Blue" },
                    { 3, "Green" },
                    { 4, "Yellow" },
                    { 5, "Gray" },
                    { 6, "Black" },
                    { 7, "Dark Blue" },
                    { 8, "White" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CanCreate", "CanDelete", "CanManageUsers", "CanRead", "CanUpdate", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, true, true, true, true, true, null, "Админ", null },
                    { 2, true, true, false, true, true, null, "Менеджер", null },
                    { 3, false, false, false, true, false, null, "Пользователь", null }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "A3" },
                    { 2, 1, "A5" },
                    { 3, 1, "A6" },
                    { 4, 2, "X3" },
                    { 5, 2, "X5" },
                    { 6, 2, "X6" },
                    { 7, 3, "GLC" },
                    { 8, 3, "GLB" },
                    { 9, 3, "GLE" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Login", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "01b20a0c-6f88-4bce-870a-1b79b9594f20", "admin456@mail.ru", false, false, null, "admin", null, null, "admin123", null, null, false, null, 1, null, false, null },
                    { 2, 0, "921a8520-e836-4ce1-80e2-552d95eed2b1", "manager456@gmail.com", false, false, null, "manager", null, null, "manager123", null, null, false, null, 2, null, false, null },
                    { 3, 0, "c7622fc9-5dfc-4881-9aa8-4b24d4945309", "user456@yandex.ru", false, false, null, "user", null, null, "user123", null, null, false, null, 3, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "ColorId", "ModelId" },
                values: new object[,]
                {
                    { 1, 1, 3, 3 },
                    { 2, 2, 5, 5 },
                    { 3, 3, 4, 8 }
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

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Brands_BrandId",
                table: "Models",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
