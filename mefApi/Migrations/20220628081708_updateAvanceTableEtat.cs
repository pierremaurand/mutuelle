using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class updateAvanceTableEtat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstValide",
                table: "Avances",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstValide",
                table: "Avances");
        }
    }
}
