using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Project.Application.Configuration.Commands;

namespace Project.Application.Configuration.StartupExtension
{
    public static class RequestHandlerExtension
    {
        public static IServiceCollection RegisterRequestHandlers(
            this IServiceCollection services)
        {
            return services.AddMediatR(typeof(CommandBase).Assembly);
        }
    }
}
