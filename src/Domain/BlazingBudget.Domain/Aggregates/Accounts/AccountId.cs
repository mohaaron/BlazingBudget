using System.Diagnostics.CodeAnalysis;

namespace BlazingBudget.Domain.Aggregates.Accounts;
/// <summary>
/// BudgetId 
/// </summary>
/// <remarks>https://www.youtube.com/watch?v=dJxVj6390hk</remarks>
/// <param name="Value"></param>
public readonly struct AccountId : IComparable<AccountId>
{
	[JsonConstructor]
	private AccountId(Guid value)
	{
		Value = value;
	}

	public static AccountId Create()
		=> new(Guid.NewGuid());

	public Guid Value { get; }

	public bool Equals(AccountId other) => Value == other.Value;

	public override bool Equals([NotNullWhen(true)] object? obj) => obj is AccountId other && Equals(other);

	public static bool operator ==(AccountId left, AccountId right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(AccountId left, AccountId right)
	{
		return !(left == right);
	}

	public override int GetHashCode() => Value.GetHashCode();

	public int CompareTo(AccountId other) => CompareTo(other);
}
