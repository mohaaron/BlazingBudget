using Abp;
using Ardalis.GuardClauses;

namespace BlazingBudget.Domain.ValueObjects
{
    /// <summary>
    /// The money type should be used for any monetary value needed.
    /// This type enforces that a money value cannot be zero.
    /// </summary>
    public class Money : Abp.Domain.Values.ValueObject
    {
        internal Money(decimal amount)
        {
            Value = Guard.Against.NegativeOrZero(amount, nameof(amount), "An amount must be larger than zero.");

            //Money left = new Money(amount);
            //Money right = new Money(amount);
            //var result = left - right;
        }

        internal Money(decimal amount, Currency currency)
        {
            Value = Guard.Against.NegativeOrZero(amount, nameof(amount), "An amount must be larger than zero.");
            Currency = currency;
        }

        public decimal Value { get; private set; }

        public Currency Currency { get; private set; } = new Currency("Dollar", "USD");

        public void ChangeCurrency(Currency currency)
        {
            Currency = currency;
        }

        public static decimal operator -(Money left, Money right)
        {
            return left.Value - right.Value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Currency;
            yield return Value;
        }
    }
}
