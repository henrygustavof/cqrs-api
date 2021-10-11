using System.Collections.Generic;
using Project.Application.Devices.Dto;

namespace Project.Application.Users.Dto
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string DocNumber { get; set; }
        public string Address { get; set; }
        public double Consume { get; set; }
        public List<DeviceDto> Devices { get; set; }
    }
}
