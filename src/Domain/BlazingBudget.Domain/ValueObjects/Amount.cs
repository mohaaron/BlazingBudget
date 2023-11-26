using Abp;
using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;

namespace BlazingBudget.Domain.ValueObjects
{
    /// <summary>
    /// The money type should be used for any monetary value needed.
    /// This type enforces that a money value cannot be zero.
    /// </summary>
    public class Amount : Abp.Domain.Values.ValueObject
    {
        public Amount() { }

        [JsonConstructor]
        private Amount(decimal value)
        {
            Value = value;

            //Money left = new Money(amount);
            //Money right = new Money(amount);
            //var result = left - right;
        }

        //private Money(decimal amount, Currency currency)
        //{
        //    Value = amount;
        //    Currency = currency;
        //}

        public static IResult<Amount> Create(decimal amount)
        {
            if (amount < 0)
            {
                return Result.Failure<Amount>("An amount paid can not be negative.");
            }

            return Result.Success(new Amount(amount));
        }

        public decimal Value { get; private set; }

        public Currency Currency { get; private set; } = new Currency("Dollar", "USD");

        public void ChangeCurrency(Currency currency)
        {
            Currency = currency;
        }

        public static decimal operator -(Amount left, Amount right)
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
