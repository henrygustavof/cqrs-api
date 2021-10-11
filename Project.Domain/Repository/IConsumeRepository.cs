using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Domain.Entity;
using Project.Domain.Filters;

namespace Project.Domain.Repository
{
    public interface IConsumeRepository : IRepository<Consume>
    {
        Task<IEnumerable<Consume>> GetAllByDeviceIdAsync(Guid deviceId, string startDate="", string endDate="");
        Task<IEnumerable<Consume>> GetAllByZoneIdAsync(Guid zoneId);
        Task<IEnumerable<Consume>> GetAllByFilterParametersAsync(ConsumeFilterParameters consumeFilterParameters);
    }
}
