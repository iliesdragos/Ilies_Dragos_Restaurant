using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ilies_Dragos_Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MenuCategoryAssignments",
                columns: table => new
                {
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    MenuCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategoryAssignments", x => new { x.MenuID, x.MenuCategoryID });
                    table.ForeignKey(
                        name: "FK_MenuCategoryAssignments_MenuCategories_MenuCategoryID",
                        column: x => x.MenuCategoryID,
                        principalTable: "MenuCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuCategoryAssignments_Menu_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantCategoryAssignments",
                columns: table => new
                {
                    RestaurantID = table.Column<int>(type: "int", nullable: false),
                    RestaurantCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantCategoryAssignments", x => new { x.RestaurantID, x.RestaurantCategoryID });
                    table.ForeignKey(
                        name: "FK_RestaurantCategoryAssignments_RestaurantCategories_RestaurantCategoryID",
                        column: x => x.RestaurantCategoryID,
                        principalTable: "RestaurantCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantCategoryAssignments_Restaurant_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuCategoryAssignments_MenuCategoryID",
                table: "MenuCategoryAssignments",
                column: "MenuCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCategoryAssignments_RestaurantCategoryID",
                table: "RestaurantCategoryAssignments",
                column: "RestaurantCategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuCategoryAssignments");

            migrationBuilder.DropTable(
                name: "RestaurantCategoryAssignments");

            migrationBuilder.DropTable(
                name: "MenuCategories");

            migrationBuilder.DropTable(
                name: "RestaurantCategories");
        }
    }
}
