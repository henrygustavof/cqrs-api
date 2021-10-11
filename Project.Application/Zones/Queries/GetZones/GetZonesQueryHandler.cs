using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Project.Application.Configuration.Queries;
using Project.Application.Zones.Dto;
using Project.Application.Zones.Services;

namespace Project.Application.Zones.Queries.GetZones
{
    public class GetZonesQueryHandler : IQueryHandler<GetZonesQuery, List<ZoneDto>>
    {
        private readonly IZoneService _zoneService;
        public GetZonesQueryHandler(IZoneService zoneService)
        {
            _zoneService = zoneService;
        }

        public async Task<List<ZoneDto>> Handle(GetZonesQuery request, CancellationToken cancellationToken)
        {
            return await _zoneService.GetAllAsync();
        }
    }
}
