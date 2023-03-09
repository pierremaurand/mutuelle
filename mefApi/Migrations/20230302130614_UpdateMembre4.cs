using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class UpdateMembre4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avances_Membres_MembreId",
                table: "Avances");

            migrationBuilder.DropForeignKey(
                name: "FK_Cotisations_Membres_MembreId",
                table: "Cotisations");

            migrationBuilder.RenameColumn(
                name: "DateAvance",
                table: "Avances",
                newName: "DateDemande");

            migrationBuilder.AddColumn<int>(
                name: "AvanceId",
                table: "EcheanceAvances",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MembreId",
                table: "Cotisations",
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

            migrationBuilder.AddColumn<string>(
                name: "DateDeblocage",
                table: "Avances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EcheanceAvances_AvanceId",
                table: "EcheanceAvances",
                column: "AvanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avances_Membres_MembreId",
                table: "Avances",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cotisations_Membres_MembreId",
                table: "Cotisations",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EcheanceAvances_Avances_AvanceId",
                table: "EcheanceAvances",
                column: "AvanceId",
                principalTable: "Avances",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avances_Membres_MembreId",
                table: "Avances");

            migrationBuilder.DropForeignKey(
                name: "FK_Cotisations_Membres_MembreId",
                table: "Cotisations");

            migrationBuilder.DropForeignKey(
                name: "FK_EcheanceAvances_Avances_AvanceId",
                table: "EcheanceAvances");

            migrationBuilder.DropIndex(
                name: "IX_EcheanceAvances_AvanceId",
                table: "EcheanceAvances");

            migrationBuilder.DropColumn(
                name: "AvanceId",
                table: "EcheanceAvances");

            migrationBuilder.DropColumn(
                name: "DateDeblocage",
                table: "Avances");

            migrationBuilder.RenameColumn(
                name: "DateDemande",
                table: "Avances",
                newName: "DateAvance");

            migrationBuilder.AlterColumn<int>(
                name: "MembreId",
                table: "Cotisations",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Avances_Membres_MembreId",
                table: "Avances",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotisations_Membres_MembreId",
                table: "Cotisations",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id");
        }
    }
}
