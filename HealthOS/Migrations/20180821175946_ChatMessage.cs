using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthOS.Migrations
{
    public partial class ChatMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessagesFrom_AspNetUsers_SentFromId",
                table: "ChatMessagesFrom");

            migrationBuilder.DropTable(
                name: "ChatMessagesTo");

            migrationBuilder.RenameColumn(
                name: "SentFromId",
                table: "ChatMessagesFrom",
                newName: "UserToId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessagesFrom_SentFromId",
                table: "ChatMessagesFrom",
                newName: "IX_ChatMessagesFrom_UserToId");

            migrationBuilder.AddColumn<string>(
                name: "UserFromId",
                table: "ChatMessagesFrom",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessagesFrom_UserFromId",
                table: "ChatMessagesFrom",
                column: "UserFromId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessagesFrom_AspNetUsers_UserFromId",
                table: "ChatMessagesFrom");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessagesFrom_AspNetUsers_UserToId",
                table: "ChatMessagesFrom");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessagesFrom_UserFromId",
                table: "ChatMessagesFrom");

            migrationBuilder.DropColumn(
                name: "UserFromId",
                table: "ChatMessagesFrom");

            migrationBuilder.RenameColumn(
                name: "UserToId",
                table: "ChatMessagesFrom",
                newName: "SentFromId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessagesFrom_UserToId",
                table: "ChatMessagesFrom",
                newName: "IX_ChatMessagesFrom_SentFromId");

            migrationBuilder.CreateTable(
                name: "ChatMessagesTo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChatMessageFromId = table.Column<int>(nullable: false),
                    SentToId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessagesTo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessagesTo_ChatMessagesFrom_ChatMessageFromId",
                        column: x => x.ChatMessageFromId,
                        principalTable: "ChatMessagesFrom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatMessagesTo_AspNetUsers_SentToId",
                        column: x => x.SentToId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessagesTo_ChatMessageFromId",
                table: "ChatMessagesTo",
                column: "ChatMessageFromId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessagesTo_SentToId",
                table: "ChatMessagesTo",
                column: "SentToId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessagesFrom_AspNetUsers_SentFromId",
                table: "ChatMessagesFrom",
                column: "SentFromId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
