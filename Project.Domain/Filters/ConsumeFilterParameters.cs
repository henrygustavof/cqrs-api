using System;

namespace Project.Domain.Filters
{
    public class ConsumeFilterParameters
    {
        public Guid ZoneId { get; set; }
        public Guid DistrictId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string UserName { get; set; }
    }
}
