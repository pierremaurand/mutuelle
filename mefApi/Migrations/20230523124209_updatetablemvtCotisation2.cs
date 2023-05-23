using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mefapi.Migrations
{
    public partial class updatetablemvtCotisation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ModifieLe",
                table: "Cotisations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiePar",
                table: "Cotisations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifieLe",
                table: "Cotisations");

            migrationBuilder.DropColumn(
                name: "ModifiePar",
                table: "Cotisations");
        }
    }
}
