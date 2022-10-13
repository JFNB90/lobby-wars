using System;
using Shared.Domain.Bus.Query;
using Signaturit.Contract.Application;
using Signaturit.Contract.Application.Create;
using Signaturit.Lawsuit.Application.EvaluateLawsuitWinner;
using Signaturit.Lawsuit.Domain;
using Signaturit.Roles.Application;
using Signaturit.Roles.Application.FindByCriteria;
using Signaturit.Roles.Domain;

namespace Signaturit.Lawsuit.Application.EvaluateSignatureToWin
{
    public class EvaluateSignatureToWinService
    {
        private readonly QueryBus _bus;

        public EvaluateSignatureToWinService(QueryBus bus)
        {
            _bus = bus;
        }

        public async Task<EvaluateSignatureToWinResponse> Evaluate(LawsuitContractSignature plaintiffSignature, LawsuitContractSignature defendantSignature)
        {
            var plaintiffContract = await _bus.Ask<ContractResponse>(new CreateContractQuery(plaintiffSignature.Value));
            var defendantContract = await _bus.Ask<ContractResponse>(new CreateContractQuery(defendantSignature.Value));

            var roles = await _bus.Ask<RolesResponse>(new FindRolesQuery());

            var greatestContract = plaintiffContract.Points > defendantContract.Points ? plaintiffContract : defendantContract;
            string greatestSignature = greatestContract.Signatures;
            List<RoleResponse> greatestSignatureRoles = new List<RoleResponse>();

            string signatureToWin = greatestSignature;
            bool isSignatureToWin = false;

            greatestContract.Signatures.ToList().ForEach(s => {
                var role = roles.Roles.First(r => r.Id == s.ToString());

                if (role is null)
                {
                    return;
                }

                greatestSignatureRoles.Add(role);
            });

            greatestSignatureRoles.OrderBy(r => r.Value).ToList().ForEach(role => {
                var nextRol = roles.Roles.Where(r => r.Value > role.Value).OrderBy(r => r.Value).FirstOrDefault();

                if (nextRol is null || isSignatureToWin)
                {
                    return;
                }

                var replaceIndex = signatureToWin.IndexOf(role.Id);
                signatureToWin = signatureToWin.Remove(replaceIndex, 1).Insert(replaceIndex, nextRol.Id);
                isSignatureToWin = true;
            });

            return new EvaluateSignatureToWinResponse(LawsuitId.Random().ToString(),
            plaintiffContract.Id, defendantContract.Id, plaintiffContract.Signatures, defendantContract.Signatures,
            signatureToWin);
        }
    }
}

