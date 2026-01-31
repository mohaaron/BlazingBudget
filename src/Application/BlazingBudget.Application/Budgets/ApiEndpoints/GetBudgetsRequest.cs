namespace BlazingBudget.Application.Budgets.ApiEndpoints;

/// <summary>
/// Request for getting budgets.
/// </summary>
public record GetBudgetsRequest
{
	/// <summary>
	/// Optional account ID filter.
	/// </summary>
	public Guid? AccountId { get; init; }
}
