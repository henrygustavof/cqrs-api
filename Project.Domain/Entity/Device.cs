using System;

namespace Project.Domain.Entity
{
    public class Device
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public Guid ZoneId { get; set; }
        public Guid DistrictId { get; set; }
        public string SupplyNumber { get; set; }    
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsActive { get; set; }
        public string Type { get; set; }
    }
}
