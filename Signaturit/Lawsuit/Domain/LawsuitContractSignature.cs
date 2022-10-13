using Shared.Domain.ValueObject;

namespace Signaturit.Lawsuit.Domain
{
    public class LawsuitContractSignature : StringValueObject
    {
        public LawsuitContractSignature(string value) : base(value)
        {
        }
    }
}
