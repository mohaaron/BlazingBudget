using BlazingBudget.Domain.Abstractions;
using BlazingBudget.Domain.Aggregates.Payments;
using BlazingBudget.Domain.ValueObjects;

namespace BlazingBudget.Domain.Aggregates.Expenses;
public class Expense : AuditableEntity<ExpenseId>
{
	private Expense() { }

	private Expense(ExpenseId id, string name, Money cost)
	{
		Id = id;
		ChangeName(name);
		Cost = cost;
		CreatedOn = DateTime.UtcNow;
		ModifiedOn = CreatedOn;
	}

	public static Expense Create(string name, Money cost)
	{
		return new Expense(new ExpenseId(Guid.NewGuid()), name, cost);
	}

	public string Name { get; private set; }

	public Money Cost { get; private set; } = Money.Zero;

	public string Notes { get; private set; } // How do we model optional attributes?

	private ICollection<Payment> payments = [];

	internal Expense ChangeName(string name)
	{
		SetName(name);
		return this;
	}

	private void SetName(string name)
	{
		Name = name;
	}

	internal void MakePayment(Payment payment)
	{
		payments.Add(payment);
	}
}
