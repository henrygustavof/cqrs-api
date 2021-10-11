using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Project.Application.Configuration.Queries;
using Project.Application.Consumes.Dto;
using Project.Application.Consumes.Services;
using Project.Application.Consumes.Validations;

namespace Project.Application.Consumes.Queries.GetConsumes
{
    public class GetConsumesQueryHandler : 
        IQueryHandler<GetConsumesQuery, List<ConsumeDto>>,
        IQueryHandler<GetConsumesByDeviceQuery, ConsumeDeviceDetailDto>,
        IQueryHandler<GetConsumesInDistrictsByZoneQuery, List<ConsumeDistrictDto>>,
        IQueryHandler<GetConsumesInDevicesByDistrictQuery, List<ConsumeDeviceDto>>,
        IQueryHandler<GetConsumesByUsersQuery, List<ConsumeUserDto>>,
        IQueryHandler<GetConsumesByDeviceMonthlyQuery, List<ConsumeDeviceMonthlyDto>>
    {
        private readonly IConsumeValidations _consumeValidations;
        private readonly IConsumeService _consumeService;

        public GetConsumesQueryHandler(IConsumeValidations consumeValidations,
            IConsumeService consumeService)
        {
            _consumeValidations = consumeValidations;
            _consumeService = consumeService;
        }

        public async Task<List<ConsumeDto>> Handle(GetConsumesQuery request, CancellationToken cancellationToken)
        {
            return await _consumeService.GetAllAsync();
        }

        public async Task<ConsumeDeviceDetailDto> Handle(GetConsumesByDeviceQuery request,
            CancellationToken cancellationToken)
        {
            await _consumeValidations.ValidateConsumesByDeviceAsync(request);
            return await _consumeService.GetAllByDeviceIdAsync(request.DeviceId, request.StartDate, request.EndDate);
        }

        public async Task<List<ConsumeDistrictDto>> Handle(GetConsumesInDistrictsByZoneQuery request,
            CancellationToken cancellationToken)
        {
            _consumeValidations.ValidateConsumesInDistrictsByZoneId(request.ZoneId);

            return await _consumeService.GetConsumesInDistrictsByZoneIdAsync(request.ZoneId);
        }

        public async Task<List<ConsumeDeviceDto>> Handle(GetConsumesInDevicesByDistrictQuery request,
            CancellationToken cancellationToken)
        {
            return await _consumeService.GetAllByZoneIdAndDistrictIdAsync(request.ZoneId, request.DistrictId);
        }

        public async Task<List<ConsumeUserDto>> Handle(GetConsumesByUsersQuery request, CancellationToken cancellationToken)
        {
            _consumeValidations.ValidateConsumesByUsers(request);

            return await _consumeService.GetAllByUsersAsync(request);
        }

        public async Task<List<ConsumeDeviceMonthlyDto>> Handle(GetConsumesByDeviceMonthlyQuery request, CancellationToken cancellationToken)
        {
            await _consumeValidations.ValidateConsumesByDeviceMonthlyAsync(request);
            return await _consumeService.GetAllByDeviceMonthlyAsync(request);
        }
    }
}
