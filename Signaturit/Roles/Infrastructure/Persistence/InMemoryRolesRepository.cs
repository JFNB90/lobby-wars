using Signaturit.Roles.Domain;

namespace Signaturit.Roles.Infrastructure.Persistence
{
    public class InMemoryRolesRepository : RolesRepository
    {
        private readonly RolesData _roles;

        public InMemoryRolesRepository(RolesData roles)
        {
            _roles = roles;
        }

        public Task<IEnumerable<Role>> Search()
        {
            return Task.FromResult(_roles.Data);
        }

        public Task<Role> Search(RoleId id)
        {
            throw new NotImplementedException();
        }
    }
}
