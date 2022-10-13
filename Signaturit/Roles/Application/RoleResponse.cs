using Signaturit.Roles.Domain;

namespace Signaturit.Roles.Application
{
    public class RoleResponse
    {
        public string Id { get; }
        public string Name { get; }
        public int Value { get; }

        public RoleResponse(string id, string name, int value)
        {
            Id = id;
            Name = name;
            Value = value;
        }

        public static RoleResponse FromAggregate(Role role)
        {
            return new RoleResponse(role.RoleId.Value, role.RoleName.Value, role.RoleValue.Value);
        }
    }
}
