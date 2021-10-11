using System;

namespace Project.Application.Consumes.Dto
{
    public class ConsumeDeviceDto
    {
        public Guid DeviceId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string DocNumber { get; set; }
        public string Address { get; set; }
        public double Consume { get; set; }   
        public string SupplyNumber { get; set; }
        public bool DeviceStatus { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
