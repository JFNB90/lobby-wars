using Signaturit.Roles.Domain;

namespace Signaturit.Roles.Application.FindByCriteria
{
    public class FindRolesService
    {
        private readonly RolesRepository _respository;

        public FindRolesService(RolesRepository respository)
        {
            _respository = respository;
        }

        public async Task<RolesResponse> Search()
        {
            return new RolesResponse((await _respository.Search()).Select(i => RoleResponse.FromAggregate(i)));
        }
    }
}
