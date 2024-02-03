using BlazingBudget.Domain.Aggregates.Account;
using BlazingBudget.Domain.Aggregates.Budget;
using Mapster;
using Aggregate = BlazingBudget.Domain.Aggregates.Budget.Budget;

namespace BlazingBudget.Application.Models
{
    public class BudgetModel
    {
        public BudgetId Id { get; set; }
        public AccountId AccountId { get; set; }
        public string BudgetName { get; set; }
        public DateOnly Month {  get; set; }

        public static BudgetModel ToModel(Aggregate aggregate)
        {
            return aggregate.Adapt<BudgetModel>();
        }

        public static Aggregate ToAggregate(BudgetModel model)
        {
            return model.Adapt<Aggregate>();
        }
    }
}
