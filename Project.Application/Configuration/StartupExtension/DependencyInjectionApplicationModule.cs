using Autofac;
using Project.Application.Consumes.Services;
using Project.Application.Consumes.Validations;
using Project.Application.Devices.Services;
using Project.Application.Users.Services;
using Project.Application.Users.Validations;
using Project.Application.Zones.Services;

namespace Project.Application.Configuration.StartupExtension
{
    public class DependencyInjectionApplicationModule : Module
    {
        public DependencyInjectionApplicationModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConsumeValidations>()
                .As<IConsumeValidations>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserValidations>()
                .As<IUserValidations>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ConsumeService>()
                .As<IConsumeService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DeviceService>()
                .As<IDeviceService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ZoneService>()
                .As<IZoneService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DistrictService>()
                .As<IDistrictService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerLifetimeScope();
        }
    }
}
