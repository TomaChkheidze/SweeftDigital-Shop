using System;

namespace SweeftDigital.Shop.Application.Exceptions
{
    public class RegistrationException : Exception
    {
        public RegistrationException() { }
        public RegistrationException(string msg) : base(msg) { }
        public RegistrationException(string msg, Exception inner) : base(msg, inner) { }
    }
}
