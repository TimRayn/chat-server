using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chat.Migrations
{
    public partial class InitialRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                column: "RoomId",
                value: new Guid("b7c83c21-09f2-46c2-9cb1-461aea2565d4"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: new Guid("b7c83c21-09f2-46c2-9cb1-461aea2565d4"));
        }
    }
}
