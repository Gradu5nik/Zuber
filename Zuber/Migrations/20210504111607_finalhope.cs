using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zuber.Migrations
{
    public partial class finalhope : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Long = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZuberUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dots_Users_ZuberUserID",
                        column: x => x.ZuberUserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxPassangers = table.Column<int>(type: "int", nullable: false),
                    CurrentPassangers = table.Column<int>(type: "int", nullable: false),
                    TimeToFromZealand = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToZealand = table.Column<bool>(type: "bit", nullable: false),
                    ZuberUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rides_Users_ZuberUser",
                        column: x => x.ZuberUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passangers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RideID = table.Column<int>(type: "int", nullable: false),
                    ZuberUserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passangers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passangers_Rides_RideID",
                        column: x => x.RideID,
                        principalTable: "Rides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passangers_Users_ZuberUserID",
                        column: x => x.ZuberUserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dots_ZuberUserID",
                table: "Dots",
                column: "ZuberUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Passangers_RideID",
                table: "Passangers",
                column: "RideID");

            migrationBuilder.CreateIndex(
                name: "IX_Passangers_ZuberUserID",
                table: "Passangers",
                column: "ZuberUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_ZuberUser",
                table: "Rides",
                column: "ZuberUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dots");

            migrationBuilder.DropTable(
                name: "Passangers");

            migrationBuilder.DropTable(
                name: "Rides");
        }
    }
}
