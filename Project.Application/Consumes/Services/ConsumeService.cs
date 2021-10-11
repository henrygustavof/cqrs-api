using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project.Application.Configuration.Constants;
using Project.Application.Consumes.Dto;
using Project.Application.Consumes.Queries.GetConsumes;
using Project.Domain.Filters;
using Project.Domain.Helpers;
using Project.Domain.Repository;

namespace Project.Application.Consumes.Services
{
    public partial class ConsumeService : IConsumeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public ConsumeService(IMapper mapper, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<List<ConsumeDto>> GetAllAsync()
        {
            return _mapper.Map<List<ConsumeDto>>(await _unitOfWork.Consumes.GetAllAsync());
        }

        public async Task<ConsumeDeviceDetailDto> GetAllByDeviceIdAsync(Guid deviceId, string startDate, string endDate)
        {
            var device = await _unitOfWork.Devices.GetAsync(deviceId);

            var user = await _userRepository.GetByUserNameAsync(device.UserName);

            var consumes = await _unitOfWork.Consumes.GetAllByDeviceIdAsync(deviceId, startDate, endDate);

            return new ConsumeDeviceDetailDto
            {
                DeviceId = deviceId,
                SupplyNumber = device.SupplyNumber,
                DocNumber = user.DocNumber,
                FullName = user.FullName,
                UserName = user.UserName,
                ConsumePerHours = consumes.Select(consume => new ConsumeDeviceHourlyDto
                {
                    DateTime = consume.Time,
                    Consume = consume.Value
                }).ToList()
            };
        }

        public async Task<List<ConsumeDeviceDto>> GetAllByZoneIdAndDistrictIdAsync(Guid zoneId, Guid districtId)
        {
            var users = await _userRepository.GetAllByFilterParamsAsync();

            var devices = await _unitOfWork.Devices.GetAllByZoneIdAndDistrictIdAsync(zoneId, districtId);

            var consumes = await _unitOfWork.Consumes.GetAllByFilterParametersAsync(new ConsumeFilterParameters
                {ZoneId = zoneId, DistrictId = districtId});

            var deviceConsumes = consumes.GroupBy(consume => new {consume.DeviceId}).Select(result => new
            {
                DeviceId = result.Key.DeviceId,
                Consume = Math.Round(result.Sum(p => p.Value), Number.RoundNumberDecimal),

            }).ToList();


            var result = from device in devices
                join user in users on device.UserName equals user.UserName
                join deviceConsume in deviceConsumes on device.Id equals deviceConsume.DeviceId into
                    deviceConsumeResults
                from deviceConsumeResult in deviceConsumeResults.DefaultIfEmpty()
                select new ConsumeDeviceDto
                {
                    Consume = deviceConsumeResult?.Consume ?? 0,
                    DeviceId = device.Id,
                    Latitude = device.Latitude,
                    Longitude = device.Longitude,
                    SupplyNumber = device.SupplyNumber,
                    UserName = device.UserName,
                    DeviceStatus = device.IsActive,
                    DocNumber = user.DocNumber,
                    FullName = user.FullName,
                    Address = user.Address
                };
            return result.ToList();
        }

        public async Task<List<ConsumeUserDto>> GetAllByUsersAsync(GetConsumesByUsersQuery consumesByUsersQuery)
        {
            var users = await _userRepository.GetAllByFilterParamsAsync(consumesByUsersQuery.DocNumber);

            var consumes = await _unitOfWork.Consumes.GetAllByFilterParametersAsync(new ConsumeFilterParameters
            {
                ZoneId = consumesByUsersQuery.ZoneId,
                DistrictId = consumesByUsersQuery.DistrictId,
                StartDate = consumesByUsersQuery.StartDate,
                EndDate = consumesByUsersQuery.EndDate
            });

            var userConsumes = consumes.GroupBy(consume => new {consume.UserName}).Select(result => new
            {
                UserName = result.Key.UserName,
                Consume = Math.Round(result.Sum(p => p.Value), Number.RoundNumberDecimal),

            }).ToList();

            var result = from user in users
                join userConsume in userConsumes on user.UserName equals userConsume.UserName into consumeResults
                from consumeResult in consumeResults.DefaultIfEmpty()
                select new ConsumeUserDto
                {
                    UserName = user.UserName,
                    FullName = user.FullName,
                    DocNumber = user.DocNumber,
                    Consume = Math.Round(consumeResult?.Consume ?? 0, Number.RoundNumberDecimal),
                    Status = user.Status,
                    BillingAmount = Math.Round(consumeResult?.Consume * Number.FactorPerUnitLiterConsume ?? 0,
                        Number.RoundNumberDecimal)

                };
            return result.ToList();
        }

        public async Task<List<ConsumeDeviceMonthlyDto>> GetAllByDeviceMonthlyAsync(
            GetConsumesByDeviceMonthlyQuery request)
        {
            var consumes = await _unitOfWork.Consumes.GetAllByDeviceIdAsync(request.DeviceId);

            var consumesFixed = consumes.Select(consume => new
            {
                YearNumber = consume.Time.Year,
                MonthNumber = consume.Time.Month,
                DateOfFirstDayOfTheMonth = TimeHelper.SetToDateOfFirstDayOfMonth(consume.Time.Year, consume.Time.Month),
                Consume = consume.Value
            });

            var consumesGroupedByDateOfFirstDayOfTheMonth = consumesFixed.GroupBy(consume => new
            {
                consume.DateOfFirstDayOfTheMonth,
                consume.YearNumber,
                consume.MonthNumber
            }).Select(result => new ConsumeDeviceMonthlyDto
            {
                YearNumber = result.Key.YearNumber,
                MonthNumber = result.Key.MonthNumber,
                DateOfFirstDayOfTheMonth = result.Key.DateOfFirstDayOfTheMonth,
                Consume = Math.Round(result.Sum(p => p.Consume), Number.RoundNumberDecimal),

            }).ToList();

            return consumesGroupedByDateOfFirstDayOfTheMonth;
        }
    }
}
