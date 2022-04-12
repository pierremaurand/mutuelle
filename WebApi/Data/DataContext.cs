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
        public DbSet<User>? Users { get; set; }
    }
}