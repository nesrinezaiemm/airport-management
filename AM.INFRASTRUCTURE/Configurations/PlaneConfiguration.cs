using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.INFRASTRUCTURE.Configurations { 
public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
{
    public void Configure(EntityTypeBuilder<Plane> builder)
        {
        builder.HasKey(p => p.PlaneId); // to define primary key 
        builder.ToTable("MyPlanes"); //to change table name in db
        builder.Property(p => p.capacity).HasColumnName("PlaneCapacity"); //change column name
    }
}
}