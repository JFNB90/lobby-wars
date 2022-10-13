using Shared.Domain.Bus.Query;
using Signaturit.Contract.Domain;
using Signaturit.Roles.Application;
using Signaturit.Roles.Application.FindByCriteria;

namespace Signaturit.Contract.Application.Create
{
    public class CreateContractService
    {
        private readonly QueryBus _bus;

        public CreateContractService(QueryBus bus)
        {
            _bus = bus;
        }

        public async Task<ContractResponse> Create(ContractSignatures signatures)
        {
            int points = 0;
            var roles = await _bus.Ask<RolesResponse>(new FindRolesQuery());
            var _signatures = signatures.Value.ToList<char>();

            if (signatures.Value.Contains("K"))
            {
                _signatures = signatures.Value.ToList<char>().Where(c => c != 'V').ToList();
            }

            _signatures.ForEach(signature => 
            {
                var rol = roles.Roles.FirstOrDefault(r => r.Id == signature.ToString());

                points += rol?.Value ?? 0;
            });


            return new ContractResponse(ContractId.Random().ToString(), signatures.Value, points);
        }
    }
}
