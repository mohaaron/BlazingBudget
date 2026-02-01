using BlazingBudget.Domain.Abstractions;
using BlazingBudget.Domain.ValueObjects;

namespace BlazingBudget.Domain.Aggregates.Incomes;
/// <summary>
/// {BudgetPlan}Income is an entity because the amount of a payment over time affects long term finances.
/// </summary>
public class Income : AuditableEntity<IncomeId>
{
	private Income() { }

	private Income(IncomeId id, string source, Money amount, DateOnly payDate)
	{
		Id = id;
		Source = source;
		Amount = amount;
		PayDate = payDate;
		CreatedOn = DateTime.UtcNow;
		ModifiedOn = CreatedOn;
	}

	public static Income Create(string source, Money amount, DateOnly payDate)
	{
		return new Income(new IncomeId(Guid.NewGuid()), source, amount, payDate);
	}

	public string Source { get; private set; }

	public Money Amount { get; private set; }

	public DateOnly PayDate { get; private set; }

	public string Notes { get; private set; } // How do we model optional attributes?
}
