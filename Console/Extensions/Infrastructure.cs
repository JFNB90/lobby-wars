using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shared.Domain.Bus.Query;
using Shared.Infrastructure.Bus.Query;
using Signaturit.Roles.Domain;
using Signaturit.Roles.Infrastructure.Persistence;
using System.Reflection;

namespace ConsoleApp.Extensions
{
    public static class Infrastructure
    {
        internal static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<QueryBus, MediatrQueryBus>();

            services.AddScoped<RolesData, RolesData>();
            services.AddScoped<RolesRepository, InMemoryRolesRepository>();

            return services;
        }
    }
}
