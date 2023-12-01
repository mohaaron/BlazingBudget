using BlazingBudget.Domain.Aggregates.Account;
using BlazingBudget.Domain.Aggregates.Budget;
using Microsoft.EntityFrameworkCore;

namespace BlazingBudget.Infrastructure.Persistence.EntityFramework
{
    internal interface IBudgetContext
    {
        internal DbSet<Account> Accounts { get; set; }
        internal DbSet<Budget> Budgets { get; set; }
    }
}
