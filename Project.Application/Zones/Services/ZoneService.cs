using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Project.Application.Zones.Dto;
using Project.Domain.Repository;

namespace Project.Application.Zones.Services
{
    public class ZoneService: IZoneService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ZoneService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ZoneDto>> GetAllAsync()
        {
            var items = await _unitOfWork.Zones.GetAllAsync();

            return _mapper.Map<List<ZoneDto>>(items);
        }
    }
}
