using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class UpdateEcheances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcheanceAvances_Avances_AvanceId",
                table: "EcheanceAvances");

            migrationBuilder.DropForeignKey(
                name: "FK_EcheanceCredits_Credits_CreditId",
                table: "EcheanceCredits");

            migrationBuilder.RenameColumn(
                name: "estValider",
                table: "Credits",
                newName: "EstValider");

            migrationBuilder.RenameColumn(
                name: "estValider",
                table: "Avances",
                newName: "EstValider");

            migrationBuilder.AlterColumn<int>(
                name: "CreditId",
                table: "EcheanceCredits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EstPaye",
                table: "EcheanceCredits",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AvanceId",
                table: "EcheanceAvances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EstPaye",
                table: "EcheanceAvances",
                type: "bit",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EcheanceAvances_Avances_AvanceId",
                table: "EcheanceAvances",
                column: "AvanceId",
                principalTable: "Avances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EcheanceCredits_Credits_CreditId",
                table: "EcheanceCredits",
                column: "CreditId",
                principalTable: "Credits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EcheanceAvances_Avances_AvanceId",
                table: "EcheanceAvances");

            migrationBuilder.DropForeignKey(
                name: "FK_EcheanceCredits_Credits_CreditId",
                table: "EcheanceCredits");

            migrationBuilder.DropColumn(
                name: "EstPaye",
                table: "EcheanceCredits");

            migrationBuilder.DropColumn(
                name: "EstPaye",
                table: "EcheanceAvances");

            migrationBuilder.RenameColumn(
                name: "EstValider",
                table: "Credits",
                newName: "estValider");

            migrationBuilder.RenameColumn(
                name: "EstValider",
                table: "Avances",
                newName: "estValider");

            migrationBuilder.AlterColumn<int>(
                name: "CreditId",
                table: "EcheanceCredits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AvanceId",
                table: "EcheanceAvances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EcheanceAvances_Avances_AvanceId",
                table: "EcheanceAvances",
                column: "AvanceId",
                principalTable: "Avances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EcheanceCredits_Credits_CreditId",
                table: "EcheanceCredits",
                column: "CreditId",
                principalTable: "Credits",
                principalColumn: "Id");
        }
    }
}
