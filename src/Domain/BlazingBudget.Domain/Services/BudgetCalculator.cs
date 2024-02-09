using BlazingBudget.Domain.Aggregates.Budgets;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Domain.Services
{
    internal class BudgetCalculator
    {
        public IResult<decimal> GetTotalExpenses(ICollection<Expense> expenses)
        {
            decimal total = expenses.Sum(e => e.Cost.Value);
            return Result.Success(total);
        }
    }
}
