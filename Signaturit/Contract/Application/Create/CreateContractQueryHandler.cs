using MediatR;
using Shared.Domain.Bus.Query;

namespace Signaturit.Contract.Application.Create
{
    public class CreateContractQueryHandler : QueryHandler<CreateContractQuery, ContractResponse>
    {
        private readonly CreateContractService _creator;

        public CreateContractQueryHandler(CreateContractService creator)
        {
            _creator = creator;
        }

        public async Task<ContractResponse> Handle(CreateContractQuery query)
        {
            return await _creator.Create(new Domain.ContractSignatures(query.Signatures));
        }
    }
}
