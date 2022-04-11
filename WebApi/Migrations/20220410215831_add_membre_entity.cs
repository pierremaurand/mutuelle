using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class add_membre_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Membres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SexeId = table.Column<int>(type: "int", nullable: false),
                    DateAdhesion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgenceId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    EstActif = table.Column<bool>(type: "bit", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membres_Agences_AgenceId",
                        column: x => x.AgenceId,
                        principalTable: "Agences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membres_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membres_Sexes_SexeId",
                        column: x => x.SexeId,
                        principalTable: "Sexes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Membres_AgenceId",
                table: "Membres",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Membres_ServiceId",
                table: "Membres",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Membres_SexeId",
                table: "Membres",
                column: "SexeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Membres");
        }
    }
}
