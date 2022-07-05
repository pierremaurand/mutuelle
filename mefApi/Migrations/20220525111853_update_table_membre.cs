using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class update_table_membre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adhesions");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdhesion",
                table: "Membres",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "FraisAdhesion",
                table: "Membres",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdhesion",
                table: "Membres");

            migrationBuilder.DropColumn(
                name: "FraisAdhesion",
                table: "Membres");

            migrationBuilder.CreateTable(
                name: "Adhesions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembreId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DateAdhesion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FraisAdhesion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adhesions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adhesions_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adhesions_MembreId",
                table: "Adhesions",
                column: "MembreId");
        }
    }
}
