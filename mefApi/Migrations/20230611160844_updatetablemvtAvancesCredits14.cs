using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mefapi.Migrations
{
    public partial class updatetablemvtAvancesCredits14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvanceId",
                table: "Mouvements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreditId",
                table: "Mouvements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mouvements_AvanceId",
                table: "Mouvements",
                column: "AvanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Mouvements_CreditId",
                table: "Mouvements",
                column: "CreditId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mouvements_Avances_AvanceId",
                table: "Mouvements",
                column: "AvanceId",
                principalTable: "Avances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mouvements_Credits_CreditId",
                table: "Mouvements",
                column: "CreditId",
                principalTable: "Credits",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mouvements_Avances_AvanceId",
                table: "Mouvements");

            migrationBuilder.DropForeignKey(
                name: "FK_Mouvements_Credits_CreditId",
                table: "Mouvements");

            migrationBuilder.DropIndex(
                name: "IX_Mouvements_AvanceId",
                table: "Mouvements");

            migrationBuilder.DropIndex(
                name: "IX_Mouvements_CreditId",
                table: "Mouvements");

            migrationBuilder.DropColumn(
                name: "AvanceId",
                table: "Mouvements");

            migrationBuilder.DropColumn(
                name: "CreditId",
                table: "Mouvements");
        }
    }
}
