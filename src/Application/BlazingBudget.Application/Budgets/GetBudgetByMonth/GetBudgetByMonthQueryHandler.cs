using BlazingBudget.Application.Budgets.UpsertBudgets;
using BlazingBudget.Domain.Aggregates.Accounts;
using BlazingBudget.Domain.Aggregates.Budgets;
using Mapster;
using Mediator;

namespace BlazingBudget.Application.Budgets.GetBudgetByMonth;
public class GetBudgetByMonthQueryHandler : IRequestHandler<GetBudgetByMonthQuery, UpsertBudget>
{
    public ValueTask<UpsertBudget> Handle(GetBudgetByMonthQuery request, CancellationToken cancellationToken)
    {
        Budget budget = Budget.Create(AccountId.Create(), "My new budget", new DateOnly(2024, 1, 1));
        return ValueTask.FromResult(budget.Adapt<UpsertBudget>());
    }
}
