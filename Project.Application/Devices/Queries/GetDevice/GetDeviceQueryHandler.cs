using System.Threading;
using System.Threading.Tasks;
using Project.Application.Configuration.Queries;
using Project.Application.Devices.Dto;
using Project.Application.Devices.Services;

namespace Project.Application.Devices.Queries.GetDevice
{
    public class GetDeviceQueryHandler : IQueryHandler<GetDeviceQuery, DeviceDto>
    {
        private readonly IDeviceService _deviceService;
        public GetDeviceQueryHandler(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        public async Task<DeviceDto> Handle(GetDeviceQuery request, CancellationToken cancellationToken)
        {

            return await _deviceService.GetAsync(request.Id);
        }
    }
}

