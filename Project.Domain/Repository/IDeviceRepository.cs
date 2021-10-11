using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Domain.Entity;

namespace Project.Domain.Repository
{
    public interface IDeviceRepository : IRepository<Device>
    {
        Task<IEnumerable<Device>> GetAllByZoneIdAsync(Guid zoneId);
        Task<IEnumerable<Device>> GetAllByZoneIdAndDistrictIdAsync(Guid zoneId, Guid districtId);
        Task<IEnumerable<Device>> GetAllByUserNameAsync(string userName);
    }
}
