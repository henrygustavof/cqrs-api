using System.Collections.Generic;
using Project.Application.Configuration.Queries;
using Project.Application.Zones.Dto;

namespace Project.Application.Zones.Queries.GetZones
{
    public class GetZonesQuery : IQuery<List<ZoneDto>>
    {
        public string UserName { get; set; }
    }
}
