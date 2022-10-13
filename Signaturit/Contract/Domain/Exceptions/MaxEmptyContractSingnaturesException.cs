using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signaturit.Contract.Domain.Exceptions
{
    public class MaxEmptyContractSignaturesException : Exception
    {
        public MaxEmptyContractSignaturesException(string signatures) : base($"Max Empty Contract Signatures exceded '${signatures}'" )
        {

        }
    }
}
