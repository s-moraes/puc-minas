using Microsoft.EntityFrameworkCore;
using DepositoService.Models;

namespace DepositoService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base (options)
        {
            
        }

        public DbSet<Envio> Envios {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<Deposito> Depositos {get; set;}
        public DbSet<User> User {get; set;}
    }
}