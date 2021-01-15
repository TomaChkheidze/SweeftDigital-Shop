using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Shop.Infrastructure.Exceptions
{
    public class AuthException : Exception
    {
        public AuthException() { }
        public AuthException(string msg) : base(msg) { }
        public AuthException(string msg, Exception inner) : base(msg, inner) { }
    }
}
