using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Entity;
using Project.Domain.Filters;
using Project.Domain.Repository;
using Project.Infrastructure.Database.Utils;

namespace Project.Infrastructure.Database.Repository
{
    public class ConsumeRepository : BaseRepository<Consume>, IConsumeRepository
    {
        public ConsumeRepository(ProjectContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Consume>> GetAllByDeviceIdAsync(Guid deviceId, string startDate = "",
            string endDate = "")
        {
            return await Context.Set<Consume>().WithPartitionKey(deviceId.ToString())
                .WhereIf(!string.IsNullOrEmpty(startDate) &&
                         !string.IsNullOrEmpty(endDate),
                    consume => consume.Time >= DateTime.Parse(startDate) &&
                               consume.Time <= DateTime.Parse(endDate))
                .ToListAsync();
        }

        public async Task<IEnumerable<Consume>> GetAllByZoneIdAsync(Guid zoneId)
        {
            return await Context.Set<Consume>().AsAsyncEnumerable().Where(consume => consume.ZoneId == zoneId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Consume>> GetAllByFilterParametersAsync(
            ConsumeFilterParameters consumeFilterParameters)
        {
            return await Context.Set<Consume>()
                .WhereIf(
                    consumeFilterParameters.ZoneId != Guid.Empty && consumeFilterParameters.DistrictId != Guid.Empty,
                    consume => consume.ZoneId == consumeFilterParameters.ZoneId &&
                               consume.DistrictId == consumeFilterParameters.DistrictId)
                .WhereIf(
                    !string.IsNullOrEmpty(consumeFilterParameters.StartDate) &&
                    !string.IsNullOrEmpty(consumeFilterParameters.EndDate),
                    consume => consume.Time >= DateTime.Parse(consumeFilterParameters.StartDate) &&
                               consume.Time <= DateTime.Parse(consumeFilterParameters.EndDate))
                .WhereIf(!string.IsNullOrEmpty(consumeFilterParameters.UserName),
                    consume => consume.UserName == consumeFilterParameters.UserName)
                .ToListAsync();
        }
    }
}
