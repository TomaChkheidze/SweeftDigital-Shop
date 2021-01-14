using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Application.Exceptions
{
    public class RegistrationException : Exception
    {
        public RegistrationException() { }
        public RegistrationException(string msg) : base(msg) { }
        public RegistrationException(string msg, Exception inner) : base(msg, inner) { }
    }
}
