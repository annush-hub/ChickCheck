using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class FeederAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feeders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Capacity = table.Column<float>(type: "real", nullable: false),
                    Fullness = table.Column<float>(type: "real", nullable: false),
                    IsInUse = table.Column<bool>(type: "bit", nullable: false),
                    BarnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feeders_Barns_BarnId",
                        column: x => x.BarnId,
                        principalTable: "Barns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feeders_BarnId",
                table: "Feeders",
                column: "BarnId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feeders");
        }
    }
}
