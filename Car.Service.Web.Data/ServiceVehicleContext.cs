using Car.Service.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Car.Service.Web.Data
{
    public class ServiceVehicleContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ServiceVehicleContext(DbContextOptions<ServiceVehicleContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<ServiceEntry> ServiceEntries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceEntry>().ToTable("ServiceEntry", "dbo");
            modelBuilder.Entity<User>().ToTable("User", "dbo");
            modelBuilder.Entity<City>().ToTable("City", "dbo");
        }
    }
}
