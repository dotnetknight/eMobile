using Autofac;
using Autofac.Extras.DynamicProxy;
using CQRS.Bus;
using CQRS.Interfaces;
using eMobile.API.Handlers.CommandHandlers;
using eMobile.Respository;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Services
{
    public class CommandServices
    {
        public static void RegisterServices(ContainerBuilder builder, IServiceCollection services)
        {
            services.AddTransient<ICommandBusAsync, CommandBusAsync>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.RegisterAssemblyTypes(typeof(AddPhoneCommandHandler).Assembly)
                .AsClosedTypesOf(typeof(ICommandHandlerAsync<>))
                .EnableClassInterceptors();

            builder.RegisterAssemblyTypes(typeof(DeletePhoneCommandHandler).Assembly)
                .AsClosedTypesOf(typeof(ICommandHandlerAsync<>))
                .EnableClassInterceptors();

            builder.RegisterAssemblyTypes(typeof(UpdatePhoneCommandHandler).Assembly).AsClosedTypesOf(typeof(ICommandHandlerAsync<>))
                .EnableClassInterceptors();

            builder.RegisterAssemblyTypes(typeof(AddUserCommandHandler).Assembly)
                .AsClosedTypesOf(typeof(ICommandHandlerAsync<>))
                 .EnableClassInterceptors();

            builder.RegisterAssemblyTypes(typeof(UpdateMediaCommandHandler).Assembly)
                .AsClosedTypesOf(typeof(ICommandHandlerAsync<>))
                .EnableClassInterceptors();
        }
    }
}
