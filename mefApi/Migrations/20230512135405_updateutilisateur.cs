using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mefapi.Migrations
{
    public partial class updateutilisateur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Membres_MembreId",
                table: "Utilisateurs");

            migrationBuilder.DropIndex(
                name: "IX_Utilisateurs_MembreId",
                table: "Utilisateurs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_MembreId",
                table: "Utilisateurs",
                column: "MembreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_Membres_MembreId",
                table: "Utilisateurs",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
