using Shared.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signaturit.Roles.Domain
{
    public class RoleId : StringValueObject
    {
        public RoleId(string value) : base(value)
        {
        }
    }
}
