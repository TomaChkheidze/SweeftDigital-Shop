using System;

namespace SweeftDigital.Shop.Application.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException() { }
        public ForbiddenException(string msg) : base(msg) { }
        public ForbiddenException(string msg, Exception inner) : base(msg, inner) { }
    }
}
