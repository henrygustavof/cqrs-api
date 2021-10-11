using System;
using System.Collections.Generic;
using Project.Application.Configuration.Queries;
using Project.Application.Consumes.Dto;

namespace Project.Application.Consumes.Queries.GetConsumes
{
    public class GetConsumesInDevicesByDistrictQuery : IQuery<List<ConsumeDeviceDto>>
    {
        public Guid ZoneId { get; set; }
        public Guid DistrictId { get; set; }
    }
}