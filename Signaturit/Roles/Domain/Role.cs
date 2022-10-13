using Shared.Domain.Aggregate;
using Shared.Domain.ValueObject;

namespace Signaturit.Roles.Domain
{
    public class Role : AggregateRoot
    {
        public RoleId RoleId { get; }
        public RoleName RoleName { get; }
        public RoleValue RoleValue { get; }

        public Role(string roleId, string roleName, int roleValue)
        {
            RoleId = new RoleId(roleId);
            RoleName = new RoleName(roleName);
            RoleValue = new RoleValue(roleValue);
        }
    }
}
