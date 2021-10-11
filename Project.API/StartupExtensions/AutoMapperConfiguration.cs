using Project.Application.Configuration.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Project.API.StartupExtensions
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DeviceMapperDto));
            services.AddAutoMapper(typeof(ConsumeMapperDto));
            services.AddAutoMapper(typeof(ZoneMappingDto));
        }
    }
}
