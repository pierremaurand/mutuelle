using mefapi.Enums;
using mefApi.Models;
using Microsoft.EntityFrameworkCore;

namespace mefApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Utilisateur>? Utilisateurs { get; set; }   
        public DbSet<Membre>? Membres { get; set; }
         
        public DbSet<Avance>? Avances { get; set; }
        public DbSet<Credit>? Credits { get; set; } 
        public DbSet<Deboursement>? Deboursements { get; set; } 
        public DbSet<Echeance>? Echeances { get; set; } 
        public DbSet<Cotisation>? Cotisations { get; set; } 
        public DbSet<Mouvement>? Mouvements { get; set; }

        public DbSet<CompteComptable>? CompteComptables { get; set; } 
        public DbSet<EcritureComptable>? EcritureComptables { get; set; } 
        public DbSet<DetailEcritureComptable>? DetailEcritureComptables { get; set; } 

        public DbSet<Gabarit>? Gabarits { get; set; } 
        public DbSet<Agence>? Agences { get; set; }  
        public DbSet<Operation>? Operations { get; set; }  
        public DbSet<Poste>? Postes { get; set; }            
    }
}