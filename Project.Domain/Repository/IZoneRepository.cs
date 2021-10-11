using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Domain.Entity;

namespace Project.Domain.Repository
{
    public interface IZoneRepository : IRepository<Zone>
    {
        Task<IEnumerable<District>> GetDistrictsByZoneIdAsync(Guid zoneId);
    }
}
