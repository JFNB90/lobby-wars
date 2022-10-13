using Shared.Domain.Bus.Query;
using Signaturit.Contract.Application;
using Signaturit.Contract.Application.Create;
using Signaturit.Lawsuit.Domain;
using Signaturit.Roles.Application;
using Signaturit.Roles.Application.FindByCriteria;

namespace Signaturit.Lawsuit.Application.EvaluateLawsuitWinner
{
    public class EvaluateLawsuitWinnerService
    {
        private readonly QueryBus _bus;

        public EvaluateLawsuitWinnerService(QueryBus bus)
        {
            _bus = bus;
        }

        public async Task<EvaluateLawsuitWinnerResponse> Evaluate(LawsuitContractSignature plaintiffSignature, LawsuitContractSignature defendantSignature)
        {
            var plaintiffContract = await _bus.Ask<ContractResponse>(new CreateContractQuery(plaintiffSignature.Value));
            var defendantContract = await _bus.Ask<ContractResponse>(new CreateContractQuery(defendantSignature.Value));
            string? winnerContractId = null;
            
            if (plaintiffContract.Points > defendantContract.Points)
            {
                winnerContractId = plaintiffContract.Id;
            }

            if (defendantContract.Points > plaintiffContract.Points)
            {
                winnerContractId = defendantContract.Id;
            }

            return new EvaluateLawsuitWinnerResponse(LawsuitId.Random().ToString(), plaintiffContract.Id, defendantContract.Id, winnerContractId);
        }
    }
}
