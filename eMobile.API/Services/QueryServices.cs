using Autofac;
using CQRS.Bus;
using CQRS.Interfaces;
using Autofac.Extras.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using eMobile.Respository;
using eMobile.API.Queries;

namespace CQRS.Services
{
    public class QueryServices
    {
        public static void RegisterServices(ContainerBuilder builder, IServiceCollection services)
        {
            services.AddTransient<IQueryBusAsync, QueryBusAsync>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.RegisterAssemblyTypes(typeof(PhoneQuery).Assembly).AsClosedTypesOf(typeof(IQueryHandlerAsync<,>)).EnableClassInterceptors();
        }
    }
}
