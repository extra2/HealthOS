using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthOS.Migrations
{
    public partial class relationsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorizedDoctorsId = table.Column<string>(nullable: true),
                    AuthorizedPatientsId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relations_AspNetUsers_AuthorizedDoctorsId",
                        column: x => x.AuthorizedDoctorsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relations_AspNetUsers_AuthorizedPatientsId",
                        column: x => x.AuthorizedPatientsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relations_AuthorizedDoctorsId",
                table: "Relations",
                column: "AuthorizedDoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_AuthorizedPatientsId",
                table: "Relations",
                column: "AuthorizedPatientsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relations");
        }
    }
}
