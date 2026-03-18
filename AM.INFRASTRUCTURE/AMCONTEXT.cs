using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AM.APPCORE.domain;
using AM.ApplicationCore.Domain;
using AM.INFRASTRUCTURE.Configurations;
using Microsoft.EntityFrameworkCore;
using Plane = AM.ApplicationCore.Domain.Plane;
namespace AM.INFRASTRUCTURE
{
    public class AMCONTEXT : DbContext 
    {
        //les classes:dbset
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Plane> Planes { get; set; }
       
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;

        Initial Catalog=AirportMangment;

        Integrated Security=true;MultipleActiveResultSets=true");
        }
   
           // Fluent API configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            //config TPH (descriminator)
            /*modelBuilder.Entity<Passenger>()
                 .HasDiscriminator<int>("PassengerType")
                 .HasValue<Staff>(1)
                 .HasValue<Traveller>(2)
                 .HasValue<Passenger>(0);*/

            //config table par type (tpt) apply 1 only approach tpt OR thp

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Staff>()
                .ToTable("Staffs");

            modelBuilder.Entity<Traveller>()
                .ToTable("Travellers");

            modelBuilder.Entity<Ticket>().HasKey(t => new { t.PassengerFK, t.FlightFK });


        }
    
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // All DateTime 
            configurationBuilder.Properties<DateTime>()
                                .HaveColumnType("date");
        }

    }
}
