using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ilies_Dragos_Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class Menu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuID",
                table: "Restaurant",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_MenuID",
                table: "Restaurant",
                column: "MenuID");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Menu_MenuID",
                table: "Restaurant",
                column: "MenuID",
                principalTable: "Menu",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Menu_MenuID",
                table: "Restaurant");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_MenuID",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "MenuID",
                table: "Restaurant");
        }
    }
}
