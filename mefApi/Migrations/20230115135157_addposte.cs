using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class addposte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membres_Sexes_SexeId",
                table: "Membres");

            migrationBuilder.AlterColumn<int>(
                name: "SexeId",
                table: "Membres",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "EstActif",
                table: "Membres",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PosteId",
                table: "Membres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Membres_PosteId",
                table: "Membres",
                column: "PosteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membres_Postes_PosteId",
                table: "Membres",
                column: "PosteId",
                principalTable: "Postes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Membres_Sexes_SexeId",
                table: "Membres",
                column: "SexeId",
                principalTable: "Sexes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membres_Postes_PosteId",
                table: "Membres");

            migrationBuilder.DropForeignKey(
                name: "FK_Membres_Sexes_SexeId",
                table: "Membres");

            migrationBuilder.DropIndex(
                name: "IX_Membres_PosteId",
                table: "Membres");

            migrationBuilder.DropColumn(
                name: "PosteId",
                table: "Membres");

            migrationBuilder.AlterColumn<int>(
                name: "SexeId",
                table: "Membres",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "EstActif",
                table: "Membres",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddForeignKey(
                name: "FK_Membres_Sexes_SexeId",
                table: "Membres",
                column: "SexeId",
                principalTable: "Sexes",
                principalColumn: "Id");
        }
    }
}
