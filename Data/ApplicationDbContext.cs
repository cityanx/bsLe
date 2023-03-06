using bs.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace bs.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Location>? Locations { get; set; }
        public DbSet<Agency>? Agencies { get; set; }
        public DbSet<Uninterruptible>? Uninterruptibles { get; set; }
        public DbSet<BatteryChange>? BatteryChanges { get; set; }

    }
}