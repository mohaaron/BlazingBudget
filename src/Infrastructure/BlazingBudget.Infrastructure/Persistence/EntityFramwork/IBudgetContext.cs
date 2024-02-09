using BlazingBudget.Domain.Aggregates.Accounts;
using BlazingBudget.Domain.Aggregates.Budgets;
using Microsoft.EntityFrameworkCore;

namespace BlazingBudget.Infrastructure.Persistence.EntityFramework
{
    internal interface IBudgetContext
    {
        internal DbSet<Account> Accounts { get; set; }
        internal DbSet<Budget> Budgets { get; set; }
    }
}
