using Microsoft.EntityFrameworkCore;
using RASS_System.Models;

namespace RASS_System.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
            : base(contextOptions)
        {

        }

        // Code first approach
        public DbSet<accidentData> accidentDatas { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Police> Polices { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }            
        public DbSet<Driver> Drivers { get; set; }
        
    }
}
