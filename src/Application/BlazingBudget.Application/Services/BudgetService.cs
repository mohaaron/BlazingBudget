using BlazingBudget.Application.Models;
using BlazingBudget.Domain.Aggregates.Account;
using Mapster;
using Aggregate = BlazingBudget.Domain.Aggregates.Budget.Budget;

namespace BlazingBudget.Application.Services
{
    public class BudgetService : IBudgetService
    {
        public BudgetService() { }

        public BudgetModel GetMonthlyBudget()
        {
            var budget = Aggregate.Create(AccountId.Create(), "Budget Name", new DateOnly(2024, 1, 1));
            return budget.Adapt<BudgetModel>();
        }
    }
}
