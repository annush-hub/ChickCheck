using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class EggGradeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EggGradeId",
                table: "Barns",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "EggGrades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GradeUA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeEU = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EggGrades", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barns_EggGradeId",
                table: "Barns",
                column: "EggGradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Barns_EggGrades_EggGradeId",
                table: "Barns",
                column: "EggGradeId",
                principalTable: "EggGrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Barns_EggGrades_EggGradeId",
                table: "Barns");

            migrationBuilder.DropTable(
                name: "EggGrades");

            migrationBuilder.DropIndex(
                name: "IX_Barns_EggGradeId",
                table: "Barns");

            migrationBuilder.DropColumn(
                name: "EggGradeId",
                table: "Barns");
        }
    }
}
