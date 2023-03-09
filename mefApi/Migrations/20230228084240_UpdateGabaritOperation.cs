using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class UpdateGabaritOperation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GabaritId",
                table: "Operations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_GabaritId",
                table: "Operations",
                column: "GabaritId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Gabarits_GabaritId",
                table: "Operations",
                column: "GabaritId",
                principalTable: "Gabarits",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Gabarits_GabaritId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_GabaritId",
                table: "Operations");

            migrationBuilder.AlterColumn<int>(
                name: "GabaritId",
                table: "Operations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
