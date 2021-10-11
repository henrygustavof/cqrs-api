using System;
using System.Collections.Generic;
using Project.Application.Configuration.Queries;
using Project.Application.Consumes.Dto;

namespace Project.Application.Consumes.Queries.GetConsumes
{
    public class GetConsumesInDistrictsByZoneQuery : IQuery<List<ConsumeDistrictDto>>
    {
        public Guid ZoneId { get; set; }

    }
}
