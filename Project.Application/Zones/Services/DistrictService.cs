using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project.Application.Zones.Dto;
using Project.Domain.Repository;

namespace Project.Application.Zones.Services
{
    public class DistrictService: IDistrictService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DistrictService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<DistrictDto>> GetAllAsync()
        {
            var zones = await _unitOfWork.Zones.GetAllAsync();

            return zones.SelectMany(zone => _mapper.Map<List<DistrictDto>>(zone)).ToList();
        }
    }
}
