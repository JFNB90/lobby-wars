

using Shared.Domain.Aggregate;
using Signaturit.Contract.Domain;

namespace Signaturit.Lawsuit.Domain
{
    public class Lawsuit : AggregateRoot
    {
        public LawsuitId LawsuitId { get; }
        public LawsuitContractSignature PlaintiffContractSignature { get; }
        public LawsuitContractSignature DefendantContractSignature { get; }

        public Lawsuit(string plaintiffSignature, string defendantSignature)
        {
        }
    }
}
