using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class update_cotisation_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeriodeId",
                table: "Cotisations");

            migrationBuilder.AddColumn<bool>(
                name: "EstValide",
                table: "Cotisations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstValide",
                table: "Cotisations");

            migrationBuilder.AddColumn<int>(
                name: "PeriodeId",
                table: "Cotisations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
