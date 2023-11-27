using Abp;
using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;

namespace BlazingBudget.Domain.ValueObjects
{
    /// <summary>
    /// Money paid is an amount of money paid.
    /// </summary>
    public class MoneyPaid : Abp.Domain.Values.ValueObject
    {
        public MoneyPaid() { }

        [JsonConstructor]
        private MoneyPaid(decimal value)
        {
            Value = value;
        }

        private MoneyPaid(decimal amount, Currency currency)
        {
            Value = amount;
            Currency = currency;
        }

        public static IResult<MoneyPaid> Create(decimal amount)
        {
            if (amount < 0)
            {
                return Result.Failure<MoneyPaid>("An amount paid can not be negative.");
            }

            return Result.Success(new MoneyPaid(amount));
        }

        public decimal Value { get; private set; }

        public Currency Currency { get; private set; } = new Currency("Dollar", "USD");

        public void ChangeCurrency(Currency currency)
        {
            Currency = currency;
        }

        public static decimal operator -(MoneyPaid left, MoneyPaid right)
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
