using Abp;
using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;

namespace BlazingBudget.Domain.ValueObjects
{
    /// <summary>
    /// Money owed is an amount of money still left to pay.
    /// </summary>
    public class MoneyOwed : Abp.Domain.Values.ValueObject
    {
        public MoneyOwed() { }

        [JsonConstructor]
        private MoneyOwed(decimal value)
        {
            Value = value;
        }

        private MoneyOwed(decimal amount, Currency currency)
        {
            Value = amount;
            Currency = currency;
        }

        public static Result<MoneyOwed> Create(decimal amount)
        {
            if (amount < 0)
            {
                return Result.Failure<MoneyOwed>("An amount paid can not be negative.");
            }

            return Result.Success(new MoneyOwed(amount));
        }

        public decimal Value { get; private set; }

        public Currency Currency { get; private set; } = new Currency("Dollar", "USD");

        public void ChangeCurrency(Currency currency)
        {
            Currency = currency;
        }

        public static decimal operator -(MoneyOwed left, MoneyOwed right)
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
