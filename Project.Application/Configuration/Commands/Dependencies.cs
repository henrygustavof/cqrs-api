using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Project.Application.Configuration.Commands
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterRequestHandlers(
            this IServiceCollection services)
        {
            return services.AddMediatR(typeof(Dependencies).Assembly);
        }
    }
}
