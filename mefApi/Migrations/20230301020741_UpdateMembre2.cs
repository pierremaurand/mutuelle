using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class UpdateMembre2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifieLe",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "ModifiePar",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "ModifieLe",
                table: "MvtComptes");

            migrationBuilder.DropColumn(
                name: "ModifiePar",
                table: "MvtComptes");

            migrationBuilder.DropColumn(
                name: "ModifieLe",
                table: "EcheanceCredits");

            migrationBuilder.DropColumn(
                name: "ModifieLe",
                table: "EcheanceAvances");

            migrationBuilder.DropColumn(
                name: "ModifieLe",
                table: "DetailEcritureComptables");

            migrationBuilder.DropColumn(
                name: "ModifiePar",
                table: "DetailEcritureComptables");

            migrationBuilder.DropColumn(
                name: "ModifieLe",
                table: "Cotisations");

            migrationBuilder.DropColumn(
                name: "ModifiePar",
                table: "Cotisations");

            migrationBuilder.RenameColumn(
                name: "ModifiePar",
                table: "EcheanceCredits",
                newName: "Mois");

            migrationBuilder.RenameColumn(
                name: "CreditId",
                table: "EcheanceCredits",
                newName: "Annee");

            migrationBuilder.RenameColumn(
                name: "ModifiePar",
                table: "EcheanceAvances",
                newName: "Mois");

            migrationBuilder.RenameColumn(
                name: "AvanceId",
                table: "EcheanceAvances",
                newName: "Annee");

            migrationBuilder.AddColumn<string>(
                name: "DateCredit",
                table: "Credits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DateAvance",
                table: "Avances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCredit",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "DateAvance",
                table: "Avances");

            migrationBuilder.RenameColumn(
                name: "Mois",
                table: "EcheanceCredits",
                newName: "ModifiePar");

            migrationBuilder.RenameColumn(
                name: "Annee",
                table: "EcheanceCredits",
                newName: "CreditId");

            migrationBuilder.RenameColumn(
                name: "Mois",
                table: "EcheanceAvances",
                newName: "ModifiePar");

            migrationBuilder.RenameColumn(
                name: "Annee",
                table: "EcheanceAvances",
                newName: "AvanceId");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifieLe",
                table: "Operations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiePar",
                table: "Operations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifieLe",
                table: "MvtComptes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiePar",
                table: "MvtComptes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifieLe",
                table: "EcheanceCredits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifieLe",
                table: "EcheanceAvances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifieLe",
                table: "DetailEcritureComptables",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiePar",
                table: "DetailEcritureComptables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifieLe",
                table: "Cotisations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiePar",
                table: "Cotisations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
