using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Application.Configuration.Constants;
using Project.Application.Consumes.Dto;
using Project.Domain.Entity;
using Project.Domain.Helpers;

namespace Project.Application.Consumes.Services
{
    public partial class ConsumeService : IConsumeService
    {
        public async Task<List<ConsumeDistrictDto>> GetConsumesInDistrictsByZoneIdAsync(Guid zoneId)
        {
            var districts = await _unitOfWork.Zones.GetDistrictsByZoneIdAsync(zoneId);

            var consumes = await _unitOfWork.Consumes.GetAllByZoneIdAsync(zoneId);

            var consumesInDistrictsGroupedByMonth = GetConsumesInDistrictsGroupedByMonthAsync(consumes.ToList());

            var dateOfFirstDayOfTheMonthList = consumesInDistrictsGroupedByMonth.OrderBy(y => y.Year)
                .ThenBy(z => z.Month)
                .Select(x => x.DateOfFirstDayOfTheMonth)
                .Distinct()
                .ToList();

            return districts.Select(district => new ConsumeDistrictDto
            {
                DistrictId = district.Id,
                DistrictName = district.Name,
                Consumes = GetConsumesByDistrictAsync(dateOfFirstDayOfTheMonthList,
                    consumesInDistrictsGroupedByMonth,
                    district)
            }).ToList();
        }

        private List<ConsumeDistrictMonthlyDto> GetConsumesInDistrictsGroupedByMonthAsync(
            List<Consume> consumes)
        {
            var consumesByDistricts = consumes
                .GroupBy(u => new { u.DistrictId, u.Time.Year, u.Time.Month })
                .Select(g => new ConsumeDistrictMonthlyDto
                {
                    DistrictId = g.Key.DistrictId,
                    Month = g.Key.Month,
                    Year = g.Key.Year,
                    DateOfFirstDayOfTheMonth = TimeHelper.SetToDateOfFirstDayOfMonth(g.Key.Year, g.Key.Month),
                    Consume = g.Sum(x => x.Value)
                }).ToList();
            return consumesByDistricts;
        }

        private List<ConsumeMonthlyDto> GetConsumesByDistrictAsync(List<string> dateOfFirstDayOfTheMonthList,
            List<ConsumeDistrictMonthlyDto> consumesByDistricts,
            District district)
        {
            var consumesByDistrict = consumesByDistricts.Where(p => p.DistrictId == district.Id);
            if (!consumesByDistrict.Any()) return new List<ConsumeMonthlyDto>();

            return (from dateOfFirstDayOfTheMonth in dateOfFirstDayOfTheMonthList
                join cd in consumesByDistrict on dateOfFirstDayOfTheMonth equals
                    cd.DateOfFirstDayOfTheMonth into consumes
                from consume in consumes.DefaultIfEmpty()
                select new ConsumeMonthlyDto
                {
                    Year = consume.Year,
                    Month = consume.Month,
                    DateOfFirstDayOfTheMonth = DateTime.Parse(dateOfFirstDayOfTheMonth).ToString(Time.DateFormat),
                    Consume = Math.Round(consume?.Consume ?? 0, Number.RoundNumberDecimal)
                }).ToList();
        }

    }
}
