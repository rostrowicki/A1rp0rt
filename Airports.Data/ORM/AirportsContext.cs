using Airports.Data.DO;
using Microsoft.EntityFrameworkCore;

namespace Airports.Data.ORM
{
    public class AirportsContext : DbContext
    {
        public DbSet<Airport> Airports {get; set;}    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=Airports;Trusted_Connection=True;MultipleActiveResultSets=true");            
        }
    }
}