using Microsoft.EntityFrameworkCore.Migrations;

namespace Full_Stack_Food_Truck_Application.Migrations
{
    public partial class setting_up_coordinates3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Favorites_Coordinate_Id",
                table: "Favorites");

            migrationBuilder.AddColumn<string>(
                name: "Favorite_Id",
                table: "Coordinates",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_Coordinate_Id",
                table: "Favorites",
                column: "Coordinate_Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Favorites_Coordinate_Id",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "Favorite_Id",
                table: "Coordinates");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_Coordinate_Id",
                table: "Favorites",
                column: "Coordinate_Id");
        }
    }
}
