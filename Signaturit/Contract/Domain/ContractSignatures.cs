using Shared.Domain.ValueObject;
using Signaturit.Contract.Domain.Exceptions;

namespace Signaturit.Contract.Domain
{
    public class ContractSignatures : StringValueObject
    {
        private enum Roles
        {
            K = 5, // King
            N = 2, // Notary
            V = 1 // Validator
        }

        public ContractSignatures(string value) : base(value)
        {
            Validate(value);
        }

        private void Validate(string value)
        {
            if (isInvalidateLength(value))
            {
                throw new InvalidContractSingnaturesException(value);
            }

            if (hasMaxEmptySignatures(value))
            {
                throw new MaxEmptyContractSignaturesException(value);
            }
        }

        private bool isInvalidateLength(string value)
        {
            return value.Length > 3 || value.Length < 1;
        }

        private bool hasMaxEmptySignatures(string value)
        {
            return value.Split('#').Length > 2;
        }
    }
}
