using Microsoft.EntityFrameworkCore;

namespace EruMobileScooter.Data
{
    public class ApplicationContext: DbContext{

        public DbSet<ActiveScooter> ActiveScooters {get; set;}
        public DbSet<EnergyGenerator> EnergyGenerators { get; set; }
        public DbSet<EnergyStation> EnergyStations { get; set; }
        public DbSet<Scooter> Scooters { get; set; }
        public DbSet<ScooterTransportHistory> ScooterTransportHistories { get; set; }
        public DbSet<ScooterStation> ScooterStations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }

     
     public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
     

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        //TODO: Tablolari Ozellestır.
        base.OnModelCreating(modelBuilder);
        }

    }
}