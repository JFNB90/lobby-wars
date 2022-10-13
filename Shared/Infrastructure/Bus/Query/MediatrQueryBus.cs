using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shared.Domain.Bus.Query;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Reflection;

namespace Shared.Infrastructure.Bus.Query
{
    public class MediatrQueryBus : QueryBus
    {
        private readonly ISender _mediator = null!;
        private readonly IServiceProvider _serviceProvider;

        private static readonly ConcurrentDictionary<Type, object> _queryHandlers =
    new ConcurrentDictionary<Type, object>();

        public MediatrQueryBus(ISender mediator, IServiceProvider serviceProvider)
        {
            _mediator = mediator;
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Ask<TResponse>(Domain.Bus.Query.Query query)
        {
            var handler = GetWrappedHandlers<TResponse>(query);

            //return await _mediator.Send<TResponse>((IRequest<TResponse>) query);

            return await handler.Handle(query, _serviceProvider);
        }

        private QueryHandlerWrapper<TResponse> GetWrappedHandlers<TResponse>(Domain.Bus.Query.Query query)
        {
            Type[] typeArgs = { query.GetType(), typeof(TResponse) };

            var handlerType = typeof(QueryHandler<,>).MakeGenericType(typeArgs);
            var wrapperType = typeof(QueryHandlerWrapper<,>).MakeGenericType(typeArgs);

            var handlers = (IEnumerable)_serviceProvider.GetService(typeof(IEnumerable<>).MakeGenericType(handlerType));

            var wrappedHandlers = (QueryHandlerWrapper<TResponse>)_queryHandlers.GetOrAdd(query.GetType(),
                handlers.Cast<object>()
                    .Select(handler => (QueryHandlerWrapper<TResponse>)Activator.CreateInstance(wrapperType))
                    .FirstOrDefault());

            return wrappedHandlers;
        }
    }
}
