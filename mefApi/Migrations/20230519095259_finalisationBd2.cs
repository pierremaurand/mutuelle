using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mefapi.Migrations
{
    public partial class finalisationBd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcritureComptables_Mouvement_MouvementId",
                table: "EcritureComptables");

            migrationBuilder.DropForeignKey(
                name: "FK_Mouvement_Gabarits_GabaritId",
                table: "Mouvement");

            migrationBuilder.DropForeignKey(
                name: "FK_MvtAvancesDebourses_Mouvement_MouvementId",
                table: "MvtAvancesDebourses");

            migrationBuilder.DropForeignKey(
                name: "FK_MvtComptes_Mouvement_MouvementId",
                table: "MvtComptes");

            migrationBuilder.DropForeignKey(
                name: "FK_MvtCreditsDebourses_Mouvement_MouvementId",
                table: "MvtCreditsDebourses");

            migrationBuilder.DropForeignKey(
                name: "FK_MvtEcheancesAvances_Mouvement_MouvementId",
                table: "MvtEcheancesAvances");

            migrationBuilder.DropForeignKey(
                name: "FK_MvtEcheancesCredits_Mouvement_MouvementId",
                table: "MvtEcheancesCredits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mouvement",
                table: "Mouvement");

            migrationBuilder.RenameTable(
                name: "Mouvement",
                newName: "Mouvements");

            migrationBuilder.RenameIndex(
                name: "IX_Mouvement_GabaritId",
                table: "Mouvements",
                newName: "IX_Mouvements_GabaritId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mouvements",
                table: "Mouvements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EcritureComptables_Mouvements_MouvementId",
                table: "EcritureComptables",
                column: "MouvementId",
                principalTable: "Mouvements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mouvements_Gabarits_GabaritId",
                table: "Mouvements",
                column: "GabaritId",
                principalTable: "Gabarits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MvtAvancesDebourses_Mouvements_MouvementId",
                table: "MvtAvancesDebourses",
                column: "MouvementId",
                principalTable: "Mouvements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MvtComptes_Mouvements_MouvementId",
                table: "MvtComptes",
                column: "MouvementId",
                principalTable: "Mouvements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MvtCreditsDebourses_Mouvements_MouvementId",
                table: "MvtCreditsDebourses",
                column: "MouvementId",
                principalTable: "Mouvements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MvtEcheancesAvances_Mouvements_MouvementId",
                table: "MvtEcheancesAvances",
                column: "MouvementId",
                principalTable: "Mouvements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MvtEcheancesCredits_Mouvements_MouvementId",
                table: "MvtEcheancesCredits",
                column: "MouvementId",
                principalTable: "Mouvements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcritureComptables_Mouvements_MouvementId",
                table: "EcritureComptables");

            migrationBuilder.DropForeignKey(
                name: "FK_Mouvements_Gabarits_GabaritId",
                table: "Mouvements");

            migrationBuilder.DropForeignKey(
                name: "FK_MvtAvancesDebourses_Mouvements_MouvementId",
                table: "MvtAvancesDebourses");

            migrationBuilder.DropForeignKey(
                name: "FK_MvtComptes_Mouvements_MouvementId",
                table: "MvtComptes");

            migrationBuilder.DropForeignKey(
                name: "FK_MvtCreditsDebourses_Mouvements_MouvementId",
                table: "MvtCreditsDebourses");

            migrationBuilder.DropForeignKey(
                name: "FK_MvtEcheancesAvances_Mouvements_MouvementId",
                table: "MvtEcheancesAvances");

            migrationBuilder.DropForeignKey(
                name: "FK_MvtEcheancesCredits_Mouvements_MouvementId",
                table: "MvtEcheancesCredits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mouvements",
                table: "Mouvements");

            migrationBuilder.RenameTable(
                name: "Mouvements",
                newName: "Mouvement");

            migrationBuilder.RenameIndex(
                name: "IX_Mouvements_GabaritId",
                table: "Mouvement",
                newName: "IX_Mouvement_GabaritId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mouvement",
                table: "Mouvement",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EcritureComptables_Mouvement_MouvementId",
                table: "EcritureComptables",
                column: "MouvementId",
                principalTable: "Mouvement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mouvement_Gabarits_GabaritId",
                table: "Mouvement",
                column: "GabaritId",
                principalTable: "Gabarits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MvtAvancesDebourses_Mouvement_MouvementId",
                table: "MvtAvancesDebourses",
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

            migrationBuilder.AddForeignKey(
                name: "FK_MvtCreditsDebourses_Mouvement_MouvementId",
                table: "MvtCreditsDebourses",
                column: "MouvementId",
                principalTable: "Mouvement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MvtEcheancesAvances_Mouvement_MouvementId",
                table: "MvtEcheancesAvances",
                column: "MouvementId",
                principalTable: "Mouvement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MvtEcheancesCredits_Mouvement_MouvementId",
                table: "MvtEcheancesCredits",
                column: "MouvementId",
                principalTable: "Mouvement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
