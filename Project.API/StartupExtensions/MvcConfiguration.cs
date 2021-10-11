using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Project.API.Response;

namespace Project.API.StartupExtensions
{
    public static class MvcConfiguration
    {
        public static void AddMvcConfiguration(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(
                    new ProducesResponseTypeAttribute(typeof(ErrorResponse), StatusCodes.Status400BadRequest));
                options.Filters.Add(
                    new ProducesResponseTypeAttribute(typeof(ErrorResponse), StatusCodes.Status401Unauthorized));
                options.Filters.Add(
                    new ProducesResponseTypeAttribute(typeof(ErrorResponse), StatusCodes.Status403Forbidden));
                options.Filters.Add(
                    new ProducesResponseTypeAttribute(typeof(ErrorResponse), StatusCodes.Status404NotFound));
                options.Filters.Add(
                    new ProducesResponseTypeAttribute(typeof(ErrorResponse), StatusCodes.Status415UnsupportedMediaType));
                options.Filters.Add(
                    new ProducesResponseTypeAttribute(typeof(ErrorResponse), StatusCodes.Status500InternalServerError));

            });
        }
    }
}
