using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class UpdateAvanceCredit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifieLe",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "ModifiePar",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "ModifieLe",
                table: "Avances");

            migrationBuilder.DropColumn(
                name: "ModifiePar",
                table: "Avances");

            migrationBuilder.RenameColumn(
                name: "DateCredit",
                table: "Credits",
                newName: "DateEnregistrement");

            migrationBuilder.RenameColumn(
                name: "DateDemande",
                table: "Avances",
                newName: "DateEnregistrement");

            migrationBuilder.AddColumn<int>(
                name: "CreditId",
                table: "EcheanceCredits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateDeblocage",
                table: "Credits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateSolde",
                table: "Credits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "estValider",
                table: "Credits",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateSolde",
                table: "Avances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "estValider",
                table: "Avances",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EcheanceCredits_CreditId",
                table: "EcheanceCredits",
                column: "CreditId");

            migrationBuilder.AddForeignKey(
                name: "FK_EcheanceCredits_Credits_CreditId",
                table: "EcheanceCredits",
                column: "CreditId",
                principalTable: "Credits",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcheanceCredits_Credits_CreditId",
                table: "EcheanceCredits");

            migrationBuilder.DropIndex(
                name: "IX_EcheanceCredits_CreditId",
                table: "EcheanceCredits");

            migrationBuilder.DropColumn(
                name: "CreditId",
                table: "EcheanceCredits");

            migrationBuilder.DropColumn(
                name: "DateDeblocage",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "DateSolde",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "estValider",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "DateSolde",
                table: "Avances");

            migrationBuilder.DropColumn(
                name: "estValider",
                table: "Avances");

            migrationBuilder.RenameColumn(
                name: "DateEnregistrement",
                table: "Credits",
                newName: "DateCredit");

            migrationBuilder.RenameColumn(
                name: "DateEnregistrement",
                table: "Avances",
                newName: "DateDemande");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifieLe",
                table: "Credits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiePar",
                table: "Credits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifieLe",
                table: "Avances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiePar",
                table: "Avances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
