using BlazingBudget.Application.Budgets.UpsertBudgets;
using BlazingBudget.Domain.Aggregates.Accounts;
using BlazingBudget.Domain.Aggregates.Budgets;
using BlazingBudget.Domain.ValueObjects;
using Mapster;

namespace BlazingBudget.Application.Tests
{
    public class BudgetModelTests
    {
        [Fact]
        public void Map_From_Aggregate_To_Model_Successfully()
        {
            Budget budget = Budget.Create(AccountId.Create(), "Budget Name", new DateOnly(2024, 1, 1));
            budget.AddExpense(Expense.Create("Rent", Money.Create(1).Value));
            budget.AddIncome(Income.Create("Salery", Money.Create(1).Value, new DateOnly(2024, 1, 1)));
			_ = budget.Adapt<UpsertBudget>();
		}

  //      [Fact]
  //      public void Map_From_Model_To_Aggregate_Successfully()
  //      {
		//	BudgetModel model = new()
  //          {
  //              Id = BudgetId.New(),
  //              AccountId = AccountId.Create(),
  //              Name = "Budget Name",
  //              Month = new DateOnly(2024, 1, 1)
  //          };

  //          Budget budget = Budget.Create(model.AccountId, model.Name, model.Month);
  //          budget.AddExpense(Expense.Create("Rent", Money.Create(1).Value));
  //          budget.AddIncome(Income.Create("Salery", Money.Create(1).Value, new DateOnly(2024, 1, 1)));
		//	_ = model.Adapt<Budget>();
		//}
    }
}
