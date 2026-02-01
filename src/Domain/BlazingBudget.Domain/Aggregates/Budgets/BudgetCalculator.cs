using CSharpFunctionalExtensions;

namespace BlazingBudget.Domain.Aggregates.Budgets
{
    internal class BudgetCalculator
    {
        public Result<decimal> GetTotalExpenses(ICollection<Expense> expenses)
        {
            decimal total = expenses.Sum(e => e.Cost.Value);
            return Result.Success(total);
        }
    }
}
