using BlazingBudget.Domain.ValueObjects;

namespace BlazingBudget.Domain.Aggregates.Debts;
/// <summary>
/// Money paid is an amount of money paid.
/// </summary>
public class MoneyPaid : ValueObject
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

	public static Result<MoneyPaid> Create(decimal amount) => amount < 0
			? Result.Failure<MoneyPaid>("An amount paid can not be negative.")
			: Result.Success(new MoneyPaid(amount, Currency.Default));

	public decimal Value { get; private set; }

    public Currency Currency { get; private set; } = new Currency("Dollar", "USD");

    public MoneyPaid ChangeCurrency(Currency currency)
    {
        Currency = currency;
		return this;
    }

    public static decimal operator -(MoneyPaid left, MoneyPaid right)
    {
        return left.Value - right.Value;
    }

	protected override IEnumerable<object> GetEqualityComponents()
	{
		yield return Currency;
		yield return Value;
	}
}
