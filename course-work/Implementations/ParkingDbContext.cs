using Car.Parking.System.Models;
using Microsoft.EntityFrameworkCore;


namespace Car.Parking.System
{
    public class ParkingDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ParkingDbContext() { }

        public DbSet<CarModel> CarModel { get; set; }

        public DbSet<ParkingModel> Parking { get; set; }

        public DbSet<Part> Part { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured is false)
            {
                optionsBuilder.UseSqlServer("Server=FMI;Database=CarParking;Integrated Security=True;TrustServerCertificate=True;");
            }
        }
    }
}
