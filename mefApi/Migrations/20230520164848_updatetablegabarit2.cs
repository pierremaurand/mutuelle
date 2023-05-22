using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mefapi.Migrations
{
    public partial class updatetablegabarit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GabaritId",
                table: "Operations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "EstActif",
                table: "Gabarits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Operations_GabaritId",
                table: "Operations",
                column: "GabaritId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Gabarits_GabaritId",
                table: "Operations",
                column: "GabaritId",
                principalTable: "Gabarits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Gabarits_GabaritId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_GabaritId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "GabaritId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "EstActif",
                table: "Gabarits");
        }
    }
}
