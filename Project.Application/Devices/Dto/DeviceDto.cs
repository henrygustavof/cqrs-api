using System;

namespace Project.Application.Devices.Dto
{
    public class DeviceDto
    {
        public Guid Id { get; set; }
        public string SupplyNumber { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
    }
}
