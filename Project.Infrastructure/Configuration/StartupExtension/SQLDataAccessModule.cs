using Autofac;
using Microsoft.EntityFrameworkCore;
using Project.Infrastructure.Database;
using Project.Infrastructure.Database.SQL;

namespace Project.Infrastructure.Configuration.StartupExtension
{
    public class SqlDataAccessModule : Module
    {
        private readonly string _databaseConnectionString;

        public SqlDataAccessModule(string databaseConnectionString)
        {
            _databaseConnectionString = databaseConnectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", _databaseConnectionString)
                .InstancePerLifetimeScope();

            builder
                .Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<ProjectContext>();
                    dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);

                    return new ProjectContext(dbContextOptionsBuilder.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}
