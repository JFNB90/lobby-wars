
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shared.Domain.Bus.Query;
using System.Reflection;

namespace Shared
{
    public static class QueryServicesExtensions
    {
        public static IServiceCollection AddQueryServices(this IServiceCollection services,
            Assembly assembly)
        {
            var classTypes = assembly.ExportedTypes.Select(t => t.GetTypeInfo()).Where(t => t.IsClass && !t.IsAbstract);

            foreach (var type in classTypes)
            {
                var interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());

                foreach (var handlerInterfaceType in interfaces.Where(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(QueryHandler<,>)))
                    services.AddScoped(handlerInterfaceType.AsType(), type.AsType());
            }

            services.AddMediatR(assembly);


            return services;
        }
    }
}
