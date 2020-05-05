using Microsoft.EntityFrameworkCore.Migrations;

namespace Full_Stack_Food_Truck_Application.Migrations
{
    public partial class setting_up_coordinates8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Creator_Id",
                table: "Favorites",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creator_Id",
                table: "Favorites");
        }
    }
}
