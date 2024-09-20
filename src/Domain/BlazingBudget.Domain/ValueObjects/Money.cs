using Abp;
using CSharpFunctionalExtensions;

namespace BlazingBudget.Domain.ValueObjects
{
    /// <summary>
    /// The money type should be used for any monetary value needed.
    /// This type enforces that a money value cannot be zero.
    /// </summary>
    public class Money : Abp.Domain.Values.ValueObject
    {
        public Money() { }

        [JsonConstructor]
        private Money(decimal value)
        {
            Value = value;
        }

        private Money(decimal amount, Currency currency)
        {
            Value = amount;
            Currency = currency;
        }

        public static Result<Money> Create(decimal amount)
        {
            if (amount <= 0)
            {
                return Result.Failure<Money>($"[{nameof(Money)}] An amount must be larger than zero.");
            }

            return Result.Success(new Money(amount));
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
