using System;

namespace Project.Application.Zones.Dto
{
    public class DistrictDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public  Guid ZoneId { get; set; }
    }
}
