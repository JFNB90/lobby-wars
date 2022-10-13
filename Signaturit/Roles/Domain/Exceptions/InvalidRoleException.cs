using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signaturit.Roles.Domain.Exceptions
{
    public class InvalidRoleException : Exception
    {
        public InvalidRoleException(string role) : base($"Role '${role}' invalid")
        {

        }
    }
}
