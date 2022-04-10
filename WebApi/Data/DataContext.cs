using hspaApi2.Models;
using Microsoft.EntityFrameworkCore;

namespace hspaApi2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Agence>? Agences { get; set; } 
        public DbSet<User>? Users { get; set; }
        
        
    }
}