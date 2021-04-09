using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusalaSoft.GatewayApp.Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaSoft.GatewayApp.Api.Infrastracture.EntityConfiguration
{
    public class DeviceConfig : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasKey(c => c.Uid);
            builder.Property(c => c.Vendor).IsRequired();
            builder.Property(c => c.Date).HasDefaultValueSql("getdate()");
        }
    }
}
