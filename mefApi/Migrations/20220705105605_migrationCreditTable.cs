using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class migrationCreditTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "Credits",
                newName: "MontantCapital");

            migrationBuilder.RenameColumn(
                name: "Interets",
                table: "Credits",
                newName: "Interet");

            migrationBuilder.AddColumn<decimal>(
                name: "Commission",
                table: "Credits",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Commission",
                table: "Credits");

            migrationBuilder.RenameColumn(
                name: "MontantCapital",
                table: "Credits",
                newName: "Montant");

            migrationBuilder.RenameColumn(
                name: "Interet",
                table: "Credits",
                newName: "Interets");
        }
    }
}
