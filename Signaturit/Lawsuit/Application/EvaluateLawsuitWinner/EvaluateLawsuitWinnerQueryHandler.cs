using MediatR;
using Shared.Domain.Bus.Query;

namespace Signaturit.Lawsuit.Application.EvaluateLawsuitWinner
{
    public class EvaluateLawsuitWinnerQueryHandler : QueryHandler<EvaluateLawsuitWinnerQuery, EvaluateLawsuitWinnerResponse>
    {
        private readonly EvaluateLawsuitWinnerService _evaluator;

        public EvaluateLawsuitWinnerQueryHandler(EvaluateLawsuitWinnerService evaluator)
        {
            _evaluator = evaluator;
        }

        public async Task<EvaluateLawsuitWinnerResponse> Handle(EvaluateLawsuitWinnerQuery query)
        {
            return await _evaluator.Evaluate(new Domain.LawsuitContractSignature(query.PlaintiffSignature), new Domain.LawsuitContractSignature(query.DefendantSignature));
        }
    }
}
