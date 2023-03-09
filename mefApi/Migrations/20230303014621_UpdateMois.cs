using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class UpdateMois : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mois",
                table: "EcheanceCredits",
                newName: "MoisId");

            migrationBuilder.RenameColumn(
                name: "Mois",
                table: "EcheanceAvances",
                newName: "MoisId");

            migrationBuilder.RenameColumn(
                name: "Mois",
                table: "Cotisations",
                newName: "MoisId");

            migrationBuilder.CreateTable(
                name: "Mois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valeur = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mois", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EcheanceCredits_MoisId",
                table: "EcheanceCredits",
                column: "MoisId");

            migrationBuilder.CreateIndex(
                name: "IX_EcheanceAvances_MoisId",
                table: "EcheanceAvances",
                column: "MoisId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotisations_MoisId",
                table: "Cotisations",
                column: "MoisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotisations_Mois_MoisId",
                table: "Cotisations",
                column: "MoisId",
                principalTable: "Mois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EcheanceAvances_Mois_MoisId",
                table: "EcheanceAvances",
                column: "MoisId",
                principalTable: "Mois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EcheanceCredits_Mois_MoisId",
                table: "EcheanceCredits",
                column: "MoisId",
                principalTable: "Mois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotisations_Mois_MoisId",
                table: "Cotisations");

            migrationBuilder.DropForeignKey(
                name: "FK_EcheanceAvances_Mois_MoisId",
                table: "EcheanceAvances");

            migrationBuilder.DropForeignKey(
                name: "FK_EcheanceCredits_Mois_MoisId",
                table: "EcheanceCredits");

            migrationBuilder.DropTable(
                name: "Mois");

            migrationBuilder.DropIndex(
                name: "IX_EcheanceCredits_MoisId",
                table: "EcheanceCredits");

            migrationBuilder.DropIndex(
                name: "IX_EcheanceAvances_MoisId",
                table: "EcheanceAvances");

            migrationBuilder.DropIndex(
                name: "IX_Cotisations_MoisId",
                table: "Cotisations");

            migrationBuilder.RenameColumn(
                name: "MoisId",
                table: "EcheanceCredits",
                newName: "Mois");

            migrationBuilder.RenameColumn(
                name: "MoisId",
                table: "EcheanceAvances",
                newName: "Mois");

            migrationBuilder.RenameColumn(
                name: "MoisId",
                table: "Cotisations",
                newName: "Mois");
        }
    }
}
