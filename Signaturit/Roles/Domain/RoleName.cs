using Shared.Domain.ValueObject;

namespace Signaturit.Roles.Domain
{
    public class RoleName : StringValueObject
    {
        public RoleName(string value) : base(value)
        {
        }
    }
}
