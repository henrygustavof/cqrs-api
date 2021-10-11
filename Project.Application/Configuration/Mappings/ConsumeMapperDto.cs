using AutoMapper;
using Project.Application.Consumes.Dto;
using Project.Domain.Helpers;

namespace Project.Application.Configuration.Mappings
{
    public class ConsumeMapperDto : Profile
    {
        public ConsumeMapperDto()
        {
            CreateMap<Domain.Entity.Consume, ConsumeDto>()
                .ForMember(dest => dest.Consume, opt => opt.MapFrom(src => src.Value));

            CreateMap<Domain.Entity.Consume, ConsumeDistrictMonthlyDto>()
                .ForMember(dest => dest.Consume, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Time.Year))
                .ForMember(dest => dest.Month, opt => opt.MapFrom(src => src.Time.Month))
                .ForMember(dest => dest.DateOfFirstDayOfTheMonth, opt => opt.MapFrom(src => TimeHelper.SetToDateOfFirstDayOfMonth(src.Time.Year,src.Time.Month)));
        }
    }
}
