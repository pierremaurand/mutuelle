using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class add_new_entite_update_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avances_DemandeAvances_DemandeAvanceId",
                table: "Avances");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_DemandeCredits_DemandeCreditId",
                table: "Credits");

            migrationBuilder.DropTable(
                name: "DemandeAvances");

            migrationBuilder.DropTable(
                name: "DemandeCredits");

            migrationBuilder.DropTable(
                name: "MvtCotisations");

            migrationBuilder.DropIndex(
                name: "IX_Credits_DemandeCreditId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Avances_DemandeAvanceId",
                table: "Avances");

            migrationBuilder.DropColumn(
                name: "DemandeCreditId",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "DemandeAvanceId",
                table: "Avances");

            migrationBuilder.RenameColumn(
                name: "Mois",
                table: "Cotisations",
                newName: "PeriodeId");

            migrationBuilder.RenameColumn(
                name: "Annee",
                table: "Cotisations",
                newName: "MembreId");

            migrationBuilder.AddColumn<decimal>(
                name: "Montant",
                table: "Cotisations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Periodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cotisations_MembreId",
                table: "Cotisations",
                column: "MembreId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotisations_PeriodeId",
                table: "Cotisations",
                column: "PeriodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotisations_Membres_MembreId",
                table: "Cotisations",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cotisations_Periodes_PeriodeId",
                table: "Cotisations",
                column: "PeriodeId",
                principalTable: "Periodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotisations_Membres_MembreId",
                table: "Cotisations");

            migrationBuilder.DropForeignKey(
                name: "FK_Cotisations_Periodes_PeriodeId",
                table: "Cotisations");

            migrationBuilder.DropTable(
                name: "Periodes");

            migrationBuilder.DropIndex(
                name: "IX_Cotisations_MembreId",
                table: "Cotisations");

            migrationBuilder.DropIndex(
                name: "IX_Cotisations_PeriodeId",
                table: "Cotisations");

            migrationBuilder.DropColumn(
                name: "Montant",
                table: "Cotisations");

            migrationBuilder.RenameColumn(
                name: "PeriodeId",
                table: "Cotisations",
                newName: "Mois");

            migrationBuilder.RenameColumn(
                name: "MembreId",
                table: "Cotisations",
                newName: "Annee");

            migrationBuilder.AddColumn<int>(
                name: "DemandeCreditId",
                table: "Credits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DemandeAvanceId",
                table: "Avances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DemandeAvances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembreId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DateDemande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstApprouve = table.Column<bool>(type: "bit", nullable: true),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontantApprouve = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontantSolicite = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NombreEcheance = table.Column<int>(type: "int", nullable: false)
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
                    MembreId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DateDemande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstApprouve = table.Column<bool>(type: "bit", nullable: true),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontantApprouve = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontantSolicite = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NombreEcheance = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "MvtCotisations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CotisationId = table.Column<int>(type: "int", nullable: false),
                    MembreId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    EstDebit = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                        name: "FK_MvtCotisations_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credits_DemandeCreditId",
                table: "Credits",
                column: "DemandeCreditId");

            migrationBuilder.CreateIndex(
                name: "IX_Avances_DemandeAvanceId",
                table: "Avances",
                column: "DemandeAvanceId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandeAvances_MembreId",
                table: "DemandeAvances",
                column: "MembreId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandeCredits_MembreId",
                table: "DemandeCredits",
                column: "MembreId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtCotisations_CotisationId",
                table: "MvtCotisations",
                column: "CotisationId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtCotisations_MembreId",
                table: "MvtCotisations",
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
    }
}
