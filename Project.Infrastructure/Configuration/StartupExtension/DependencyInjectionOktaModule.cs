using Autofac;
using Project.Domain.Repository;
using Project.Infrastructure.Okta.Repository;

namespace Project.Infrastructure.Configuration.StartupExtension
{
    public class DependencyInjectionOktaModule: Module
    {
        private readonly string _oktaDomain;
        private readonly string _apiToken;

        public DependencyInjectionOktaModule(string oktaDomain, string apiToken)
        {
            _oktaDomain = oktaDomain;
            _apiToken = apiToken;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .WithParameter("oktaDomain", _oktaDomain)
                .WithParameter("apiToken", _apiToken)
                .InstancePerLifetimeScope();
        }
    }
}
