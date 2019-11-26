using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Delivery_Tracking_Web_API.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrackingInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    DeliveryStatus = table.Column<string>(nullable: true),
                    DispatchedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingInfo", x => x.Id);
                });

            var sqlFile = Path.Combine(".\\DatabaseScripts", @"data.sql");

            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackingInfo");
        }
    }
}
