using Microsoft.EntityFrameworkCore;
using MusalaSoft.GatewayApp.Api.Core.Models;
using MusalaSoft.GatewayApp.Api.Infrastracture.EntityConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaSoft.GatewayApp.Api.Infrastracture.Shared
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DeviceConfig());
            modelBuilder.ApplyConfiguration(new GatewayConfig());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Gateway> Gateways { get; set; }
    }
}
