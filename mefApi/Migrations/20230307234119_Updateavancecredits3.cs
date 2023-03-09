using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class Updateavancecredits3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Membres_MembreId",
                table: "Credits");

            migrationBuilder.AlterColumn<int>(
                name: "MembreId",
                table: "Credits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "FK_Credits_Membres_MembreId",
                table: "Credits");

            migrationBuilder.AlterColumn<int>(
                name: "MembreId",
                table: "Credits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_Membres_MembreId",
                table: "Credits",
                column: "MembreId",
                principalTable: "Membres",
                principalColumn: "Id");
        }
    }
}
