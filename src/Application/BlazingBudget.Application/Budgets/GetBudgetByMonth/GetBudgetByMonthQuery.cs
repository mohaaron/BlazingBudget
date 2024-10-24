using BlazingBudget.Application.Budgets.UpsertBudgets;
using Mediator;

namespace BlazingBudget.Application.Budgets.GetBudgetByMonth;
public class GetBudgetByMonthQuery : IRequest<UpsertBudget>
{
    private string name;

	public GetBudgetByMonthQuery()
	{
		name = "GetBudgetByMonthQuery";

		if (name is not null)
		{
			Console.WriteLine(name);
		}
	}
}
