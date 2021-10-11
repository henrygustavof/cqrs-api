using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Application.Zones.Dto;

namespace Project.Application.Zones.Services
{
    public interface IZoneService
    {
        Task<List<ZoneDto>> GetAllAsync();
    }
}
