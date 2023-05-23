using mefApi.Models;
using Microsoft.EntityFrameworkCore;

namespace mefApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Avance>? Avances { get; set; }
        public DbSet<AvanceDebourse>? AvancesDebourses { get; set; }
        public DbSet<MvtAvanceDebourse>? MvtAvancesDebourses { get; set; }
        public DbSet<CompteComptable>? CompteComptables { get; set; } 
        public DbSet<Cotisation>? Cotisations { get; set; } 
        public DbSet<MvtCotisation>? MvtCotisations { get; set; } 
        public DbSet<Credit>? Credits { get; set; } 
        public DbSet<CreditDebourse>? CreditsDebourses { get; set; } 
        public DbSet<MvtCreditDebourse>? MvtCreditsDebourses { get; set; } 
        public DbSet<DetailEcritureComptable>? DetailEcritureComptables { get; set; } 
        public DbSet<EcheanceAvance>? EcheancesAvances { get; set; } 
        public DbSet<MvtEcheanceAvance>? MvtEcheancesAvances { get; set; } 
        public DbSet<EcheanceCredit>? EcheancesCredits { get; set; } 
        public DbSet<MvtEcheanceCredit>? MvtEcheancesCredits { get; set; } 
        public DbSet<EcritureComptable>? EcritureComptables { get; set; } 
        public DbSet<Gabarit>? Gabarits { get; set; } 
        public DbSet<LieuAffectation>? LieuAffectations { get; set; }  
        public DbSet<Membre>? Membres { get; set; }
        public DbSet<MvtCompte>? MvtComptes { get; set; } 
        public DbSet<Operation>? Operations { get; set; }  
        public DbSet<Poste>? Postes { get; set; } 
        public DbSet<Sexe>? Sexes { get; set; }      
        public DbSet<Mois>? Mois { get; set; }      
        public DbSet<Utilisateur>? Utilisateurs { get; set; }      
        public DbSet<Mouvement>? Mouvements { get; set; }      
    }
}