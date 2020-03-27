using Microsoft.EntityFrameworkCore;
using System;

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

     
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
             this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder){
        //TODO: Tablolari Ozellestır.
            base.OnModelCreating(modelBuilder);
           // ConfigureTables(modelBuilder);
        }

        private void ConfigureTables(ModelBuilder modelBuilder)
        {
            UserTable(modelBuilder);
            ActiveScooterTable(modelBuilder);
            EnergyGeneratorsTable(modelBuilder);
            EnergyStationsTable(modelBuilder);
            ScooterTable(modelBuilder);
            ScooterTransportsTableTable(modelBuilder);
            ScooterStationsTable(modelBuilder);
            PaymentsTable(modelBuilder);
        }

        private void UserTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(s => s.Id).HasName("id");
                u.ToTable("users");
            });
        }

        private void ActiveScooterTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActiveScooter>(u =>
            {
                u.HasKey(s => s.Id).HasName("id");
                u.ToTable("active_scooters");
            });
        }

        private void EnergyGeneratorsTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnergyGenerator>(u =>
            {
                u.HasKey(s => s.Id).HasName("id");
                u.ToTable("energy_generators");
            });
        }
        private void EnergyStationsTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnergyStation>(u =>
            {
                u.HasKey(s => s.Id).HasName("id");
                u.ToTable("energy_stations");
            });
        }
        private void ScooterTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scooter>(u =>
            {
                u.HasKey(s => s.Id).HasName("id");
                u.ToTable("scooters");
            });
        }
        private void ScooterTransportsTableTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScooterTransportHistory>(u =>
            {
                u.HasKey(s => s.Id).HasName("id");
                u.ToTable("scooter_transport_histories");
            });
        }

        private void ScooterStationsTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScooterStation>(u =>
            {
                u.HasKey(s => s.Id).HasName("id");
                u.ToTable("scooter_stations");
            });
        }
        private void PaymentsTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>(u =>
            {
                u.HasKey(s => s.Id).HasName("id");
                u.ToTable("payments");
            });
        }
    }
}