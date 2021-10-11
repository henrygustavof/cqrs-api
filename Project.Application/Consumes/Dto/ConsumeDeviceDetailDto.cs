using System;
using System.Collections.Generic;

namespace Project.Application.Consumes.Dto
{
    public class ConsumeDeviceDetailDto
    {
        public Guid DeviceId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string DocNumber { get; set; }
        public string SupplyNumber { get; set; }
        public List<ConsumeDeviceHourlyDto> ConsumePerHours { get; set; }
    }

    public class ConsumeDeviceHourlyDto
    {
        public DateTime DateTime { get; set; }
       public double Consume { get; set; }
    }
}
