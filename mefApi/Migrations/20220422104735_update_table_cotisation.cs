using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class update_table_cotisation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotisations_Periodes_PeriodeId",
                table: "Cotisations");

            migrationBuilder.DropTable(
                name: "Periodes");

            migrationBuilder.DropIndex(
                name: "IX_Cotisations_PeriodeId",
                table: "Cotisations");

            migrationBuilder.AddColumn<string>(
                name: "Periode",
                table: "Cotisations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Periode",
                table: "Cotisations");

            migrationBuilder.CreateTable(
                name: "Periodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cotisations_PeriodeId",
                table: "Cotisations",
                column: "PeriodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotisations_Periodes_PeriodeId",
                table: "Cotisations",
                column: "PeriodeId",
                principalTable: "Periodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
