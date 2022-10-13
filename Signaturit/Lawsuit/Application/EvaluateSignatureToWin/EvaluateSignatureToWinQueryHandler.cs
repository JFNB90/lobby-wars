using System;
using MediatR;
using Shared.Domain.Bus.Query;
using Signaturit.Lawsuit.Application.EvaluateLawsuitWinner;

namespace Signaturit.Lawsuit.Application.EvaluateSignatureToWin
{
    public class EvaluateSignatureToWinQueryHandler : QueryHandler<EvaluateSignatureToWinQuery, EvaluateSignatureToWinResponse>
    {
        private readonly EvaluateSignatureToWinService _evaluator;

        public EvaluateSignatureToWinQueryHandler(EvaluateSignatureToWinService evaluator)
        {
            _evaluator = evaluator;
        }

        public async Task<EvaluateSignatureToWinResponse> Handle(EvaluateSignatureToWinQuery query)
        {
            return await _evaluator.Evaluate(new Domain.LawsuitContractSignature(query.PlaintiffSignature), new Domain.LawsuitContractSignature(query.DefendantSignature));
        }
    }
}

