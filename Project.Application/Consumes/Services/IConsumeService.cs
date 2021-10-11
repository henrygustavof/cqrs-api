using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Application.Consumes.Dto;
using Project.Application.Consumes.Queries.GetConsumes;

namespace Project.Application.Consumes.Services
{
    public interface IConsumeService
    {
        Task<List<ConsumeDto>> GetAllAsync();
        Task<ConsumeDeviceDetailDto> GetAllByDeviceIdAsync(Guid deviceId, string startDate, string endDate);
        Task<List<ConsumeDeviceDto>> GetAllByZoneIdAndDistrictIdAsync(Guid zoneId, Guid districtId);
        Task<List<ConsumeDistrictDto>> GetConsumesInDistrictsByZoneIdAsync(Guid zoneId);
        Task<List<ConsumeUserDto>> GetAllByUsersAsync(GetConsumesByUsersQuery consumesByUsersQuery);
        Task<List<ConsumeDeviceMonthlyDto>> GetAllByDeviceMonthlyAsync(GetConsumesByDeviceMonthlyQuery request);
    }
}
