using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Entity;
using Project.Domain.Repository;

namespace Project.Infrastructure.Database.Repository
{
    public class ZoneRepository : BaseRepository<Zone>, IZoneRepository
    {
        public ZoneRepository(ProjectContext context) : base(context)
        {
        }

        public async Task<IEnumerable<District>> GetDistrictsByZoneIdAsync(Guid zoneId)
        {
          var zone = await Context.Set<Zone>().FirstOrDefaultAsync(zone => zone.Id == zoneId);

          return zone == null ? new List<District>() : zone.Districts;
        }
    }
}
