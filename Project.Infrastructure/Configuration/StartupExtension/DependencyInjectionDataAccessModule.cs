using Autofac;
using Project.Domain.Repository;
using Project.Infrastructure.Database.Repository;

namespace Project.Infrastructure.Configuration.StartupExtension
{
    public class DependencyInjectionDataAccessModule : Module
    {
        public DependencyInjectionDataAccessModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();


            builder.RegisterType<DeviceRepository>()
                .As<IDeviceRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ZoneRepository>()
                .As<IZoneRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ConsumeRepository>()
                .As<IConsumeRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
