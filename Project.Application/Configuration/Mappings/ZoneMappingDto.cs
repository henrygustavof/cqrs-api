using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Project.Application.Zones.Dto;

namespace Project.Application.Configuration.Mappings
{
    public class ZoneMappingDto : Profile
    {
        public ZoneMappingDto()
        {
            CreateMap<Domain.Entity.District, DistrictDto>();
            CreateMap<Domain.Entity.Zone, ZoneDto>();
            CreateMap<Domain.Entity.Zone, List<DistrictDto>>()
                .ConvertUsing(zone => zone.Districts.Select(district => new DistrictDto
                    {
                        ZoneId = zone.Id,
                        Id = district.Id,
                        Name = district.Name
                    }).ToList()
                );
        }
    }
}
