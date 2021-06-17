using AddressManager.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressManager.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
