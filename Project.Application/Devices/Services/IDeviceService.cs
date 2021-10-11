using System;
using System.Threading.Tasks;
using Project.Application.Devices.Commands.SaveDevice;
using Project.Application.Devices.Dto;

namespace Project.Application.Devices.Services
{
    public interface IDeviceService
    {
        Task<DeviceDto> GetAsync(Guid deviceId);
        Task<DeviceDto> AddAsync(SaveDeviceCommand request);
    }
}
