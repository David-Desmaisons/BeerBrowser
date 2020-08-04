using BeerAPI.Data.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.DependencyInjection;

namespace BeerAPI
{
    public static class NHibernateExtensions
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, string connectionString)
        {
            var sessionFactory = Fluently.Configure()
                .Database(
                    PostgreSQLConfiguration.Standard.ConnectionString(connectionString)
                )
                .Mappings(m =>
                    m.FluentMappings.AddFromAssembly(typeof(BeerMap).Assembly))
                .BuildSessionFactory();

            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());
            return services;
        }
    }
}
