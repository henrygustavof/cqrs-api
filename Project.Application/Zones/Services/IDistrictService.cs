using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Application.Zones.Dto;

namespace Project.Application.Zones.Services
{
    public interface IDistrictService
    {
        Task<List<DistrictDto>> GetAllAsync();
    }
}
