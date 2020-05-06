using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Full_Stack_Food_Truck_Application.Migrations
{
    public partial class set_up_category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Favorites");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Rating = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Favorite_Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Favorites_Favorite_Id",
                        column: x => x.Favorite_Id,
                        principalTable: "Favorites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Favorite_Id",
                table: "Categories",
                column: "Favorite_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.AddColumn<string[]>(
                name: "Categories",
                table: "Favorites",
                type: "text[]",
                nullable: true);
        }
    }
}
