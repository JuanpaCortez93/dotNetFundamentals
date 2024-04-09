using _003_Example2.Models;
using Microsoft.EntityFrameworkCore;

namespace _003_Example2.Context
{
    public class DoctorsContext : DbContext
    {
        public DoctorsContext(DbContextOptions<DoctorsContext> options) : base(options) { }
        public DbSet<Doctors> Doctors { get; set; }

    }
}
