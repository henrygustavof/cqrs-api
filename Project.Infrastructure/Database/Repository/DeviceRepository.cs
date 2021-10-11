using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Entity;
using Project.Domain.Repository;
using Project.Infrastructure.Database.Utils;

namespace Project.Infrastructure.Database.Repository
{
    public class DeviceRepository : BaseRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ProjectContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Device>> GetAllByUserNameAsync(string userName)
        {
            return await Context.Set<Device>().AsAsyncEnumerable().Where(device => device.UserName == userName).ToListAsync();
        }

        public async Task<IEnumerable<Device>> GetAllByZoneIdAsync(Guid zoneId)
        {
          return  await Context.Set<Device>().AsAsyncEnumerable().Where(device => device.Id == zoneId).ToListAsync();
        }

        public async Task<IEnumerable<Device>> GetAllByZoneIdAndDistrictIdAsync(Guid zoneId, Guid districtId)
        {
            return await Context.Set<Device>()
                .WhereIf(zoneId != Guid.Empty, device => device.ZoneId == zoneId)
                .WhereIf(districtId != Guid.Empty, device => device.DistrictId == districtId).ToListAsync();
        }
    }
}