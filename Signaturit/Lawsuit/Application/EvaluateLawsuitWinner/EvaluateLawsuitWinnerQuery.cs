using MediatR;
using Shared.Domain.Bus.Query;

namespace Signaturit.Lawsuit.Application.EvaluateLawsuitWinner
{
    public class EvaluateLawsuitWinnerQuery : Query, IRequest<EvaluateLawsuitWinnerResponse>
    {
        public string PlaintiffSignature { get; }
        public string DefendantSignature { get; }

        public EvaluateLawsuitWinnerQuery(string plaintiffSignature, string defendantSignature)
        {
            PlaintiffSignature = plaintiffSignature.Trim().ToUpper();
            DefendantSignature = defendantSignature.Trim().ToUpper();
        }
    }
}
