using Shared.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signaturit.Contract.Domain
{
    public class ContractId : UuidValueObject
    {
        public ContractId(string value) : base(value)
        {
        }
    }
}
