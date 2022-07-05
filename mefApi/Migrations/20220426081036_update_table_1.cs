using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class update_table_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateEcheance",
                table: "EcheanceCredits",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DateEcheance",
                table: "EcheanceAvances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DateFin",
                table: "Credits",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DateDebut",
                table: "Credits",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "MembreId",
                table: "Credits",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Periode",
                table: "Cotisations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DateFin",
                table: "Avances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DateDebut",
                table: "Avances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "MembreId",
                table: "Avances",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Credits_MembreId",
                table: "Credits",
                column: "MembreId");

            migrationBuilder.CreateIndex(
                name: "IX_Avances_MembreId",
                table: "Avances",
                column: "MembreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avances_Membres_MembreId",
                table: "Avances",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_Membres_MembreId",
                table: "Credits",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avances_Membres_MembreId",
                table: "Avances");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Membres_MembreId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Credits_MembreId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Avances_MembreId",
                table: "Avances");

            migrationBuilder.DropColumn(
                name: "MembreId",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "MembreId",
                table: "Avances");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateEcheance",
                table: "EcheanceCredits",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateEcheance",
                table: "EcheanceAvances",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFin",
                table: "Credits",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDebut",
                table: "Credits",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Periode",
                table: "Cotisations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFin",
                table: "Avances",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDebut",
                table: "Avances",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
