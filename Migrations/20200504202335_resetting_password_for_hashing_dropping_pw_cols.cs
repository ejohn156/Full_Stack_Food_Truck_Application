using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Full_Stack_Food_Truck_Application.Migrations
{
    public partial class resetting_password_for_hashing_dropping_pw_cols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");
        }
    }
}
