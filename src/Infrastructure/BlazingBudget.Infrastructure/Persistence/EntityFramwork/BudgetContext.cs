using BlazingBudget.Domain.Aggregates.Accounts;
using BlazingBudget.Domain.Aggregates.Budgets;
using BlazingBudget.Domain.Aggregates.Debts;
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

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Debt> Debts { get; set; }
    }
}
