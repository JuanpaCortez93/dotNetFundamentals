using _004_Example3.Models;
using Microsoft.EntityFrameworkCore;

namespace _004_Example3.Context
{
    public class PatientsDatabaseContext : DbContext
    {

        public PatientsDatabaseContext(DbContextOptions<PatientsDatabaseContext> options) : base(options) { }

        public DbSet<Patients> Patients { get; set; }

    }
}
