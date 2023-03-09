using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class UpdateMembre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotisations_Membres_MembreId",
                table: "Cotisations");

            migrationBuilder.AlterColumn<int>(
                name: "MembreId",
                table: "Credits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "FK_Cotisations_Membres_MembreId",
                table: "Cotisations",
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
                name: "FK_Cotisations_Membres_MembreId",
                table: "Cotisations");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Membres_MembreId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Credits_MembreId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Avances_MembreId",
                table: "Avances");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Cotisations_Membres_MembreId",
                table: "Cotisations",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
