using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class updateCredit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Membres_MembreId",
                table: "Utilisateurs");

            migrationBuilder.AlterColumn<int>(
                name: "MembreId",
                table: "Utilisateurs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MontantCommission",
                table: "Credits",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_Membres_MembreId",
                table: "Utilisateurs",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilisateurs_Membres_MembreId",
                table: "Utilisateurs");

            migrationBuilder.DropColumn(
                name: "MontantCommission",
                table: "Credits");

            migrationBuilder.AlterColumn<int>(
                name: "MembreId",
                table: "Utilisateurs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilisateurs_Membres_MembreId",
                table: "Utilisateurs",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id");
        }
    }
}
