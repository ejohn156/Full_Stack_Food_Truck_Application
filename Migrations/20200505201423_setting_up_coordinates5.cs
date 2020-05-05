using Microsoft.EntityFrameworkCore.Migrations;

namespace Full_Stack_Food_Truck_Application.Migrations
{
    public partial class setting_up_coordinates5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_Creator_Id",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_Creator_Id",
                table: "Favorites");

            migrationBuilder.AddColumn<string>(
                name: "Favorite_Id",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Favorite_Id",
                table: "Favorites",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_Favorite_Id",
                table: "Favorites",
                column: "Favorite_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_Favorite_Id",
                table: "Favorites",
                column: "Favorite_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_Favorite_Id",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_Favorite_Id",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "Favorite_Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Favorite_Id",
                table: "Favorites");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_Creator_Id",
                table: "Favorites",
                column: "Creator_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_Creator_Id",
                table: "Favorites",
                column: "Creator_Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
