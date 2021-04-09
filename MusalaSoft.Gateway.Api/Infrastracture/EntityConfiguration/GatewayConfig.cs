using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusalaSoft.GatewayApp.Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaSoft.GatewayApp.Api.Infrastracture.EntityConfiguration
{
    public class GatewayConfig : IEntityTypeConfiguration<Gateway>
    {
        public void Configure(EntityTypeBuilder<Gateway> builder)
        {
            builder.Property(c => c.SerialNumber).IsRequired().HasMaxLength(200);
            builder.HasIndex(c => c.SerialNumber).IsUnique();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
            builder.Property(c => c.IPV4).IsRequired().HasMaxLength(15);
            builder.HasMany(c => c.Devices).WithOne(c => c.Gateway).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
