using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthOS.Migrations
{
    public partial class AddedSeenStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Seen",
                table: "ChatMessagesFrom",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seen",
                table: "ChatMessagesFrom");
        }
    }
}
