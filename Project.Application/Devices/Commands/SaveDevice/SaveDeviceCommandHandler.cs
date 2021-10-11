using System.Threading;
using System.Threading.Tasks;
using Project.Application.Configuration.Commands;
using Project.Application.Devices.Dto;
using Project.Application.Devices.Services;

namespace Project.Application.Devices.Commands.SaveDevice
{
    public class SaveDeviceCommandHandler : ICommandHandler<SaveDeviceCommand, DeviceDto>
    {
        private readonly IDeviceService _deviceService;
        public SaveDeviceCommandHandler(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        public async Task<DeviceDto> Handle(SaveDeviceCommand request, CancellationToken cancellationToken)
        {
            return await _deviceService.AddAsync(request);
        }
    }
}
