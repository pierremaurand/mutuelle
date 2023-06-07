using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mefapi.Migrations
{
    public partial class updatetablemvtAvancesCredits8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcheancesAvances_Mouvements_MouvementId",
                table: "EcheancesAvances");

            migrationBuilder.DropIndex(
                name: "IX_EcheancesAvances_MouvementId",
                table: "EcheancesAvances");

            migrationBuilder.DropColumn(
                name: "MouvementId",
                table: "EcheancesAvances");

            migrationBuilder.AddColumn<int>(
                name: "EcheanceAvanceId",
                table: "Mouvements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mouvements_EcheanceAvanceId",
                table: "Mouvements",
                column: "EcheanceAvanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mouvements_EcheancesAvances_EcheanceAvanceId",
                table: "Mouvements",
                column: "EcheanceAvanceId",
                principalTable: "EcheancesAvances",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mouvements_EcheancesAvances_EcheanceAvanceId",
                table: "Mouvements");

            migrationBuilder.DropIndex(
                name: "IX_Mouvements_EcheanceAvanceId",
                table: "Mouvements");

            migrationBuilder.DropColumn(
                name: "EcheanceAvanceId",
                table: "Mouvements");

            migrationBuilder.AddColumn<int>(
                name: "MouvementId",
                table: "EcheancesAvances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EcheancesAvances_MouvementId",
                table: "EcheancesAvances",
                column: "MouvementId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EcheancesAvances_Mouvements_MouvementId",
                table: "EcheancesAvances",
                column: "MouvementId",
                principalTable: "Mouvements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
