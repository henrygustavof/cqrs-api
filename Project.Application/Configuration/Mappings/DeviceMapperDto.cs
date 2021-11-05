using AutoMapper;
using Project.Application.Devices.Commands.SaveDevice;
using Project.Application.Devices.Dto;

namespace Project.Application.Configuration.Mappings
{
    public class DeviceMapperDto : Profile
    {
        public DeviceMapperDto()
        {
            CreateMap<SaveDeviceRequest, SaveDeviceCommand>();
            CreateMap<SaveDeviceCommand, Domain.Entity.Device>();
            CreateMap<SaveDeviceCommand, Domain.Entity.Zone>();
            CreateMap<Domain.Entity.Zone, DeviceDto>();
            CreateMap<Domain.Entity.Device, DeviceDto>();
        }
    }
}