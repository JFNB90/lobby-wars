using Signaturit.Roles.Domain;

namespace Signaturit.Roles.Application
{
    public class RolesResponse
    {
        public readonly IEnumerable<RoleResponse> Roles;

        public RolesResponse(IEnumerable<RoleResponse> roles)
        {
            Roles = roles;
        }
    }
}
