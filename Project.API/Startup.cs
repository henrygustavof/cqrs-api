using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.API.Constants;
using Project.API.Middleware;
using Project.API.StartupExtensions;
using Project.Application.Configuration.Commands;
using Project.Infrastructure.Configuration.StartupExtension;
using Project.Infrastructure.Database;
using ApplicationStartupExtension = Project.Application.Configuration.StartupExtension;

namespace Project.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Register the MediatR request handlers
            services.RegisterRequestHandlers();
            services.AddSwaggerConfiguration();
            services.AddAuthConfiguration(Configuration);
            services.AddCorsConfiguration();
            services.AddAutoMapperConfiguration();
            services.AddMvcConfiguration();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DependencyInjectionDataAccessModule());
            builder.RegisterModule(new DependencyInjectionOktaModule(Configuration[OktaConfigKeysConstants.Domain],
                Configuration[OktaConfigKeysConstants.ApiToken]));
            builder.RegisterModule(new ApplicationStartupExtension.DependencyInjectionApplicationModule());

            builder.RegisterModule(new CosmosDataAccessModule(
                Configuration[DataBaseConfigKeysConstants.CosmosDB.ConnectionString], 
                Configuration[DataBaseConfigKeysConstants.CosmosDB.DataBaseName]));
            //builder.RegisterModule(new SqlDataAccessModule(this.Configuration[DataBaseConfigKeysConstants.SqlDB.ConnectionString]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ProjectContext projectContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(CorsConstants.PolicyName)
               .UseMiddleware(typeof(ErrorMiddleware))
               .UseHttpsRedirection()
               .UseRouting()
               .UseAuthentication()
               .UseAuthorization()
               .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                })
               .UseSwaggerConfiguration();

            projectContext.Database.EnsureCreated();
        }
    }
}
