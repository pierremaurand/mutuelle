using Microsoft.EntityFrameworkCore;
using mefApi.Models;

namespace mefApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Sexe>? Sexes { get; set; }
        public DbSet<Poste>? Postes { get; set; }  
        public DbSet<LieuAffectation>? LieuAffectations { get; set; } 
        public DbSet<Membre>? Membres { get; set; }
        public DbSet<CompteComptable>? CompteComptables { get; set; }  
        public DbSet<Gabarit>? Gabarits { get; set; }  
        public DbSet<Operation>? Operations { get; set; }  
        public DbSet<Compte>? Comptes { get; set; }  
        public DbSet<MvtCompte>? MvtComptes { get; set; } 
         
    }
}