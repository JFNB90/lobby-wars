using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signaturit.Contract.Domain.Exceptions
{
    public class InvalidContractSingnaturesException : Exception
    {
        public InvalidContractSingnaturesException(string signatures) : base($"Contract Signatures '${signatures}' invalid" )
        {

        }
    }
}
