using BlazingBudget.Application.Models;
using BlazingBudget.Application.Services;
using BlazingBudget.Domain.Aggregates.Account;
using Aggregate = BlazingBudget.Domain.Aggregates.Budget.Budget;
using Mapster;
using BlazingBudget.Domain.Aggregates.Budget;

namespace BlazingBudget.Application.Tests
{
    public class BudgetModelTests
    {
        [Fact]
        public void Map_From_Aggregate_To_Model_Successfully()
        {
            var aggregate = Aggregate.Create(AccountId.Create(), "Budget Name", new DateOnly(2024, 1, 1));
            var mappedModel = aggregate.Adapt<BudgetModel>();
        }

        [Fact]
        public void Map_From_Model_To_Aggregate_Successfully()
        {
            var model = new BudgetModel()
            {
                Id = BudgetId.New(),
                AccountId = AccountId.Create(),
                BudgetName = "Budget Name",
                Month = new DateOnly(2024, 1, 1)
            };

            var mappedAggregate = model.Adapt<Aggregate>();
        }
    }
}
