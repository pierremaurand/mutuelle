using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class Updateavancecredits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstValider",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "EstValider",
                table: "Avances");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstValider",
                table: "Credits",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EstValider",
                table: "Avances",
                type: "bit",
                nullable: true);
        }
    }
}
