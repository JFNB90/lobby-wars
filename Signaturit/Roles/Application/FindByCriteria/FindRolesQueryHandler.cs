using MediatR;
using Shared.Domain.Bus.Query;

namespace Signaturit.Roles.Application.FindByCriteria
{
    public class FindRolesQueryHandler : QueryHandler<FindRolesQuery, RolesResponse>
    {
        private readonly FindRolesService _finder;

        public FindRolesQueryHandler(FindRolesService finder)
        {
            _finder = finder;
        }

        public async Task<RolesResponse> Handle(FindRolesQuery query)
        {
            return await _finder.Search();
        }
    }
}
