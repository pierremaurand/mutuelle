using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class add_new_entite_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avances_Membres_MembreId",
                table: "Avances");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Membres_MembreId",
                table: "Credits");

            migrationBuilder.RenameColumn(
                name: "MembreId",
                table: "Credits",
                newName: "DemandeCreditId");

            migrationBuilder.RenameIndex(
                name: "IX_Credits_MembreId",
                table: "Credits",
                newName: "IX_Credits_DemandeCreditId");

            migrationBuilder.RenameColumn(
                name: "MembreId",
                table: "Avances",
                newName: "DemandeAvanceId");

            migrationBuilder.RenameIndex(
                name: "IX_Avances_MembreId",
                table: "Avances",
                newName: "IX_Avances_DemandeAvanceId");

            migrationBuilder.CreateTable(
                name: "Adhesions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembreId = table.Column<int>(type: "int", nullable: false),
                    FraisAdhesion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateAdhesion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "DemandeAvances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDemande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MembreId = table.Column<int>(type: "int", nullable: false),
                    MontantSolicite = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontantApprouve = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NombreEcheance = table.Column<int>(type: "int", nullable: false),
                    EstApprouve = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandeAvances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemandeAvances_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DemandeCredits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDemande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MembreId = table.Column<int>(type: "int", nullable: false),
                    MontantSolicite = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontantApprouve = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NombreEcheance = table.Column<int>(type: "int", nullable: false),
                    EstApprouve = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandeCredits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemandeCredits_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adhesions_MembreId",
                table: "Adhesions",
                column: "MembreId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandeAvances_MembreId",
                table: "DemandeAvances",
                column: "MembreId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandeCredits_MembreId",
                table: "DemandeCredits",
                column: "MembreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avances_DemandeAvances_DemandeAvanceId",
                table: "Avances",
                column: "DemandeAvanceId",
                principalTable: "DemandeAvances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_DemandeCredits_DemandeCreditId",
                table: "Credits",
                column: "DemandeCreditId",
                principalTable: "DemandeCredits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avances_DemandeAvances_DemandeAvanceId",
                table: "Avances");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_DemandeCredits_DemandeCreditId",
                table: "Credits");

            migrationBuilder.DropTable(
                name: "Adhesions");

            migrationBuilder.DropTable(
                name: "DemandeAvances");

            migrationBuilder.DropTable(
                name: "DemandeCredits");

            migrationBuilder.RenameColumn(
                name: "DemandeCreditId",
                table: "Credits",
                newName: "MembreId");

            migrationBuilder.RenameIndex(
                name: "IX_Credits_DemandeCreditId",
                table: "Credits",
                newName: "IX_Credits_MembreId");

            migrationBuilder.RenameColumn(
                name: "DemandeAvanceId",
                table: "Avances",
                newName: "MembreId");

            migrationBuilder.RenameIndex(
                name: "IX_Avances_DemandeAvanceId",
                table: "Avances",
                newName: "IX_Avances_MembreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avances_Membres_MembreId",
                table: "Avances",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_Membres_MembreId",
                table: "Credits",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
