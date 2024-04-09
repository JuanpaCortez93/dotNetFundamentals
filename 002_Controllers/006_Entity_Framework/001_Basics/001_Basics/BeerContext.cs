using _001_Basics.Models;
using Microsoft.EntityFrameworkCore;

namespace _001_Basics
{
    public class BeerContext : DbContext
    {

        public BeerContext(DbContextOptions<BeerContext> options) : base (options)
        {

        }


        public DbSet<BeerBrands> BeerBrands { get; set; }
        public DbSet<BeerModels> BeerModels { get; set; }



    }
}
