namespace BlazingBudget.Application.ViewModels.Budgets;
public class Budget
{
	public required string Id { get; set; }
	public required string Name { get; set; }
	public DateOnly Month { get; set; }
}
