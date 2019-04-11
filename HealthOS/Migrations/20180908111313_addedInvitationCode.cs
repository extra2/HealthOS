using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthOS.Migrations
{
    public partial class addedInvitationCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvitationCode",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvitationCode",
                table: "AspNetUsers");
        }
    }
}
