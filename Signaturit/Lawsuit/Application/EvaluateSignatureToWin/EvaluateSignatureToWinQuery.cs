using System;
using MediatR;
using Shared.Domain.Bus.Query;

namespace Signaturit.Lawsuit.Application.EvaluateSignatureToWin
{
    public class EvaluateSignatureToWinQuery : Query, IRequest<EvaluateSignatureToWinResponse>
    {
        public string PlaintiffSignature { get; }
        public string DefendantSignature { get; }

        public EvaluateSignatureToWinQuery(string plaintiffSignature, string defendantSignature)
        {
            PlaintiffSignature = plaintiffSignature.Trim().ToUpper();
            DefendantSignature = defendantSignature.Trim().ToUpper();
        }
    }
}

