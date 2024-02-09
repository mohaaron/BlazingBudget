using BlazingBudget.Domain.Aggregates.Accounts;
using BlazingBudget.Domain.Aggregates.Budgets;
using Mapster;

namespace BlazingBudget.Application.Models
{
    public class BudgetModel
    {
        public BudgetId Id { get; set; }
        public AccountId AccountId { get; set; }
        public required string Name { get; set; }
        public DateOnly Month {  get; set; }

        public static BudgetModel ToModel(Budget budget)
        {
            return budget.Adapt<BudgetModel>();
        }
    }
}
