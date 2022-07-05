using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class update_all_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avances_Membres_MembreId",
                table: "Avances");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Membres_MembreId",
                table: "Credits");

            migrationBuilder.DropTable(
                name: "EcheanceAvances");

            migrationBuilder.DropTable(
                name: "EcheanceCredits");

            migrationBuilder.AlterColumn<int>(
                name: "MembreId",
                table: "Credits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MembreId",
                table: "Avances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Avances_Membres_MembreId",
                table: "Avances",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_Membres_MembreId",
                table: "Credits",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avances_Membres_MembreId",
                table: "Avances");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Membres_MembreId",
                table: "Credits");

            migrationBuilder.AlterColumn<int>(
                name: "MembreId",
                table: "Credits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MembreId",
                table: "Avances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "EcheanceAvances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvanceId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DateEcheance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstPaye = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcheanceAvances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcheanceAvances_Avances_AvanceId",
                        column: x => x.AvanceId,
                        principalTable: "Avances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EcheanceCredits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DateEcheance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstPaye = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcheanceCredits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcheanceCredits_Credits_CreditId",
                        column: x => x.CreditId,
                        principalTable: "Credits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EcheanceAvances_AvanceId",
                table: "EcheanceAvances",
                column: "AvanceId");

            migrationBuilder.CreateIndex(
                name: "IX_EcheanceCredits_CreditId",
                table: "EcheanceCredits",
                column: "CreditId");

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
    }
}
