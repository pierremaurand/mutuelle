using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mefapi.Migrations
{
    public partial class updatetablemvtCotisation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MvtCotisations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MouvementId = table.Column<int>(type: "int", nullable: false),
                    CotisationId = table.Column<int>(type: "int", nullable: false),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MvtCotisations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MvtCotisations_Cotisations_CotisationId",
                        column: x => x.CotisationId,
                        principalTable: "Cotisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MvtCotisations_Mouvements_MouvementId",
                        column: x => x.MouvementId,
                        principalTable: "Mouvements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MvtCotisations_CotisationId",
                table: "MvtCotisations",
                column: "CotisationId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtCotisations_MouvementId",
                table: "MvtCotisations",
                column: "MouvementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MvtCotisations");
        }
    }
}
