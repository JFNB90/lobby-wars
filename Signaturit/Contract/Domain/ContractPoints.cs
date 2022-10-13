using Shared.Domain.ValueObject;

namespace Signaturit.Contract.Domain
{
    public class ContractPoints : IntValueObject
    {
        public ContractPoints() : base(0)
        {
        }

        public ContractPoints(int value) : base(value) 
        {
        }

    }
}
