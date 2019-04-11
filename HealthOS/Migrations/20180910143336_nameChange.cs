using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthOS.Migrations
{
    public partial class nameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessagesFrom_AspNetUsers_UserFromId",
                table: "ChatMessagesFrom");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessagesFrom_AspNetUsers_UserToId",
                table: "ChatMessagesFrom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessagesFrom",
                table: "ChatMessagesFrom");

            migrationBuilder.RenameTable(
                name: "ChatMessagesFrom",
                newName: "ChatMessages");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessagesFrom_UserToId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_UserToId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessagesFrom_UserFromId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_UserFromId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_UserFromId",
                table: "ChatMessages",
                column: "UserFromId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_AspNetUsers_UserToId",
                table: "ChatMessages",
                column: "UserToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_UserFromId",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_AspNetUsers_UserToId",
                table: "ChatMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages");

            migrationBuilder.RenameTable(
                name: "ChatMessages",
                newName: "ChatMessagesFrom");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_UserToId",
                table: "ChatMessagesFrom",
                newName: "IX_ChatMessagesFrom_UserToId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_UserFromId",
                table: "ChatMessagesFrom",
                newName: "IX_ChatMessagesFrom_UserFromId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessagesFrom",
                table: "ChatMessagesFrom",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessagesFrom_AspNetUsers_UserFromId",
                table: "ChatMessagesFrom",
                column: "UserFromId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessagesFrom_AspNetUsers_UserToId",
                table: "ChatMessagesFrom",
                column: "UserToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
