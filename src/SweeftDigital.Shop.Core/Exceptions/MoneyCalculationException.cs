using System;

namespace SweeftDigital.Shop.Core.Exceptions
{
    public class MoneyCalculationException : Exception
    {
        public MoneyCalculationException(string msg)
            : base($"money calculation exception: {msg}")
        {
        }
    }
}
