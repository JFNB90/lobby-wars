using System.Collections.Generic;

namespace Signaturit.Roles.Domain
{
    public interface RolesRepository
    {
        Task<IEnumerable<Role>> Search();
    }
}
