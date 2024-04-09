using _004_Example4_Refactorizacion.Model;
using Microsoft.EntityFrameworkCore;

namespace _004_Example4_Refactorizacion.DatabaseContext
{
    public class EShopDbContext : DbContext
    {
        public EShopDbContext(DbContextOptions<EShopDbContext> options) : base(options) { }

        public DbSet<Clients> Clients { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
