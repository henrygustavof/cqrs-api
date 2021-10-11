using System;

namespace Project.Domain.Entity
{
    public class Consume
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public Guid ZoneId { get; set; }
        public Guid DistrictId { get; set; }
        public string UserName { get; set; }
        public DateTime Time { get; set; }
        public double TotalConsume { get; set; }
        public double Value { get; set; }
        public int IsAnomalous { get; set; }
        public string IsAtHome { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
