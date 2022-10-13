using Shared.Domain.ValueObject;

namespace Signaturit.Lawsuit.Domain
{
    public class LawsuitId : UuidValueObject
    {
        public LawsuitId(string value) : base(value)
        {
        }
    }
}
