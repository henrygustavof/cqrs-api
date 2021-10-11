using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.API.Authorization;
using Project.API.Constants;

namespace Project.API.StartupExtensions
{
    public static class AuthConfiguration
    {
        public static void AddAuthConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure JWT authentication.
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearerConfiguration(
                configuration[JwtConfigKeysConstants.Issuer],
                configuration[JwtConfigKeysConstants.Audience]
              );

            services.AddScoped<IClaimsTransformation>(_ => new GroupsToRolesTransformation(
                configuration[OktaConfigKeysConstants.Domain],
                configuration[OktaConfigKeysConstants.ApiToken]));
        }
    }
}
