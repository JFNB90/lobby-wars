using Shared.Domain.ValueObject;

namespace Signaturit.Lawsuit.Domain
{
    public class LawsuitContractId : UuidValueObject
    {

        public LawsuitContractId(string value) : base(value)
        {
        }
    }
}
