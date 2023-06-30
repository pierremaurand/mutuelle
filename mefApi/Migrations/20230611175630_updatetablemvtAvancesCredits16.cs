using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mefapi.Migrations
{
    public partial class updatetablemvtAvancesCredits16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mouvements_Avances_AvanceId",
                table: "Mouvements");

            migrationBuilder.DropIndex(
                name: "IX_Mouvements_AvanceId",
                table: "Mouvements");

            migrationBuilder.DropColumn(
                name: "AvanceId",
                table: "Mouvements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvanceId",
                table: "Mouvements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mouvements_AvanceId",
                table: "Mouvements",
                column: "AvanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mouvements_Avances_AvanceId",
                table: "Mouvements",
                column: "AvanceId",
                principalTable: "Avances",
                principalColumn: "Id");
        }
    }
}
