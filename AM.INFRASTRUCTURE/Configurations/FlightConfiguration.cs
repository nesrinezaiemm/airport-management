using AM.APPCORE.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.INFRASTRUCTURE.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasMany(f => f.passengers)
                .WithMany(p => p.flights)
                .UsingEntity(j => j.ToTable("MyReservations"));
            builder.HasOne(f => f.plane)
                .WithMany(p => p.flights);
            // .HasForeignKey(f => f.planeFk)
            // .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
