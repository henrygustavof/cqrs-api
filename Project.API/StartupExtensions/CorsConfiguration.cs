using Project.API.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace Project.API.StartupExtensions
{
    public static class CorsConfiguration
    {
        public static void AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CorsConstants.PolicyName,
                builder => builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
                        });
        }
    }
}
