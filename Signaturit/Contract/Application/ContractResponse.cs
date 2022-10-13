using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signaturit.Contract.Application
{
    public class ContractResponse
    {
        public string Id { get; }
        public string Signatures { get; }
        public int Points { get; }

        public ContractResponse(string id, string signatures, int points)
        {
            Id = id;
            Signatures = signatures;
            Points = points;
        }
    }
}
