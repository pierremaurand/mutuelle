﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mefApi.Data;

#nullable disable

namespace hspaApi2.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230228081745_intialeupdate")]
    partial class intialeupdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("mefApi.Models.Avance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("MembreId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifieLe")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiePar")
                        .HasColumnType("int");

                    b.Property<decimal?>("Montant")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("NombreEcheances")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Avances");
                });

            modelBuilder.Entity("mefApi.Models.CompteComptable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Compte")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifieLe")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiePar")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CompteComptables");
                });

            modelBuilder.Entity("mefApi.Models.Cotisation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Annee")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("MembreId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifieLe")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiePar")
                        .HasColumnType("int");

                    b.Property<int>("Mois")
                        .HasColumnType("int");

                    b.Property<decimal?>("Montant")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MembreId");

                    b.ToTable("Cotisations");
                });

            modelBuilder.Entity("mefApi.Models.Credit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("MembreId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifieLe")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiePar")
                        .HasColumnType("int");

                    b.Property<decimal?>("MontantCapital")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MontantInteret")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("NombreEcheances")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Credits");
                });

            modelBuilder.Entity("mefApi.Models.DetailEcritureComptable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CompteComptableId")
                        .HasColumnType("int");

                    b.Property<int?>("EcritureComptableId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifieLe")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiePar")
                        .HasColumnType("int");

                    b.Property<decimal?>("Montant")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TypeOperation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompteComptableId");

                    b.HasIndex("EcritureComptableId");

                    b.ToTable("DetailEcritureComptables");
                });

            modelBuilder.Entity("mefApi.Models.EcheanceAvance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AvanceId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifieLe")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiePar")
                        .HasColumnType("int");

                    b.Property<decimal?>("Montant")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("EcheanceAvances");
                });

            modelBuilder.Entity("mefApi.Models.EcheanceCredit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreditId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifieLe")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiePar")
                        .HasColumnType("int");

                    b.Property<decimal?>("MontantCapital")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("MontantInteret")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("EcheanceCredits");
                });

            modelBuilder.Entity("mefApi.Models.EcritureComptable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("GabaritId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifieLe")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiePar")
                        .HasColumnType("int");

                    b.Property<decimal?>("Montant")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("MvtCompteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GabaritId");

                    b.HasIndex("MvtCompteId");

                    b.ToTable("EcritureComptables");
                });

            modelBuilder.Entity("mefApi.Models.Gabarit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifieLe")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiePar")
                        .HasColumnType("int");

                    b.Property<int>("TypeMouvement")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Gabarits");
                });

            modelBuilder.Entity("mefApi.Models.LieuAffectation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Lieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifieLe")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiePar")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LieuAffectations");
                });

            modelBuilder.Entity("mefApi.Models.Membre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateAdhesion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateNaissance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstActif")
                        .HasColumnType("bit");

                    b.Property<int>("LieuAffectationId")
                        .HasColumnType("int");

                    b.Property<string>("LieuNaissance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifieLe")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiePar")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonnelId")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PosteId")
                        .HasColumnType("int");

                    b.Property<int>("SexeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LieuAffectationId");

                    b.HasIndex("PosteId");

                    b.HasIndex("SexeId");

                    b.ToTable("Membres");
                });

            modelBuilder.Entity("mefApi.Models.MvtCompte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AvanceId")
                        .HasColumnType("int");

                    b.Property<int?>("CotisationId")
                        .HasColumnType("int");

                    b.Property<int?>("CreditId")
                        .HasColumnType("int");

                    b.Property<string>("DateMvt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EcheanceAvanceId")
                        .HasColumnType("int");

                    b.Property<int?>("EcheanceCreditId")
                        .HasColumnType("int");

                    b.Property<int>("GabaritId")
                        .HasColumnType("int");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MembreId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifieLe")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiePar")
                        .HasColumnType("int");

                    b.Property<decimal>("Montant")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TypeOperation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AvanceId");

                    b.HasIndex("CotisationId");

                    b.HasIndex("CreditId");

                    b.HasIndex("EcheanceAvanceId");

                    b.HasIndex("EcheanceCreditId");

                    b.HasIndex("GabaritId");

                    b.HasIndex("MembreId");

                    b.ToTable("MvtComptes");
                });

            modelBuilder.Entity("mefApi.Models.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompteComptableId")
                        .HasColumnType("int");

                    b.Property<int>("GabaritId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifieLe")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiePar")
                        .HasColumnType("int");

                    b.Property<decimal>("Taux")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TypeOperation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("mefApi.Models.Poste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifieLe")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiePar")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Postes");
                });

            modelBuilder.Entity("mefApi.Models.Sexe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ModifieLe")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiePar")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sexes");
                });

            modelBuilder.Entity("mefApi.Models.Cotisation", b =>
                {
                    b.HasOne("mefApi.Models.Membre", "Membre")
                        .WithMany()
                        .HasForeignKey("MembreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Membre");
                });

            modelBuilder.Entity("mefApi.Models.DetailEcritureComptable", b =>
                {
                    b.HasOne("mefApi.Models.CompteComptable", "CompteComptable")
                        .WithMany("DetailEcritureComptables")
                        .HasForeignKey("CompteComptableId");

                    b.HasOne("mefApi.Models.EcritureComptable", null)
                        .WithMany("DetailEcritureComptables")
                        .HasForeignKey("EcritureComptableId");

                    b.Navigation("CompteComptable");
                });

            modelBuilder.Entity("mefApi.Models.EcritureComptable", b =>
                {
                    b.HasOne("mefApi.Models.Gabarit", "Gabarit")
                        .WithMany()
                        .HasForeignKey("GabaritId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mefApi.Models.MvtCompte", null)
                        .WithMany("EcritureComptable")
                        .HasForeignKey("MvtCompteId");

                    b.Navigation("Gabarit");
                });

            modelBuilder.Entity("mefApi.Models.Membre", b =>
                {
                    b.HasOne("mefApi.Models.LieuAffectation", "LieuAffectation")
                        .WithMany()
                        .HasForeignKey("LieuAffectationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mefApi.Models.Poste", "Poste")
                        .WithMany()
                        .HasForeignKey("PosteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mefApi.Models.Sexe", "Sexe")
                        .WithMany()
                        .HasForeignKey("SexeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LieuAffectation");

                    b.Navigation("Poste");

                    b.Navigation("Sexe");
                });

            modelBuilder.Entity("mefApi.Models.MvtCompte", b =>
                {
                    b.HasOne("mefApi.Models.Avance", null)
                        .WithMany("MvtComptes")
                        .HasForeignKey("AvanceId");

                    b.HasOne("mefApi.Models.Cotisation", null)
                        .WithMany("MvtComptes")
                        .HasForeignKey("CotisationId");

                    b.HasOne("mefApi.Models.Credit", null)
                        .WithMany("MvtComptes")
                        .HasForeignKey("CreditId");

                    b.HasOne("mefApi.Models.EcheanceAvance", null)
                        .WithMany("MvtComptes")
                        .HasForeignKey("EcheanceAvanceId");

                    b.HasOne("mefApi.Models.EcheanceCredit", null)
                        .WithMany("MvtComptes")
                        .HasForeignKey("EcheanceCreditId");

                    b.HasOne("mefApi.Models.Gabarit", "Gabarit")
                        .WithMany()
                        .HasForeignKey("GabaritId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mefApi.Models.Membre", "Membre")
                        .WithMany("MvtComptes")
                        .HasForeignKey("MembreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gabarit");

                    b.Navigation("Membre");
                });

            modelBuilder.Entity("mefApi.Models.Avance", b =>
                {
                    b.Navigation("MvtComptes");
                });

            modelBuilder.Entity("mefApi.Models.CompteComptable", b =>
                {
                    b.Navigation("DetailEcritureComptables");
                });

            modelBuilder.Entity("mefApi.Models.Cotisation", b =>
                {
                    b.Navigation("MvtComptes");
                });

            modelBuilder.Entity("mefApi.Models.Credit", b =>
                {
                    b.Navigation("MvtComptes");
                });

            modelBuilder.Entity("mefApi.Models.EcheanceAvance", b =>
                {
                    b.Navigation("MvtComptes");
                });

            modelBuilder.Entity("mefApi.Models.EcheanceCredit", b =>
                {
                    b.Navigation("MvtComptes");
                });

            modelBuilder.Entity("mefApi.Models.EcritureComptable", b =>
                {
                    b.Navigation("DetailEcritureComptables");
                });

            modelBuilder.Entity("mefApi.Models.Membre", b =>
                {
                    b.Navigation("MvtComptes");
                });

            modelBuilder.Entity("mefApi.Models.MvtCompte", b =>
                {
                    b.Navigation("EcritureComptable");
                });
#pragma warning restore 612, 618
        }
    }
}