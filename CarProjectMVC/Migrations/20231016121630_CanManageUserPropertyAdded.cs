using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarProjectMVC.Migrations
{
    /// <inheritdoc />
    public partial class CanManageUserPropertyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanManageUsers",
                table: "Roles",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanManageUsers",
                table: "Roles");
        }
    }
}
