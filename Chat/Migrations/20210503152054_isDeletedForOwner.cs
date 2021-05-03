using Microsoft.EntityFrameworkCore.Migrations;

namespace Chat.Migrations
{
    public partial class isDeletedForOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeletedForOwner",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeletedForOwner",
                table: "Messages");
        }
    }
}
