﻿using SweeftDigital.Shop.Core.Common;
using System.Collections.Generic;

namespace SweeftDigital.Shop.Core.ValueObjects
{
    public class Currency : ValueObject
    {
        public string Symbol { get; private set; }
        public string Code { get; private set; }
        protected Currency(string symbol, string code)
        {
            Symbol = symbol;
            Code = code;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Symbol;
            yield return Code;
        }

        public static Currency Default => new GelCurrency();
    }

    public class UsdCurrency : Currency
    {
        public UsdCurrency()
            : base("$", "USD")
        {
        }
    }

    public class GelCurrency : Currency
    {
        public GelCurrency()
            : base("₾", "GEL")
        {
        }
    }
}