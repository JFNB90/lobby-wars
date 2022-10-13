using MediatR;
using Shared.Domain.Bus.Query;

namespace Signaturit.Contract.Application.Create
{
    public class CreateContractQuery : Query, IRequest<ContractResponse>
    {
        public string Signatures { get; }

        public CreateContractQuery(string signatures)
        {
            Signatures = signatures;
        }
    }
}
