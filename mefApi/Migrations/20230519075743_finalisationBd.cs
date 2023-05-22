using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mefapi.Migrations
{
    public partial class finalisationBd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MvtComptes_Gabarits_GabaritId",
                table: "MvtComptes");

            migrationBuilder.DropIndex(
                name: "IX_MvtComptes_GabaritId",
                table: "MvtComptes");

            migrationBuilder.DropColumn(
                name: "DateMvt",
                table: "MvtComptes");

            migrationBuilder.DropColumn(
                name: "GabaritId",
                table: "MvtComptes");

            migrationBuilder.DropColumn(
                name: "Libelle",
                table: "MvtComptes");

            migrationBuilder.DropColumn(
                name: "Montant",
                table: "MvtComptes");

            migrationBuilder.RenameColumn(
                name: "TypeOperation",
                table: "MvtComptes",
                newName: "MouvementId");

            migrationBuilder.AddColumn<int>(
                name: "MouvementId",
                table: "EcritureComptables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Mouvement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateMvt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOperation = table.Column<int>(type: "int", nullable: false),
                    GabaritId = table.Column<int>(type: "int", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mouvement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mouvement_Gabarits_GabaritId",
                        column: x => x.GabaritId,
                        principalTable: "Gabarits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MvtAvancesDebourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MouvementId = table.Column<int>(type: "int", nullable: false),
                    AvanceDebourseId = table.Column<int>(type: "int", nullable: false),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MvtAvancesDebourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MvtAvancesDebourses_AvancesDebourses_AvanceDebourseId",
                        column: x => x.AvanceDebourseId,
                        principalTable: "AvancesDebourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MvtAvancesDebourses_Mouvement_MouvementId",
                        column: x => x.MouvementId,
                        principalTable: "Mouvement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MvtCreditsDebourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MouvementId = table.Column<int>(type: "int", nullable: false),
                    CreditDebourseId = table.Column<int>(type: "int", nullable: false),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MvtCreditsDebourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MvtCreditsDebourses_CreditsDebourses_CreditDebourseId",
                        column: x => x.CreditDebourseId,
                        principalTable: "CreditsDebourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MvtCreditsDebourses_Mouvement_MouvementId",
                        column: x => x.MouvementId,
                        principalTable: "Mouvement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MvtEcheancesAvances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MouvementId = table.Column<int>(type: "int", nullable: false),
                    EcheanceAvanceId = table.Column<int>(type: "int", nullable: false),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MvtEcheancesAvances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MvtEcheancesAvances_EcheancesAvances_EcheanceAvanceId",
                        column: x => x.EcheanceAvanceId,
                        principalTable: "EcheancesAvances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MvtEcheancesAvances_Mouvement_MouvementId",
                        column: x => x.MouvementId,
                        principalTable: "Mouvement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MvtEcheancesCredits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MouvementId = table.Column<int>(type: "int", nullable: false),
                    EcheanceCreditId = table.Column<int>(type: "int", nullable: false),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MvtEcheancesCredits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MvtEcheancesCredits_EcheancesCredits_EcheanceCreditId",
                        column: x => x.EcheanceCreditId,
                        principalTable: "EcheancesCredits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MvtEcheancesCredits_Mouvement_MouvementId",
                        column: x => x.MouvementId,
                        principalTable: "Mouvement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MvtComptes_MouvementId",
                table: "MvtComptes",
                column: "MouvementId");

            migrationBuilder.CreateIndex(
                name: "IX_EcritureComptables_MouvementId",
                table: "EcritureComptables",
                column: "MouvementId");

            migrationBuilder.CreateIndex(
                name: "IX_Mouvement_GabaritId",
                table: "Mouvement",
                column: "GabaritId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtAvancesDebourses_AvanceDebourseId",
                table: "MvtAvancesDebourses",
                column: "AvanceDebourseId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtAvancesDebourses_MouvementId",
                table: "MvtAvancesDebourses",
                column: "MouvementId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtCreditsDebourses_CreditDebourseId",
                table: "MvtCreditsDebourses",
                column: "CreditDebourseId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtCreditsDebourses_MouvementId",
                table: "MvtCreditsDebourses",
                column: "MouvementId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtEcheancesAvances_EcheanceAvanceId",
                table: "MvtEcheancesAvances",
                column: "EcheanceAvanceId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtEcheancesAvances_MouvementId",
                table: "MvtEcheancesAvances",
                column: "MouvementId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtEcheancesCredits_EcheanceCreditId",
                table: "MvtEcheancesCredits",
                column: "EcheanceCreditId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtEcheancesCredits_MouvementId",
                table: "MvtEcheancesCredits",
                column: "MouvementId");

            migrationBuilder.AddForeignKey(
                name: "FK_EcritureComptables_Mouvement_MouvementId",
                table: "EcritureComptables",
                column: "MouvementId",
                principalTable: "Mouvement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MvtComptes_Mouvement_MouvementId",
                table: "MvtComptes",
                column: "MouvementId",
                principalTable: "Mouvement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcritureComptables_Mouvement_MouvementId",
                table: "EcritureComptables");

            migrationBuilder.DropForeignKey(
                name: "FK_MvtComptes_Mouvement_MouvementId",
                table: "MvtComptes");

            migrationBuilder.DropTable(
                name: "MvtAvancesDebourses");

            migrationBuilder.DropTable(
                name: "MvtCreditsDebourses");

            migrationBuilder.DropTable(
                name: "MvtEcheancesAvances");

            migrationBuilder.DropTable(
                name: "MvtEcheancesCredits");

            migrationBuilder.DropTable(
                name: "Mouvement");

            migrationBuilder.DropIndex(
                name: "IX_MvtComptes_MouvementId",
                table: "MvtComptes");

            migrationBuilder.DropIndex(
                name: "IX_EcritureComptables_MouvementId",
                table: "EcritureComptables");

            migrationBuilder.DropColumn(
                name: "MouvementId",
                table: "EcritureComptables");

            migrationBuilder.RenameColumn(
                name: "MouvementId",
                table: "MvtComptes",
                newName: "TypeOperation");

            migrationBuilder.AddColumn<string>(
                name: "DateMvt",
                table: "MvtComptes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GabaritId",
                table: "MvtComptes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Libelle",
                table: "MvtComptes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Montant",
                table: "MvtComptes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_MvtComptes_GabaritId",
                table: "MvtComptes",
                column: "GabaritId");

            migrationBuilder.AddForeignKey(
                name: "FK_MvtComptes_Gabarits_GabaritId",
                table: "MvtComptes",
                column: "GabaritId",
                principalTable: "Gabarits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
