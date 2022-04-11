using hspaApi2.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace hspaApi2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Agence>? Agences { get; set; } 
        public DbSet<Service>? Services { get; set; }
        public DbSet<Sexe>? Sexes { get; set; }
        public DbSet<Membre>? Membres { get; set; }
        public DbSet<User>? Users { get; set; }
    }
}