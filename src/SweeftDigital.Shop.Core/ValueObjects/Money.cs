using SweeftDigital.Shop.Core.Common;
using SweeftDigital.Shop.Core.Exceptions;
using System.Collections.Generic;

namespace SweeftDigital.Shop.Core.ValueObjects
{
    public class Money : ValueObject
    {
        public Currency Currency { get; private set; }
        public decimal Quantity { get; private set; }

        public Money(Currency currency, decimal quantity)
        {
            Currency = currency;
            Quantity = quantity;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Currency;
            yield return Quantity;
        }

        public static Money Zero => new Money(Currency.Default, 0);

		#region Operators

		public static Money operator +(Money left, Money right)
		{
			if (left.Currency != right.Currency)
			{
				throw new MoneyCalculationException("+ operation error! currencies are not the same");
			}

			return new Money(left.Currency, left.Quantity + right.Quantity);
		}

		public static Money operator -(Money left, Money right)
		{
			if (left.Currency != right.Currency)
			{
				throw new MoneyCalculationException("- operation error! currencies are not the same");
			}

			return new Money(left.Currency, left.Quantity - right.Quantity);
		}

		public static Money operator +(Money money, decimal quantity)
		{
			return new Money(money.Currency, money.Quantity + quantity);
		}

		public static Money operator *(Money money, decimal multiplier)
		{
			return new Money(money.Currency, money.Quantity * multiplier);
		}

		public static Money operator *(decimal multiplier, Money money)
		{
			return new Money(money.Currency, money.Quantity * multiplier);
		}

		#endregion
	}
}
