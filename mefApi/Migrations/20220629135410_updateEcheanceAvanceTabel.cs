using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class updateEcheanceAvanceTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePaiement",
                table: "EcheanceAvances");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "EcheanceAvances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastUpdatedBy",
                table: "EcheanceAvances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "EcheanceAvances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EcheanceAvances");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "EcheanceAvances");

            migrationBuilder.DropColumn(
                name: "LastUpdatedOn",
                table: "EcheanceAvances");

            migrationBuilder.AddColumn<string>(
                name: "DatePaiement",
                table: "EcheanceAvances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
