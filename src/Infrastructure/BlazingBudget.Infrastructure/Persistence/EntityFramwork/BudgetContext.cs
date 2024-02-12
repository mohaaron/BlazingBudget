using BlazingBudget.Domain.Aggregates.Accounts;
using BlazingBudget.Domain.Aggregates.Budgets;
using BlazingBudget.Domain.ValueConverters;
using Microsoft.EntityFrameworkCore;

namespace BlazingBudget.Infrastructure.Persistence.EntityFramework
{
    // TODO: Make two contexts, one for write only and one for read only
    internal sealed class BudgetContext : DbContext//, IBudgetContext
    {
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<BudgetId>().HaveConversion<BudgetIdConverter>();
        }

        internal DbSet<Account> Accounts { get; set; }
        internal DbSet<Budget> Budgets { get; set; }
        //DbSet<Account> IBudgetContext.Accounts { get; set; }
        //DbSet<Budget> IBudgetContext.Budgets { get; set; }
    }
}
