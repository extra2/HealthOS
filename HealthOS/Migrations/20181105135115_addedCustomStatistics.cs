using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace HealthOS.Migrations
{
    public partial class addedCustomStatistics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    StatisticsName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomStatistics_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomStatisticsDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomStatisticsId = table.Column<int>(nullable: true),
                    FirstMeasurement = table.Column<double>(nullable: false),
                    IsSecondMeasurementUsed = table.Column<bool>(nullable: false),
                    MeasurementDate = table.Column<DateTime>(nullable: false),
                    SecondMeasurement = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomStatisticsDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomStatisticsDatas_CustomStatistics_CustomStatisticsId",
                        column: x => x.CustomStatisticsId,
                        principalTable: "CustomStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomStatistics_ApplicationUserId",
                table: "CustomStatistics",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomStatisticsDatas_CustomStatisticsId",
                table: "CustomStatisticsDatas",
                column: "CustomStatisticsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomStatisticsDatas");

            migrationBuilder.DropTable(
                name: "CustomStatistics");
        }
    }
}
