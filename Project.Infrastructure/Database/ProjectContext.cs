using Microsoft.EntityFrameworkCore;
using Project.Domain.Entity;

namespace Project.Infrastructure.Database
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public ProjectContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var deviceTable = modelBuilder.Entity<Device>().ToContainer("device");
            deviceTable.HasNoDiscriminator();
            deviceTable.HasPartitionKey(device => device.SupplyNumber);
            deviceTable.Property(device => device.Id).HasConversion<string>().ToJsonProperty("id");
            deviceTable.HasKey(device => device.Id);
            deviceTable.Property(device => device.SupplyNumber).ToJsonProperty("supplyNumber");
            deviceTable.Property(device => device.Latitude).ToJsonProperty("latitude");
            deviceTable.Property(device => device.Longitude).ToJsonProperty("longitude");
            deviceTable.Property(device => device.UserName).ToJsonProperty("userName");
            deviceTable.Property(device => device.DistrictId).ToJsonProperty("districtId");
            deviceTable.Property(device => device.ZoneId).ToJsonProperty("zoneId");
            deviceTable.Property(device => device.IsActive).ToJsonProperty("isActive");
            deviceTable.Property(device => device.Type).ToJsonProperty("type");

            var consumeTable = modelBuilder.Entity<Consume>().ToContainer("consume");
            consumeTable.HasNoDiscriminator();
            consumeTable.HasPartitionKey(consume => consume.DeviceId);
            consumeTable.Property(consume => consume.Id).HasConversion<string>().ToJsonProperty("id");
            consumeTable.HasKey(consume => consume.Id);
            consumeTable.Property(consume => consume.DeviceId).HasConversion<string>().ToJsonProperty("deviceId");
            consumeTable.Property(consume => consume.UserName).ToJsonProperty("userName");
            consumeTable.Property(consume => consume.ZoneId).HasConversion<string>().ToJsonProperty("zoneId");
            consumeTable.Property(consume => consume.DistrictId).HasConversion<string>().ToJsonProperty("districtId");
            consumeTable.Property(consume => consume.Time).HasConversion<string>().ToJsonProperty("time");
            consumeTable.Property(consume => consume.TotalConsume).ToJsonProperty("totalConsume");
            consumeTable.Property(consume => consume.IsAnomalous).ToJsonProperty("isAnomalous");
            consumeTable.Property(consume => consume.IsAtHome).ToJsonProperty("isAtHome");
            consumeTable.Property(consume => consume.CreateTime).HasConversion<string>().ToJsonProperty("createTime");
            consumeTable.Property(consume => consume.UpdateTime).HasConversion<string>().ToJsonProperty("updateTime");
            consumeTable.Property(consume => consume.Value).HasColumnName("consume").ToJsonProperty("consume");

            var zoneTable = modelBuilder.Entity<Zone>().ToContainer("zone");
            zoneTable.HasNoDiscriminator();
            zoneTable.HasPartitionKey(zone => zone.Name);
            zoneTable.Property(zone => zone.Id).HasConversion<string>().ToJsonProperty("id");
            zoneTable.HasKey(zone => zone.Id);
            zoneTable.Property(zone => zone.Name).ToJsonProperty("name");
            zoneTable.OwnsMany(zone => zone.Districts,
                sa =>
                {
                    sa.ToJsonProperty("districts");
                    sa.Property(p => p.Id).ToJsonProperty("id");
                    sa.Property(p => p.Name).ToJsonProperty("name");
                });
        }
    }
}
