using Autofac;
using Microsoft.EntityFrameworkCore;
using Project.Infrastructure.Database;

namespace Project.Infrastructure.Configuration.StartupExtension
{
    public class CosmosDataAccessModule : Module
    {
        private readonly string _accountEndpoint;
        private readonly string _databaseName;

        public CosmosDataAccessModule(string accountEndpoint, string databaseName)
        {
            _accountEndpoint = accountEndpoint;
            _databaseName = databaseName;
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder
                .Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<ProjectContext>();

                    dbContextOptionsBuilder.UseCosmos(
                    _accountEndpoint,
                    databaseName: _databaseName);

                    return new ProjectContext(dbContextOptionsBuilder.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}
