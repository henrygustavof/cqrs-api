using System;
using System.Collections.Generic;
using Project.Application.Configuration.Queries;
using Project.Application.Consumes.Dto;

namespace Project.Application.Consumes.Queries.GetConsumes
{
    public class GetConsumesByUsersQuery: IQuery<List<ConsumeUserDto>>
    {
        public Guid ZoneId { get; set; }
        public Guid DistrictId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string DocNumber { get; set; }
    }
}
