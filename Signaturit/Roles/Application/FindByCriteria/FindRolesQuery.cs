using MediatR;
using Shared.Domain.Bus.Query;

namespace Signaturit.Roles.Application.FindByCriteria
{
    public class FindRolesQuery : Query, IRequest<RolesResponse>
    {
        public FindRolesQuery()
        {
        }
    }
}
