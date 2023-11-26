﻿using BlazingBudget.Domain.Aggregates.Account;
using BlazingBudget.Domain.Aggregates.Budget;
using BlazingBudget.Domain.ValueConverters;
using Microsoft.EntityFrameworkCore;

namespace BlazingBudget.Infrastructure.Persistence.DbContexts
{
    internal sealed class BudgetContext : DbContext, IBudgetContext
    {
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<BudgetId>().HaveConversion<BudgetIdConverter>();
        }

        internal DbSet<Account> Accounts { get; set; }
        internal DbSet<Budget> Budgets { get; set; }
    }
}
