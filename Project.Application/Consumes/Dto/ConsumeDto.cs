using System;

namespace Project.Application.Consumes.Dto
{
    public class ConsumeDto
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public Guid ZoneId { get; set; }
        public Guid DistrictId { get; set; }
        public string UserName { get; set; }
        public DateTime Time { get; set; }
        public double TotalConsume { get; set; }
        public double Consume { get; set; }
        public int IsAnomalous { get; set; }
        public string IsAtHome { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
