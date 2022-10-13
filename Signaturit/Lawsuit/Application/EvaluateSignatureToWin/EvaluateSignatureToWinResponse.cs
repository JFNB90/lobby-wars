using System;

namespace Signaturit.Lawsuit.Application.EvaluateSignatureToWin
{
    public class EvaluateSignatureToWinResponse
    {
        public string LawsuitId { get; }
        public string LawsuitContractPlaintiffId { get; }
        public string LawsuitContractDefendantfId { get; }
        public string LawsuitContractPlaintiffSignature { get; }
        public string LawsuitContractDefendantfSignature { get; }
        public string LawsuitSignatureToWin { get; }

        public EvaluateSignatureToWinResponse(string lawsuitId, string lawsuitContractPlaintiffId,
            string lawsuitContractDefendantfId, string lawsuitContractPlaintiffSignature,
            string lawsuitContractDefendantSignature, string lawsuitSignatureToWin)
        {
            LawsuitId = lawsuitId;
            LawsuitContractPlaintiffId = lawsuitContractPlaintiffId;
            LawsuitContractDefendantfId = lawsuitContractDefendantfId;
            LawsuitContractPlaintiffSignature = lawsuitContractPlaintiffSignature;
            LawsuitContractDefendantfSignature = lawsuitContractDefendantSignature;
            LawsuitSignatureToWin = lawsuitSignatureToWin;
        }
    }
}

