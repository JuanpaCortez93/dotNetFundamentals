using _004_Example5_Complete.Models;
using Microsoft.EntityFrameworkCore;

namespace _004_Example5_Complete.SchoolDbContext
{
    public class SchoolDbContext : DbContext
    {

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        public DbSet<Students> Students { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Teachers> Teachers { get; set; }

    }
}
