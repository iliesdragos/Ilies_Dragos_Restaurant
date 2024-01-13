using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ilies_Dragos_Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class modificari : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_Menu_MenuID",
                table: "MenuItem");

            migrationBuilder.DropIndex(
                name: "IX_MenuItem_MenuID",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "MenuID",
                table: "MenuItem");

            migrationBuilder.AddColumn<int>(
                name: "MenuItemID",
                table: "Menu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_MenuItemID",
                table: "Menu",
                column: "MenuItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Menu_MenuItem_MenuItemID",
                table: "Menu",
                column: "MenuItemID",
                principalTable: "MenuItem",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menu_MenuItem_MenuItemID",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_Menu_MenuItemID",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "MenuItemID",
                table: "Menu");

            migrationBuilder.AddColumn<int>(
                name: "MenuID",
                table: "MenuItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_MenuID",
                table: "MenuItem",
                column: "MenuID");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_Menu_MenuID",
                table: "MenuItem",
                column: "MenuID",
                principalTable: "Menu",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
