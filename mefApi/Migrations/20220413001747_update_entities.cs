using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class update_entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MouvementComptables");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "MouvementMembres");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordKey",
                table: "Users",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedBy",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Sexes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedBy",
                table: "Sexes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Sexes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Services",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedBy",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Parametres",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedBy",
                table: "Parametres",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Parametres",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Membres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Membres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Membres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Membres",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedBy",
                table: "Membres",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Membres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Membres",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Libelle",
                table: "Gabaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Gabaries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedBy",
                table: "Gabaries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Gabaries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Gabaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Comptes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Libelle",
                table: "Comptes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Comptes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedBy",
                table: "Comptes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Comptes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Agences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedBy",
                table: "Agences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Agences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Cotisations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mois = table.Column<int>(type: "int", nullable: false),
                    Annee = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotisations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Interets = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MembreId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credits_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MvtComptes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompteId = table.Column<int>(type: "int", nullable: false),
                    EstDebit = table.Column<bool>(type: "bit", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MvtComptes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MvtComptes_Comptes_CompteId",
                        column: x => x.CompteId,
                        principalTable: "Comptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MvtGabaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstDebit = table.Column<bool>(type: "bit", nullable: false),
                    EstFixe = table.Column<bool>(type: "bit", nullable: false),
                    Valeur = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompteId = table.Column<int>(type: "int", nullable: false),
                    GabarieId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MvtGabaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MvtGabaries_Comptes_CompteId",
                        column: x => x.CompteId,
                        principalTable: "Comptes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MvtGabaries_Gabaries_GabarieId",
                        column: x => x.GabarieId,
                        principalTable: "Gabaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MvtCotisations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembreId = table.Column<int>(type: "int", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstDebit = table.Column<bool>(type: "bit", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CotisationId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MvtCotisations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MvtCotisations_Cotisations_CotisationId",
                        column: x => x.CotisationId,
                        principalTable: "Cotisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MvtCotisations_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EcheanceCredits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEcheance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstPaye = table.Column<bool>(type: "bit", nullable: false),
                    CreditId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcheanceCredits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcheanceCredits_Credits_CreditId",
                        column: x => x.CreditId,
                        principalTable: "Credits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credits_MembreId",
                table: "Credits",
                column: "MembreId");

            migrationBuilder.CreateIndex(
                name: "IX_EcheanceCredits_CreditId",
                table: "EcheanceCredits",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtComptes_CompteId",
                table: "MvtComptes",
                column: "CompteId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtCotisations_CotisationId",
                table: "MvtCotisations",
                column: "CotisationId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtCotisations_MembreId",
                table: "MvtCotisations",
                column: "MembreId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtGabaries_CompteId",
                table: "MvtGabaries",
                column: "CompteId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtGabaries_GabarieId",
                table: "MvtGabaries",
                column: "GabarieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EcheanceCredits");

            migrationBuilder.DropTable(
                name: "MvtComptes");

            migrationBuilder.DropTable(
                name: "MvtCotisations");

            migrationBuilder.DropTable(
                name: "MvtGabaries");

            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.DropTable(
                name: "Cotisations");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Gabaries");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordKey",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedBy",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Sexes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedBy",
                table: "Sexes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Sexes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Services",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedBy",
                table: "Services",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Services",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Parametres",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedBy",
                table: "Parametres",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Parametres",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "Membres",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Membres",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Membres",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Membres",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedBy",
                table: "Membres",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Membres",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Membres",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Libelle",
                table: "Gabaries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Gabaries",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedBy",
                table: "Gabaries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Gabaries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Comptes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Libelle",
                table: "Comptes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Comptes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedBy",
                table: "Comptes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Comptes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Agences",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "LastUpdatedBy",
                table: "Agences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Agences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "MouvementMembres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembreId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    EstDebit = table.Column<bool>(type: "bit", nullable: true),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MouvementMembres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MouvementMembres_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompteId = table.Column<int>(type: "int", nullable: true),
                    GabarieId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    EstDebit = table.Column<bool>(type: "bit", nullable: true),
                    EstFixe = table.Column<bool>(type: "bit", nullable: true),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Valeur = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_Comptes_CompteId",
                        column: x => x.CompteId,
                        principalTable: "Comptes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Operations_Gabaries_GabarieId",
                        column: x => x.GabarieId,
                        principalTable: "Gabaries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MouvementComptables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompteId = table.Column<int>(type: "int", nullable: true),
                    MouvementMembreId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstDebit = table.Column<bool>(type: "bit", nullable: true),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MouvementComptables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MouvementComptables_Comptes_CompteId",
                        column: x => x.CompteId,
                        principalTable: "Comptes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MouvementComptables_MouvementMembres_MouvementMembreId",
                        column: x => x.MouvementMembreId,
                        principalTable: "MouvementMembres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MouvementComptables_CompteId",
                table: "MouvementComptables",
                column: "CompteId");

            migrationBuilder.CreateIndex(
                name: "IX_MouvementComptables_MouvementMembreId",
                table: "MouvementComptables",
                column: "MouvementMembreId");

            migrationBuilder.CreateIndex(
                name: "IX_MouvementMembres_MembreId",
                table: "MouvementMembres",
                column: "MembreId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_CompteId",
                table: "Operations",
                column: "CompteId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_GabarieId",
                table: "Operations",
                column: "GabarieId");
        }
    }
}
