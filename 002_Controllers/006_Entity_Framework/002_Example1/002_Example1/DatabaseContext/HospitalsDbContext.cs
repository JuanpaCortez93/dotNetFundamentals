using _002_Example1.Models;
using Microsoft.EntityFrameworkCore;

namespace _002_Example1.DatabaseContext
{
    public class HospitalsDbContext : DbContext
    {
        public HospitalsDbContext(DbContextOptions<HospitalsDbContext> options) : base (options) { }

        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Visits> Visits { get; set; }
        public DbSet<Diagnostics> Diagnostics { get; set; }

    }
}
