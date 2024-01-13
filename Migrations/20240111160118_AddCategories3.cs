using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ilies_Dragos_Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "RestaurantCategoryAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "MenuCategoryAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID",
                table: "RestaurantCategoryAssignments");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "MenuCategoryAssignments");
        }
    }
}
