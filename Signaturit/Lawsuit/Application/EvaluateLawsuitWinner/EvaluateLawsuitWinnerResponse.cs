namespace Signaturit.Lawsuit.Application.EvaluateLawsuitWinner
{
    public class EvaluateLawsuitWinnerResponse
    {
        public string LawsuitId { get; }
        public string LawsuitContractPlaintiffId { get; }
        public string LawsuitContractDefendantfId { get; }
        public string LawsuitContractWinnerId { get; }

        public EvaluateLawsuitWinnerResponse(string lawsuitId, string lawsuitContractPlaintiffId, string lawsuitContractDefendantfId, string lawsuitContractWinnerId)
        {
            LawsuitId = lawsuitId;
            LawsuitContractPlaintiffId = lawsuitContractPlaintiffId;
            LawsuitContractDefendantfId = lawsuitContractDefendantfId;
            LawsuitContractWinnerId = lawsuitContractWinnerId;
        }
    }
}
