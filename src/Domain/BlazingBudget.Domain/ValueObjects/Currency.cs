using CSharpFunctionalExtensions;

namespace BlazingBudget.Domain.ValueObjects;
/// <summary>
/// Is currency an aggregate?
/// </summary>
public class Currency : ValueObject
{
    private Currency() { }

    internal Currency(string name, string currencyCode)
    {
        Name = name;
        CurrencyCode = currencyCode;
        //Rate = Guard.Against.NegativeOrZero(rate, nameof(rate), "Rate must be larger than zero.");
    }

	public static Currency Default => new("United States Dollar", "USD");

    public string Name { get; private set; }
    public string CurrencyCode { get; private set; }
    //public decimal Rate { get; private set; }

	protected override IEnumerable<object> GetEqualityComponents()
	{
		yield return Name;
		yield return CurrencyCode;
		//yield return Rate;
	}
}
