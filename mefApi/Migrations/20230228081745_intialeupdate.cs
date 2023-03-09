using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hspaApi2.Migrations
{
    public partial class intialeupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembreId = table.Column<int>(type: "int", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NombreEcheances = table.Column<int>(type: "int", nullable: false),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompteComptables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Compte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompteComptables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembreId = table.Column<int>(type: "int", nullable: false),
                    MontantCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontantInteret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NombreEcheances = table.Column<int>(type: "int", nullable: false),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EcheanceAvances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvanceId = table.Column<int>(type: "int", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcheanceAvances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EcheanceCredits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditId = table.Column<int>(type: "int", nullable: false),
                    MontantCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontantInteret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcheanceCredits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gabarits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeMouvement = table.Column<int>(type: "int", nullable: false),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gabarits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LieuAffectations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LieuAffectations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompteComptableId = table.Column<int>(type: "int", nullable: false),
                    GabaritId = table.Column<int>(type: "int", nullable: false),
                    TypeOperation = table.Column<int>(type: "int", nullable: false),
                    Taux = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Postes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sexes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Membres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonnelId = table.Column<int>(type: "int", nullable: false),
                    EstActif = table.Column<bool>(type: "bit", nullable: false),
                    SexeId = table.Column<int>(type: "int", nullable: false),
                    LieuAffectationId = table.Column<int>(type: "int", nullable: false),
                    PosteId = table.Column<int>(type: "int", nullable: false),
                    DateNaissance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdhesion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LieuNaissance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membres_LieuAffectations_LieuAffectationId",
                        column: x => x.LieuAffectationId,
                        principalTable: "LieuAffectations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membres_Postes_PosteId",
                        column: x => x.PosteId,
                        principalTable: "Postes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membres_Sexes_SexeId",
                        column: x => x.SexeId,
                        principalTable: "Sexes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cotisations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembreId = table.Column<int>(type: "int", nullable: false),
                    Mois = table.Column<int>(type: "int", nullable: false),
                    Annee = table.Column<int>(type: "int", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotisations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cotisations_Membres_MembreId",
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
                    DateMvt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MembreId = table.Column<int>(type: "int", nullable: false),
                    TypeOperation = table.Column<int>(type: "int", nullable: false),
                    GabaritId = table.Column<int>(type: "int", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvanceId = table.Column<int>(type: "int", nullable: true),
                    CotisationId = table.Column<int>(type: "int", nullable: true),
                    CreditId = table.Column<int>(type: "int", nullable: true),
                    EcheanceAvanceId = table.Column<int>(type: "int", nullable: true),
                    EcheanceCreditId = table.Column<int>(type: "int", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MvtComptes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MvtComptes_Avances_AvanceId",
                        column: x => x.AvanceId,
                        principalTable: "Avances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MvtComptes_Cotisations_CotisationId",
                        column: x => x.CotisationId,
                        principalTable: "Cotisations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MvtComptes_Credits_CreditId",
                        column: x => x.CreditId,
                        principalTable: "Credits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MvtComptes_EcheanceAvances_EcheanceAvanceId",
                        column: x => x.EcheanceAvanceId,
                        principalTable: "EcheanceAvances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MvtComptes_EcheanceCredits_EcheanceCreditId",
                        column: x => x.EcheanceCreditId,
                        principalTable: "EcheanceCredits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MvtComptes_Gabarits_GabaritId",
                        column: x => x.GabaritId,
                        principalTable: "Gabarits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MvtComptes_Membres_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EcritureComptables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GabaritId = table.Column<int>(type: "int", nullable: false),
                    MvtCompteId = table.Column<int>(type: "int", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcritureComptables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcritureComptables_Gabarits_GabaritId",
                        column: x => x.GabaritId,
                        principalTable: "Gabarits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EcritureComptables_MvtComptes_MvtCompteId",
                        column: x => x.MvtCompteId,
                        principalTable: "MvtComptes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DetailEcritureComptables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompteComptableId = table.Column<int>(type: "int", nullable: true),
                    TypeOperation = table.Column<int>(type: "int", nullable: false),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EcritureComptableId = table.Column<int>(type: "int", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiePar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailEcritureComptables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailEcritureComptables_CompteComptables_CompteComptableId",
                        column: x => x.CompteComptableId,
                        principalTable: "CompteComptables",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetailEcritureComptables_EcritureComptables_EcritureComptableId",
                        column: x => x.EcritureComptableId,
                        principalTable: "EcritureComptables",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cotisations_MembreId",
                table: "Cotisations",
                column: "MembreId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailEcritureComptables_CompteComptableId",
                table: "DetailEcritureComptables",
                column: "CompteComptableId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailEcritureComptables_EcritureComptableId",
                table: "DetailEcritureComptables",
                column: "EcritureComptableId");

            migrationBuilder.CreateIndex(
                name: "IX_EcritureComptables_GabaritId",
                table: "EcritureComptables",
                column: "GabaritId");

            migrationBuilder.CreateIndex(
                name: "IX_EcritureComptables_MvtCompteId",
                table: "EcritureComptables",
                column: "MvtCompteId");

            migrationBuilder.CreateIndex(
                name: "IX_Membres_LieuAffectationId",
                table: "Membres",
                column: "LieuAffectationId");

            migrationBuilder.CreateIndex(
                name: "IX_Membres_PosteId",
                table: "Membres",
                column: "PosteId");

            migrationBuilder.CreateIndex(
                name: "IX_Membres_SexeId",
                table: "Membres",
                column: "SexeId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtComptes_AvanceId",
                table: "MvtComptes",
                column: "AvanceId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtComptes_CotisationId",
                table: "MvtComptes",
                column: "CotisationId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtComptes_CreditId",
                table: "MvtComptes",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtComptes_EcheanceAvanceId",
                table: "MvtComptes",
                column: "EcheanceAvanceId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtComptes_EcheanceCreditId",
                table: "MvtComptes",
                column: "EcheanceCreditId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtComptes_GabaritId",
                table: "MvtComptes",
                column: "GabaritId");

            migrationBuilder.CreateIndex(
                name: "IX_MvtComptes_MembreId",
                table: "MvtComptes",
                column: "MembreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailEcritureComptables");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "CompteComptables");

            migrationBuilder.DropTable(
                name: "EcritureComptables");

            migrationBuilder.DropTable(
                name: "MvtComptes");

            migrationBuilder.DropTable(
                name: "Avances");

            migrationBuilder.DropTable(
                name: "Cotisations");

            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.DropTable(
                name: "EcheanceAvances");

            migrationBuilder.DropTable(
                name: "EcheanceCredits");

            migrationBuilder.DropTable(
                name: "Gabarits");

            migrationBuilder.DropTable(
                name: "Membres");

            migrationBuilder.DropTable(
                name: "LieuAffectations");

            migrationBuilder.DropTable(
                name: "Postes");

            migrationBuilder.DropTable(
                name: "Sexes");
        }
    }
}
