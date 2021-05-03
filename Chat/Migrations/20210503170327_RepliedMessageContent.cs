using Microsoft.EntityFrameworkCore.Migrations;

namespace Chat.Migrations
{
    public partial class RepliedMessageContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RepliedMessageContent",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepliedMessageContent",
                table: "Messages");
        }
    }
}
