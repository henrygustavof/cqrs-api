using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Project.Application.Configuration.Queries;
using Project.Application.Zones.Dto;
using Project.Application.Zones.Services;

namespace Project.Application.Zones.Queries.GetDistricts
{
    public class GetDistrictsQueryHandler : IQueryHandler<GetDistrictsQuery, List<DistrictDto>>
    {
        private readonly IDistrictService _districtService;
        public GetDistrictsQueryHandler(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        public async Task<List<DistrictDto>> Handle(GetDistrictsQuery request, CancellationToken cancellationToken)
        {
           return  await _districtService.GetAllAsync();
        }
    }
}
