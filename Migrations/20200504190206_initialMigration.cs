using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Full_Stack_Food_Truck_Application.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    First_Name = table.Column<string>(nullable: true),
                    Last_Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Favorite_Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Truck_Name = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    Rating = table.Column<decimal>(nullable: false),
                    Phone_Number = table.Column<string>(nullable: true),
                    Categories = table.Column<string[]>(nullable: true),
                    Coordinate_Id = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    User_Id = table.Column<string>(nullable: true),
                    Favorite_Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_Favorite_Id",
                        column: x => x.Favorite_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favorites_Coordinates_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Coordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_Favorite_Id",
                table: "Favorites",
                column: "Favorite_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_User_Id",
                table: "Favorites",
                column: "User_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Coordinates");
        }
    }
}
