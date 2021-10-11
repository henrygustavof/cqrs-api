using System;
using System.Threading.Tasks;
using AutoMapper;
using Project.Application.Devices.Commands.SaveDevice;
using Project.Application.Devices.Dto;
using Project.Domain.Repository;

namespace Project.Application.Devices.Services
{
    public class DeviceService: IDeviceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeviceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeviceDto> GetAsync(Guid deviceId)
        {
            var device = await _unitOfWork.Devices.GetAsync(deviceId);
            return _mapper.Map<DeviceDto>(device);
        }

        public async Task<DeviceDto> AddAsync(SaveDeviceCommand request)
        {
            var device = _mapper.Map<Domain.Entity.Device>(request);
            await _unitOfWork.Devices.AddAsync(device);

            await _unitOfWork.CommitAsync();

            return new DeviceDto { Id = device.Id };
        }
    }
}
