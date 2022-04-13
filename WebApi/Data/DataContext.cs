using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Agence>? Agences { get; set; } 
        public DbSet<Service>? Services { get; set; }
        public DbSet<Sexe>? Sexes { get; set; }
        public DbSet<Membre>? Membres { get; set; }
        public DbSet<Parametre>? Parametres { get; set; }
        public DbSet<Compte>? Comptes { get; set; }
        public DbSet<Gabarie>? Gabaries { get; set; }
        public DbSet<Cotisation>? Cotisations { get; set; }
        public DbSet<Credit>? Credits { get; set; }
        public DbSet<Avance>? Avances { get; set; }
        public DbSet<MvtCompte>? MvtComptes { get; set; }
        public DbSet<DemandeAvance>? DemandeAvances { get; set; }
        public DbSet<DemandeCredit>? DemandeCredits { get; set; }
        public DbSet<Adhesion>? Adhesions { get; set; }
        public DbSet<User>? Users { get; set; }
    }
}