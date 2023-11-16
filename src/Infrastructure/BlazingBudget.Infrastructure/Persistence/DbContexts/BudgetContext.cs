using BlazingBudget.Domain.Aggregates.Budget;
using BlazingBudget.Domain.ValueConverters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingBudget.Infrastructure.Persistence.DbContexts
{
    public sealed class BudgetContext : DbContext, IBudgetContext
    {
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<BudgetId>().HaveConversion<BudgetIdConverter>();
        }

        public DbSet<Budget> Budgets { get; set; }
    }
}
