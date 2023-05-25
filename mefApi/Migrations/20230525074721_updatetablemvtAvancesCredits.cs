using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mefapi.Migrations
{
    public partial class updatetablemvtAvancesCredits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcheancesAvances_Avances_AvanceId",
                table: "EcheancesAvances");

            migrationBuilder.DropForeignKey(
                name: "FK_EcheancesAvances_Mois_MoisId",
                table: "EcheancesAvances");

            migrationBuilder.DropForeignKey(
                name: "FK_EcheancesCredits_Credits_CreditId",
                table: "EcheancesCredits");

            migrationBuilder.DropForeignKey(
                name: "FK_EcheancesCredits_Mois_MoisId",
                table: "EcheancesCredits");

            migrationBuilder.DropIndex(
                name: "IX_EcheancesCredits_CreditId",
                table: "EcheancesCredits");

            migrationBuilder.DropIndex(
                name: "IX_EcheancesAvances_AvanceId",
                table: "EcheancesAvances");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "EcheancesCredits");

            migrationBuilder.DropColumn(
                name: "CreditId",
                table: "EcheancesCredits");

            migrationBuilder.DropColumn(
                name: "EstPaye",
                table: "EcheancesCredits");

            migrationBuilder.DropColumn(
                name: "MontantCapital",
                table: "EcheancesCredits");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "EcheancesAvances");

            migrationBuilder.DropColumn(
                name: "AvanceId",
                table: "EcheancesAvances");

            migrationBuilder.DropColumn(
                name: "EstPaye",
                table: "EcheancesAvances");

            migrationBuilder.DropColumn(
                name: "DateDebut",
                table: "CreditsDebourses");

            migrationBuilder.DropColumn(
                name: "MontantCapital",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "MontantCommission",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "DateDebut",
                table: "AvancesDebourses");

            migrationBuilder.DropColumn(
                name: "Avis1",
                table: "Avances");

            migrationBuilder.DropColumn(
                name: "Avis2",
                table: "Avances");

            migrationBuilder.RenameColumn(
                name: "MontantInteret",
                table: "EcheancesCredits",
                newName: "Pricipal");

            migrationBuilder.RenameColumn(
                name: "MontantCommission",
                table: "EcheancesCredits",
                newName: "Interet");

            migrationBuilder.RenameColumn(
                name: "MoisId",
                table: "EcheancesCredits",
                newName: "CreditDebourseId");

            migrationBuilder.RenameIndex(
                name: "IX_EcheancesCredits_MoisId",
                table: "EcheancesCredits",
                newName: "IX_EcheancesCredits_CreditDebourseId");

            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "EcheancesAvances",
                newName: "MontantEcheance");

            migrationBuilder.RenameColumn(
                name: "MoisId",
                table: "EcheancesAvances",
                newName: "AvanceDebourseId");

            migrationBuilder.RenameIndex(
                name: "IX_EcheancesAvances_MoisId",
                table: "EcheancesAvances",
                newName: "IX_EcheancesAvances_AvanceDebourseId");

            migrationBuilder.RenameColumn(
                name: "NombreEcheances",
                table: "CreditsDebourses",
                newName: "DureeAccordee");

            migrationBuilder.RenameColumn(
                name: "MontantCapital",
                table: "CreditsDebourses",
                newName: "MontantAccorde");

            migrationBuilder.RenameColumn(
                name: "DateFin",
                table: "CreditsDebourses",
                newName: "DateDecaissement");

            migrationBuilder.RenameColumn(
                name: "NombreEcheances",
                table: "Credits",
                newName: "DureeSollicite");

            migrationBuilder.RenameColumn(
                name: "MontantInteret",
                table: "Credits",
                newName: "MontantSollicite");

            migrationBuilder.RenameColumn(
                name: "NombreEcheances",
                table: "AvancesDebourses",
                newName: "NombreEcheancesApprouve");

            migrationBuilder.RenameColumn(
                name: "MontantDebourse",
                table: "AvancesDebourses",
                newName: "MontantApprouve");

            migrationBuilder.RenameColumn(
                name: "DateFin",
                table: "AvancesDebourses",
                newName: "DateDecaissement");

            migrationBuilder.RenameColumn(
                name: "NombreEcheances",
                table: "Avances",
                newName: "NombreEcheancesSollicite");

            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "Avances",
                newName: "MontantSollicite");

            migrationBuilder.AddColumn<string>(
                name: "DateEcheance",
                table: "EcheancesCredits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DateEcheance",
                table: "EcheancesAvances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DateDemande",
                table: "Credits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DateDemande",
                table: "Avances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_EcheancesAvances_AvancesDebourses_AvanceDebourseId",
                table: "EcheancesAvances",
                column: "AvanceDebourseId",
                principalTable: "AvancesDebourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EcheancesCredits_CreditsDebourses_CreditDebourseId",
                table: "EcheancesCredits",
                column: "CreditDebourseId",
                principalTable: "CreditsDebourses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcheancesAvances_AvancesDebourses_AvanceDebourseId",
                table: "EcheancesAvances");

            migrationBuilder.DropForeignKey(
                name: "FK_EcheancesCredits_CreditsDebourses_CreditDebourseId",
                table: "EcheancesCredits");

            migrationBuilder.DropColumn(
                name: "DateEcheance",
                table: "EcheancesCredits");

            migrationBuilder.DropColumn(
                name: "DateEcheance",
                table: "EcheancesAvances");

            migrationBuilder.DropColumn(
                name: "DateDemande",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "DateDemande",
                table: "Avances");

            migrationBuilder.RenameColumn(
                name: "Pricipal",
                table: "EcheancesCredits",
                newName: "MontantInteret");

            migrationBuilder.RenameColumn(
                name: "Interet",
                table: "EcheancesCredits",
                newName: "MontantCommission");

            migrationBuilder.RenameColumn(
                name: "CreditDebourseId",
                table: "EcheancesCredits",
                newName: "MoisId");

            migrationBuilder.RenameIndex(
                name: "IX_EcheancesCredits_CreditDebourseId",
                table: "EcheancesCredits",
                newName: "IX_EcheancesCredits_MoisId");

            migrationBuilder.RenameColumn(
                name: "MontantEcheance",
                table: "EcheancesAvances",
                newName: "Montant");

            migrationBuilder.RenameColumn(
                name: "AvanceDebourseId",
                table: "EcheancesAvances",
                newName: "MoisId");

            migrationBuilder.RenameIndex(
                name: "IX_EcheancesAvances_AvanceDebourseId",
                table: "EcheancesAvances",
                newName: "IX_EcheancesAvances_MoisId");

            migrationBuilder.RenameColumn(
                name: "MontantAccorde",
                table: "CreditsDebourses",
                newName: "MontantCapital");

            migrationBuilder.RenameColumn(
                name: "DureeAccordee",
                table: "CreditsDebourses",
                newName: "NombreEcheances");

            migrationBuilder.RenameColumn(
                name: "DateDecaissement",
                table: "CreditsDebourses",
                newName: "DateFin");

            migrationBuilder.RenameColumn(
                name: "MontantSollicite",
                table: "Credits",
                newName: "MontantInteret");

            migrationBuilder.RenameColumn(
                name: "DureeSollicite",
                table: "Credits",
                newName: "NombreEcheances");

            migrationBuilder.RenameColumn(
                name: "NombreEcheancesApprouve",
                table: "AvancesDebourses",
                newName: "NombreEcheances");

            migrationBuilder.RenameColumn(
                name: "MontantApprouve",
                table: "AvancesDebourses",
                newName: "MontantDebourse");

            migrationBuilder.RenameColumn(
                name: "DateDecaissement",
                table: "AvancesDebourses",
                newName: "DateFin");

            migrationBuilder.RenameColumn(
                name: "NombreEcheancesSollicite",
                table: "Avances",
                newName: "NombreEcheances");

            migrationBuilder.RenameColumn(
                name: "MontantSollicite",
                table: "Avances",
                newName: "Montant");

            migrationBuilder.AddColumn<int>(
                name: "Annee",
                table: "EcheancesCredits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreditId",
                table: "EcheancesCredits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EstPaye",
                table: "EcheancesCredits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "MontantCapital",
                table: "EcheancesCredits",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Annee",
                table: "EcheancesAvances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AvanceId",
                table: "EcheancesAvances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EstPaye",
                table: "EcheancesAvances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DateDebut",
                table: "CreditsDebourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "MontantCapital",
                table: "Credits",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontantCommission",
                table: "Credits",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "DateDebut",
                table: "AvancesDebourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Avis1",
                table: "Avances",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Avis2",
                table: "Avances",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EcheancesCredits_CreditId",
                table: "EcheancesCredits",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_EcheancesAvances_AvanceId",
                table: "EcheancesAvances",
                column: "AvanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_EcheancesAvances_Avances_AvanceId",
                table: "EcheancesAvances",
                column: "AvanceId",
                principalTable: "Avances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EcheancesAvances_Mois_MoisId",
                table: "EcheancesAvances",
                column: "MoisId",
                principalTable: "Mois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EcheancesCredits_Credits_CreditId",
                table: "EcheancesCredits",
                column: "CreditId",
                principalTable: "Credits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EcheancesCredits_Mois_MoisId",
                table: "EcheancesCredits",
                column: "MoisId",
                principalTable: "Mois",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
