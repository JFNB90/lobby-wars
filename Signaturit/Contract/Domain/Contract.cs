using Shared.Domain.Aggregate;
using Shared.Domain.ValueObject;

namespace Signaturit.Contract.Domain
{
    public class Contract : AggregateRoot
    {
        public ContractId ContractId { get; }
        public ContractSignatures ContractSignatures { get; }
        public ContractPoints ContractPoints { get; }

        public Contract(string value)
        {
            ContractId = new ContractId(UuidValueObject.Random().ToString());
            ContractSignatures = new ContractSignatures(value);
        }
    }
}
