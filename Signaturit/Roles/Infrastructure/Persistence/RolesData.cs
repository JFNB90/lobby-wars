using Signaturit.Roles.Domain;

namespace Signaturit.Roles.Infrastructure.Persistence
{
    public class RolesData
    {
        public IEnumerable<Role> Data { get; }

        public RolesData()
        {
            Data = new List<Role>()
            {
                new Role("K", "King", 5),
                new Role("N", "Notary", 2),
                new Role("V", "Validator", 1),
                new Role("#", "Empty", 0)
            };
        }
    }
}
